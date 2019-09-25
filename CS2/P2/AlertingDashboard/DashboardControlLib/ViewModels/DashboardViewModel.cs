using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmUtilityLib;
using System.Windows.Input;
using DashboardControlLib.Models;
using System.ComponentModel;
using System.Net.Http;
using AlertingUrlsLib;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Threading;

namespace DashboardControlLib.ViewModels
{
    public class DashboardViewModel: INotifyPropertyChanged
    {
        #region PrivateField
        readonly PatientModel _PatientRef = new PatientModel();
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<IcuModel> icu = new ObservableCollection<IcuModel>();
        //create  3 lists to get the patients monitors and the beds available 
        private ObservableCollection<BedModel> beds = new ObservableCollection<BedModel>();
        private ObservableCollection<PatientModel> patients = new ObservableCollection<PatientModel>();
        private ObservableCollection<MonitorModel> monitors = new ObservableCollection<MonitorModel>();
       
        //priavte fields for selected patients monitors and beds
        private PatientModel patientselected;
        private MonitorModel monitorSelected;
        private BedModel bedSelected;
        private static DashboardViewModel dashboardRef;
        private static int count=1;
        #endregion

        #region Initializers
        public DashboardViewModel()
        {
            this.AddNewPatientCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewPatient(); },
                (object obj) => { return true; }
                );
            StartMonitoringCommand = new DelegateCommand((object obj) => { this.StartMonitoring(); }, (object obj) => { return true; });
            AddPatientToIcuCommand = new DelegateCommand((object obj) => { this.AddPatientToIcu(); }, (object obj) => { return true; });
            
            this.GetAllBeds(new UrlFactory().BedsUrl);
            this.GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.GetAllPatients(new UrlFactory().PatientsUrl);
            this.GetAllIcuPatients(new UrlFactory().IcuAssociationUrl);
            if (count == 1)
            {
                dashboardRef = this;
                count = 0;
            }
            
        }

        public void DischargeFromIcu(string v)
        {
            UrlFactory url = new UrlFactory();
            url.Id = v;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(new Uri(url.IcuAssociationUrl)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.Windows.MessageBox.Show("Patient Removed Successfully");
                }
                else
                {
                    System.Windows.MessageBox.Show("Patient not removed");
                }
            }
            this.GetAllBeds(new UrlFactory().BedsUrl);
            this.GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.GetAllPatients(new UrlFactory().PatientsUrl);
            this.GetAllIcuPatients(new UrlFactory().IcuAssociationUrl);
        }
        #endregion

        #region Properties
        public string Name { get => _PatientRef.Name; set => _PatientRef.Name = value; }
        public DateTime Dob { get => _PatientRef.Dob; set => _PatientRef.Dob = value; }
        public bool IsAssigned { get => _PatientRef.IsAssigned; set => _PatientRef.IsAssigned = false; }
        public string Id { get => _PatientRef.Id; set => _PatientRef.Id = value; }
        public bool IsIcuSelected { get; set; }=true;
        public void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            var eventhandler = this.PropertyChanged;
            if (eventhandler != null)
                eventhandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<BedModel> Beds
        {
            get
            {
                return this.beds;
            }

            set
            {
                beds = value;
                OnPropertyChange("Beds");
            }
        }
        public ObservableCollection<PatientModel> Patients
        {
            get
            {
                return this.patients;
            }
            set
            {
                patients = value;
                OnPropertyChange("Patients");
            }
        }
        public ObservableCollection<MonitorModel> Monitors
        {
            get
            {
                return this.monitors;
            }
            set
            {
                monitors = value;
                OnPropertyChange("Monitors");
            }
        }

        public ObservableCollection<IcuModel> Icu
        {
            get
            {
                return this.icu;
            }
            set
            {
                icu = value;
                OnPropertyChange("Icu");
                
            }
        }
        public PatientModel PatientSelected
        {
            get => patientselected;
            set
            {
                patientselected = value;
                OnPropertyChange("PatientSelected");
            }
        }
        public MonitorModel MonitorSelected
        {
            get => monitorSelected;
            set
            {
                monitorSelected = value;
                OnPropertyChange("MonitorSelected");
            }
        }
        public BedModel BedSelected
        {
            get => bedSelected;
            set
            {
                bedSelected = value;
                OnPropertyChange("BedSelected");
            }
        }


        #endregion

        #region Commands
        public ICommand AddNewPatientCommand { get; set; }
        public ICommand StartMonitoringCommand { get; set; }
        public ICommand AddPatientToIcuCommand { get; set; }
        public ICommand DischargeFromIcuCommand { get; set; }
        #endregion

        #region ViewLogic
        public void AddNewPatient()
        {
            string patientId = GetPatientId("P");
            this._PatientRef.Id = patientId;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(PatientModel));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(new UrlFactory().PatientsUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), this._PatientRef);
            var response = _req.GetResponse() as HttpWebResponse;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Windows.MessageBox.Show("Patient added Succesfully");
                this.GetAllPatients(new UrlFactory().PatientsUrl);
            }
            else
            {
                System.Windows.MessageBox.Show("Patient Not Added");
            }
        }
        private string GetPatientId(string type)
        {
            UrlFactory url = new UrlFactory();
            url.Id = type;
            using (var httpClient = new HttpClient())
            {

                var response = httpClient.GetStringAsync(new Uri(url.RandomIdGeneratorUrl)).Result;
                return response;
            }
        }

        //write 3 get methods which calls the api to store inside the collection
        public void GetAllBeds(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<BedModel> allbeds = JsonConvert.DeserializeObject<ObservableCollection<BedModel>>(Convert.ToString(response));
                this.Beds = allbeds;
            }

        }
        public void GetAllPatients(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<PatientModel> allpatients = JsonConvert.DeserializeObject<ObservableCollection<PatientModel>>(Convert.ToString(response));
                this.Patients = allpatients;
            }

        }
        public void GetAllMonitors(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<MonitorModel> allmonitors = JsonConvert.DeserializeObject<ObservableCollection<MonitorModel>>(Convert.ToString(response));
                this.Monitors = allmonitors;
            }

        }
        public DashboardViewModel GetCurrentReference()
        {
            return dashboardRef;
        }
        public void GetAllIcuPatients(string url)
        {
            using (var httpClient = new HttpClient())
            {
                ObservableCollection<IcuModel> tempIcu = new ObservableCollection<IcuModel>();
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<IcuResponseModel> icuPatients = JsonConvert.DeserializeObject<ObservableCollection<IcuResponseModel>>(Convert.ToString(response));
                foreach (var icupatient in icuPatients)
                {
                    IcuModel PatientAdmitted = new IcuModel();
                    PatientAdmitted.AssociationId = icupatient.Id;
                    UrlFactory uri = new UrlFactory(); //url object
                    //Get patients and assign to icumodel
                    uri.Id = icupatient.PatientId;
                    var PatientResponseMessage = httpClient.GetStringAsync(new Uri(uri.PatientsUrl)).Result;
                    PatientModel patient = JsonConvert.DeserializeObject<PatientModel>(Convert.ToString(PatientResponseMessage));
                    PatientAdmitted.Age = (DateTime.Now - patient.Dob).TotalDays.ToString();
                    PatientAdmitted.Name = patient.Name;

                    //get monitors and assign to icu model
                    uri.Id = icupatient.MonitorId;
                    var MonitorResponseMessage = httpClient.GetStringAsync(new Uri(uri.MonitorsUrl)).Result;
                    MonitorModel monitor = JsonConvert.DeserializeObject<MonitorModel>(Convert.ToString(MonitorResponseMessage));
                    PatientAdmitted.Monitor = monitor.Model;

                    //get beds and asssign to icu model
                    uri.Id = icupatient.BedId;
                    var BedResponseMessage = httpClient.GetStringAsync(new Uri(uri.BedsUrl)).Result;
                    BedModel bed = JsonConvert.DeserializeObject<BedModel>(Convert.ToString(BedResponseMessage));
                    PatientAdmitted.Bed = bed.Id;

                    //assign intial vitals to icu model
                    var vitalsResponseMessage = httpClient.GetStringAsync(new Uri(new UrlFactory().RandomVitalsGeneratorUrl)).Result;
                    var vitals = Convert.ToString(vitalsResponseMessage);
                    string[] VitalsList = vitals.Split(',');
                    PatientAdmitted.Temperature = double.Parse(VitalsList[0]);
                    PatientAdmitted.Spo2 = int.Parse(VitalsList[1]);
                    PatientAdmitted.PulseRate = int.Parse(VitalsList[2]);

                    //post vitals to the api
                    uri.Id = PatientAdmitted.Bed;
                    PatientVitalsModel patientVitals = new PatientVitalsModel();
                    patientVitals.Temperature = decimal.Parse(VitalsList[0]);
                    patientVitals.Spo2 = int.Parse(VitalsList[1]);
                    patientVitals.PulseRate = int.Parse(VitalsList[2]);
                    patientVitals.Id = PatientAdmitted.Bed;
                    DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(PatientVitalsModel));
                    System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(uri.WritePatientVitalsUrl);
                    _req.Method = "POST";
                    _req.ContentType = "application/json";
                    _serailizer.WriteObject(_req.GetRequestStream(), patientVitals);
                    var result = _req.GetResponse() as System.Net.HttpWebResponse;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //get the out of threshold vitals
                        uri.Id = PatientAdmitted.Bed;
                        var PatientVitalsResponseMessage = httpClient.GetStringAsync(new Uri(uri.PatientVitalsValidationUrl)).Result;
                        List<string> patientVitalsList = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(PatientVitalsResponseMessage));
                        if (patientVitalsList.Contains("Temperature"))
                        {
                            PatientAdmitted.TemperatureColor = "Red";
                           
                        }
                        else
                        {
                            PatientAdmitted.TemperatureColor = "Green";
                        }
                        if (patientVitalsList.Contains("Spo2"))
                        {
                            PatientAdmitted.Spo2Color = "Red";
                            
                        }
                        else
                        {
                            PatientAdmitted.TemperatureColor = "Green";
                        }
                        if (patientVitalsList.Contains("PulseRate"))
                        {
                            PatientAdmitted.PulseRateColor = "Red";
                        }
                        else
                        {
                            PatientAdmitted.TemperatureColor = "Green";
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("failed");
                    }
                    tempIcu.Add(PatientAdmitted);

                }
                this.Icu = tempIcu;
                if(this.Icu.Count==0)
                {
                    this.IsIcuSelected = false;
                    OnPropertyChange("IsIcuSelected");
                }
                else
                {
                    this.IsIcuSelected = true;
                    OnPropertyChange("IsIcuSelected");
                }
            }
        }

        //start monitoring
        public void StartMonitoring()
        {
            int count = 5;
            while (count > 0)
            {
                GetAllIcuPatients(new UrlFactory().IcuAssociationUrl);
                foreach (var patient in Icu)
                {
                    if (patient.TemperatureColor.Contains("Red"))
                    {
                        showAlert(string.Format("Patient {0} at bed {1} is crtical temperature is rising", patient.Name, patient.Bed));
                        patient.TemperatureColor = "Green";
                        Random random = new Random();
                        patient.Temperature = random.Next(97,99) + random.NextDouble();
                    }
                    if (patient.PulseRateColor.Contains("Red"))
                    {
                        showAlert(string.Format("Patient {0} at bed {1} is crtical pulse rate is rising", patient.Name, patient.Bed));
                        patient.PulseRateColor = "Green";
                        Random random = new Random();
                        patient.PulseRate = random.Next(40, 100);
                    }
                    if (patient.Spo2Color.Contains("Red"))
                    {
                        showAlert(string.Format("Patient {0} at bed {1} is crtical spo2 level is rising", patient.Name, patient.Bed));
                        patient.Spo2Color = "Green";
                        Random random = new Random();
                        patient.Spo2 = random.Next(91, 100);
                    }
                }
                Thread.Sleep(1000);
                count--;
            }


        }
        private void showAlert(string msg)
        {
            System.Windows.MessageBox.Show(msg);
        }

        //add patient to icu
        private void AddPatientToIcu()
        {
            IcuResponseModel res = new IcuResponseModel();
            res.BedId = BedSelected.Id;
            res.MonitorId = MonitorSelected.Id;
            res.PatientId = PatientSelected.Id;
            UrlFactory url = new UrlFactory();
            url.Id = "A";
            using (var httpClient = new HttpClient())
            {
                res.Id = httpClient.GetStringAsync(new Uri(url.RandomIdGeneratorUrl)).Result;
            }
            url.Id = res.Id;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(IcuResponseModel));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(url.IcuAssociationUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), res);
            var response = _req.GetResponse() as System.Net.HttpWebResponse;
            this.GetAllBeds(new UrlFactory().BedsUrl);
            this.GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.GetAllPatients(new UrlFactory().PatientsUrl);
            this.GetAllIcuPatients(new UrlFactory().IcuAssociationUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Windows.MessageBox.Show("Patient added to ICU Succesfully");
            }
            else
            {
                System.Windows.MessageBox.Show("Patient was not added to ICU");
            }

        }
        #endregion

    }
}

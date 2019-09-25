using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmUtilityLib;
using System.Windows.Input;
using PatientControlLib.Models;
using System.ComponentModel;
using System.Net.Http;
using AlertingUrlsLib;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;

namespace PatientControlLib.ViewModels
{
    public class RegisterNewPatientViewModel : INotifyPropertyChanged
    {

        #region PrivateField
        readonly PatientDetails _PatientRef = new PatientDetails();
        public event PropertyChangedEventHandler PropertyChanged;
        string successMessage = "";
        #endregion

        #region Initializers
        public RegisterNewPatientViewModel()
        {
            this.AddNewPatientCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewPatient(); },
                (object obj) => { return true; }
                );
        }
        #endregion

        #region Properties
        public string Name { get => _PatientRef.Name; set => _PatientRef.Name = value; }
        public DateTime Dob { get => _PatientRef.Dob; set => _PatientRef.Dob = value; }
        public bool IsAssigned { get => _PatientRef.IsAssigned; set => _PatientRef.IsAssigned = false; }
        public string Id { get => _PatientRef.Id; set => _PatientRef.Id = value; }
        public string SuccessMessage
        {
            get
            {
                return this.successMessage;
            }
            set
            {
                if (value != this.successMessage)
                {
                    this.successMessage = value;
                    OnPropertyChanged("SuccessMessage");

                }
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Commands
        public ICommand AddNewPatientCommand { get; set; }
        #endregion

        #region ViewLogic
        public void AddNewPatient()
        {
            string patientId = GetPatientId("P");
            this._PatientRef.Id = patientId;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(PatientDetails));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(new UrlFactory().PatientsUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), this._PatientRef);
            var response = _req.GetResponse() as HttpWebResponse;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.SuccessMessage = "Patient Added Successfully";
            }
            else
            {
                this.SuccessMessage = response.StatusDescription;
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

            //var request = (HttpWebRequest)WebRequest.Create(url.RandomIdGeneratorUrl);
            //request.Method = "GET";
            //request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            //var content = string.Empty;
            //using (var response = (HttpWebResponse)request.GetResponse())
            //{
            //    using (var stream = response.GetResponseStream())
            //    {
            //        using (var sr = new StreamReader(stream))
            //        {
            //            content = sr.ReadToEnd();
            //            type = content.ToString();

            //        }
            //    }
            //}

        }
        #endregion

    }

}

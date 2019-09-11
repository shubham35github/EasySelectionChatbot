using ChatBotModelLib;
using CustomerItemsPreferenceContractLib;
using CustomerModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace CustomerMonitorsPreferenceLib
{
    ///   CustomerMonitorsPreference class used for storing the customer information and their Monitors prefrence
    public class CustomerMonitorsPreference : ICustomerItemsPreferenceContract
    {


        /// <summary>
        ///IsCustomerExist method is used for checking the customer  is already present in DB or not.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="customerEmails"></param>
        /// <returns>return true if exits</returns>
        private bool IsCustomerExist(string email,List<string> customerEmails)
        {
            if(customerEmails!=null)
            {
                foreach (var customer_email in customerEmails)
                {
                    if (customer_email.Equals(email))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method is used for inserting the customer and thier Monitor preference 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="monitor_no"></param>
        private void InsertCustomerPreference(string email,int monitor_no)
        {
            using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
            {
                ChatBotModelLib.MonitorsPreference monitorObj = new ChatBotModelLib.MonitorsPreference();
                monitorObj.customer_email = email;
                monitorObj.monitors_no = monitor_no;
                monitorObj.check_in = DateTime.Now;
                dbcontext.MonitorsPreferences.InsertOnSubmit(monitorObj);
                dbcontext.SubmitChanges();
            }
        }

       
        /// <summary>
        /// Method  is used to get monitor no from the DB.
        /// </summary>
        /// <param name="monitorName"></param>
        /// <returns>monitor nomber</returns>
        private int GetMonitorIdByMonitorName(string monitorName)
        {
            using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
            {
                string MonitorNameFeild = "monitors_name";
                string MonitorNumber = null;
                var number = dbcontext.Monitors.Where(MonitorNameFeild + "=\"" + monitorName + "\"").Select("monitors_no");
                foreach (var item in number)
                {
                    MonitorNumber = item.ToString();
                }
                return int.Parse(MonitorNumber);
            }
        }

        /// <summary>
        /// Method is used to get all the customer from the Db
        /// </summary>
        /// <returns>list of customer</returns>
        public List<string> GetCustomer()
        {
            List<string> CustomerEmails = new List<string>();

            using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
            {
                IQueryable SelectedCustomersEmail = dbcontext.Customers.Select("customer_email");
                foreach (var email in SelectedCustomersEmail)
                {
                    CustomerEmails.Add(email.ToString());
                }
                return CustomerEmails;
            }
        }
        /// <summary>
        /// Method is used to insert the customer details in DB 
        /// </summary>
        /// <param name="customer"></param>
        public void InsertCustomerDetails(CustomerModelLib.Customer customer)
        {
            List<string> CustomerEmails = GetCustomer();
            try
            {
                if (!IsCustomerExist(customer.EmailId, CustomerEmails))
                {
                    using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
                    {
                        ChatBotModelLib.Customer customerObj = new ChatBotModelLib.Customer();
                        customerObj.customer_email = customer.EmailId;
                        customerObj.customer_name = customer.Name;
                        customerObj.customer_phone = customer.Phone;
                        dbcontext.Customers.InsertOnSubmit(customerObj);
                        dbcontext.SubmitChanges();
                    }
                }
                int MonitorNo = GetMonitorIdByMonitorName(customer.MonitorName);
                InsertCustomerPreference(customer.EmailId, MonitorNo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

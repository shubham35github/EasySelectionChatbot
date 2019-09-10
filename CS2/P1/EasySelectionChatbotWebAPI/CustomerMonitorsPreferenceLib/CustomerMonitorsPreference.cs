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
    public class CustomerMonitorsPreference : ICustomerItemsPreferenceContract
    {
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

        public void InsertCustomerDetails(CustomerModelLib.Customer customer)
        {
            List<string> CustomerEmails = GetCustomer();
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
            InsertCustomerPreference(customer.EmailId,customer.MonitorNo);
        }
    }
}

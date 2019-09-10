using CustomerModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerItemsPreferenceContractLib
{
    public interface ICustomerItemsPreferenceContract
    {
        List<string> GetCustomer();
        void InsertCustomerDetails(Customer customer);
    }
}

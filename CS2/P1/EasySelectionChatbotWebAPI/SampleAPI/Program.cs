
using CustomerModelLib;
using CustomerMonitorsPreferenceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerMonitorsPreference obj = new CustomerMonitorsPreference();

           obj.InsertCustomerDetails(new Customer{ Name="Shubham",EmailId="Shu@gmail.com",Phone="8381992829",MonitorNo=2});
           Console.ReadKey();
        }
    }
}

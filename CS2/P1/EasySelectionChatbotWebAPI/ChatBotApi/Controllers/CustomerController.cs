using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerModelLib;
using CustomerMonitorsPreferenceLib;

namespace ChatBotApi.Controllers
{
    public class CustomerController : ApiController
    {
        
        /// <summary>
        /// Request to insert customers details
        /// </summary>
        /// <param name="customer">customer object consists of Name,email,Phone,MonitorName
        /// </param>
        /// <remarks>This Post request allows you to save customer details</remarks>
        /// <returns>true on successfull addition of customer </returns>
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            try
            {
                new CustomerMonitorsPreference().InsertCustomerDetails(customer);
                return Content(HttpStatusCode.Created, true);
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Content Not Added"+ex.Message);
            }
        }

       

        
    }
}

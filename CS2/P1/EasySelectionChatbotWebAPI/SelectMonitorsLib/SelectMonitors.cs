using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectedItemsContractLib;
using ChatBotModelLib;
using System.Data.Linq;
using System.Linq.Dynamic;
using DataAccessLayerContractLib;

namespace SelectMonitorsLib
{
    public class SelectMonitors : ISelectedItemsContract
    {
        private readonly IDataAccessLayerContract dataref;
        public SelectMonitors(IDataAccessLayerContract dataref)
        {
            this.dataref = dataref;
        }
        public List<string> GetAllSelectedItems(int Feature_No, string FeatureValue)
        {
            var FeatureDictionary = dataref.ReadAttributes();
            string Feature;
            if (Feature_No == 0)
            {
                Feature = "FirstFeature";
            }
            else
            {
                Feature = FeatureDictionary[Feature_No].ToString();
            }

            List<string> Selectedlist = new List<string>();
            if (!string.IsNullOrEmpty(Feature)  || !string.IsNullOrEmpty(FeatureValue))
            {
                using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
                {
                    if (Feature=="FirstFeature" && FeatureValue.Equals("FirstValue"))
                    {
                        var Selectedtems = dbcontext.Monitors.Select("monitors_name");
                        foreach (var Item in Selectedtems)
                        {
                            Selectedlist.Add(Item.ToString());
                        }
                    }
                    else
                    {
                        var Selectedtems = dbcontext.Monitors.Where(Feature + "=\"" + FeatureValue + "\"").Select("monitors_name");
                        foreach (var Item in Selectedtems)
                        {
                            Selectedlist.Add(Item.ToString());
                        }
                    }
                }
            }
            else
                throw new ArgumentException("String Empty");
            return Selectedlist;
        }
    }
}


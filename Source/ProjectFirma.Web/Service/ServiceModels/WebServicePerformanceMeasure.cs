using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServicePerformanceMeasure : SimpleModelObject
    {
        public WebServicePerformanceMeasure(PerformanceMeasure performanceMeasure)
        {
            var indicator = performanceMeasure.Indicator;
            IndicatorID = indicator.IndicatorID;
            IndicatorName = indicator.IndicatorDisplayName;
            IndicatorUnits = indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName;

            if (performanceMeasure.Indicator.HasRealSubcategories)
            {
                var currentSubcategoryIndex = 1;
                foreach (var indicatorSubcategory in performanceMeasure.IndicatorSubcategories)
                {
                    if (currentSubcategoryIndex == 1)
                    {
                        PMSubcategoryName1 = indicatorSubcategory.IndicatorSubcategoryDisplayName;
                        PMSubcategoryOptionCount1 = indicatorSubcategory.IndicatorSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 2)
                    {
                        PMSubcategoryName2 = indicatorSubcategory.IndicatorSubcategoryDisplayName;
                        PMSubcategoryOptionCount2 = indicatorSubcategory.IndicatorSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 3)
                    {
                        PMSubcategoryName3 = indicatorSubcategory.IndicatorSubcategoryDisplayName;
                        PMSubcategoryOptionCount3 = indicatorSubcategory.IndicatorSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 4)
                    {
                        PMSubcategoryName4 = indicatorSubcategory.IndicatorSubcategoryDisplayName;
                        PMSubcategoryOptionCount4 = indicatorSubcategory.IndicatorSubcategoryOptions.Count;
                    }
                    else
                    {
                        throw new NotImplementedException("Cannot handle more than four subcategories on a PM");
                    }
                    currentSubcategoryIndex++;
                }
            }
        }    

        [DataMember] public int IndicatorID { get; set; }
        [DataMember] public string IndicatorName { get; set; }
        [DataMember] public string IndicatorDescription { get; set; }
        [DataMember] public string IndicatorUnits { get; set; }
        
        [DataMember] public string PMSubcategoryName1 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount1 { get; set; }
        [DataMember] public string PMSubcategoryName2 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount2 { get; set; }
        [DataMember] public string PMSubcategoryName3 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount3 { get; set; }
        [DataMember] public string PMSubcategoryName4 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount4 { get; set; }

        public static List<WebServicePerformanceMeasure> GetIndicators()
        {
            var indicators = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            return indicators.Select(x => new WebServicePerformanceMeasure(x)).OrderBy(x => x.IndicatorID).ToList();
        }
    }

    public class WebServicePerformanceMeasureGridSpec : GridSpec<WebServicePerformanceMeasure>
    {
        public WebServicePerformanceMeasureGridSpec()
        {
            Add("IndicatorID", x => x.IndicatorID, 0);
            Add("IndicatorName", x => x.IndicatorName, 0);
            Add("IndicatorDescription", x => x.IndicatorDescription, 0);
            Add("IndicatorUnits", x => x.IndicatorUnits, 0);

            Add("PMSubcategoryName1", x => x.PMSubcategoryName1, 0);
            Add("PMSubcategoryOptionCount1", x => x.PMSubcategoryOptionCount1, 0);
            Add("PMSubcategoryName2", x => x.PMSubcategoryName2, 0);
            Add("PMSubcategoryOptionCount2", x => x.PMSubcategoryOptionCount2, 0);
            Add("PMSubcategoryName3", x => x.PMSubcategoryName3, 0);
            Add("PMSubcategoryOptionCount3", x => x.PMSubcategoryOptionCount3, 0);
            Add("PMSubcategoryName4", x => x.PMSubcategoryName4, 0);
            Add("PMSubcategoryOptionCount4", x => x.PMSubcategoryOptionCount4, 0);
        }
    }
}

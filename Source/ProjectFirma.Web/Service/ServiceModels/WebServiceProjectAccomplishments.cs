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
    public class WebServiceProjectAccomplishments : SimpleModelObject
    {
        public WebServiceProjectAccomplishments(PerformanceMeasureActual perfomanceMeasureActualValue)
        {
            var project = perfomanceMeasureActualValue.Project;
            var pm = perfomanceMeasureActualValue.PerformanceMeasure.Indicator;
            ProjectNumber = project.ProjectNumberString;

            IndicatorID = pm.IndicatorID;
            IndicatorName = pm.IndicatorDisplayName;
            IndicatorUnits = pm.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            IndicatorProjectValue = perfomanceMeasureActualValue.ActualValue;
            IndicatorProjectYear = perfomanceMeasureActualValue.CalendarYear;

            var currentPMSubcategoryIndex = 1;
            foreach (var perfomanceMeasureActualValueSubcategoryOption in perfomanceMeasureActualValue.PerformanceMeasureActualSubcategoryOptions)
            {
                if (currentPMSubcategoryIndex == 1)
                {
                    PMSubcategoryName1 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategory.IndicatorSubcategoryDisplayName;
                    PMSubcategoryOption1 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 2)
                {
                    PMSubcategoryName2 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategory.IndicatorSubcategoryDisplayName;
                    PMSubcategoryOption2 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 3)
                {
                    PMSubcategoryName3 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategory.IndicatorSubcategoryDisplayName;
                    PMSubcategoryOption3 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 4)
                {
                    PMSubcategoryName4 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategory.IndicatorSubcategoryDisplayName;
                    PMSubcategoryOption4 = perfomanceMeasureActualValueSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                }
                else
                {
                    throw new NotImplementedException("Cannot handle more than four subcategories on a PM");
                }
                currentPMSubcategoryIndex++;
            }
        }

      

        [DataMember] public string ProjectNumber { get; set; }
        [DataMember] public int IndicatorID { get; set; }
        [DataMember] public string IndicatorName { get; set; }
        [DataMember] public string IndicatorUnits { get; set; }
        [DataMember] public int IndicatorProjectYear { get; set; }
        [DataMember] public double IndicatorProjectValue { get; set; }
        
        [DataMember] public string PMSubcategoryName1 { get; set; }
        [DataMember] public string PMSubcategoryOption1 { get; set; }
        [DataMember] public string PMSubcategoryName2 { get; set; }
        [DataMember] public string PMSubcategoryOption2 { get; set; }
        [DataMember] public string PMSubcategoryName3 { get; set; }
        [DataMember] public string PMSubcategoryOption3 { get; set; }
        [DataMember] public string PMSubcategoryName4 { get; set; }
        [DataMember] public string PMSubcategoryOption4 { get; set; }    

        public static List<WebServiceProjectAccomplishments> GetProjectAccomplishments(string projectNumber)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProjectByProjectNumber(projectNumber);
            return project.PerformanceMeasureActuals.Select(x => new WebServiceProjectAccomplishments(x)).OrderBy(x => x.IndicatorID).ToList();
        }       
    }

    public class WebServiceProjectAccomplishmentsGridSpec : GridSpec<WebServiceProjectAccomplishments>
    {
        public WebServiceProjectAccomplishmentsGridSpec()
        {
            Add("ProjectNumber", x => x.ProjectNumber, 0);
            Add("IndicatorID", x => x.IndicatorID, 0);
            Add("IndicatorName", x => x.IndicatorName, 0);
            Add("IndicatorUnits", x => x.IndicatorUnits, 0);
            Add("IndicatorProjectYear", x => x.IndicatorProjectYear, 0);
            Add("IndicatorProjectValue", x => x.IndicatorProjectValue, 0);

            Add("PMSubcategoryName1", x => x.PMSubcategoryName1, 0);
            Add("PMSubcategoryOptionCount1", x => x.PMSubcategoryOption1, 0);
            Add("PMSubcategoryName2", x => x.PMSubcategoryName2, 0);
            Add("PMSubcategoryOptionCount2", x => x.PMSubcategoryOption2, 0);
            Add("PMSubcategoryName3", x => x.PMSubcategoryName3, 0);
            Add("PMSubcategoryOptionCount3", x => x.PMSubcategoryOption3, 0);
            Add("PMSubcategoryName4", x => x.PMSubcategoryName4, 0);
            Add("PMSubcategoryOptionCount4", x => x.PMSubcategoryOption4, 0);
        }
    }
}

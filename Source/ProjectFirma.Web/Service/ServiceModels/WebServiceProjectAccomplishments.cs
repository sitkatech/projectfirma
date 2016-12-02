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
            var pm = perfomanceMeasureActualValue.PerformanceMeasure;
            ProjectNumber = project.ProjectNumberString;

            PerformanceMeasureID = pm.PerformanceMeasureID;
            PerformanceMeasureName = pm.PerformanceMeasureDisplayName;
            PerformanceMeasureUnits = pm.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            PerformanceMeasureProjectValue = perfomanceMeasureActualValue.ActualValue;
            PerformanceMeasureProjectYear = perfomanceMeasureActualValue.CalendarYear;

            var currentPMSubcategoryIndex = 1;
            foreach (var perfomanceMeasureActualValueSubcategoryOption in perfomanceMeasureActualValue.PerformanceMeasureActualSubcategoryOptions)
            {
                if (currentPMSubcategoryIndex == 1)
                {
                    PMSubcategoryName1 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption1 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 2)
                {
                    PMSubcategoryName2 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption2 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 3)
                {
                    PMSubcategoryName3 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption3 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 4)
                {
                    PMSubcategoryName4 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption4 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else
                {
                    throw new NotImplementedException("Cannot handle more than four subcategories on a PM");
                }
                currentPMSubcategoryIndex++;
            }
        }

      

        [DataMember] public string ProjectNumber { get; set; }
        [DataMember] public int PerformanceMeasureID { get; set; }
        [DataMember] public string PerformanceMeasureName { get; set; }
        [DataMember] public string PerformanceMeasureUnits { get; set; }
        [DataMember] public int PerformanceMeasureProjectYear { get; set; }
        [DataMember] public double PerformanceMeasureProjectValue { get; set; }
        
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
            return project.PerformanceMeasureActuals.Select(x => new WebServiceProjectAccomplishments(x)).OrderBy(x => x.PerformanceMeasureID).ToList();
        }       
    }

    public class WebServiceProjectAccomplishmentsGridSpec : GridSpec<WebServiceProjectAccomplishments>
    {
        public WebServiceProjectAccomplishmentsGridSpec()
        {
            Add("ProjectNumber", x => x.ProjectNumber, 0);
            Add("PerformanceMeasureID", x => x.PerformanceMeasureID, 0);
            Add("PerformanceMeasureName", x => x.PerformanceMeasureName, 0);
            Add("PerformanceMeasureUnits", x => x.PerformanceMeasureUnits, 0);
            Add("PerformanceMeasureProjectYear", x => x.PerformanceMeasureProjectYear, 0);
            Add("PerformanceMeasureProjectValue", x => x.PerformanceMeasureProjectValue, 0);

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

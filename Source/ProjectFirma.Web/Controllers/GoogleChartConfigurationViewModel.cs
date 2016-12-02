using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Controllers
{
    public class GoogleChartConfigurationViewModel : IValidatableObject
    {
        [JsonProperty(PropertyName = "options")]
        public string ChartConfigurationJson { get; set; }
        [JsonProperty(PropertyName = "chartType")]
        public string ChartType { get; set; }

        public void UpdateModel(PerformanceMeasure performanceMeasure, int performanceMeasureSubcategoryID)
        {            
            //Remove certain properties that we don't want saved to the DB
            var chartConfigurationString = CleanAndSerializeChartJsonString(ChartConfigurationJson);
            var perfomanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            perfomanceMeasureSubcategory.ChartType = ChartType;
            perfomanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationString;
        }

        public string CleanAndSerializeChartJsonString(string json)
        {
            var chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(json);
            chartConfiguration.SanitizeForSaving();
            return JsonConvert.SerializeObject(chartConfiguration);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            
            //Ensure our new values can be parsed without exceptions. No need to store the values.
            JsonConvert.DeserializeObject<GoogleChartConfiguration>(ChartConfigurationJson);
            Enum.Parse(typeof(GoogleChartType), ChartType);
            
            return validationResults;
        }       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartPopupViewModel : FormViewModel, IValidatableObject
    {
        public string GoogleChartJson { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            try
            {
                DeserializeGoogleChartJson();
            }
            catch
            {
                errors.Add(new SitkaValidationResult<GoogleChartPopupViewModel, string>("Data provided is not valid GoogleChartJson. Unable to deserialize.", x => x.GoogleChartJson));
            }
            return errors;
        }

        public GoogleChartJson DeserializeGoogleChartJson()
        {
            return JsonConvert.DeserializeObject<GoogleChartJson>(GoogleChartJson);
        }
    }
}
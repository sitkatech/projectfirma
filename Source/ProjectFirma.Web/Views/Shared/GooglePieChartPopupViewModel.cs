using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GooglePieChartPopupViewModel : GoogleChartPopupViewModel, IValidatableObject
    {
        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            try
            {
                DeserializeGooglePieChartJson();
            }
            catch
            {
                errors.Add(new SitkaValidationResult<GoogleChartPopupViewModel, string>("Data provided is not valid GoogleChartJson. Unable to deserialize.", x => x.GoogleChartJson));
            }
            return errors;
        }

        public GoogleChartJson DeserializeGooglePieChartJson()
        {
            JsonConverter[] converters = { new GooglePieChartConfiguration.ConfigurationConverter() };
            return JsonConvert.DeserializeObject<GoogleChartJson>(GoogleChartJson, converters);
        }
    }
}
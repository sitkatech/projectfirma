using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ImportExternalViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("External Import Data")]
        public string ProjectExternalImportRawData { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!TryParseProjectExternalImportDataSimple(ProjectExternalImportRawData))
            {
                errors.Add(new SitkaValidationResult<ImportExternalViewModel, string>("", m => m.ProjectExternalImportRawData));
            }

            return errors;
        }

        private static bool TryParseProjectExternalImportDataSimple(string data)
        {
            try
            {
                JsonConvert.DeserializeObject<ProjectExternalImportDataSimple>(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

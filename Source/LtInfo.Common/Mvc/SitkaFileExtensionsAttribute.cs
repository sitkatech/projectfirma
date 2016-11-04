using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LtInfo.Common.Mvc
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SitkaFileExtensionsAttribute : ValidationAttribute, IClientValidatable
    {
        public List<string> ValidExtensions { get; set; }

        public SitkaFileExtensionsAttribute(string fileExtensions)
        {
            ValidExtensions = fileExtensions.ToLower().Split('|').ToList();
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                var fileName = file.FileName.ToLower();
                var isValidExtension = ValidExtensions.Any(fileName.EndsWith);
                return isValidExtension;
            }
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            if (!metadata.IsRequired)
                yield break;

            if (string.IsNullOrWhiteSpace(ErrorMessage))
            {
                ErrorMessage = "Uploaded file needs to be one of the following extensions: " + string.Join(", ", ValidExtensions);
            }
            var rule = new ModelClientFileExtensionValidationRule(ErrorMessage, ValidExtensions);
            yield return rule;
        }
    }

    public class ModelClientFileExtensionValidationRule : ModelClientValidationRule
    {
        public ModelClientFileExtensionValidationRule(string errorMessage, IEnumerable<string> fileExtensions)
        {
            ErrorMessage = errorMessage;
            ValidationType = "fileextensions";
            ValidationParameters.Add("fileextensions", string.Join(",", fileExtensions));
        }
    }
}
/*-----------------------------------------------------------------------
<copyright file="SitkaFileExtensionsAttribute.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

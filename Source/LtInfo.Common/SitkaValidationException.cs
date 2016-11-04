using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LtInfo.Common
{
    public class SitkaValidationException : Exception
    {
        public IEnumerable<ValidationResult> ValidationResults { get; set; }

        public SitkaValidationException(string message, IEnumerable<string> validationErrors, IEnumerable<ValidationResult> results = null)
            : base(String.Format("{0}\r\n{1}", message, String.Join("\r\n", validationErrors)))
        {
            ValidationResults = results;
        }
    }
}
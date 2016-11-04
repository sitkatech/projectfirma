using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LtInfo.Common.Mvc
{
    /// <summary>
    /// This is useful for unit testing the ViewModel validators
    /// </summary>
    public static class DataAnnotationsValidator
    {
        public static bool TryValidate(object viewModel, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(viewModel, null, null);
            results = new List<ValidationResult>();
            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(viewModel, context, results, true);
        }
    }
}
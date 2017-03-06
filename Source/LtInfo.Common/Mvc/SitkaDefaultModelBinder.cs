/*-----------------------------------------------------------------------
<copyright file="SitkaDefaultModelBinder.cs" company="Sitka Technology Group">
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
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace LtInfo.Common.Mvc
{
    public class SitkaDefaultModelBinder : DefaultModelBinder
    {
        /// <summary>
        /// We override the default because we want it to handle nullable types
        /// </summary>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(double))
            {
                return TryModelBindDouble(bindingContext);
            }
            if (bindingContext.ModelType == typeof(double?))
            {
                return TryModelBindNullableDouble(bindingContext);
            }
            if (bindingContext.ModelType == typeof(int))
            {
                return TryModelBindInt(bindingContext);
            }
            if (bindingContext.ModelType == typeof(int?))
            {
                return TryModelBindNullableInt(bindingContext);
            }
            if (bindingContext.ModelType == typeof(Money))
            {
                return TryModelBindMoney(bindingContext);
            }
            if (bindingContext.ModelType == typeof(Money?))
            {
                return TryModelBindNullableMoney(bindingContext);
            }
            if (bindingContext.ModelType == typeof(HtmlString))
            {
                return TryModelBindHtmlString(bindingContext);
            }
            var underlyingType = Nullable.GetUnderlyingType(bindingContext.ModelType);
            if (underlyingType != null)
            {
                var newBindingContext = new ModelBindingContext(bindingContext)
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => bindingContext.Model, underlyingType),
                    ModelName = bindingContext.ModelName
                };
                return ModelBinders.Binders.GetBinder(underlyingType).BindModel(controllerContext, newBindingContext);
            }
            return base.BindModel(controllerContext, bindingContext);
        }

        private static double TryModelBindDouble(ModelBindingContext bindingContext)
        {
            var result = TryModelBindNullableDouble(bindingContext);
            if (!result.HasValue)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Could not parse a blank value for field '{0}' to a number.", bindingContext.ModelName));
                return 0;
            }
            return result.Value;
        }

        private static double? TryModelBindNullableDouble(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (CheckIfValueProviderResultIsNull(valueProviderResult))
            {
                return null;
            }
            double result;
            if (!double.TryParse(valueProviderResult.AttemptedValue, NumberStyles.Any, new NumberFormatInfo(), out result))
            {
                bindingContext.ModelState.AddModelError(modelName, string.Format("Could not parse {0} for field '{1}' to a number.", valueProviderResult.AttemptedValue, modelName));
            }
            return result;
        }

        private static bool CheckIfValueProviderResultIsNull(ValueProviderResult valueProviderResult)
        {
            return valueProviderResult == null || String.IsNullOrWhiteSpace(valueProviderResult.AttemptedValue) || valueProviderResult.AttemptedValue.Equals("null", StringComparison.InvariantCultureIgnoreCase);
        }

        private static int TryModelBindInt(ModelBindingContext bindingContext)
        {
            var result = TryModelBindNullableInt(bindingContext);
            if (!result.HasValue)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Could not parse a blank value for field '{0}' to an integer.", bindingContext.ModelName));
                return 0;
            }
            return result.Value;
        }

        private static int? TryModelBindNullableInt(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (CheckIfValueProviderResultIsNull(valueProviderResult))
            {
                return null;
            }
            int result;
            if (!int.TryParse(valueProviderResult.AttemptedValue, NumberStyles.Any, new NumberFormatInfo(), out result))
            {
                bindingContext.ModelState.AddModelError(modelName, string.Format("Could not parse {0} for field '{1}' to an integer.", valueProviderResult.AttemptedValue, modelName));
            }
            return result;
        }

        private static Money TryModelBindMoney(ModelBindingContext bindingContext)
        {
            var result = TryModelBindNullableMoney(bindingContext);
            if (!result.HasValue)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("A valid currency value is required for field '{0}'.", bindingContext.ModelName));
                return 0;
            }
            return result.Value;
        }

        private static Money? TryModelBindNullableMoney(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (CheckIfValueProviderResultIsNull(valueProviderResult))
            {
                return null;
            }
            Money result;
            if (!Money.TryParse(valueProviderResult.AttemptedValue, out result))
            {
                bindingContext.ModelState.AddModelError(modelName, string.Format("The value '{0}' is not in a valid currency format.", valueProviderResult.AttemptedValue));
            }
            return result;
        }

        private static HtmlString TryModelBindHtmlString(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var attemptedValue = bindingContext.ValueProvider.GetValue(modelName).AttemptedValue;
            if (string.IsNullOrWhiteSpace(attemptedValue))
            {
                return null;
            }
            return new HtmlString(attemptedValue);
        }
    }
}

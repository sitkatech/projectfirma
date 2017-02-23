/*-----------------------------------------------------------------------
<copyright file="SitkaModelBinder.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// Provides easy way to make <see cref="IModelBinder"/>
    /// </summary>
    public abstract class SitkaModelBinder : IModelBinder
    {
        private readonly Func<string, object> _stringConstructorFunc;

        protected SitkaModelBinder(Func<string, object> stringConstructorFunc)
        {
            _stringConstructorFunc = stringConstructorFunc;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            Check.RequireType<string>(valueProviderResult.AttemptedValue, string.Format("Parameter {0} {1} but wrong primitive type.", typeof(object).Name, bindingContext.ModelName));
            var modelState = new ModelState() {Value = valueProviderResult};
            object actualValue = null;
            try
            {
                actualValue = ConstructFromString(valueProviderResult.AttemptedValue);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e.Message);

            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

            return actualValue;
        }

        public object ConstructFromString(string stringValue)
        {
            return ((Func<string, object>)(s => _stringConstructorFunc(s)))(stringValue);
        }


    }
}

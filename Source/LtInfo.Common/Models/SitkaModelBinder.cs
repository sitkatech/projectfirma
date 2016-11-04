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
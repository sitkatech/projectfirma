using System;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.EntityModelBinding
{
    /// <summary>
    /// Loads the <see cref="LtInfoEntityPrimaryKey{T}"/> from a url parameter that is an integer
    /// </summary>
    public class LtInfoEntityPrimaryKeyModelBinder : IModelBinder
    {
        /// <summary>
        /// This is really a call to <see cref="LtInfoEntityPrimaryKey{T}"/> constructor
        /// </summary>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var urlParameterValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var primaryKey = Int32.Parse(urlParameterValue.AttemptedValue);

            var modelType = bindingContext.ModelType;

            Check.Require(IsGenericTypeOf(modelType, typeof(LtInfoEntityPrimaryKey<>)), String.Format("Expected type of \"{0}\" but got type of \"{1}\". Can only be a binder for that type.", typeof(LtInfoEntityPrimaryKey<>), modelType));

            var constructorFunc = modelType.GetConstructor(new[] {typeof(int)});
            Check.RequireNotNull(constructorFunc, String.Format("Could not find constructor taking single integer parameter on type \"{0}\"", modelType.FullName));

            // ReSharper disable PossibleNullReferenceException
            var entity = constructorFunc.Invoke(new object[] { primaryKey });
            // ReSharper restore PossibleNullReferenceException
            return entity;
        }

        private static bool IsGenericTypeOf(Type typeToCheck, Type openGenericType)
        {
            if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == openGenericType)
            {
                return true;
            }
            return typeToCheck.BaseType != null && IsGenericTypeOf(typeToCheck.BaseType, openGenericType);
        }
    }
}
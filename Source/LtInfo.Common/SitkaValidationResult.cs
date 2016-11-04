using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace LtInfo.Common
{
    public class SitkaValidationResult<TObject, TProperty> : ValidationResult
    {
        public SitkaValidationResult(string errorMessage, Expression<Func<TObject, TProperty>> propertyNameLambda) : base(errorMessage, GetPropertyNameArray(propertyNameLambda)) {}

        private static IEnumerable<string> GetPropertyNameArray(Expression<Func<TObject, TProperty>> propertyLambda)
        {
            var type = typeof(TObject);
            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.", propertyLambda));
            }
            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", propertyLambda));
            }
            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
            {
                throw new ArgumentException(string.Format("Expresion '{0}' refers to a property that is not from type {1}.", propertyLambda, type));
            }

            return new[] {propInfo.Name};
        }
    }
}
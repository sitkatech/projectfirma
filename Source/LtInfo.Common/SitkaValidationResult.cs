/*-----------------------------------------------------------------------
<copyright file="SitkaValidationResult.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");
            }
            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");
            }
            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
            {
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a property that is not from type {type}.");
            }

            return new[] {propInfo.Name};
        }
    }
}

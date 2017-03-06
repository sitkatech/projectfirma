/*-----------------------------------------------------------------------
<copyright file="ModelAttributeHelpers.cs" company="Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LtInfo.Common.Mvc
{
    public static class ModelAttributeHelpers
    {
        public static string GetFileExtensions<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
        {

            var type = typeof(TModel);

            var memberExpression = (MemberExpression)expression.Body;
            var propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);
            if (propertyName == null)
            {
                return string.Empty;
            }

            // First look into attributes on a type and it's parents
            var attr = (SitkaFileExtensionsAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(SitkaFileExtensionsAttribute), true).SingleOrDefault();

            // Look for [MetadataType] attribute in type hierarchy
            // http://stackoverflow.com/questions/1910532/attribute-isdefined-doesnt-see-attributes-applied-with-metadatatype-class
            if (attr == null)
            {
                var metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null)
                    {
                        attr = (SitkaFileExtensionsAttribute)property.GetCustomAttributes(typeof(SitkaFileExtensionsAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? string.Join(", ", attr.ValidExtensions) : String.Empty;


        }
    }
}

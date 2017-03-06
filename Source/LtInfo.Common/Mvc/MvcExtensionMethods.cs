/*-----------------------------------------------------------------------
<copyright file="MvcExtensionMethods.cs" company="Sitka Technology Group">
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
using System.Linq.Expressions;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Mvc
{
    public static class MvcExtensionMethods
    {
        public static void AddModelError(this ModelStateDictionary modelState, string message)
        {
            modelState.AddModelError("", message);
        }

        public static void AddModelError<TViewModel>(this ModelStateDictionary modelState, Expression<Func<TViewModel, object>> method, string message)
        {
            Check.RequireNotNull(method);

            var mce = (MemberExpression) method.Body;
            var property = mce.Member.Name;
            modelState.AddModelError(property, message);
        }
    }
}

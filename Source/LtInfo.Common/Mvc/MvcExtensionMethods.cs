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
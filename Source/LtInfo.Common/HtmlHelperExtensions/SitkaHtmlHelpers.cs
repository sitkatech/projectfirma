/*-----------------------------------------------------------------------
<copyright file="SitkaHtmlHelpers.cs" company="Sitka Technology Group">
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
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;

namespace LtInfo.Common.HtmlHelperExtensions
{
    public static class SitkaHtmlHelpers
    {
        /// <summary>
        /// Used by <see cref="CalculateWebPathFromViewType{TPartialView}"/> to convert from a namespace to a web path
        /// </summary>
        private static readonly Regex NamespacesRegex = new Regex(@".*Web\.(?<NamespacesAfterWeb>.*)", RegexOptions.IgnoreCase);

        /// <summary>
        /// Renders your partial view.  Partial view must be contained in a ".*Web.*" namespace by convention.
        /// </summary>
        /// <typeparam name="TPartialView">The type of partial view you want to render</typeparam>
        /// <typeparam name="TViewModel">The viewModel type the partial view requires</typeparam>
        /// <typeparam name="TViewData">The strongly typed viewdata class, which is derived from TypedViewData</typeparam>
        /// <param name="helper">An html helper class</param>
        /// <param name="viewModel">The viewModel the partial view needs</param>
        /// <param name="viewData">The viewdata which the partial view expects</param>
        public static void RenderRazorSitkaPartial<TPartialView, TViewData, TViewModel>(this HtmlHelper helper,
                                                                               TViewData viewData, TViewModel viewModel)
            where TPartialView : TypedWebPartialViewPage<TViewData, TViewModel>
        {
            var partialViewName = CalculateWebPathFromRazorViewType<TPartialView>();
            var vdd = new ViewDataDictionary();
            vdd[TypedWebViewPage.ViewDataDictionaryKey] = viewData;

            helper.RenderPartial(partialViewName, viewModel, vdd);
        }

        /// <summary>
        /// Renders your partial view.  Partial view must be contained in a ".*Web.*" namespace by convention.
        /// </summary>
        /// <typeparam name="TPartialView">The type of partial view you want to render</typeparam>
        /// <typeparam name="TViewData">The viewModel type the partial view requires</typeparam>
        /// <param name="helper">An html helper class</param>
        /// <param name="viewData">The viewModel the partial view needs</param>
        public static void RenderRazorSitkaPartial<TPartialView, TViewData>(this HtmlHelper helper, TViewData viewData)
            where TPartialView : TypedWebPartialViewPage<TViewData>
        {
            var partialViewName = CalculateWebPathFromRazorViewType<TPartialView>();
            var vdd = new ViewDataDictionary();
            vdd[TypedWebViewPage.ViewDataDictionaryKey] = viewData;

            helper.RenderPartial(partialViewName, null, vdd);
        }

        /// <summary>
        /// Renders your partial view.  Partial view must be contained in a ".*Web.*" namespace by convention.
        /// </summary>
        /// <typeparam name="TPartialView">The type of partial view you want to render</typeparam>
        /// <param name="helper">An html helper class</param>
        public static void RenderRazorSitkaPartial<TPartialView>(this HtmlHelper helper)
            where TPartialView : WebViewPage
        {
            var partialViewName = CalculateWebPathFromRazorViewType<TPartialView>();
            helper.RenderPartial(partialViewName);
        }

        /// <summary>
        /// Only public for testing purposes
        /// </summary>
        internal static string CalculateWebPathFromViewType<TPartialView>()
        {
            var type = typeof(TPartialView);
            Check.RequireNotNull(type.Namespace,
                                 String.Format("Type {0} missing its namespace, unable to calculate web path.",
                                               type.Name));

            // ReSharper disable AssignNullToNotNullAttribute
            var match = NamespacesRegex.Match(type.Namespace);
            // ReSharper restore AssignNullToNotNullAttribute

            Check.Require(match.Success,
                          String.Format(
                              "Type {0} has namespace {1} that doesn't match regular expression \"{2}\", unable to calculate web path. Is the type following the naming conventions?",
                              type.Name, type.Namespace, NamespacesRegex));

            var namespacesAfterWeb = match.Groups["NamespacesAfterWeb"].ToString();
            var pathOutOfNamespaces = namespacesAfterWeb.Replace(".", "/");
            var webPathToPartialView = String.Format("~/{0}/{1}.ascx", pathOutOfNamespaces, type.IsGenericType ? type.Name.Replace("`1", "") : type.Name); //note: removing the `1 from generic type names because the view's will not have that in their name.
            return webPathToPartialView;
        }

        /// <summary>
        /// Only public for testing purposes
        /// </summary>
        internal static string CalculateWebPathFromRazorViewType<TPartialView>()
        {
            var type = typeof(TPartialView);
            Check.RequireNotNull(type.Namespace,
                                 String.Format("Type {0} missing its namespace, unable to calculate web path.",
                                               type.Name));

            // ReSharper disable AssignNullToNotNullAttribute
            var match = NamespacesRegex.Match(type.Namespace);
            // ReSharper restore AssignNullToNotNullAttribute

            Check.Require(match.Success,
                          String.Format(
                              "Type {0} has namespace {1} that doesn't match regular expression \"{2}\", unable to calculate web path. Is the type following the naming conventions?",
                              type.Name, type.Namespace, NamespacesRegex));

            var namespacesAfterWeb = match.Groups["NamespacesAfterWeb"].ToString();
            var pathOutOfNamespaces = namespacesAfterWeb.Replace(".", "/");
            var webPathToPartialView = String.Format("~/{0}/{1}.cshtml", pathOutOfNamespaces, type.IsGenericType ? type.Name.Replace("`1", "") : type.Name); //note: removing the `1 from generic type names because the view's will not have that in their name.
            return webPathToPartialView;
        }

    }

}

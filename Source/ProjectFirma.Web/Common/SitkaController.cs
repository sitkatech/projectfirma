/*-----------------------------------------------------------------------
<copyright file="SitkaController.cs" company="Sitka Technology Group">
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

using DHTMLX.Export.Excel;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ProjectFirma.Web.Common
{
    public abstract partial class SitkaController : Controller
    {
        public const string StatusErrorIndex = "StatusError";
        public const string StatusErrorScrollablePreIndex = "StatusErrorScrollablePre";
        public const string StatusMessageIndex = "StatusMessage";
        public const string InfoMessageIndex = "InfoMessage";
        public const string WarningMessageIndex = "WarningMessage";

        public const string NotAuthorizedLoginText = "You do not have permission to do that, please log in.";

        protected static ReadOnlyCollection<MethodInfo> AllControllerActionMethodsProtected;
        
        private const string ControllerSuffix = "Controller";
        private const string ViewsRootNamespace = "Views";
        public const string DefaultAction = "Index";
        public const string DefaultController = "Home";

        protected abstract bool IsCurrentUserAnonymous();
        protected abstract string LoginUrl { get; }

        protected override void OnException(ExceptionContext filterContext)
        {
            var lastError = filterContext.Exception;
            if (lastError is SitkaRecordNotAuthorizedException && IsCurrentUserAnonymous())
            {
                var requestUrl = Request.Url != null ? Request.Url.ToString() : String.Empty;
                var url = $"{LoginUrl}?returnUrl={Server.UrlEncode(requestUrl)}";
                filterContext.ExceptionHandled = true;
                Response.Redirect(url);
                return;
            }

            if (lastError is SitkaRecordNotFoundException)
            {
                SitkaHttpRequestStorage.NotFoundStoredError = lastError as SitkaRecordNotFoundException;
            }

            base.OnException(filterContext);
        }

        public void SetErrorWithScrollablePreForDisplay(string errorMessage)
        {
            SetMessage(StatusErrorScrollablePreIndex, errorMessage, TempData);
        }
        protected void ClearErrorWithScrollablePreForDisplay()
        {
            RemoveMessage(StatusErrorScrollablePreIndex, TempData);
        }

        public static void SetErrorForDisplay(TempDataDictionary tempData, string errorMessage)
        {
            SetMessage(StatusErrorIndex, errorMessage, tempData);
        }

        public void SetErrorForDisplay(string errorMessage)
        {
            SetMessage(StatusErrorIndex, errorMessage, TempData);
        }

        public void SetWarningForDisplay(string errorMessage)
        {
            SetMessage(WarningMessageIndex, errorMessage, TempData);
        }

        protected void ClearErrorForDisplay()
        {
            RemoveMessage(StatusErrorIndex, TempData);
        }

        public void SetMessageForDisplay(string message)
        {
            SetMessage(StatusMessageIndex, message, TempData);
        }

        protected void ClearMessageForDisplay()
        {
            RemoveMessage(StatusMessageIndex, TempData);
        }

        private static void RemoveMessage(string index, TempDataDictionary tempData)
        {
            tempData.Remove(index);
        }

        private static void SetMessage(string index, string message, TempDataDictionary tempData)
        {
            tempData[index] = message;
        }

        public void SetInfoForDisplay(string message)
        {
            SetMessage(InfoMessageIndex, message, TempData);
        }

        protected void ClearInfoForDisplay()
        {
            RemoveMessage(InfoMessageIndex, TempData);
        }

        /// <summary>
        /// This can be null so be careful when using it
        /// </summary>
        protected abstract ISitkaDbContext SitkaDbContext { get; }


        private static bool IsSetToAutomaticallyCallEntityFrameworkSaveChangesAttribute(ActionExecutedContext filterContext)
        {
            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AutomaticallyCallEntityFrameworkSaveChangesWhenModelValidAttribute), true).Any();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if ((filterContext.Exception == null || filterContext.ExceptionHandled) && IsSetToAutomaticallyCallEntityFrameworkSaveChangesAttribute(filterContext) && ModelState.IsValid)
            {
                // We have Configuration.AutoDetectChangesEnabled turned off by default instead of it being true out of the box
                // We only need to detect changes when we know we are saving
                try
                {
                    SitkaDbContext.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // something can go wrong when we are doing our save of EF; since this happens after the action has executed, we need to clear any messages that assumed the happy path
                    ClearMessageForDisplay();
                    var errorDetails = string.Format("DbEntityValidationException occurred, below are details from the 'EntityValidationErrors' property.\r\n{0}",
                        String.Join("\r\n",
                            ex.EntityValidationErrors.Select(
                                x =>
                                    "Entry.Entity: " + x.Entry.Entity.GetType().Name + "\r\n" +
                                    String.Join("\r\n", x.ValidationErrors.Select(y => String.Format("   PropertyName: {0}, ErrorMessage: {1}", y.PropertyName, y.ErrorMessage))))));
                    throw new ApplicationException(errorDetails, ex);
                }
                catch
                {
                    // something can go wrong when we are doing our save of EF; since this happens after the action has executed, we need to clear any messages that assumed the happy path
                    ClearMessageForDisplay();
                    throw;
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public static List<MethodInfo> FindControllerActions(Type controller)
        {
            // Abstract can't be directly routed
            if (controller.IsAbstract)
            {
                return new List<MethodInfo>();
            }
            var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            // All Asp.net MVC controller actions need return type ActionResult
            return methods.Where(m => m.ReturnType == typeof(ActionResult) || m.ReturnType.IsSubclassOf(typeof(ActionResult))).ToList();
        }

        public static List<MethodInfo> GetAllControllerActionMethods(Type controllerTypeInTheAssemblyToSearchForOtherControllers)
        {
            var aspnetMvcControllerBaseClassType = typeof(Controller);
            Check.Require(controllerTypeInTheAssemblyToSearchForOtherControllers.IsSubclassOf(aspnetMvcControllerBaseClassType), string.Format("Type \"{0}\" must be a subclass of \"{1}\" to make this call. Change call site to get this fixed.", controllerTypeInTheAssemblyToSearchForOtherControllers.FullName, aspnetMvcControllerBaseClassType.FullName));

            // Find all the controllers in the main assembly for all controllers
            var assembly = Assembly.GetAssembly(controllerTypeInTheAssemblyToSearchForOtherControllers);

            Type[] allTypesInControllerAssembly;

            // To speed up troubleshooting in this area because exceptions of type ReflectionTypeLoadException can be hard to diagnose, try catch rethrow same exception but with more information in the message about *which* types failed to load
            try
            {
                allTypesInControllerAssembly = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                // Get out the most important part - the LoaderExceptions which will help speed fixing the problem
                var loaderExceptions = String.Join("\r\n   ", ex.LoaderExceptions.Select(x => x.ToString()));
                var message = string.Format("{0}\r\nLoaderExceptions:\r\n{1}", ex.Message, loaderExceptions);
                throw new ReflectionTypeLoadException(ex.Types, ex.LoaderExceptions, message);
            }

            // Find any type that is an ASP.NET MVC Controller type (excluding abstract which can't be routed)
            var controllerTypes = allTypesInControllerAssembly.Where(t => t.IsSubclassOf(aspnetMvcControllerBaseClassType) && !t.IsAbstract).ToList();

            var allMethods = new List<MethodInfo>();

            foreach (var controller in controllerTypes)
            {
                allMethods.AddRange(FindControllerActions(controller));
            }

            return allMethods;
        }

        protected void RequireViewPageIsInControllerViewDirectory<TView>()
        {
            var thisControllerType = GetType();
            var viewType = typeof(TView);

            var viewName = viewType.FullName;
            var thisControllerTypeName = thisControllerType.Name;

            // Is this one of several exceptions to the rule? If so, they don't need to have the same scope.
            var viewNamespace = (viewType.Namespace ?? String.Empty);
            var viewNamespaceSet = viewNamespace.Split('.');

            Check.Require(viewNamespaceSet.Contains(ViewsRootNamespace), string.Format("Could not find views root namespace {0} in the view {1}, is it a proper view?", ViewsRootNamespace, viewName));

            var isViewShared = viewNamespaceSet.Contains("Shared");

            // Otherwise, View and Controller should be in same directory.
            var viewNameLastNamespace = viewNamespaceSet.Last();
            var thisControllerName = ControllerTypeToControllerName(thisControllerType);
            var controllerAndPageInSameDirectory = (viewNameLastNamespace == thisControllerName);

            Check.Require(isViewShared || controllerAndPageInSameDirectory, String.Format("You can't cross boundaries on controllers ({0} -> {1}). You must return a View that is within your controller's view directory or a shared one, otherwise view resolution will fail.", thisControllerTypeName, viewName));
        }

        /// <summary>
        /// Convert a type into a controller name following MVC conventions of removing the controller suffix <see cref="ControllerSuffix" /> type: FooController => string: Foo
        /// </summary>
        /// <param name="controllerType">Type of the controller</param>
        /// <returns>string of the name minus the suffix</returns>
        public static string ControllerTypeToControllerName(Type controllerType)
        {
            var typeName = controllerType.Name;
            Check.Require(typeName.EndsWith(ControllerSuffix), string.Format("Type {0} does not match naming convention for controller, expected suffix \"{1}\"", typeName, ControllerSuffix));
            var controllerTypeToControllerName = typeName.Substring(0, typeName.Length - ControllerSuffix.Length);
            Check.RequireNotNullNotEmptyNotWhitespace(controllerTypeToControllerName, string.Format("Got an empty controller name off of type {0} after removing suffix \"{1}\", illegal name unreachable by routes", typeName, ControllerSuffix));
            return controllerTypeToControllerName;
        }

        /// <summary>
        /// Finds the name of the MVC area for a given controller type
        /// </summary>
        /// <param name="controllerType">Type of the controller</param>
        /// <returns>string of the area</returns>
        public static string ControllerTypeToAreaName(Type controllerType)
        {
            var namespaceParts = new Stack<string>(controllerType.FullName.Split('.'));

            var typeName = namespaceParts.Pop();
            Check.Require(namespaceParts.Pop() == "Controllers", string.Format("Folder containing type {0} does not match expected name convention of \"Controllers\"", typeName));
            
            var areaName = namespaceParts.Pop();
            var areasFolder = namespaceParts.Pop();

            return areasFolder.ToLower() != "areas" ? string.Empty : areaName;
        }

        /// <summary>
        /// Convert a type into a controller name for the URL following MVC conventions of removing the controller suffix <see cref="ControllerSuffix" /> type: FooController => string: Foo.mvc or Foo
        /// </summary>
        /// <param name="controllerType">Type of the controller</param>
        /// <returns>string of the name minus the suffix plus optional .mvc file extension</returns>
        public static string ControllerTypeToControllerNameForUrl(Type controllerType)
        {
            var controllerName = ControllerTypeToControllerName(controllerType);
            return ControllerNameToUrlSegment(controllerName);
        }

        /// <summary>
        /// Convert a controller name into the segement of the URL following MVC conventions adding .mvc as needed: Foo => string: Foo.mvc or Foo
        /// </summary>
        /// <param name="controllerName">Controller name (name minus the "Controller" suffix)</param>
        public static string ControllerNameToUrlSegment(string controllerName)
        {
            var mvcFileExtensionIfAny = (SitkaWebConfiguration.UseMvcExtensionInUrl) ? ".mvc" : "";
            return string.Format("{0}{1}", controllerName, mvcFileExtensionIfAny);
        }

        public static List<MethodInfo> FindAttributedMethods(Type webServiceType, Type attributeType)
        {
            var methods = webServiceType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return methods.Where(m => m.GetCustomAttributes(true).Any(a => a.GetType() == attributeType)).ToList();
        }

        protected ActionResult RedirectToReferrerOrTo<T>(SitkaRoute<T> fallbackRoute)
            where T : Controller
        {
            if (HttpContext.Request.UrlReferrer != null)
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }

            return RedirectToAction(fallbackRoute);
        }

        protected RedirectResult RedirectToAction<T>(SitkaRoute<T> route) where T : Controller
        {
            return RedirectToActionStatic(route);
        }

        protected ActionResult RedirectToActionWithError<T>(SitkaRoute<T> route, string error) where T : Controller
        {
            SetErrorForDisplay(error);
            return RedirectToActionStatic(route);
        }

        public static RedirectResult RedirectToActionStatic<T>(SitkaRoute<T> route) where T : Controller
        {
            return new RedirectResult(route.BuildUrlFromExpression());
        }

        protected FileResult ExportGridToExcelImpl(string gridName)
        {
            // In DHTMLX Grid 4.2 Formulas don't work so PrintFooter true is not very useful, leaving off for now
            var generator = new ExcelWriter { PrintFooter = false };
            var xml = Request.Form["grid_xml"];
            xml = Server.UrlDecode(xml);
            xml = xml.Replace("<![CDATA[$", "<![CDATA["); // RL 7/11/2015 Poor man's hack to remove currency and allow for total rows
            var stream = generator.Generate(xml);
            return File(stream.ToArray(), generator.ContentType, string.Format("{0}.xlsx", gridName));
        }

        /// <summary>
        /// Preferred signature for creating view results
        /// </summary>
        protected ViewResult RazorView<TPage, TViewData>(TViewData viewData) where TPage : TypedWebViewPage<TViewData>
        {
            SetViewDataTyped(viewData, ViewData);
            return ViewImpl<TPage>(null);
        }

        private static void SetViewDataTyped<TViewData>(TViewData viewData, ViewDataDictionary viewDataDictionary)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            if (!viewData.GetType().IsValueType && viewData == null)
            {
                throw new ArgumentNullException("viewData");
            }
            // ReSharper restore CompareNonConstrainedGenericWithNull
            viewDataDictionary[TypedWebViewPage.ViewDataDictionaryKey] = viewData;
        }

        protected virtual ViewResult ViewImpl<TPage>(object viewData)
        {
            RequireViewPageIsInControllerViewDirectory<TPage>();
            var viewName = typeof(TPage).Name;

#pragma warning disable 612,618
            return base.View(viewName, viewData);
#pragma warning restore 612,618
        }

        private static void EnsureViewModelIsSet<TViewModel>(TViewModel viewModel)
        {
// ReSharper disable CompareNonConstrainedGenericWithNull
            if (!viewModel.GetType().IsValueType && viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            // ReSharper restore CompareNonConstrainedGenericWithNull
        }

        /// <summary>
        /// Preferred signature for creating view results
        /// </summary>
        protected ViewResult RazorView<TPage, TViewData, TViewModel>(TViewData viewData, TViewModel viewModel) where TPage : TypedWebViewPage<TViewData, TViewModel>
        {
            EnsureViewModelIsSet(viewModel);
            SetViewDataTyped(viewData, ViewData);
            return ViewImpl<TPage>(viewModel);
        }

        protected PartialViewResult RazorPartialView<TPage, TViewData>(TViewData viewData) where TPage : TypedWebPartialViewPage<TViewData>
        {
            SetViewDataTyped(viewData, ViewData);
            return PartialViewImpl<TPage>(null);
        }

        protected PartialViewResult RazorPartialView<TPage, TViewData, TViewModel>(TViewData viewData, TViewModel viewModel) where TPage : TypedWebPartialViewPage<TViewData, TViewModel>
        {
            EnsureViewModelIsSet(viewModel);
            SetViewDataTyped(viewData, ViewData);
            return PartialViewImpl<TPage>(viewModel);
        }

        protected virtual PartialViewResult PartialViewImpl<TPage>(object viewModel)
        {
            RequireViewPageIsInControllerViewDirectory<TPage>();
            var viewName = typeof(TPage).Name;

#pragma warning disable 612,618
            return base.PartialView(viewName, viewModel);
#pragma warning restore 612,618
        }


        /// <summary>
        /// http://support.microsoft.com/kb/316431 Internet Explorer is unable to open Office documents from an SSL Web site
        /// http://support.microsoft.com/kb/815313 Prevent caching when you download active documents over SSL
        /// http://support.microsoft.com/kb/323308 Internet Explorer file downloads over SSL do not work with the cache control headers
        /// </summary>
        private void SetHeadersForInternetExplorer8Support()
        {
            HttpContext.Response.Headers.Remove("Pragma");
        }

        protected override FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName)
        {
            SetHeadersForInternetExplorer8Support();
            return base.File(fileContents, contentType, fileDownloadName);
        }

        protected override FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName)
        {
            SetHeadersForInternetExplorer8Support();
            return base.File(fileStream, contentType, fileDownloadName);
        }

        protected override FilePathResult File(string fileName, string contentType, string fileDownloadName)
        {
            SetHeadersForInternetExplorer8Support();
            return base.File(fileName, contentType, fileDownloadName);
        }

        protected FileContentResult TemporaryFile(string fileName, string contentType, string fileDownloadName)
        {
            SetHeadersForInternetExplorer8Support();
            var bytes = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(bytes, contentType, fileDownloadName);
        }

        protected string RenderPartialViewToString(string viewName, object viewData)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            }

            ViewData[TypedWebViewPage.ViewDataDictionaryKey] = viewData;

            ViewData.Model = viewData;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutomaticallyCallEntityFrameworkSaveChangesWhenModelValidAttribute : Attribute
    {}
}

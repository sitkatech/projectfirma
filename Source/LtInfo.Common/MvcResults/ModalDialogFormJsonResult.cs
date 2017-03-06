/*-----------------------------------------------------------------------
<copyright file="ModalDialogFormJsonResult.cs" company="Sitka Technology Group">
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
using System.Web.Mvc;

namespace LtInfo.Common.MvcResults
{
    public class ModalDialogFormJsonResult : JsonResult
    {
        /// <summary>
        /// Optional redirect url
        /// </summary>
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// Optional javascript function to run after successful response
        /// </summary>
        public string OnSuccessJavascriptFunctionToRun { get; private set; }

        public ModalDialogFormJsonResult(string redirectUrl, string onSuccessJavascriptFunctionToRun)
        {
            RedirectUrl = redirectUrl;
            OnSuccessJavascriptFunctionToRun = onSuccessJavascriptFunctionToRun;
        }

        public ModalDialogFormJsonResult(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        public ModalDialogFormJsonResult()
        {
            // this is mainly to satisfy unit tests because ExecuteResult does not get run
            Data = new ModalDialogFormJsonData(true, RedirectUrl, OnSuccessJavascriptFunctionToRun);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var controller = (Controller)context.Controller;
            Data = new ModalDialogFormJsonData(controller.ModelState.IsValid, RedirectUrl, OnSuccessJavascriptFunctionToRun);
            base.ExecuteResult(context);
        }

        public class ModalDialogFormJsonData
        {
            public readonly bool Success;
            public readonly string RedirectUrl;
            public readonly string OnSuccessJavascriptFunctionToRun;

            public ModalDialogFormJsonData(bool success, string redirectUrl, string onSuccessJavascriptFunctionToRun)
            {
                Success = success;
                RedirectUrl = redirectUrl;
                OnSuccessJavascriptFunctionToRun = onSuccessJavascriptFunctionToRun;
            }
        }
    }
}

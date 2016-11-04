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
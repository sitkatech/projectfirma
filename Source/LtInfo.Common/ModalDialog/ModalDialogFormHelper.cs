using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.BootstrapWrappers;

namespace LtInfo.Common.ModalDialog
{
    public static class ModalDialogFormHelper
    {
        public const string SaveButtonId = "ltinfo-modal-dialog-save-button-id";
        public const string CancelButtonId = "ltinfo-modal-dialog-cancel-button-id";
        public const int DefaultDialogWidth = 800;
        private static readonly List<string> DefaultExtraButtonCssClasses = SitkaWebConfiguration.DefaultModalDialogButtonCssClasses;

        /// <summary>
        ///  Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData)
        {
            return ModalDialogFormLink(null,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                SaveButtonId,
                saveButtonText,
                CancelButtonId,
                cancelButtonText,
                extraCssClasses,
                onJavascriptReadyFunction,
                postData,
                null,
                null);
        }

        public static HtmlString ModalDialogFormLink(string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            string dialogId)
        {
            return ModalDialogFormLink(null,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                SaveButtonId,
                saveButtonText,
                CancelButtonId,
                cancelButtonText,
                extraCssClasses,
                onJavascriptReadyFunction,
                postData,
                dialogId,
                null);
        }

        /// <summary>
        ///     Creates a link that will open a jQuery UI dialog form.
        ///     Adds additional parameters controlling button IDs if needed.
        /// </summary>
        /// <param name="linkID">Optional LinkID to be able to access it later on the page</param>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonId">ID for the save button for later reference by jQuery, etc. Take care to make unique!</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonId">ID for the cancel button for later reference by jQuery, etc. Take care to make unique!</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <param name="optionalDialogFormID"></param>
        /// <param name="extraButtonCssClasses"></param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkID,
            string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonId,
            string saveButtonText,
            string cancelButtonId,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            string optionalDialogFormID,
            List<string> extraButtonCssClasses)
        {
            var builder = new TagBuilder("a");
            builder.InnerHtml += linkText;
            if (!string.IsNullOrWhiteSpace(linkID))
            {
                builder.Attributes.Add("id", linkID);
            }
            builder.Attributes.Add("href", dialogContentUrl);
            builder.Attributes.Add("data-dismiss", "modal");
            builder.Attributes.Add("data-dialog-title", dialogTitle);
            builder.Attributes.Add("data-dialog-width", dialogWidth.ToString());

            if (saveButtonId != string.Empty)
                builder.Attributes.Add("data-save-button-id", saveButtonId);
            builder.Attributes.Add("data-save-button-text", saveButtonText);
            if (cancelButtonId != string.Empty)
                builder.Attributes.Add("data-cancel-button-id", cancelButtonId);
            builder.Attributes.Add("data-cancel-button-text", cancelButtonText);

            
            builder.Attributes.Add("data-button-css-classes", string.Join(" ", extraButtonCssClasses ?? DefaultExtraButtonCssClasses));

            if (!string.IsNullOrWhiteSpace(optionalDialogFormID))
            {
                builder.Attributes.Add("data-optional-dialog-form-id", optionalDialogFormID);
            }

            var javascripReadyFunctionAsParameter = !string.IsNullOrWhiteSpace(onJavascriptReadyFunction) ? string.Format("function() {{{0}();}}", onJavascriptReadyFunction) : "null";
            var postDataAsParameter = !string.IsNullOrWhiteSpace(postData) ? postData : "null";
            var onclickFunction = string.Format("return modalDialogLink(this, {0}, {1});", javascripReadyFunctionAsParameter, postDataAsParameter);
            builder.Attributes.Add("onclick", onclickFunction);

            if (extraCssClasses != null)
            {
                foreach (var extraCssClass in extraCssClasses)
                {
                    builder.AddCssClass(extraCssClass);
                }
            }

            return new HtmlString(builder.ToString());
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return ModalDialogFormLink(linkText, dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission);
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, List<string> extraCssClasses)
        {
            return ModalDialogFormLink(linkText, dialogUrl, dialogTitle, DefaultDialogWidth, "Save", "Cancel", extraCssClasses, null, null);
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, List<string> extraCssClasses, string dialogFormID)
        {
            return ModalDialogFormLink(null, linkText, dialogUrl, dialogTitle, DefaultDialogWidth, SaveButtonId, "Save", CancelButtonId, "Cancel", extraCssClasses, null, null, dialogFormID, null);
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, int dialogWidth, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink(linkText, dialogUrl, dialogTitle, dialogWidth, "Save", "Cancel", new List<string>(), null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, int dialogWidth, bool hasPermission, string dialogFormID)
        {
            return hasPermission
                ? ModalDialogFormLink(null, linkText, dialogUrl, dialogTitle, dialogWidth, SaveButtonId, "Save", CancelButtonId, "Cancel", new List<string>(), null, null, dialogFormID, null)
                : new HtmlString(string.Empty);
        }

        public static HtmlString MakeDeleteLink(string linkText, string deleteDialogUrl, List<string> extraCssClasses, bool userHasDeletePermission)
        {
            return userHasDeletePermission ? ModalDialogFormLink(linkText, deleteDialogUrl, "Confirm Delete", 500, "Delete", "Cancel", extraCssClasses, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeDeleteLink(string linkText, string deleteDialogUrl, bool hasPermission)
        {
            return MakeDeleteLink(linkText, deleteDialogUrl, new List<string>(), hasPermission);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return MakeEditIconLink(dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission)
        {
            return ModalDialogFormLink(BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit blue").ToString(), dialogUrl, dialogTitle, width, hasPermission);
        }

        public static HtmlString MakeLtInfoEditIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission)
        {
            var linkText = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit blue").ToString();
            var buttonCssClasses = new List<string>(){"btn-firma"};
            return hasPermission ? ModalDialogFormLink(null, linkText, dialogUrl, dialogTitle, width, SaveButtonId, "Save", CancelButtonId, "Cancel", new List<string>(), null, null, null, buttonCssClasses) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission, string dialogFormID)
        {
            return MakeEditIconLink(dialogUrl, dialogTitle, width, "Save", hasPermission, dialogFormID);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, int width, string saveButtonText, bool hasPermission, string dialogFormID)
        {
            var linkText = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit blue").ToString();
            var extraCssClasses = new List<string>();
            return hasPermission
                ? ModalDialogFormLink(null, linkText, dialogUrl, dialogTitle, width, SaveButtonId, saveButtonText, CancelButtonId, "Cancel", extraCssClasses, null, null, dialogFormID, null)
                : new HtmlString(string.Empty);
        }
    }
}
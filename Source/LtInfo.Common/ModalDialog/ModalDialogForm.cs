/*-----------------------------------------------------------------------
<copyright file="ModalDialogForm.cs" company="Sitka Technology Group">
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
namespace LtInfo.Common.ModalDialog
{
    public class ModalDialogForm
    {
        private const int DefaultWidth = 800;
        private const string DefaultSaveButtonText = "Save";
        private const string DefaultCancelButtonText = "Cancel";

        public readonly string ContentUrl;
        public readonly string DialogTitle;
        public readonly int DialogWidth;
        public readonly string OnJavascriptReadyFunction;
        public readonly string LinkID;

        public readonly string SaveButtonText;
        public readonly string CancelButtonText;

        public ModalDialogForm(string contentUrl)
            : this(null, contentUrl, DefaultWidth, null, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, string dialogTitle)
            : this(null, contentUrl, DefaultWidth, dialogTitle, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, int dialogWidth, string dialogTitle)
            : this(null, contentUrl, dialogWidth, dialogTitle, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction)
            : this(null, contentUrl, dialogWidth, dialogTitle, onJavascriptReadyFunction, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string linkID, string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction)
            : this(linkID, contentUrl, dialogWidth, dialogTitle, onJavascriptReadyFunction, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string linkID, string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction, string saveButtonText, string cancelButtonText)
        {
            ContentUrl = contentUrl;
            DialogWidth = dialogWidth;
            DialogTitle = dialogTitle;
            OnJavascriptReadyFunction = onJavascriptReadyFunction;
            LinkID = linkID;
            SaveButtonText = saveButtonText;
            CancelButtonText = cancelButtonText;
        }
    }
}

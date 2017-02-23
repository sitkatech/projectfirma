/*-----------------------------------------------------------------------
<copyright file="BulkTagModalDialogForm.cs" company="Sitka Technology Group">
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
namespace LtInfo.Common.DhtmlWrappers
{
    public class BulkTagModalDialogForm
    {
        public string DialogUrl;
        public string DialogLinkText;
        public string DialogTitle;
        public int CheckboxColumnIndex;
        public string ValueColumnName;
        public string ReturnListName;

        public BulkTagModalDialogForm(string dialogUrl)
        {
            DialogUrl = dialogUrl;
            DialogLinkText = "Tag Checked Projects";
            DialogTitle = "Tag Projects";
            CheckboxColumnIndex = 0;
            ValueColumnName = "ProjectID";
            ReturnListName = "ProjectIDList";

        }
    }
}

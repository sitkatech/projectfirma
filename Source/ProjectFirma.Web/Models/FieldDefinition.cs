/*-----------------------------------------------------------------------
<copyright file="FieldDefinition.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Models
{
    public partial class FieldDefinition : IFieldDefinition
    {
        public bool HasDefinition
        {
            get { return HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.Any(x => x.FieldDefinitionID == FieldDefinitionID); }
        }

        public HtmlString FieldDefinitionDataValue
        {
            get
            {
                var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(this);
                return fieldDefinitionData != null ? fieldDefinitionData.FieldDefinitionDataValueHtmlString : new HtmlString(string.Empty);
            }
        }

        public IFieldDefinitionData FieldDefinitionData 
        {
            get { return HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(this); }
        }
        public string GetContentUrl()
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetails(FieldDefinitionID));
        }
    }
}

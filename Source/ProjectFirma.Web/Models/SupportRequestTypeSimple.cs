/*-----------------------------------------------------------------------
<copyright file="SupportRequestTypeSimple.cs" company="Sitka Technology Group">
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
namespace ProjectFirma.Web.Models
{
    public class SupportRequestTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public SupportRequestTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SupportRequestTypeSimple(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder)
            : this()
        {
            SupportRequestTypeID = supportRequestTypeID;
            SupportRequestTypeName = supportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestTypeSortOrder;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public SupportRequestTypeSimple(SupportRequestType supportRequestType)
            : this()
        {
            SupportRequestTypeID = supportRequestType.SupportRequestTypeID;
            SupportRequestTypeName = supportRequestType.SupportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestType.SupportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestType.SupportRequestTypeSortOrder;
        }

        public int SupportRequestTypeID { get; set; }
        public string SupportRequestTypeName { get; set; }
        public string SupportRequestTypeDisplayName { get; set; }
        public int SupportRequestTypeSortOrder { get; set; }
    }
}

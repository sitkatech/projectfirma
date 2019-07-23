/*-----------------------------------------------------------------------
<copyright file="EditUsersContactTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.User
{
    public class EditUsersContactTypeViewModel : FormViewModel
    {
        [Required] public int PersonID { get; set; }

        [Required] [DisplayName("Contact Type")]
        public int? ContactTypeID { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditUsersContactTypeViewModel()
        {
        }

        public EditUsersContactTypeViewModel(Person person)
        {
            PersonID = person.PersonID;
            ContactTypeID = person.ContactTypeID;
        }

        public void UpdateModel(Person person, Person currentPerson)
        {

            person.ContactTypeID = ContactTypeID ?? ModelObjectHelpers.NotYetAssignedID;

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(person.PersonID))
            {
                person.UpdateDate = DateTime.Now; // Existing person
            }
            else
            {
                person.CreateDate = DateTime.Now; // New person
            }


        }
    }
}

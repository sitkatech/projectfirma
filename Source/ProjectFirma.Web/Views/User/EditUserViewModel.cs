/*-----------------------------------------------------------------------
<copyright file="EditUserViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirma.Web.Views.User
{
    public class EditUserViewModel : FormViewModel
    {
        [Required] 
        public int PersonID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationID { get; set; }

        [Required]
        public string Username { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditUserViewModel()
        {
        }

        public EditUserViewModel(Person person)
        {
            PersonID = person.PersonID;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            PhoneNumber = person.Phone;
            OrganizationID = person.OrganizationID;
            Username = person.LoginName;

        }

        public void UpdateModel(Person personBeingEdited, FirmaSession currentFirmaSession)
        {

            personBeingEdited.FirstName = FirstName;
            personBeingEdited.LastName = LastName;
            personBeingEdited.Email = Email;
            personBeingEdited.Phone = PhoneNumber;
            personBeingEdited.OrganizationID = OrganizationID;
            personBeingEdited.LoginName = Username;
        }
    }
}

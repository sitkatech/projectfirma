/*-----------------------------------------------------------------------
<copyright file="ChangePasswordViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DocumentFormat.OpenXml.Bibliography;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using LtInfo.Common.Security;
using Microsoft.Web.Mvc.Controls;
using ProjectFirma.Web.Common;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirma.Web.Views.User
{
    public class ChangePasswordViewModel : FormViewModel
    {
        public int PersonID { get; set; }

        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Confirm New Password")]
        public string ConfirmNewPassword { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ChangePasswordViewModel()
        {
        }

        public ChangePasswordViewModel(Person person)
        {
            PersonID = person.PrimaryKey;

        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var personLoginAccount = HttpRequestStorage.DatabaseEntities.Person.PersonLoginAccount;

            var isSelfEdit = personLoginAccount.PersonID == PersonID;

            if (isSelfEdit && !PBKDF2PasswordHash.ValidatePassword(personLoginAccount.PasswordSalt, OldPassword, personLoginAccount.PasswordHash))
            {
                errors.Add(new SitkaValidationResult<ChangePasswordViewModel, string>("Bad password", z => z.OldPassword));
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                errors.Add(new SitkaValidationResult<ChangePasswordViewModel, string>("Please specify a new password", z => z.NewPassword));
            }

            if (string.IsNullOrEmpty(ConfirmNewPassword))
            {
                errors.Add(new SitkaValidationResult<ChangePasswordViewModel, string>("Please confirm the new password", z => z.ConfirmNewPassword));
            }

            if (NewPassword != ConfirmNewPassword)
            {
                errors.Add(new SitkaValidationResult<ChangePasswordViewModel, string>("Passwords must match.", z => z.NewPassword));
            }

            if (!PasswordHelper.VerifyPasswordComplexity(NewPassword))
            {
                errors.Add(new ValidationResult(PasswordHelper.GetPasswordComplexityErrorMessage(NewPassword)));
            }

            return errors;
        }
    }
}

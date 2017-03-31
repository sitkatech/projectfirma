/*-----------------------------------------------------------------------
<copyright file="PullUserFromKeystoneViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.User
{
    public class PullUserFromKeystoneViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("User Name")]
        [StringLength(Person.FieldLengths.LoginName)]
        public String LoginName { get; set; }


        // Needed by model binder
        public PullUserFromKeystoneViewModel()
        {
        }


        public void UpdateModel(Models.Tenant currentTenant)
        {
            try
            {
                HttpRequestStorage.DatabaseEntities.Database.ExecuteSqlCommand("execute dbo.PullPersonFromKeystone {0} {1} {2}", LoginName, currentTenant.TenantID, Models.Role.Unassigned.RoleID);            
            }
            catch (Exception)
            {
                
            }
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            return errors;
        }
    }
}

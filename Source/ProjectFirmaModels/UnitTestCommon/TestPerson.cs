﻿/*-----------------------------------------------------------------------
<copyright file="TestPerson.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerson
        {
            public static Person Create()
            {
                var organization = TestOrganization.Create();
                var person = Person.CreateNewBlank(Role.Normal, organization);
                person.TenantID = Tenant.SitkaTechnologyGroup.TenantID;
                person.Organization = organization;
                person.Email = MakeTestEmail("email");
                person.FirstName = MakeTestName("firstName", Person.FieldLengths.FirstName);
                person.LastName = MakeTestName("lastName", Person.FieldLengths.LastName);
                person.PasswordPdfK2SaltHash = null;

                return person;
            }

            public static Person Create(Tenant tenant)
            {
                var person = Create();
                person.TenantID = tenant.TenantID;
                return person;
            }
        }




    }
}

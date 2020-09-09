/*-----------------------------------------------------------------------
<copyright file="TestOrganization.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestOrganization
        {
            public static Organization Create()
            {
                var organizationType = TestFramework.TestOrganizationType.Create();
                var organization = Organization.CreateNewBlank(organizationType);
                return organization;
            }

            public static Organization Create(string organizationName)
            {
                var organizationType = TestFramework.TestOrganizationType.Create();
                var organization = new Organization(organizationName, true, organizationType, Organization.UseOrganizationBoundaryForMatchmakerDefault);
                return organization;
            }

            public static Organization Create(DatabaseEntities dbContext)
            {
                var testOrganizationName = MakeTestName("Org Name");
                const int maxLengthOfOrganizationShortName = Organization.FieldLengths.OrganizationShortName - 1;
                var testOrganizationShortName = MakeTestName(testOrganizationName, maxLengthOfOrganizationShortName);

                var organizationType = TestFramework.TestOrganizationType.Create();
                var testOrganization = new Organization(testOrganizationName, true, organizationType, Organization.UseOrganizationBoundaryForMatchmakerDefault);
                testOrganization.OrganizationShortName = testOrganizationShortName;

                dbContext.AllOrganizations.Add(testOrganization);
                return testOrganization;
            }
        }
    }
}

using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestOrganization
        {
            public static Organization Create()
            {
                var organization = Organization.CreateNewBlank(Sector.Local);
                return organization;
            }

            public static Organization Create(string organizationName)
            {
                var organization = new Organization(organizationName, Sector.Private, true);
                return organization;
            }

            public static Organization Create(DatabaseEntities dbContext)
            {
                string testOrganizationName = MakeTestName("Org Name");
                const int maxLengthOfOrganizationAbbreviation = Organization.FieldLengths.OrganizationAbbreviation - 1;
                string testOrganizationAbbreviation = TestFramework.MakeTestName(testOrganizationName, maxLengthOfOrganizationAbbreviation);
                Sector testSector = Sector.Federal;
                // Since a person contains an Org, we get into a chicken & egg recursion issue. So we put in a stubby Person to start with
                //Person testPersonPrimaryContact = TestPerson.Create();

                var testOrganization = new Organization(testOrganizationName, testSector, true);
                testOrganization.OrganizationAbbreviation = testOrganizationAbbreviation;
                //testOrganization.PrimaryContactPerson = testPersonPrimaryContact;

                // Now we sew up the Person with our org
                //testPersonPrimaryContact.Organization = testOrganization;
                //HttpRequestStorage.DatabaseEntities.People.Add(testPersonPrimaryContact);

                dbContext.Organizations.Add(testOrganization);
                return testOrganization;
            }

            public static Organization Insert(DatabaseEntities dbContext)
            {
                var organization = Create(dbContext);
                HttpRequestStorage.DatabaseEntities.ChangeTracker.DetectChanges();
                HttpRequestStorage.DatabaseEntities.SaveChanges();
                return organization;
            }
        }
    }
}
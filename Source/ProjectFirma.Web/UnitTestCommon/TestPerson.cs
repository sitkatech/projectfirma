using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerson
        {
            public static Person Create()
            {
                var organization = TestOrganization.Create();
                var testLeadAgency = LeadAgency.CreateNewBlank(organization);
                var person = Person.CreateNewBlank(EIPRole.Normal, organization, SustainabilityRole.Normal, LTInfoRole.Normal, ParcelTrackerRole.Normal, ThresholdRole.Normal);
                person.Organization = organization;
                person.Email = MakeTestEmail("email");
                person.FirstName = MakeTestName("firstName", Person.FieldLengths.FirstName);
                person.LastName = MakeTestName("lastName", Person.FieldLengths.LastName);
                person.PasswordPdfK2SaltHash = person.PasswordPdfK2SaltHash = LtInfo.Common.PasswordHash.CreateHash(LoginConstants.Password);

                return person;
            }

            public static Person Create(ParcelTrackerRole role)
            {
                var leadAgency = TestLeadAgency.Create();
                return Create(leadAgency, role);
            }

            public static Person Create(LeadAgency leadAgency, ParcelTrackerRole parcelTrackerRole)
            {
                var organization = TestOrganization.Create();

                var person = new Person(Guid.NewGuid(),
                    MakeTestName("firstName", 100),
                    MakeTestName("lastName", 100),
                    MakeTestName("email"),
                    EIPRole.Normal,
                    DateTime.Now,
                    true,
                    organization,
                    SustainabilityRole.Normal,
                    LTInfoRole.Normal,
                    parcelTrackerRole,
                    ThresholdRole.Normal);
                person.Organization = leadAgency.Organization;
                return HttpRequestStorage.DatabaseEntities.People.Add(person);
            }
        }
    }
}
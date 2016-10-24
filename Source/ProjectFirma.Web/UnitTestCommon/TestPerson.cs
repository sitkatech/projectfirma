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
                var person = Person.CreateNewBlank(EIPRole.Normal, organization, SustainabilityRole.Normal, LTInfoRole.Normal, ThresholdRole.Normal);
                person.Organization = organization;
                person.Email = MakeTestEmail("email");
                person.FirstName = MakeTestName("firstName", Person.FieldLengths.FirstName);
                person.LastName = MakeTestName("lastName", Person.FieldLengths.LastName);
                person.PasswordPdfK2SaltHash = person.PasswordPdfK2SaltHash = LtInfo.Common.PasswordHash.CreateHash(LoginConstants.Password);

                return person;
            }
        }
    }
}
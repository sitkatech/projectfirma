using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static class TestFirmaSession
    {
        public static FirmaSession Create()
        {
            var tenant = TestFramework.TestTenant.Get();
            var person = TestFramework.TestPerson.Create(tenant);

            var firmaSession = new FirmaSession(person);
            return firmaSession;
        }

        public static FirmaSession Create(Person person)
        {
            var firmaSession = new FirmaSession(person);
            return firmaSession;
        }
    }
}
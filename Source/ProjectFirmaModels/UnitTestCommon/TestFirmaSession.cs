using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestFirmaSession
        {
            public static FirmaSession Create()
            {
                var tenant = TestTenant.Get();
                var person = TestPerson.Create(tenant);

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
}




//namespace ProjectFirmaModels.UnitTestCommon
//{
//    public static partial class TestFramework
//    {
//        public static class TestProject
//        {
//            public static Project Create()
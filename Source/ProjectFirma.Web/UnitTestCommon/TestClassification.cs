using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestClassification
        {
            public static Classification Create()
            {
                var classification = Classification.CreateNewBlank();
                classification.ClassificationName = MakeTestName("TestClassificationName", Classification.FieldLengths.ClassificationName);
                classification.ClassificationDescription = MakeTestName("New ClassificationDescription");
                classification.ThemeColor = "blue";
                classification.DisplayName = "Test Classification Display Name";
                return classification;
            }

            public static Classification Create(DatabaseEntities dbContext)
            {
                var classification = Create();
                dbContext.AllClassifications.Add(classification);
                return classification;
            }
        }
    }
}
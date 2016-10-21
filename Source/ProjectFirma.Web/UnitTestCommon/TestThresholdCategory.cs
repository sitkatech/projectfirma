using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestThresholdCategory
        {
            public static ThresholdCategory Create()
            {
                var thresholdCategory = ThresholdCategory.CreateNewBlank();
                thresholdCategory.ThresholdCategoryName = MakeTestName("TestThresholdCategoryName", ThresholdCategory.FieldLengths.ThresholdCategoryName);
                thresholdCategory.ThresholdCategoryDescription = MakeTestName("New ThresholdCategoryDescription");
                thresholdCategory.ThemeColor = "blue";
                thresholdCategory.DisplayName = "Test Threshold Category Display Name";
                return thresholdCategory;
            }

            public static ThresholdCategory Create(DatabaseEntities dbContext)
            {
                var thresholdCategory = Create();
                dbContext.ThresholdCategories.Add(thresholdCategory);
                return thresholdCategory;
            }
        }
    }
}
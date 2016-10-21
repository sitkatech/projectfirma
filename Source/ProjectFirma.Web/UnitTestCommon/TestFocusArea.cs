using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestFocusArea
        {
            public static FocusArea Create()
            {
                var focusArea = FocusArea.CreateNewBlank();
                return focusArea;
            }

            /// <summary>
            /// Create new FocusArea and attach it to the given context
            /// </summary>
            public static FocusArea Create(DatabaseEntities dbContext)
            {
                var nextFocusAreaNumber = FocusArea.GetNextFocusAreaNumber(dbContext.FocusAreas);
                var focusArea = new FocusArea(nextFocusAreaNumber, MakeTestName("Focus Area", FocusArea.FieldLengths.FocusAreaName));
                dbContext.FocusAreas.Add(focusArea);
                return focusArea;
            }
        }
    }
}
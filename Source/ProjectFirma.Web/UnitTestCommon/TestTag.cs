using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTag
        {
            public static Tag Create()
            {
                var tag = Tag.CreateNewBlank();
                tag.TagName = MakeTestTagName();
                return tag;
            }

            public static Tag Create(DatabaseEntities dbContext)
            {
                var tag = Create();
                dbContext.AllTags.Add(tag);
                return tag;
            }

            private static string MakeTestTagName()
            {
                return TestFramework.MakeTestName("Test Tag Name", Tag.FieldLengths.TagName);
            }
        }
    }
}
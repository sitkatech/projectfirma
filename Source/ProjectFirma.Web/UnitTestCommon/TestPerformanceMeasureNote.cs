using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureNote
        {
            public static PerformanceMeasureNote Create()
            {
                var performanceMeasure = TestPerformanceMeasure.Create();
                var performanceMeasureNote = PerformanceMeasureNote.CreateNewBlank(performanceMeasure);
                performanceMeasureNote.Note = MakeTestName("TestPerformanceMeasureNote", PerformanceMeasureNote.FieldLengths.Note);
                performanceMeasureNote.CreateDate = DateTime.Now;
                return performanceMeasureNote;
            }
        }
    }
}
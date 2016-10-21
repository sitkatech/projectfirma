using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestIndicatorNote
        {
            public static IndicatorNote Create()
            {
                var indicator = TestIndicator.Create();
                var indicatorNote = IndicatorNote.CreateNewBlank(indicator);
                indicatorNote.Note = MakeTestName("TestIndicatorNote", IndicatorNote.FieldLengths.Note);
                indicatorNote.CreateDate = DateTime.Now;
                return indicatorNote;
            }
        }
    }
}
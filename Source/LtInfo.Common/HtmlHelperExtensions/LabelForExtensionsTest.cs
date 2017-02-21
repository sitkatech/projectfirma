using System.Web;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace LtInfo.Common.HtmlHelperExtensions
{
    [TestFixture]
    public class LabelWithSugarForExtensionsTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithSugarForNotYetDefinedFieldDefinitionTest()
        {
            var result = LabelWithSugarForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                null,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithSugarForDefinedFieldDefinitionTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelWithSugarForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithSugarForDefinedFieldDefinitionForGridHeaderTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelWithSugarForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelWithSugarForExtensions.DisplayStyle.AsGridHeader, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithSugarForDefinedFieldDefinitionForHelpIconOnlyTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelWithSugarForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelWithSugarForExtensions.DisplayStyle.HelpIconOnly, false);
            Approvals.Verify(result);
        }
    }

    public class TestFieldDefinitionData : IFieldDefinitionData
    {
        public HtmlString FieldDefinitionDataValueHtmlString { get; private set; }

        public TestFieldDefinitionData(int id, string definition)
        {
            FieldDefinitionDataValueHtmlString = new HtmlString(definition);   
        }
    }
}
using System.Web;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace LtInfo.Common.HtmlHelperExtensions
{
    [TestFixture]
    public class LabelForExtensionsTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithFieldDefinitionForNotYetDefinedFieldDefinitionTest()
        {
            var result = LabelForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                null,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelForExtensions.DisplayStyle.HelpIconWithLabel, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithFieldDefinitionForDefinedFieldDefinitionTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelForExtensions.DisplayStyle.HelpIconWithLabel, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithFieldDefinitionForDefinedFieldDefinitionForGridHeaderTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelForExtensions.DisplayStyle.AsGridHeader, false);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateLabelWithFieldDefinitionForDefinedFieldDefinitionForHelpIconOnlyTest()
        {
            var fieldDefinitionData = new TestFieldDefinitionData(-1, "My field's definition");
            var result = LabelForExtensions.LabelWithFieldDefinitionForImpl("My Field",
                "myField",
                fieldDefinitionData,
                "/FieldDefinition/FieldDefinitionDetails/1",
                300,
                LabelForExtensions.DisplayStyle.HelpIconOnly, false);
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
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureExpectedSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSimple(int eipPerformanceMeasureExpectedID, int projectID, int eipPerformanceMeasureID, double? expectedValue)
            : this()
        {
            EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpectedID;
            ProjectID = projectID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureExpectedSimple(EIPPerformanceMeasureExpected eipPerformanceMeasureExpected)
            : this()
        {
            EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpected.EIPPerformanceMeasureExpectedID;
            ProjectID = eipPerformanceMeasureExpected.ProjectID;
            EIPPerformanceMeasureID = eipPerformanceMeasureExpected.EIPPerformanceMeasureID;
            ExpectedValue = eipPerformanceMeasureExpected.ExpectedValue;
            EIPPerformanceMeasureExpectedSubcategoryOptions = EIPPerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(eipPerformanceMeasureExpected);
        }

        public EIPPerformanceMeasureExpectedSimple(EIPPerformanceMeasureExpectedProposed eipPerformanceMeasureExpectedProposed)
        {
            EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpectedProposed.EIPPerformanceMeasureExpectedProposedID;
            ProjectID = eipPerformanceMeasureExpectedProposed.ProposedProjectID;
            EIPPerformanceMeasureID = eipPerformanceMeasureExpectedProposed.EIPPerformanceMeasureID;
            ExpectedValue = eipPerformanceMeasureExpectedProposed.ExpectedValue;
            EIPPerformanceMeasureExpectedSubcategoryOptions = EIPPerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(eipPerformanceMeasureExpectedProposed);
        }

        public int EIPPerformanceMeasureExpectedID { get; set; }
        public int ProjectID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }        
        public List<EIPPerformanceMeasureExpectedSubcategoryOptionSimple> EIPPerformanceMeasureExpectedSubcategoryOptions { get; set; }
    }
}
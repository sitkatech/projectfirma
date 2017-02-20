using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureExpectedSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureExpectedSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSimple(int performanceMeasureExpectedID, string displayName, int projectID, int performanceMeasureID, double? expectedValue)
            : this()
        {
            PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            DisplayName = displayName;
            ProjectID = projectID;
            PerformanceMeasureID = performanceMeasureID;
            ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureExpectedSimple(PerformanceMeasureExpected performanceMeasureExpected)
            : this()
        {
            PerformanceMeasureExpectedID = performanceMeasureExpected.PerformanceMeasureExpectedID;
            DisplayName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;
            ProjectID = performanceMeasureExpected.ProjectID;
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            ExpectedValue = performanceMeasureExpected.ExpectedValue;
            PerformanceMeasureExpectedSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureExpected);
        }

        public PerformanceMeasureExpectedSimple(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
        {
            PerformanceMeasureExpectedID = performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID;
            DisplayName = performanceMeasureExpectedProposed.PerformanceMeasure.PerformanceMeasureDisplayName;
            ProjectID = performanceMeasureExpectedProposed.ProposedProjectID;
            PerformanceMeasureID = performanceMeasureExpectedProposed.PerformanceMeasureID;
            ExpectedValue = performanceMeasureExpectedProposed.ExpectedValue;
            PerformanceMeasureExpectedSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureExpectedProposed);
        }

        public int PerformanceMeasureExpectedID { get; set; }
        public string DisplayName { get; set; }
        public int ProjectID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }        
        public List<PerformanceMeasureExpectedSubcategoryOptionSimple> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
    }
}
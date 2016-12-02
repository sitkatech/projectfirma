using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureValueSubcategoryOption
    {
        public readonly int PrimaryKey;
        public readonly PerformanceMeasure PerformanceMeasure;
        public readonly PerformanceMeasureSubcategory PerformanceMeasureSubcategory;
        public int PerformanceMeasureSubcategoryOptionID { get; set; }

        public PerformanceMeasureValueSubcategoryOption(int primaryKey, int performanceMeasureSubcategoryOptionID, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            PrimaryKey = primaryKey;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasure = performanceMeasure;
            PerformanceMeasureSubcategory = performanceMeasureSubcategory;
        }

        public int PerformanceMeasureID
        {
            get { return PerformanceMeasure.PerformanceMeasureID; }
        }

        public int PerformanceMeasureSubcategoryID
        {
            get { return PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID; }
        }

        private static IEnumerable<PerformanceMeasureValueSubcategoryOption> GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(IPerformanceMeasureValue performanceMeasureValue)
        {
            var performanceMeasure = performanceMeasureValue.PerformanceMeasure;
            var selectedPerformanceMeasureValueSubcategoryOptions = performanceMeasureValue.PerformanceMeasureSubcategoryOptions;
            // we need to get all possible subcategories for this performance measure and default it with empty values
            // we do this to prime the angular editor to have these performanceMeasureSubcategory dropdowns there, even if they didn't choose an option for that performanceMeasureSubcategory
            // since this part is optional when creating an expected value record
            var allPossiblePerformanceMeasureActualUpdateSubcategoryOptions =
                performanceMeasure.PerformanceMeasureSubcategories.Select(
                    x => new PerformanceMeasureValueSubcategoryOption(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, x.PerformanceMeasure, x)).ToList();

            var subcategoryOptionUpdateSimplesSelected =
                selectedPerformanceMeasureValueSubcategoryOptions.Select(
                    x =>
                        new PerformanceMeasureValueSubcategoryOption(x.PrimaryKey,
                            x.PerformanceMeasureSubcategoryOption == null ? ModelObjectHelpers.NotYetAssignedID : x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                            x.PerformanceMeasure,
                            x.PerformanceMeasureSubcategory)).ToList();
            allPossiblePerformanceMeasureActualUpdateSubcategoryOptions.MergeUpdate(subcategoryOptionUpdateSimplesSelected,
                (x, y) => x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID);
            return allPossiblePerformanceMeasureActualUpdateSubcategoryOptions;
        }

        public static List<PerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpectedProposed);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureExpectedSubcategoryOptionSimple(x, performanceMeasureExpectedProposed)).ToList();
        }

        public static List<PerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureExpected performanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureExpectedSubcategoryOptionSimple(x, performanceMeasureExpected)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureActual performanceMeasureActual)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureActual);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionSimple(x, performanceMeasureActual)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionUpdateSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureActualUpdate);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionUpdateSimple(x, performanceMeasureActualUpdate)).ToList();
        }
    }
}
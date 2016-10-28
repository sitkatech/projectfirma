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
        public readonly IndicatorSubcategory IndicatorSubcategory;
        public int IndicatorSubcategoryOptionID { get; set; }

        public PerformanceMeasureValueSubcategoryOption(int primaryKey, int indicatorSubcategoryOptionID, PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            PrimaryKey = primaryKey;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            PerformanceMeasure = performanceMeasure;
            IndicatorSubcategory = indicatorSubcategory;
        }

        public int PerformanceMeasureID
        {
            get { return PerformanceMeasure.PerformanceMeasureID; }
        }

        public int IndicatorSubcategoryID
        {
            get { return IndicatorSubcategory.IndicatorSubcategoryID; }
        }

        private static IEnumerable<PerformanceMeasureValueSubcategoryOption> GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(IPerformanceMeasureValue performanceMeasureValue)
        {
            var performanceMeasure = performanceMeasureValue.PerformanceMeasure;
            var selectedPerformanceMeasureValueSubcategoryOptions = performanceMeasureValue.IndicatorSubcategoryOptions;
            // we need to get all possible subcategories for this performance measure and default it with empty values
            // we do this to prime the angular editor to have these indicatorSubcategory dropdowns there, even if they didn't choose an option for that indicatorSubcategory
            // since this part is optional when creating an expected value record
            var allPossiblePerformanceMeasureActualUpdateSubcategoryOptions =
                performanceMeasure.IndicatorSubcategories.Select(
                    x => new PerformanceMeasureValueSubcategoryOption(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, x.PerformanceMeasure, x)).ToList();

            var subcategoryOptionUpdateSimplesSelected =
                selectedPerformanceMeasureValueSubcategoryOptions.Select(
                    x =>
                        new PerformanceMeasureValueSubcategoryOption(x.PrimaryKey,
                            x.IndicatorSubcategoryOption == null ? ModelObjectHelpers.NotYetAssignedID : x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionID,
                            x.PerformanceMeasure,
                            x.IndicatorSubcategory)).ToList();
            allPossiblePerformanceMeasureActualUpdateSubcategoryOptions.MergeUpdate(subcategoryOptionUpdateSimplesSelected,
                (x, y) => x.IndicatorSubcategoryID == y.IndicatorSubcategoryID,
                (x, y) => x.IndicatorSubcategoryOptionID = y.IndicatorSubcategoryOptionID);
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
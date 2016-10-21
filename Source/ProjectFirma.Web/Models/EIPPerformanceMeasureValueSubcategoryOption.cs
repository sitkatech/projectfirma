using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureValueSubcategoryOption
    {
        public readonly int PrimaryKey;
        public readonly EIPPerformanceMeasure EIPPerformanceMeasure;
        public readonly IndicatorSubcategory IndicatorSubcategory;
        public int IndicatorSubcategoryOptionID { get; set; }

        public EIPPerformanceMeasureValueSubcategoryOption(int primaryKey, int indicatorSubcategoryOptionID, EIPPerformanceMeasure eipPerformanceMeasure, IndicatorSubcategory indicatorSubcategory)
        {
            PrimaryKey = primaryKey;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            EIPPerformanceMeasure = eipPerformanceMeasure;
            IndicatorSubcategory = indicatorSubcategory;
        }

        public int EIPPerformanceMeasureID
        {
            get { return EIPPerformanceMeasure.EIPPerformanceMeasureID; }
        }

        public int IndicatorSubcategoryID
        {
            get { return IndicatorSubcategory.IndicatorSubcategoryID; }
        }

        private static IEnumerable<EIPPerformanceMeasureValueSubcategoryOption> GetAllPossibleSubcategoryOptionsForEIPPerformanceMeasureValue(IEIPPerformanceMeasureValue eipPerformanceMeasureValue)
        {
            var eipPerformanceMeasure = eipPerformanceMeasureValue.EIPPerformanceMeasure;
            var selectedEIPPerformanceMeasureValueSubcategoryOptions = eipPerformanceMeasureValue.IndicatorSubcategoryOptions;
            // we need to get all possible subcategories for this performance measure and default it with empty values
            // we do this to prime the angular editor to have these indicatorSubcategory dropdowns there, even if they didn't choose an option for that indicatorSubcategory
            // since this part is optional when creating an expected value record
            var allPossibleEIPPerformanceMeasureActualUpdateSubcategoryOptions =
                eipPerformanceMeasure.IndicatorSubcategories.Select(
                    x => new EIPPerformanceMeasureValueSubcategoryOption(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, x.EIPPerformanceMeasure, x)).ToList();

            var subcategoryOptionUpdateSimplesSelected =
                selectedEIPPerformanceMeasureValueSubcategoryOptions.Select(
                    x =>
                        new EIPPerformanceMeasureValueSubcategoryOption(x.PrimaryKey,
                            x.IndicatorSubcategoryOption == null ? ModelObjectHelpers.NotYetAssignedID : x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionID,
                            x.EIPPerformanceMeasure,
                            x.IndicatorSubcategory)).ToList();
            allPossibleEIPPerformanceMeasureActualUpdateSubcategoryOptions.MergeUpdate(subcategoryOptionUpdateSimplesSelected,
                (x, y) => x.IndicatorSubcategoryID == y.IndicatorSubcategoryID,
                (x, y) => x.IndicatorSubcategoryOptionID = y.IndicatorSubcategoryOptionID);
            return allPossibleEIPPerformanceMeasureActualUpdateSubcategoryOptions;
        }

        public static List<EIPPerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(EIPPerformanceMeasureExpectedProposed eipPerformanceMeasureExpectedProposed)
        {
            var allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForEIPPerformanceMeasureValue(eipPerformanceMeasureExpectedProposed);
            return allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue.Select(x => new EIPPerformanceMeasureExpectedSubcategoryOptionSimple(x, eipPerformanceMeasureExpectedProposed)).ToList();
        }

        public static List<EIPPerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(EIPPerformanceMeasureExpected eipPerformanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForEIPPerformanceMeasureValue(eipPerformanceMeasureExpected);
            return allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue.Select(x => new EIPPerformanceMeasureExpectedSubcategoryOptionSimple(x, eipPerformanceMeasureExpected)).ToList();
        }

        public static List<EIPPerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(EIPPerformanceMeasureActual eipPerformanceMeasureActual)
        {
            var allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForEIPPerformanceMeasureValue(eipPerformanceMeasureActual);
            return allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue.Select(x => new EIPPerformanceMeasureActualSubcategoryOptionSimple(x, eipPerformanceMeasureActual)).ToList();
        }

        public static List<EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple> GetAllPossibleSubcategoryOptions(EIPPerformanceMeasureActualUpdate eipPerformanceMeasureActualUpdate)
        {
            var allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForEIPPerformanceMeasureValue(eipPerformanceMeasureActualUpdate);
            return allPossibleSubcategoryOptionsForEIPPerformanceMeasureValue.Select(x => new EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple(x, eipPerformanceMeasureActualUpdate)).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartDataSimple
    {
        public Dictionary<string, GoogleChartRowV> ColumnValues { get; set; }

        public static List<GoogleChartDataSimple> DeriveSimplesFromGoogleChartJson(GoogleChartJson googleChartJson)
        {
            var googleChartColumns = googleChartJson.GoogleChartDataTable.GoogleChartColumns;

            return googleChartJson.GoogleChartDataTable.GoogleChartRowCs.Select(googleChartRowC =>
                {
                    return new GoogleChartDataSimple
                    {
                        ColumnValues = googleChartColumns.Where(x => x.ColumnLabel != null)
                            .ToDictionary(x => x.ColumnLabel,
                                x =>
                                {
                                    var index = googleChartColumns.IndexOf(x);
                                    return index < googleChartRowC.GoogleChartRowVs.Count ? googleChartRowC.GoogleChartRowVs[index] : null;
                                })
                    };
                })
                .ToList();
        }
    }
}

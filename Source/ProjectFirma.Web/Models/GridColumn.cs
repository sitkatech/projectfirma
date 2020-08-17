using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class GridColumn
    {
        public GridColumn()
        {
        }

        public GridColumn(PersonSettingGridColumnSetting columnSetting)
        {
            ColumnName = columnSetting.PersonSettingGridColumn.ColumnName;
            FilterTextArray = columnSetting.PersonSettingGridColumnSettingFilters.Select(f => f.FilterText).ToArray();
        }

        public string ColumnName { get; set; }
        public string[] FilterTextArray { get; set; }
        public int? Width { get; set; }


        public bool? IsSorted { get; set; }
        public string SortType { get; set; }

    }
}
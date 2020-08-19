using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    ///     A json class used to communicate PersonSettingGridColumnSettings to sitka.grid.js.  Any renames of properties should also be done to GridTable.js
    /// </summary>
    public class GridTable
    {
        public GridTable()
        {
            Columns = new List<GridColumn>();
        }

        public GridTable(string gridName, IEnumerable<PersonSettingGridColumnSetting> columnSettings)
        {
            GridName = gridName;
            Columns = columnSettings.Select(c => new GridColumn(c)).ToList();

        }

        public string GridName { get; set; }
        public List<GridColumn> Columns { get; set; }
        public double? WidthX { get; set; }
        public double? HeightY { get; set; }
    }
}
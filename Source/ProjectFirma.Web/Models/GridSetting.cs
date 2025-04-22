using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    ///     A json class used to communicate PersonGridSettings. 
    /// </summary>
    public class GridSetting
    {
        public string GridName { get; set; }

        public string FilterState { get; set; }

        public string ColumnState { get; set; }


        public GridSetting()
        {
            
        }

        public GridSetting(string gridName, string filterState, string columnState)
        {
            GridName = gridName;
            FilterState = filterState;
            ColumnState = columnState;

        }

        public GridSetting(PersonGridSetting personGridSetting)
        {
            GridName = personGridSetting.GridName;
            FilterState = personGridSetting.FilterState;
            ColumnState = personGridSetting.ColumnState;

        }


    }
}
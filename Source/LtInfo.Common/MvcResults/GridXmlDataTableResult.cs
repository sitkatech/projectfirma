using System.Data;
using System.Web.Mvc;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace LtInfo.Common.MvcResults
{
    public class GridXmlDataTableResult : ActionResult
    {
        public GridXmlDataTableResult(DataTable dataTable, GridSpec<IStringIndexer> gridSpec)
        {
            DataTable = dataTable;
            GridSpec = gridSpec;
        }
    
        public DataTable DataTable;
        public GridSpec<IStringIndexer> GridSpec;
        
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AddHeader("Content-type", "text/xml; charset=utf-8");
            context.HttpContext.Response.Write(DataTable.DataTableToXmlRowCol(GridSpec));
        }
    }
}
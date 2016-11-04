using System.Collections.Generic;
using System.Web.Mvc;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace LtInfo.Common.MvcResults
{
    public class GridXmlResult<T> : ActionResult
    {
        private readonly string _xmlDataForallRows;

        private readonly GridSpec<T> _gridSpec;
        public GridSpec<T> GridSpec
        {
            get { return _gridSpec; }
        }

        private readonly List<T> _modelList;
        public List<T> ModelList
        {
            get { return _modelList; }
        }

        public GridXmlResult(List<T> modelList, GridSpec<T> gridSpec)
            : this(modelList, gridSpec, ModelListAbstract.UnlimitedRowLimit)
        { }

        public GridXmlResult(List<T> modelList, GridSpec<T> gridSpec, int rowLimit)
        {
            _gridSpec = gridSpec;
            _modelList = modelList;
            _xmlDataForallRows = ModelList.ToXmlRowCell(GridSpec, rowLimit);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AddHeader("Content-type", "text/xml; charset=utf-8");
            // TM 2011/06/17
            // SitkaGlobalBase sets the no-cache pragma as part of ApplicationBeginRequest, but when we clear all headers explicitly for grid results.
            // This seems like it could cause problems in general.  Specifically, this causes issues with grid xml results being cached on Google Chrome.
            context.HttpContext.Response.AppendHeader("Pragma", "no-cache");
            context.HttpContext.Response.Write(_xmlDataForallRows);
        }

        public string GetAsXMLString()
        {
            return _xmlDataForallRows;
        }
    }
}
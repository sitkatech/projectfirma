/*-----------------------------------------------------------------------
<copyright file="GridXmlResult.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

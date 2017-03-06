/*-----------------------------------------------------------------------
<copyright file="GridJsonNetJObjectResult.cs" company="Sitka Technology Group">
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
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using Newtonsoft.Json.Linq;

namespace LtInfo.Common.MvcResults
{
    public class GridJsonNetJObjectResult<T> : JsonResult
    {
        private readonly JObject _data;

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

        public GridJsonNetJObjectResult(List<T> modelList, GridSpec<T> gridSpec) : this(modelList, gridSpec, null)
        {
        }

        /// <summary>
        /// DHTMLx Grid expects a json format like this:
        /// {
        ///    rows:[
        ///        { id:1, data: ["A Time to Kill", "John Grisham", "100"]},
        ///        { id:2, data: ["Blood and Smoke", "Stephen King", "1000"]},
        ///        { id:3, data: ["The Rainmaker", "John Grisham", "-200"]}
        ///    ]
        /// }
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="gridSpec"></param>
        /// <param name="rowLimit"></param>
        public GridJsonNetJObjectResult(List<T> modelList, GridSpec<T> gridSpec, int? rowLimit)
        {
            _gridSpec = gridSpec;
            _modelList = modelList;
            var list = rowLimit.HasValue ? modelList.Take(rowLimit.Value) : modelList;
            _data = JObject.FromObject(new { rows = list.Select((t, i) => t.ToDhtmlxGridJsonRow(i + 1, _gridSpec)).ToList() });
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            // TM 2011/06/17
            // SitkaGlobalBase sets the no-cache pragma as part of ApplicationBeginRequest, but when we clear all headers explicitly for grid results.
            // This seems like it could cause problems in general.  Specifically, this causes issues with grid xml results being cached on Google Chrome.
            response.AppendHeader("Pragma", "no-cache");
            response.ContentType = "application/json";
            response.Write(_data.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}

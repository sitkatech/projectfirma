/*-----------------------------------------------------------------------
<copyright file="MyTest1Controller.cs" company="Sitka Technology Group">
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
using System;
using System.Web.Mvc;

namespace LtInfo.Common.RouteTableBuilderTestFolder.Controllers
{
    public class MyTest1Controller : MyAbstractBaseController
    {
        public ActionResult MyAction1(string p0, int p1, int p2, int p3, int p4, int p5)
        {
            return Content(String.Empty);
        }

        public ContentResult ActionWithNoParameters()
        {
            return Content(String.Empty);
        }

        public ContentResult ActionWithOneParameter(string s)
        {
            return Content(String.Empty);
        }
    }

}

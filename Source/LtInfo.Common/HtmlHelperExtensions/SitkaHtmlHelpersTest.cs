/*-----------------------------------------------------------------------
<copyright file="SitkaHtmlHelpersTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Web.Mvc;
using NUnit.Framework;
using LtInfo.Common.Web.Testing.Path1.Path2;

namespace LtInfo.Common.HtmlHelperExtensions
{
    [TestFixture]
    public class SitkaHtmlHelpersTest
    {
        [Test]
        public void CalculateViewName()
        {
            var viewType = typeof(UnitTestUserControl1);
            var viewPath = SitkaHtmlHelpers.CalculateWebPathFromViewType<UnitTestUserControl1>();
            Assert.That(viewPath, Is.EqualTo(string.Format("~/Testing/Path1/Path2/{0}.ascx", viewType.Name)));
        }
    }
}

namespace LtInfo.Common.Web.Testing.Path1.Path2
{
    public class UnitTestUserControl1 : ViewUserControl { }
}

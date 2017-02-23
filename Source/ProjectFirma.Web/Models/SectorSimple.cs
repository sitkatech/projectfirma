/*-----------------------------------------------------------------------
<copyright file="SectorSimple.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
namespace ProjectFirma.Web.Models
{
    public class SectorSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public SectorSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SectorSimple(int sectorID, string sectorName, string sectorDisplayName, string sectorAbbreviation, string legendColor)
            : this()
        {
            SectorID = sectorID;
            SectorName = sectorName;
            SectorDisplayName = sectorDisplayName;
            SectorAbbreviation = sectorAbbreviation;
            LegendColor = legendColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public SectorSimple(Sector sector)
            : this()
        {
            SectorID = sector.SectorID;
            SectorName = sector.SectorName;
            SectorDisplayName = sector.SectorDisplayName;
            SectorAbbreviation = sector.SectorAbbreviation;
            LegendColor = sector.LegendColor;
        }

        public int SectorID { get; set; }
        public string SectorName { get; set; }
        public string SectorDisplayName { get; set; }
        public string SectorAbbreviation { get; set; }
        public string LegendColor { get; set; }
    }
}

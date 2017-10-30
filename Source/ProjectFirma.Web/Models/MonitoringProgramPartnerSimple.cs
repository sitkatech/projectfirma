/*-----------------------------------------------------------------------
<copyright file="MonitoringProgramPartnerSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramPartnerSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public MonitoringProgramPartnerSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramPartnerSimple(int monitoringProgramPartnerID, int monitoringProgramID, int organizationID)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartnerID;
            MonitoringProgramID = monitoringProgramID;
            OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public MonitoringProgramPartnerSimple(MonitoringProgramPartner monitoringProgramPartner)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartner.MonitoringProgramPartnerID;
            MonitoringProgramID = monitoringProgramPartner.MonitoringProgramID;
            OrganizationID = monitoringProgramPartner.OrganizationID;
        }

        public int MonitoringProgramPartnerID { get; set; }
        public int MonitoringProgramID { get; set; }
        public int OrganizationID { get; set; }
    }
}

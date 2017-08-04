/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.ProposedProject
{    
    public class LocationSimpleViewModel : ProjectLocationSimpleViewModel
    {
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationSimpleViewModel()
        {
        }

        public LocationSimpleViewModel(Models.ProposedProject proposedProject) : base(proposedProject.ProjectLocationPoint, proposedProject.ProjectLocationAreaID, proposedProject.ProjectLocationSimpleType.ToEnum, proposedProject.ProjectLocationNotes)
        {
        }
        
        public void UpdateModel(Models.ProposedProject proposedProject)
        {
            base.UpdateModel(proposedProject);
        }
    }    
}

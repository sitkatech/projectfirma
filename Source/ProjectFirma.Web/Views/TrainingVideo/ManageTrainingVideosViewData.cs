/*-----------------------------------------------------------------------
<copyright file="ManageTrainingVideosViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TrainingVideo
{
    public class ManageTrainingVideosViewData : FirmaViewData
    {
        public ManageTrainingVideosGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewUrl { get; }
        public string EditSortOrderUrl { get; }


        public ManageTrainingVideosViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Manage Training Videos";

            GridSpec = new ManageTrainingVideosGridSpec
            {
                ObjectNameSingular = "Training Video",
                ObjectNamePlural = "Training Videos"
            };
            GridName = "trainingVideosGrid";
            GridDataUrl = SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(tc => tc.ManageTrainingVideosGridJsonData());
            NewUrl = SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(tc => tc.New());
            EditSortOrderUrl = SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
        }
    }
}

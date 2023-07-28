﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TrainingVideo
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        public int? TrainingVideoID { get; set; }

        [Required]
        [DisplayName("Video Title")]
        [StringLength(ProjectFirmaModels.Models.TrainingVideo.FieldLengths.VideoName)]
        public string VideoName { get; set; }

        [DisplayName("Video Description")]
        [StringLength(ProjectFirmaModels.Models.TrainingVideo.FieldLengths.VideoDescription)]
        public string VideoDescription { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TrainingVideoUploadDate)]
        public DateTime? VideoUploadDate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TrainingVideoUrl)]
        [StringLength(ProjectFirmaModels.Models.TrainingVideo.FieldLengths.VideoURL)]
        public string VideoURL { get; set; }

        [DisplayName("Anonymous (Public)")]
        public bool ViewableByAnonymous { get; set; }

        [DisplayName("Unassigned")]
        public bool ViewableByUnassigned { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool ViewableByNormal { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool ViewableByProjectSteward { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.TrainingVideo trainingVideo)
        {
            TrainingVideoID = trainingVideo.TrainingVideoID;
            VideoName = trainingVideo.VideoName;
            VideoDescription = trainingVideo.VideoDescription;
            VideoUploadDate = trainingVideo.VideoUploadDate == default(DateTime) ? (DateTime?)null : trainingVideo.VideoUploadDate;
            VideoURL = trainingVideo.VideoURL;

            ViewableByAnonymous = trainingVideo.TrainingVideoRoles.Any(x => x.RoleID == null);
            ViewableByUnassigned = trainingVideo.TrainingVideoRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Unassigned.RoleID);
            ViewableByNormal = trainingVideo.TrainingVideoRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            ViewableByProjectSteward = trainingVideo.TrainingVideoRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);

        }

        public void UpdateModel(ProjectFirmaModels.Models.TrainingVideo trainingVideo, ICollection<TrainingVideoRole> allTrainingVideoRoles)
        {
            trainingVideo.VideoName = VideoName;
            trainingVideo.VideoDescription = VideoDescription;
            trainingVideo.VideoUploadDate = VideoUploadDate.HasValue ? VideoUploadDate.Value : DateTime.Today;
            trainingVideo.VideoURL = VideoURL;

            var newTrainingVideoRoles = new List<TrainingVideoRole>();

            if (ViewableByAnonymous)
            {
                newTrainingVideoRoles.Add(new TrainingVideoRole(trainingVideo.TrainingVideoID));
            }
            if (ViewableByUnassigned)
            {
                newTrainingVideoRoles.Add(new TrainingVideoRole(trainingVideo.TrainingVideoID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Unassigned.RoleID
                });
            }
            if (ViewableByNormal)
            {
                newTrainingVideoRoles.Add(new TrainingVideoRole(trainingVideo.TrainingVideoID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Normal.RoleID
                });
            }
            if (ViewableByProjectSteward)
            {
                newTrainingVideoRoles.Add(new TrainingVideoRole(trainingVideo.TrainingVideoID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.ProjectSteward.RoleID
                });
            }

            trainingVideo.TrainingVideoRoles.Merge(newTrainingVideoRoles,
                allTrainingVideoRoles,
                (x, y) => x.TrainingVideoID == y.TrainingVideoID && x.RoleID == y.RoleID,
                HttpRequestStorage.DatabaseEntities);
        }
    }
}

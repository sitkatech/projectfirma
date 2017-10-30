/*-----------------------------------------------------------------------
<copyright file="ProposedProjectImage.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectImage : IFileResourcePhoto, IAuditableEntity
    {
        public ProposedProjectImage(ProposedProject proposedProject)
            : this(ModelObjectHelpers.NotYetAssignedID, proposedProject.ProposedProjectID, ProjectImageTiming.Unknown.ProjectImageTimingID, string.Empty, string.Empty)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ProposedProject = proposedProject;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor           
        }

        public DateTime CreateDate => FileResource.CreateDate;

        public string DeleteUrl
        {
            get { return SitkaRoute<ProposedProjectImageController>.BuildUrlFromExpression(x => x.Delete(ProposedProjectImageID)); }
        }
        public bool IsKeyPhoto => false;

        public string CaptionOnFullView
        {
            get
            {
                var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : $"\r\nCredit: {Credit}";
                return $"{CaptionOnGallery}{creditString}";
            }
        }

        public string CaptionOnGallery => $"{Caption}\r\n{FileResource.FileResourceDataLengthString}";

        public string PhotoUrl => FileResource.FileResourceUrl;

        public string PhotoUrlScaledThumbnail => FileResource.FileResourceUrlScaledThumbnail;

        public string PhotoUrlScaledForPrint => FileResource.FileResourceUrlScaledForPrint;

        public string EditUrl
        {
            get { return SitkaRoute<ProposedProjectImageController>.BuildUrlFromExpression(x => x.Edit(ProposedProjectImageID)); }
        }

        private List<string> _additionalCssClasses = new List<string>();
        public List<string> AdditionalCssClasses
        {
            get => _additionalCssClasses;
            set => _additionalCssClasses = value;
        }

        private object _orderBy;
        public object OrderBy
        {
            get => _orderBy ?? CaptionOnFullView;
            set => _orderBy = value;
        }       

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string AuditDescriptionString
        {
            get
            {
                var proposedProject = HttpRequestStorage.DatabaseEntities.AllProposedProjects.Find(ProposedProjectID);
                var proposedProjectName = proposedProject != null ? proposedProject.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"{FieldDefinition.Project.GetFieldDefinitionLabel()}: {proposedProjectName}, Image: {Caption}";
            }
        }

        public int? EntityImageIDAsNullable => ProposedProjectImageID;
    }
}

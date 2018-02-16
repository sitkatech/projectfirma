/*-----------------------------------------------------------------------
<copyright file="ProjectClassificationSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProjectClassificationSimple
    {
        public int ProjectClassificationID { get; set; }
        public int ProjectID { get; set; }
        public int ClassificationID { get; set; }
        public int ClassificationSystemID { get; set; }
        public string ProjectClassificationNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProjectClassification.FieldLengths.ProjectClassificationNotes)]
        public string ProjectClassificationNotesForBinding
        {
            get { return ProjectClassificationNotes; }
            set { ProjectClassificationNotes = value; }
        }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectClassificationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassificationSimple(int projectClassificationID, int projectID, int classificationSystemID, int classificationID, string projectClassificationNotes)
            : this()
        {
            ProjectClassificationID = projectClassificationID;
            ProjectID = projectID;
            ClassificationID = classificationID;
            ClassificationSystemID = classificationSystemID;
            ProjectClassificationNotes = projectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectClassificationSimple(ProjectClassification projectClassification)
            : this()
        {
            ProjectClassificationID = projectClassification.ProjectClassificationID;
            ProjectID = projectClassification.ProjectID;
            ClassificationID = projectClassification.ClassificationID;
            ClassificationSystemID = projectClassification.Classification.ClassificationSystemID;
        }

        /// <summary>
        /// Used for a posteriori validation.
        /// </summary>
        public ProjectClassificationSimple(int projectClassificationID, int projectID, int classificationSystemID, int classificationID, string projectClassificationNotes, bool selected)
            : this()
        {
            ProjectClassificationID = projectClassificationID;
            ProjectID = projectID;
            ClassificationID = classificationID;
            ClassificationSystemID = classificationSystemID;
            ProjectClassificationNotes = projectClassificationNotes;
            Selected = selected;
        }
    }
}

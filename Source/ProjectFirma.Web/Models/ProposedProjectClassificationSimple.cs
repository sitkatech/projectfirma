/*-----------------------------------------------------------------------
<copyright file="ProposedProjectClassificationSimple.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectClassificationSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectClassificationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectClassificationSimple(int proposedProjectClassificationID, int proposedProjectID, int classificationID, string proposedProjectClassificationNotes)
            : this()
        {
            ProposedProjectClassificationID = proposedProjectClassificationID;
            ProposedProjectID = proposedProjectID;
            ClassificationID = classificationID;
            ProposedProjectClassificationNotes = proposedProjectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProposedProjectClassificationSimple(ProposedProjectClassification proposedProjectClassification)
            : this()
        {
            ProposedProjectClassificationID = proposedProjectClassification.ProposedProjectClassificationID;
            ProposedProjectID = proposedProjectClassification.ProposedProjectID;
            ClassificationID = proposedProjectClassification.ClassificationID;
            ProposedProjectClassificationNotes = proposedProjectClassification.ProposedProjectClassificationNotes;
        }

        public ProposedProjectClassificationSimple(int classificationID)
        {
            ClassificationID = classificationID;
        }

        public int ProposedProjectClassificationID { get; set; }
        public int ProposedProjectID { get; set; }
        public int ClassificationID { get; set; }
        public string ProposedProjectClassificationNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProposedProjectClassification.FieldLengths.ProposedProjectClassificationNotes)]
        public string ProposedProjectClassificationNotesForBinding
        {
            get { return ProposedProjectClassificationNotes; }
            set { ProposedProjectClassificationNotes = value; }
        }
    }
}

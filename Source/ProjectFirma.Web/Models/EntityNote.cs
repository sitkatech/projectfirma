/*-----------------------------------------------------------------------
<copyright file="EntityNote.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EntityNote
    {
        private readonly string _deleteUrl;
        private readonly string _editUrl;
        private readonly string _lastUpdatedBy;
        private readonly DateTime _lastUpdated;

        public string Note { get; set; }
        public DateTime GetLastUpdated()
        {
            return _lastUpdated;
        }

        public string GetLastUpdatedBy()
        {
            return _lastUpdatedBy;
        }

        public string GetDeleteUrl()
        {
            return _deleteUrl;
        }

        public string GetEditUrl()
        {
            return _editUrl;
        }

        public string DisplayCssClass { get; set; }

        public EntityNote(DateTime lastUpdated, string lastUpdatedBy, string deleteUrl, string editUrl, string note, string displayCssClass)
        {
            _lastUpdated = lastUpdated;
            _lastUpdatedBy = lastUpdatedBy;
            _deleteUrl = deleteUrl;
            _editUrl = editUrl;
            Note = note;
            DisplayCssClass = displayCssClass;
        }

        public static List<EntityNote> CreateFromEntityNote(IEnumerable<ProjectNote> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, null)).ToList();
        }
        public static List<EntityNote> CreateFromEntityNote(IEnumerable<ProjectNoteUpdate> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, null)).ToList();
        }
        public static List<EntityNote> CreateFromEntityNote(IEnumerable<ProjectInternalNote> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, null)).ToList();
        }

        public static List<EntityNote> CreateFromEntityNote(IEnumerable<PerformanceMeasureNote> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, null)).ToList();
        }
        public static List<EntityNote> CreateFromEntityNote(IEnumerable<ReleaseNote> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, null)).ToList();
        }
    }
}

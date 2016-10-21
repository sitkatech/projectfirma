using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectNoteUpdate : IEntityNote
    {
        public DateTime LastUpdated
        {
            get { return UpdateDate ?? CreateDate; }
        }

        public string LastUpdatedBy
        {
            get
            {
                if (UpdatePersonID.HasValue)
                {
                    return UpdatePerson.FullNameFirstLast;
                }
                if (CreatePersonID.HasValue)
                {
                    return CreatePerson.FullNameFirstLast;
                }
                return "System";
            }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Delete(ProjectNoteUpdateID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Edit(ProjectNoteUpdateID)); }
        }

        public string CreatePersonName
        {
            get { return CreatePersonID.HasValue ? CreatePerson.FullNameFirstLast : string.Empty; }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectNoteUpdates =
                project.ProjectNotes.Select(
                    pn => new ProjectNoteUpdate(projectUpdateBatch, pn.Note, pn.CreateDate) {CreatePerson = pn.CreatePerson, UpdateDate = pn.UpdateDate, UpdatePerson = pn.UpdatePerson}).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectNote> allProjectNotes)
        {
            var project = projectUpdateBatch.Project;
            var projectNotesFromProjectUpdate =
                projectUpdateBatch.ProjectNoteUpdates.Select(
                    x => new ProjectNote(project.ProjectID, x.Note, x.CreateDate) {CreatePersonID = x.CreatePersonID, UpdateDate = x.UpdateDate, UpdatePersonID = x.UpdatePersonID}).ToList();
            project.ProjectNotes.Merge(projectNotesFromProjectUpdate, allProjectNotes, (x, y) => x.ProjectID == y.ProjectID && x.Note == y.Note);
        }
    }
}
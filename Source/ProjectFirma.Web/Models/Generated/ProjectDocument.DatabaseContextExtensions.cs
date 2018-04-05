//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocument]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectDocument GetProjectDocument(this IQueryable<ProjectDocument> projectDocuments, int projectDocumentID)
        {
            var projectDocument = projectDocuments.SingleOrDefault(x => x.ProjectDocumentID == projectDocumentID);
            Check.RequireNotNullThrowNotFound(projectDocument, "ProjectDocument", projectDocumentID);
            return projectDocument;
        }

        public static void DeleteProjectDocument(this List<int> projectDocumentIDList)
        {
            if(projectDocumentIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectDocuments.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectDocuments.Where(x => projectDocumentIDList.Contains(x.ProjectDocumentID)));
            }
        }

        public static void DeleteProjectDocument(this ICollection<ProjectDocument> projectDocumentsToDelete)
        {
            if(projectDocumentsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectDocuments.RemoveRange(projectDocumentsToDelete);
            }
        }

        public static void DeleteProjectDocument(this int projectDocumentID)
        {
            DeleteProjectDocument(new List<int> { projectDocumentID });
        }

        public static void DeleteProjectDocument(this ProjectDocument projectDocumentToDelete)
        {
            DeleteProjectDocument(new List<ProjectDocument> { projectDocumentToDelete });
        }
    }
}
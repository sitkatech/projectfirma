//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocument]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectDocument GetProjectDocument(this IQueryable<ProjectDocument> projectDocuments, int projectDocumentID)
        {
            var projectDocument = projectDocuments.SingleOrDefault(x => x.ProjectDocumentID == projectDocumentID);
            Check.RequireNotNullThrowNotFound(projectDocument, "ProjectDocument", projectDocumentID);
            return projectDocument;
        }

    }
}
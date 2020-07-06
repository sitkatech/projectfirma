//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Project GetProject(this IQueryable<Project> projects, int projectID)
        {
            var project = projects.SingleOrDefault(x => x.ProjectID == projectID);
            Check.RequireNotNullThrowNotFound(project, "Project", projectID);
            return project;
        }

    }
}
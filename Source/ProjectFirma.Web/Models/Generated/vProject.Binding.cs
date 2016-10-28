//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProject]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class vProject
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProject()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProject(string projectNumberFull, int projectID, int actionPriorityID, short projectNumber, string projectName, string projectDescription, int projectStageID, string projectStageDisplayName, int? implementationStartYear, int? completionYear, bool implementsMultipleProjects) : this()
        {
            this.ProjectNumberFull = projectNumberFull;
            this.ProjectID = projectID;
            this.ActionPriorityID = actionPriorityID;
            this.ProjectNumber = projectNumber;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
            this.ProjectStageID = projectStageID;
            this.ProjectStageDisplayName = projectStageDisplayName;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.ImplementsMultipleProjects = implementsMultipleProjects;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProject(vProject vProject) : this()
        {
            this.ProjectNumberFull = vProject.ProjectNumberFull;
            this.ProjectID = vProject.ProjectID;
            this.ActionPriorityID = vProject.ActionPriorityID;
            this.ProjectNumber = vProject.ProjectNumber;
            this.ProjectName = vProject.ProjectName;
            this.ProjectDescription = vProject.ProjectDescription;
            this.ProjectStageID = vProject.ProjectStageID;
            this.ProjectStageDisplayName = vProject.ProjectStageDisplayName;
            this.ImplementationStartYear = vProject.ImplementationStartYear;
            this.CompletionYear = vProject.CompletionYear;
            this.ImplementsMultipleProjects = vProject.ImplementsMultipleProjects;
            CallAfterConstructor(vProject);
        }

        partial void CallAfterConstructor(vProject vProject);

        public string ProjectNumberFull { get; set; }
        public int ProjectID { get; set; }
        public int ActionPriorityID { get; set; }
        public short ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectStageDisplayName { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public bool ImplementsMultipleProjects { get; set; }
    }
}
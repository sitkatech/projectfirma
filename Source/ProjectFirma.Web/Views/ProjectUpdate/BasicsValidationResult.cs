using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsValidationResult
    {
        public const string ImplementationStartYearIsRequired = "Implementation Start Year is a required field.";
        public const string PlanningDesignStartYearIsRequired = "Planning / Design Start Year is a required field.";
        public const string CompletionYearIsRequired = "For projects in the Completed or Post-Implementation stage, Completion Year is a required field.";
        public const string ProjectDescriptionIsRequired = "Project Description is required.";
        public const string CompletionYearShouldBeLessThanCurrentYear = "Since project is in Completed or Post-Implementation stage, the Completion Year needs to be less than or equal to this year";
        public const string PlanningDesignStartYearShouldBeLessThanCurrentYear = "Since project is in the Planning / Design stage, the Planning / Design Start Year needs to be less than or equal to this year";
        public const string ImplementationStartYearShouldBeLessThanCurrentYear = "Since project is in Implementation stage, the Implementation Year needs to be less than or equal to this year";

        private readonly List<string> _warningMessages;

        public BasicsValidationResult(Models.ProjectUpdate projectUpdate)
        {
            _warningMessages = new List<string>();

            if (projectUpdate.PlanningDesignStartYear == null)
            {
                _warningMessages.Add(PlanningDesignStartYearIsRequired);
            }
            if (projectUpdate.ImplementationStartYear == null && projectUpdate.ProjectStage != ProjectStage.Terminated && projectUpdate.ProjectStage != ProjectStage.Deferred )
            {
                _warningMessages.Add(ImplementationStartYearIsRequired);
            }
                        
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.CompletionYear == null)
            {
                _warningMessages.Add(CompletionYearIsRequired);
            }

            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(projectUpdate.ProjectDescription))
            {
                _warningMessages.Add(ProjectDescriptionIsRequired);
            }
            
            var currentYear = DateTime.Now.Year;
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.CompletionYear > currentYear)
            {
                _warningMessages.Add(CompletionYearShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.PlanningDesign && projectUpdate.PlanningDesignStartYear > currentYear)
            {
                _warningMessages.Add(PlanningDesignStartYearShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.Implementation && projectUpdate.ImplementationStartYear > currentYear)
            {
                _warningMessages.Add(ImplementationStartYearShouldBeLessThanCurrentYear);
            }

            if (projectUpdate.ImplementationStartYear < projectUpdate.PlanningDesignStartYear)
            {
                _warningMessages.Add(ProjectFirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear);
            }
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear)
            {
                _warningMessages.Add(ProjectFirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear);
            }
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear)
            {
                _warningMessages.Add(ProjectFirmaValidationMessages.CompletionYearGreaterThanEqualToPlanningDesignStartYear);
            }
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid
        {
            get { return !_warningMessages.Any(); }
        }
    }
}
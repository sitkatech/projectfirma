using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class EIPPerformanceMeasureType
    {
        public abstract bool ValuesAreNotCalculated(bool implementsMultipleProjects);

        public virtual List<EIPPerformanceMeasureReportedValue> CalculateEIPPerformanceMeasureReportedValues(EIPPerformanceMeasure eipPerformanceMeasure, int? projectID)
        {
            var eipPerformanceMeasureActuals =
                HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActuals.Where(
                    pmav => pmav.EIPPerformanceMeasureID == eipPerformanceMeasure.EIPPerformanceMeasureID && (!projectID.HasValue || (projectID.HasValue && pmav.ProjectID == projectID))).ToList();
            var eipPerformanceMeasureReportedValues = EIPPerformanceMeasureReportedValue.MakeFromList(eipPerformanceMeasureActuals);
            return eipPerformanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }

        public virtual string GetYAxisFormat()
        {
            return null;
        }

        public abstract Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure);

        public abstract bool CanAssociatePrograms();

        protected static Dictionary<Program, bool> GetProgramsFromProgramEIPPerformanceMeasurePrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return eipPerformanceMeasure.ProgramEIPPerformanceMeasures.Any()
                ? eipPerformanceMeasure.ProgramEIPPerformanceMeasures.ToDictionary(x => x.Program, x => x.IsPrimaryProgram, new HavePrimaryKeyComparer<Program>())
                : new Dictionary<Program, bool>();
        }

        protected static Dictionary<Program, bool> GetAllProgramsAsNotPrimary()
        {
            return HttpRequestStorage.DatabaseEntities.Programs.ToList().ToDictionary(x => x, x => false, new HavePrimaryKeyComparer<Program>());
        }

        public abstract bool ForProjectsImplementsMultiplePrograms();
    }

    public partial class EIPPerformanceMeasureTypeNormal
    {
        public override bool ValuesAreNotCalculated(bool implementsMultipleProjects)
        {
            return true;
        }

        public override Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return GetProgramsFromProgramEIPPerformanceMeasurePrograms(eipPerformanceMeasure);
        }

        public override bool CanAssociatePrograms()
        {
            return true;
        }

        public override bool ForProjectsImplementsMultiplePrograms()
        {
            return false;
        }
    }

    public partial class EIPPerformanceMeasureTypeTMDLRelevant
    {
        public override bool ValuesAreNotCalculated(bool implementsMultipleProjects)
        {
            return true;
        }

        public override Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return new Dictionary<Program, bool>();
        }

        public override bool CanAssociatePrograms()
        {
            return false;
        }

        public override bool ForProjectsImplementsMultiplePrograms()
        {
            return false;
        }
    }

    public partial class EIPPerformanceMeasureTypeEIPPerformanceMeasure33
    {
        public override bool ValuesAreNotCalculated(bool implementsMultipleProjects)
        {
            return false;
        }

        public override Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return GetAllProgramsAsNotPrimary();
        }

        public override bool CanAssociatePrograms()
        {
            return false;
        }

        public override List<EIPPerformanceMeasureReportedValue> CalculateEIPPerformanceMeasureReportedValues(EIPPerformanceMeasure eipPerformanceMeasure, int? projectID)
        {
            // PM 33 is essentially the funding source expenditures for the project, grouped and summed by year
            var projectFundingSourceExpenditures =
                HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward()
                    .Where(pmav => !projectID.HasValue || (projectID.HasValue && pmav.ProjectID == projectID))
                    .ToList();
            return
                projectFundingSourceExpenditures.GroupBy(x => new {x.CalendarYear, x.Project})
                    .Select(
                        yearlyExpenditure =>
                            new EIPPerformanceMeasureReportedValue(eipPerformanceMeasure,
                                yearlyExpenditure.Key.Project,
                                yearlyExpenditure.Key.CalendarYear,
                                Convert.ToDouble(yearlyExpenditure.Sum(x => x.ExpenditureAmount))))
                    .OrderByDescending(pma => pma.CalendarYear)
                    .ThenBy(pma => pma.ProjectName)
                    .ToList();
        }

        public override string GetYAxisFormat()
        {
            return "$,s";
        }

        public override bool ForProjectsImplementsMultiplePrograms()
        {
            return false;
        }
    }

    public partial class EIPPerformanceMeasureTypeEIPPerformanceMeasure34
    {
        public override bool ValuesAreNotCalculated(bool implementsMultipleProjects)
        {
            return implementsMultipleProjects;
        }

        public override Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return GetAllProgramsAsNotPrimary();
        }

        public override bool CanAssociatePrograms()
        {
            return false;
        }

        public override List<EIPPerformanceMeasureReportedValue> CalculateEIPPerformanceMeasureReportedValues(EIPPerformanceMeasure eipPerformanceMeasure, int? projectID)
        {
            // PM 34; if not implementing multiple projects, need to add a PM Reported Value for this project's completion year with a value of 1 (itself essentially) when this project is set to stage Completed
            var projects =
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .Where(x => !x.ImplementsMultipleProjects && x.ProjectStage.ValidForEIPPerformanceMeasure34() && x.CompletionYear.HasValue && (!projectID.HasValue || x.ProjectID == projectID))
                    .ToList();

            var projectsThatDoNotImplementMultipleProjectsAndAreCompleted =
                projects.Select(project => new EIPPerformanceMeasureReportedValue(eipPerformanceMeasure, project, project.CompletionYear.Value, 1)).ToList();
            // we should not be using the projectIDs from projectsThatDoNotImplementMultipleProjectsAndAreCompleted when we are looking for EIPPerformanceMeasureActuals
            var projectIDsThatDoNotImplementMultipleProjectsAndAreCompleted = projectsThatDoNotImplementMultipleProjectsAndAreCompleted.Select(x => x.Project.ProjectID).Distinct().ToList();
            // now add in the ones that are implementing multiple projects
            projectsThatDoNotImplementMultipleProjectsAndAreCompleted.AddRange(
                base.CalculateEIPPerformanceMeasureReportedValues(eipPerformanceMeasure, projectID)
                    .Where(x => !projectIDsThatDoNotImplementMultipleProjectsAndAreCompleted.Contains(x.Project.ProjectID))
                    .ToList());
            return projectsThatDoNotImplementMultipleProjectsAndAreCompleted.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }

        public override bool ForProjectsImplementsMultiplePrograms()
        {
            return true;
        }
    }

    public partial class EIPPerformanceMeasureTypeForProjectsFunctioningAsAProgram
    {
        public override bool ValuesAreNotCalculated(bool implementsMultipleProjects)
        {
            return implementsMultipleProjects;
        }

        public override Dictionary<Program, bool> GetPrograms(EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return GetProgramsFromProgramEIPPerformanceMeasurePrograms(eipPerformanceMeasure);
        }

        public override bool CanAssociatePrograms()
        {
            return false;
        }

        public override List<EIPPerformanceMeasureReportedValue> CalculateEIPPerformanceMeasureReportedValues(EIPPerformanceMeasure eipPerformanceMeasure, int? projectID)
        {
            // PM 1, 2, 3; we only get a value if implementing multiple projects
            var projectsThatDoNotImplementMultipleProjects =
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .Where(x => !x.ImplementsMultipleProjects && (!projectID.HasValue || x.ProjectID == projectID))
                    .ToList();

            // we should not be using the projectIDs from projectsThatDoNotImplementMultipleProjectsAndAreCompleted when we are looking for EIPPerformanceMeasureActuals
            var projectIDsThatDoNotImplementMultipleProjects = projectsThatDoNotImplementMultipleProjects.Select(x => x.ProjectID).Distinct().ToList();

            return
                base.CalculateEIPPerformanceMeasureReportedValues(eipPerformanceMeasure, projectID)
                    .Where(x => !projectIDsThatDoNotImplementMultipleProjects.Contains(x.Project.ProjectID))
                    .ToList()
                    .OrderByDescending(pma => pma.CalendarYear)
                    .ThenBy(pma => pma.ProjectName)
                    .ToList();
        }

        public override bool ForProjectsImplementsMultiplePrograms()
        {
            return true;
        }
    }
}
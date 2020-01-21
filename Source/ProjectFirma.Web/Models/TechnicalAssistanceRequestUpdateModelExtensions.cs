using System.Linq;
using LtInfo.Common.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TechnicalAssistanceRequestUpdateModelExtensions
    {

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.TechnicalAssistanceRequestUpdates =
                project.TechnicalAssistanceRequests.Select(
                    technicalAssistanceRequest =>
                        new TechnicalAssistanceRequestUpdate(technicalAssistanceRequest.TechnicalAssistanceRequestID, projectUpdateBatch.ProjectUpdateBatchID,
                            technicalAssistanceRequest.FiscalYear,
                            technicalAssistanceRequest.PersonID,
                            technicalAssistanceRequest.TechnicalAssistanceTypeID,
                            technicalAssistanceRequest.HoursRequested,
                            technicalAssistanceRequest.HoursAllocated,
                            technicalAssistanceRequest.HoursProvided,
                            technicalAssistanceRequest.Notes)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var technicalAssistanceRequestsFromProjectUpdate =
                projectUpdateBatch.TechnicalAssistanceRequestUpdates.Select(
                    x => new TechnicalAssistanceRequest(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), project.ProjectID, 
                        x.FiscalYear, x.PersonID, x.TechnicalAssistanceTypeID,
                        x.HoursRequested, x.HoursAllocated, x.HoursProvided, x.Notes)).ToList();
            project.TechnicalAssistanceRequests.Merge(technicalAssistanceRequestsFromProjectUpdate,
                (x, y) => x.TechnicalAssistanceRequestID == y.TechnicalAssistanceRequestID,
                (x, y) =>
                {
                    x.ProjectID = y.ProjectID;
                    x.FiscalYear = y.FiscalYear;
                    x.PersonID = y.PersonID;
                    x.TechnicalAssistanceTypeID = y.TechnicalAssistanceTypeID;
                    x.HoursRequested = y.HoursRequested;
                    x.HoursAllocated = y.HoursAllocated;
                    x.HoursProvided = y.HoursProvided;
                    x.Notes = y.Notes;
                },
                databaseEntities);
        }
    }
}
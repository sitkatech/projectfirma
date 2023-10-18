﻿/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateStatusGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateStatusGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        private readonly bool _canStewardProjects;

        public ProjectUpdateStatusGridSpec(FirmaSession currentFirmaSession, ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterTypeEnum,
            bool canStewardProjects)
        {
            _canStewardProjects = canStewardProjects;

            AddViewEditColumn(projectUpdateStatusFilterTypeEnum);

            Add("Reporting Period Update Status",
                x =>
                {
                    var projectUpdateState = x.GetLatestUpdateStateResilientToDuplicateUpdateBatches();
                    var latestApprovedUpdateBatch = x.GetLatestApprovedUpdateBatch();
                    if (projectUpdateState == null ||
                        (projectUpdateState == ProjectUpdateState.Approved && latestApprovedUpdateBatch != null && !latestApprovedUpdateBatch.LastUpdateDate.IsDateInRange(FirmaDateUtilities.LastReportingPeriodStartDate(), FirmaDateUtilities.LastReportingPeriodEndDate())))
                        return "Not Started";

                    return projectUpdateState.ToEnum.ToString();
                },
                110,
                AgGridColumnFilterType.SelectFilterStrict);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 180, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.OrganizationPrimaryContact.ToType().ToGridHeaderString(),
                x => x.GetPrimaryContact() == null ? ViewUtilities.NoneString.ToHTMLFormattedString() : x.GetPrimaryContact().GetFullNameFirstLastAndOrgShortNameAsUrl(currentFirmaSession),
                95);
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(),
                x => x.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.GetProjectStageDisplayName(), 80, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 95, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);

            if (projectUpdateStatusFilterTypeEnum != ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects)
            {
                AddSubmitColumn();
            }

            Add("Last Updated", x => !x.ProjectUpdateBatches.Any() ? (DateTime?) null : x.ProjectUpdateBatches.Max(y => y.LastUpdateDate), 120);
            Add("Last Updated By", x => !x.ProjectUpdateBatches.Any() ? string.Empty : x.ProjectUpdateBatches.OrderByDescending(y => y.LastUpdateDate).First().LastUpdatePerson.GetFullNameFirstLast(), 120);

            Add("Last Submitted", x => x.GetLatestUpdateSubmittalDate(), 120);
            Add("Last Submitted By", x => x.GetLatestUpdateSubmittalPerson() != null ? x.GetLatestUpdateSubmittalPerson().GetFullNameFirstLast() : string.Empty, 120);

            Add("Last Approved", x => 
            {
                var latestApprovedUpdateBatch = x.GetLatestApprovedUpdateBatch();
                return latestApprovedUpdateBatch?.LastUpdateDate;
            }, 120);
            Add("Last Approved By", x => 
            {
                var latestApprovedUpdateBatch = x.GetLatestApprovedUpdateBatch();
                return latestApprovedUpdateBatch?.LastUpdatePerson.GetFullNameFirstLast();
            }, 120);
        }

        private void AddSubmitColumn()
        {
            Add("Submit",
                x =>
                {
                    // get the current batch if any
                    var latestNotApprovedUpdateBatch = x.GetLatestNotApprovedUpdateBatch();
                    if (latestNotApprovedUpdateBatch != null)
                    {
                        if (latestNotApprovedUpdateBatch.IsReadyToSubmit())
                        {
                            var submitText = latestNotApprovedUpdateBatch.IsReturned() ? "Re-Submit" : "Submit";
                            var submitLink = AgGridHtmlHelpers.MakeModalDialogLink(
                                $"<span style=\"display:none\">Ready to</span> {submitText}",
                                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(y => y.Submit(x)),
                                500,
                                $"{submitText} {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {x.GetDisplayName()}",
                                true,
                                "Continue",
                                "Cancel",
                                new List<string> { "btn", "btn-xs", "btn-firma" },
                                null,
                                null);
                            return submitLink;
                        }
                        if (latestNotApprovedUpdateBatch.IsSubmitted())
                        {
                            return new HtmlString("<span style='display:none'>Already </span>Submitted");
                        }
                    }

                    return new HtmlString("Not Ready<span style='display:none'> to Submit</span>");
                },
                100);
        }

        private void AddViewEditColumn(ProjectUpdateStatusFilterTypeEnum? projectUpdateStatusFilterTypeEnum)
        {
            if (projectUpdateStatusFilterTypeEnum == ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects)
            {
                AddViewOnlyColumn();
            }
            else
            {
                AddEditAndOrViewColumn();
            }
        }

        private void AddViewOnlyColumn()
        {
            Add(String.Empty,
                x =>
                {
                    var latestNotApprovedUpdateBatch = x.GetLatestNotApprovedUpdateBatch();
                    if (latestNotApprovedUpdateBatch == null)
                    {
                        return MakeAlertButton("Unable to View",
                            $"The Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {x.GetDisplayName()} cannot not be displayed because no Update is in progress. The most recent Update was already approved.", "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has already been approved</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsCreated())
                    {
                        return MakeAlertButton("Unable to View",
                            $"The Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {x.GetDisplayName()} cannot not be displayed because a new Update has already been started. Go to the All My Projects list to edit the new Update.", "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: A new Update has been started</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsReturned() && x.IsUpdateMandatory())
                    {
                        return MakeAlertButton("Unable to View",
                            $"The Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {x.GetDisplayName()} cannot not be displayed because the Update has been returned for mandatory correction. Go to the My Projects Requiring an Update list to fix the returned Update.", "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has been returned</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsReturned() && !x.IsUpdateMandatory())
                    {
                        return MakeAlertButton("Unable to View",
                            $"The Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {x.GetDisplayName()} cannot not be displayed because the Update has been returned for correction. Go to the All My Projects list to fix the returned Update.", "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has been returned</span>");
                    }

                    return UrlTemplate.MakeHrefString(x.GetProjectUpdateUrl(), _canStewardProjects ? "Review" : "View", new Dictionary<string, string> {{"class", "btn btn-xs btn-firma"}});
                },
                60);
        }

        private void AddEditAndOrViewColumn()
        {

            Add("Update Actions",
                x =>
                {
                    var latestUpdateState = x.GetLatestUpdateStateResilientToDuplicateUpdateBatches();
                    var linkText = "Begin";
                    if (latestUpdateState == ProjectUpdateState.Created)
                    {
                        linkText = "Edit";
                    }
                    else if (latestUpdateState == ProjectUpdateState.Returned)
                    {
                        linkText = "Re-Edit";
                    }
                    else if (latestUpdateState == ProjectUpdateState.Submitted)
                    {
                        linkText = _canStewardProjects ? "Review" : "View";
                    }

                    return UrlTemplate.MakeHrefString(x.GetProjectUpdateUrl(), linkText, new Dictionary<string, string> {{"class", "btn btn-xs btn-firma"}});
                },
                60, AgGridColumnFilterType.SelectFilterHtmlStrict);
        }

        private static HtmlString MakeAlertButton(string alertDialogTitle, string alertDialogText, string alertDialogButtonText, string gridButtonHtml)
        {
            var cssClasses = new List<string> { "btn", "btn-xs", "btn-firma" };
            return BootstrapHtmlHelpers.MakeModalDialogAlertButton(alertDialogText, alertDialogTitle, alertDialogButtonText, gridButtonHtml, cssClasses);
        }

        public static ProjectUpdateHistory GetLastProjectUpdateHistoryOfTransition(ProjectFirmaModels.Models.Project x)
        {
            return ProjectFirmaModels.Models.Project.GetProjectUpdateHistories(x).Where(y => y.ProjectUpdateState == ProjectUpdateState.Submitted).OrderByDescending(y => y.TransitionDate).FirstOrDefault();
        }

        public enum ProjectUpdateStatusFilterTypeEnum
        {
            AllMyProjects,
            MyProjectsRequiringAnUpdate,
            MySubmittedProjects,
            AllProjects,
            SubmittedProjects
        }
    }
}

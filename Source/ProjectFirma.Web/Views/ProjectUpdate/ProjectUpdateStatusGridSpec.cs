/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateStatusGridSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateStatusGridSpec : GridSpec<Models.Project>
    {
        private readonly bool _canApprove;

        public ProjectUpdateStatusGridSpec(ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterTypeEnum,
            bool canApprove)
        {
            _canApprove = canApprove;

            AddViewEditColumn(projectUpdateStatusFilterTypeEnum);

            Add("Reporting Period Update Status",
                x =>
                {
                    var projectUpdateState = x.GetLatestUpdateState();
                    if (projectUpdateState == null ||
                        (projectUpdateState == ProjectUpdateState.Approved && x.GetLatestApprovedUpdateBatch().LastUpdateDate < FirmaDateUtilities.LastReportingPeriodStartDate()))
                        return "Not Started";

                    return projectUpdateState.ToEnum.ToString();
                },
                110,
                DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 180, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementer != null ? x.LeadImplementer.GetDetailUrl() : null, x.LeadImplementerName), 130);
            Add(Models.FieldDefinition.PrimaryContact.ToGridHeaderString(),
                x => x.GetPrimaryContact() == null ? new HtmlString(string.Format("({0})", ViewUtilities.NoneString)) : x.GetPrimaryContact().GetFullNameFirstLastAndOrgAsUrl(),
                95);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 95, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

            if (projectUpdateStatusFilterTypeEnum != ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects)
            {
                AddSubmitColumn();
            }

            Add("Last Updated", x => !x.ProjectUpdateBatches.Any() ? (DateTime?) null : x.ProjectUpdateBatches.Max(y => y.LastUpdateDate), 120);
            Add("Last Submitted", x => x.GetLatestUpdateSubmittalDate(), 120);

            Add("Last Approved", x =>
            {
                var latestApprovedUpdateBatch = x.GetLatestApprovedUpdateBatch();
                return latestApprovedUpdateBatch == null ? (DateTime?) null : latestApprovedUpdateBatch.LastUpdateDate;
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
                        if (latestNotApprovedUpdateBatch.IsReadyToSubmit)
                        {
                            var submitText = latestNotApprovedUpdateBatch.IsReturned ? "Re-Submit" : "Submit";
                            var submitLink = DhtmlxGridHtmlHelpers.MakeModalDialogLink(String.Format("<span style=\"display:none\">Ready to</span> {0}", submitText),
                                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(y => y.Submit(x)),
                                500,
                                String.Format("{0} Project {1}", submitText, x.DisplayName),
                                true,
                                "Continue",
                                "Cancel",
                                new List<string> { "btn", "btn-xs", "btn-firma" },
                                null,
                                null);
                            return submitLink;
                        }
                        if (latestNotApprovedUpdateBatch.IsSubmitted)
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
                        return MakeAlertButton("Unable to View", String.Format("The Update for Project {0} cannot not be displayed because no Update is in progress. The most recent Update was already approved.", x.DisplayName), "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has already been approved</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsCreated)
                    {
                        return MakeAlertButton("Unable to View", String.Format("The Update for Project {0} cannot not be displayed because a new Update has already been started. Go to the All My Projects list to edit the new Update.", x.DisplayName), "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: A new Update has been started</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsReturned && x.IsUpdateMandatory)
                    {
                        return MakeAlertButton("Unable to View", String.Format("The Update for Project {0} cannot not be displayed because the Update has been returned for mandatory correction. Go to the My Projects Requiring an Update list to fix the returned Update.", x.DisplayName), "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has been returned</span>");
                    }
                    if (latestNotApprovedUpdateBatch.IsReturned && !x.IsUpdateMandatory)
                    {
                        return MakeAlertButton("Unable to View", String.Format("The Update for Project {0} cannot not be displayed because the Update has been returned for correction. Go to the All My Projects list to fix the returned Update.", x.DisplayName), "OK", "<span style=\"display:none\">Unable to </span>View</a><span style=\"display:none\">: The Update has been returned</span>");
                    }

                    return UrlTemplate.MakeHrefString(x.GetProjectUpdateUrl(), _canApprove ? "Review" : "View", new Dictionary<string, string> {{"class", "btn btn-xs btn-firma"}});
                },
                60);
        }

        private void AddEditAndOrViewColumn()
        {

            Add(String.Empty,
                x =>
                {
                    var latestUpdateState = x.GetLatestUpdateState();

                    if (!x.IsUpdateMandatory && (latestUpdateState == null || latestUpdateState == ProjectUpdateState.Approved))
                    {
                        return
                            ModalDialogFormHelper.ModalDialogFormLink("Begin",
                                SitkaRoute<ProjectController>.BuildUrlFromExpression(y => y.ConfirmNonMandatoryUpdate(x.PrimaryKey)),
                                "Update this project?",
                                400,
                                "Continue",
                                "Cancel",
                                new List<string> { "btn", "btn-xs", "btn-firma" },
                                null,
                                null);
                    }

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
                        linkText = _canApprove ? "Review" : "View";
                    }

                    return UrlTemplate.MakeHrefString(x.GetProjectUpdateUrl(), linkText, new Dictionary<string, string> {{"class", "btn btn-xs btn-firma"}});
                },
                60);
        }

        private static HtmlString MakeAlertButton(string alertDialogTitle, string alertDialogText, string alertDialogButtonText, string gridButtonHtml)
        {
            var cssClasses = new List<string> { "btn", "btn-xs", "btn-firma" };
            return BootstrapHtmlHelpers.MakeModalDialogAlertButton(alertDialogText, alertDialogTitle, alertDialogButtonText, gridButtonHtml, cssClasses);
        }

        public static ProjectUpdateHistory GetLastProjectUpdateHistoryOfTransition(Models.Project x)
        {
            return x.ProjectUpdateHistories.Where(y => y.ProjectUpdateState == ProjectUpdateState.Submitted).OrderByDescending(y => y.TransitionDate).FirstOrDefault();
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

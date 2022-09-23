/*-----------------------------------------------------------------------
<copyright file = "EditProjectUpdateConfigurationViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright(c) Tahoe Regional Planning Agency and Environmental Science Associates.All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU Affero General Public License<http://www.gnu.org/licenses/> for more details.

Source code is available upon request via<support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EditProjectUpdateConfigurationViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportingPeriodKickOffDate)]
        public DateTime? ProjectUpdateKickOffDate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportingPeriodCloseOutDate)]
        public DateTime? ProjectUpdateCloseOutDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectUpdateReminderInterval)]
        public int? ProjectUpdateReminderInterval { get; set; }

        [Required]
        [DisplayName("Send Reporting Period Kick-off Reminder?")]
        public bool? EnableProjectUpdateReminders { get; set; }

        [Required]
        [DisplayName("Send Periodic Reminders?")]
        public bool? SendPeriodicReminders { get; set; }

        [Required]
        [DisplayName("Send Close-out Reminder?")]
        public bool? SendCloseOutNotification { get; set; }

        [DisplayName("Kick-off Email Intro Content")]
        public HtmlString ProjectUpdateKickOffIntroContent { get; set; }

        [DisplayName("Reminder Email Intro Content")]
        public HtmlString ProjectUpdateReminderIntroContent { get; set; }

        [DisplayName("Close-out Email Intro Content")]
        public HtmlString ProjectUpdateCloseOutIntroContent { get; set; }

        [DisplayName("Days before end date to send Close-out Reminder (days)")]
        public int? DaysBeforeCloseOutDateForReminder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditProjectUpdateConfigurationViewModel()
        {
        }

        public EditProjectUpdateConfigurationViewModel(ProjectUpdateSetting projectUpdateSetting)
        {
            ProjectUpdateKickOffDate = projectUpdateSetting?.ProjectUpdateKickOffDate;
            ProjectUpdateCloseOutDate = projectUpdateSetting?.ProjectUpdateCloseOutDate;
            ProjectUpdateReminderInterval = projectUpdateSetting?.ProjectUpdateReminderInterval;
            EnableProjectUpdateReminders = projectUpdateSetting?.EnableProjectUpdateReminders;
            SendPeriodicReminders = projectUpdateSetting?.SendPeriodicReminders;
            SendCloseOutNotification = projectUpdateSetting?.SendCloseOutNotification;
            ProjectUpdateKickOffIntroContent = projectUpdateSetting?.ProjectUpdateKickOffIntroContentHtmlString;
            ProjectUpdateReminderIntroContent = projectUpdateSetting?.ProjectUpdateReminderIntroContentHtmlString;
            ProjectUpdateCloseOutIntroContent = projectUpdateSetting?.ProjectUpdateCloseOutIntroContentHtmlString;
            DaysBeforeCloseOutDateForReminder = projectUpdateSetting?.DaysBeforeCloseOutDateForReminder;
        }

        public void UpdateModel(ProjectUpdateSetting projectUpdateSetting)
        {
            projectUpdateSetting.ProjectUpdateKickOffDate = ProjectUpdateKickOffDate;
            projectUpdateSetting.ProjectUpdateCloseOutDate = ProjectUpdateCloseOutDate;
            projectUpdateSetting.ProjectUpdateReminderInterval = ProjectUpdateReminderInterval;
            projectUpdateSetting.EnableProjectUpdateReminders = EnableProjectUpdateReminders.GetValueOrDefault(); // will never be null
            projectUpdateSetting.SendPeriodicReminders = SendPeriodicReminders.GetValueOrDefault(); // will never be null
            projectUpdateSetting.SendCloseOutNotification = SendCloseOutNotification.GetValueOrDefault(); // will never be null
            projectUpdateSetting.ProjectUpdateKickOffIntroContent = ProjectUpdateKickOffIntroContent?.ToString();
            projectUpdateSetting.ProjectUpdateReminderIntroContent =
                ProjectUpdateReminderIntroContent?.ToString();
            projectUpdateSetting.ProjectUpdateCloseOutIntroContent =
                ProjectUpdateCloseOutIntroContent?.ToString();
            projectUpdateSetting.DaysBeforeCloseOutDateForReminder = DaysBeforeCloseOutDateForReminder;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // these bools will never be null due to RequiredAttribute
            var fieldDefinitionLabelProject = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            if (EnableProjectUpdateReminders ?? false)
            {
                if (string.IsNullOrWhiteSpace(ProjectUpdateKickOffIntroContent?.ToString()))
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, HtmlString>(
                        $"You must provide {fieldDefinitionLabelProject} Update Kick-off Email Content if {fieldDefinitionLabelProject} Update Reminders are enabled.",
                        m => m.ProjectUpdateKickOffIntroContent);
            }

            if (SendPeriodicReminders ?? false)
            {
                if (string.IsNullOrWhiteSpace(ProjectUpdateReminderIntroContent?.ToString()))
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, HtmlString>(
                        $"You must provide {fieldDefinitionLabelProject} Update Reminder Email Content if Periodic Reminders are enabled.",
                        m => m.ProjectUpdateReminderIntroContent);

                if (!ProjectUpdateReminderInterval.HasValue)
                {
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, int?>(
                        $"You must provide a {fieldDefinitionLabelProject} Update Reminder Interval if Periodic Reminders are enabled.",
                        m => m.ProjectUpdateReminderInterval);
                }
                else if (ProjectUpdateReminderInterval.Value < 7)
                {
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, int?>(
                        $"{fieldDefinitionLabelProject} Update Reminder Interval must be at least 7 days.",
                        m => m.ProjectUpdateReminderInterval);
                }
                else if (ProjectUpdateReminderInterval > 365)
                {
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, int?>(
                        $"{fieldDefinitionLabelProject} Update Reminder Interval cannot be greater than 365 days.",
                        m => m.ProjectUpdateReminderInterval);
                }
            }

            if (SendCloseOutNotification ?? false)
            {
                if (string.IsNullOrWhiteSpace(ProjectUpdateCloseOutIntroContent?.ToString()))
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, HtmlString>(
                        $"You must provide {fieldDefinitionLabelProject} Update Close-out Email Content if {fieldDefinitionLabelProject} Update Close-out Reminders are enabled.",
                        m => m.ProjectUpdateCloseOutIntroContent);
                if (!DaysBeforeCloseOutDateForReminder.HasValue)
                {
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, int?>(
                        $"You must provide the Days before end date to send Close-out Reminder if {fieldDefinitionLabelProject} Update Close-out Reminders are enabled.",
                        m => m.ProjectUpdateReminderInterval);
                }
                if (DaysBeforeCloseOutDateForReminder.HasValue && DaysBeforeCloseOutDateForReminder > 365)
                {
                    yield return new SitkaValidationResult<EditProjectUpdateConfigurationViewModel, int?>(
                        "Days before end date to send Close-out Reminder cannot be greater than 365 days.",
                        m => m.DaysBeforeCloseOutDateForReminder);
                }
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewModel : FormViewModel
    {
        [Required]
        public int PersonID { get; set; }

        [Required]        
        [FieldDefinitionDisplay(FieldDefinitionEnum.EIPRoleID)]
        public int? EIPRoleID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SustainabilityRoleID)]
        public int? SustainabilityRoleID { get; set; }

        [Required]        
        [FieldDefinitionDisplay(FieldDefinitionEnum.LTInfoRoleID)]
        public int? LTInfoRoleID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdRoleID)]
        public int? ThresholdRoleID { get; set; }

        [Required]
        [DisplayName("Should Receive EIP Project Tracker Support Emails?")]
        public bool ShouldReceiveEIPProjectTrackerSupportEmails { get; set; }

        [Required]
        [DisplayName("Should Receive Sustainability Dashboard Support Emails?")]
        public bool ShouldReceiveSustainabilityDashboardSupportEmails { get; set; }

        [Required]
        [DisplayName("Should Receive LTInfo Support Emails?")]
        public bool ShouldReceiveLakeTahoeInfoSupportEmails { get; set; }

        [Required]
        [DisplayName("Should Receive Threshold Dashboard Support Emails?")]
        public bool ShouldReceiveThresholdDashboardSupportEmails { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRolesViewModel()
        {
        }

        public EditRolesViewModel(Person person)
        {
            PersonID = person.PersonID;
            EIPRoleID = person.EIPRoleID;
            SustainabilityRoleID = person.SustainabilityRoleID;
            LTInfoRoleID = person.LTInfoRoleID;
            ThresholdRoleID = person.ThresholdRoleID;

            ShouldReceiveEIPProjectTrackerSupportEmails = person.ShouldReceiveSupportEmails(LTInfoArea.EIP.LTInfoAreaID);
            ShouldReceiveSustainabilityDashboardSupportEmails = person.ShouldReceiveSupportEmails(LTInfoArea.Sustainability.LTInfoAreaID);
            ShouldReceiveLakeTahoeInfoSupportEmails = person.ShouldReceiveSupportEmails(LTInfoArea.LTInfo.LTInfoAreaID);
            ShouldReceiveThresholdDashboardSupportEmails = person.ShouldReceiveSupportEmails(LTInfoArea.Threshold.LTInfoAreaID);
        }

        public void UpdateModel(Person person, Person currentPerson)
        {
            person.EIPRoleID = EIPRoleID.Value;
            person.SustainabilityRoleID = SustainabilityRoleID.Value;
            person.LTInfoRoleID = LTInfoRoleID.Value;
            person.ThresholdRoleID = ThresholdRoleID.Value;
           
            person.SetReceiveSupportEmails(LTInfoArea.EIP, ShouldReceiveEIPProjectTrackerSupportEmails);
            person.SetReceiveSupportEmails(LTInfoArea.Sustainability, ShouldReceiveSustainabilityDashboardSupportEmails);
            person.SetReceiveSupportEmails(LTInfoArea.LTInfo, ShouldReceiveLakeTahoeInfoSupportEmails);
            person.SetReceiveSupportEmails(LTInfoArea.Threshold, ShouldReceiveThresholdDashboardSupportEmails);

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(person.PersonID))
            {
                // Existing person
                person.UpdateDate = DateTime.Now;
            }
            else
            {
                // New person
                person.CreateDate = DateTime.Now;
            }
        }
    }
}
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
        [DisplayName("Should Receive EIP Project Tracker Support Emails?")]
        public bool ShouldReceiveEIPProjectTrackerSupportEmails { get; set; }

        [Required]
        [DisplayName("Should Receive LTInfo Support Emails?")]
        public bool ShouldReceiveLakeTahoeInfoSupportEmails { get; set; }

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

            ShouldReceiveEIPProjectTrackerSupportEmails = person.ShouldReceiveSupportEmails(LTInfoArea.EIP.LTInfoAreaID);
        }

        public void UpdateModel(Person person, Person currentPerson)
        {
            person.EIPRoleID = EIPRoleID.Value;
           
            person.SetReceiveSupportEmails(LTInfoArea.EIP, ShouldReceiveEIPProjectTrackerSupportEmails);

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
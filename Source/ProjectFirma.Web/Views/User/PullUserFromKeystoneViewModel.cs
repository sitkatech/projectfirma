using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.User
{
    public class PullUserFromKeystoneViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("User Name")]
        [StringLength(Person.FieldLengths.LoginName)]
        public String LoginName { get; set; }


        // Needed by model binder
        public PullUserFromKeystoneViewModel()
        {
        }


        public void UpdateModel(Tenant currentTenant)
        {
            try
            {
                HttpRequestStorage.DatabaseEntities.Database.ExecuteSqlCommand("execute dbo.PullPersonFromKeystone {0} {1} {2}", LoginName, currentTenant.TenantID, Models.Role.Unassigned.RoleID);            
            }
            catch (Exception)
            {
                
            }
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var person = HttpRequestStorage.DatabaseEntities.People.ToList().SingleOrDefault(x => x.LoginName == LoginName);
            if (person != null)
            {
                errors.Add(new SitkaValidationResult<PullUserFromKeystoneViewModel, string>("User already exists", m => m.LoginName));
            }
            
            return errors;
        }
    }
}
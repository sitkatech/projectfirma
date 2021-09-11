using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.User
{
    public class CreateAccountViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [ValidatePassword]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationID { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Password))
            {
                errors.Add(new SitkaValidationResult<CreateAccountViewModel, string>("Please specify a password", z => z.Password));
            }
            
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                errors.Add(new SitkaValidationResult<CreateAccountViewModel, string>("Please confirm the password", z => z.ConfirmPassword));
            }

            if (Password != ConfirmPassword)
            {
                errors.Add(new SitkaValidationResult<CreateAccountViewModel, string>("Passwords must match.", z => z.Password));
            }

            //if (!PasswordHelper.VerifyPasswordComplexity(Password))
            //{
            //    errors.Add(new ValidationResult(PasswordHelper.GetPasswordComplexityErrorMessage(Password)));
            //}

            return errors;
        }

        

    }
}
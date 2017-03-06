/*-----------------------------------------------------------------------
<copyright file="ValidationAttributes.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LtInfo.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' and '{1}' do not match.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(DefaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get { return _typeId; }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, 
                                 ErrorMessageString,
                                 OriginalProperty, 
                                 ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            var properties = TypeDescriptor.GetProperties(value);
            var originalValue = properties.Find(OriginalProperty, true).GetValue(value);
            var confirmValue = properties.Find(ConfirmProperty, true).GetValue(value);
            return Equals(originalValue, confirmValue);
        }
    }

    /// <summary>
    /// Dictates what combination of requirements will be used during password validation.  
    /// </summary>
    public enum ValidatePasswordAttributeRequirement
    {
        /// <summary>
        /// A password meeting any character requirement will validate.
        /// </summary>
        Any,

        /// <summary>
        /// A password must meet all minimum character counts.
        /// </summary>
        UppercaseSpecialNumeric,

        /// <summary>
        /// A password must meet the minimum uppercase character count and minimum special character count. Numeric character counts will be ignored.
        /// </summary>
        UppercaseSpecial,

        /// <summary>
        /// A password must meet the minimum uppercase character count and numeric character counts. Special character counts will be ignored.
        /// </summary>
        UppercaseNumeric,

        /// <summary>
        /// A password must meet the minimum special character count and numeric character counts. Uppercase character counts will be ignored.
        /// </summary>
        SpecialNumeric,        
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} must be at least {1} characters long.";

        public static int MinPasswordCharacters = 6;

        public static int MinRequiredUpperCaseCharacters = 0;
        public static int MinRequiredNumericCharacters = 0;
        public static int MinRequiredSymbolCharacters = 0;


        public static string PasswordStrengthRegularExpression = "";
        public static int MinRequiredNonAlphanumericCharacters = MinRequiredNumericCharacters + MinRequiredSymbolCharacters;


        public ValidatePasswordAttribute() : base(DefaultErrorMessage) { }

        public static ValidatePasswordAttributeRequirement RequirementGroup { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, name, MinPasswordCharacters);
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= MinPasswordCharacters) || valueAsString == null;
        }

        /// <summary>
        /// A convenience method for setting the minimum requirements for password validation. Commonly implemented or used in your global.asax or other application start point. 
        /// </summary>
        /// <param name="minLength">Minimum length of the password.</param>
        /// <param name="minUpperCaseChars">The minimum number of upper case chars.</param>
        /// <param name="minSpecialChars">The minimum number special chars.</param>
        /// <param name="minNumericChars">The minimum number of numeric chars.</param>
        /// <param name="passwordStrengthRegEx">The password strength reg ex.</param>
        /// <param name="requirementGroup">The requirement group.</param>
        public static void SetRequirements(int minLength, int minUpperCaseChars, int minSpecialChars, int minNumericChars, string passwordStrengthRegEx, ValidatePasswordAttributeRequirement requirementGroup)
        {
            MinPasswordCharacters = minLength;
            MinRequiredUpperCaseCharacters = minUpperCaseChars;
            MinRequiredSymbolCharacters = minSpecialChars;
            MinRequiredNumericCharacters = minNumericChars;
            RequirementGroup = requirementGroup;
            PasswordStrengthRegularExpression = passwordStrengthRegEx;
            MinRequiredNonAlphanumericCharacters = MinRequiredNumericCharacters + MinRequiredSymbolCharacters;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateEmailAddressAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} is not a valid email address.";

        public ValidateEmailAddressAttribute() : base(DefaultErrorMessage) { }

        public override string FormatErrorMessage(string emailAddress)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, emailAddress);
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            return (valueAsString != null && Validation.IsValidEmailAddress(valueAsString)) || valueAsString == null;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePhoneNumberAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} is not a valid phone number.";
        public ValidatePhoneNumberAttribute() : base(DefaultErrorMessage) { }

        public override string FormatErrorMessage(string phoneNumber)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, phoneNumber);
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            return (valueAsString != null && Validation.IsValidPhoneNumber(valueAsString)) || valueAsString == null;
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    public static class Crypto
    {
        public static string PasswordGuidelines = "Passwords are case-sensitive and must contain at least 8 characters, 1 number, 1 symbol, and 1 uppercase character.";

        public static bool VerifyPasswordComplexity(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < ValidatePasswordAttribute.MinPasswordCharacters)
            {
                return false;
            }

            var uppercaseCount = password.Where((t, i) => Char.IsUpper(password, i)).Count() >= ValidatePasswordAttribute.MinRequiredUpperCaseCharacters;
            var specialCount = password.Where((t, i) => Char.IsPunctuation(password, i) || Char.IsSeparator(password, i) || Char.IsSymbol(password, i)).Count() >=
                               ValidatePasswordAttribute.MinRequiredSymbolCharacters;
            var digitCount = password.Where((t, i) => Char.IsDigit(password, i) || Char.IsNumber(password, i)).Count() >= ValidatePasswordAttribute.MinRequiredNumericCharacters;

            var minRequirementMet = true;
            switch (ValidatePasswordAttribute.RequirementGroup)
            {
                case ValidatePasswordAttributeRequirement.SpecialNumeric:
                    minRequirementMet = specialCount && digitCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseSpecialNumeric:
                    minRequirementMet = uppercaseCount && specialCount && digitCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseSpecial:
                    minRequirementMet = uppercaseCount && specialCount;
                    break;
                case ValidatePasswordAttributeRequirement.UppercaseNumeric:
                    minRequirementMet = uppercaseCount && digitCount;
                    break;
                    //default is any....
                case ValidatePasswordAttributeRequirement.Any:
                    minRequirementMet = specialCount || digitCount || uppercaseCount;
                    break;
            }

            if (!minRequirementMet)
            {
                return false;
            }

            if (!String.IsNullOrEmpty(ValidatePasswordAttribute.PasswordStrengthRegularExpression) && !Regex.IsMatch(password, ValidatePasswordAttribute.PasswordStrengthRegularExpression))
            {
                return false;
            }

            return true;
        }

        public static string GetPasswordComplexityErrorMessage(string newPassword)
        {
            string retVal = "Password does not meet minimum complexity requirements: ";

            if (newPassword.Length < ValidatePasswordAttribute.MinPasswordCharacters)
                retVal += String.Format("Password length of {0}. ", ValidatePasswordAttribute.MinPasswordCharacters);

            if (newPassword.Where((t, i) => Char.IsUpper(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredUpperCaseCharacters)
                retVal += String.Format("{0} required uppercase character. ", ValidatePasswordAttribute.MinRequiredUpperCaseCharacters);

            if (newPassword.Where((t, i) => Char.IsPunctuation(newPassword, i) || Char.IsSeparator(newPassword, i) || Char.IsSymbol(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredSymbolCharacters)
                retVal += String.Format("{0} required Symbol. ", ValidatePasswordAttribute.MinRequiredSymbolCharacters);

            if (newPassword.Where((t, i) => Char.IsDigit(newPassword, i) || Char.IsNumber(newPassword, i)).Count() < ValidatePasswordAttribute.MinRequiredNumericCharacters)
                retVal += String.Format("{0} required number. ", ValidatePasswordAttribute.MinRequiredNumericCharacters);

            return retVal;
        }
    }
}
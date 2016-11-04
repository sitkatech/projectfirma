using System;
using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    public class Validation
    {
        public const string EmailRegexPattern = "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";

        public static bool IsValidEmailAddress(string email)
        {
            if (email == null)
            {
                return false;
            }
            return Regex.IsMatch(email, EmailRegexPattern);
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            if (phone == null)
                return false;

            return Regex.IsMatch(GeneralUtility.CompressPhoneNumber(phone), "^(?:[0-9]{3}\x20?)(?:[0-9]{3}\x20?)(?:[0-9]{4})$");
        }
        
        public static bool IsValidHostName(string server)
        {
            if (server == null)
            {
                return false;
            }
            return Regex.IsMatch(server, "^([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.[a-zA-Z]{2,4})$");
        }
        
        public static bool IsValidInteger(string i)
        {
            if (i == null)
            {
                return false;
            }
            if (! Regex.IsMatch(i, "^\\d{1,10}$"))
            {
                return false;
            }
            try
            {
                int @int = int.Parse(i);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidLatitude(string l)
        {
            double test;

            if (!Double.TryParse(l, out test))
                return false;

            if (test < -90.0 || test > 90.0)
                return false;

            return true;
        }

        public static bool IsValidLongitude(string l)
        {
            double test;

            if (!Double.TryParse(l, out test))
                return false;

            if (test < -180.0 || test > 180.0)
                return false;

            return true;
        }

        public static bool IsValidPercent(string p)
        {
            string t = p.TrimEnd('%');
            if (! IsValidInteger(t))
            {
                return false;
            }
            int i = int.Parse(t);
            if (i >= 0 && i <= 100)
            {
                return true;
            }
            return false;
        }
        
        public static bool IsValidPort(string port)
        {
            if (port == null)
            {
                return false;
            }
            if (! Regex.IsMatch(port, "^(\\d{1,5})$"))
            {
                return false;
            }
            if (int.Parse(port) > 65535 || int.Parse(port) < 1)
            {
                return false;
            }
            return true;
        }
        
        public static bool IsProperPrecision(string value, decimal precision)
        {
            int expectedDecimalPlaceCount = precision.ToString().Length - 2;
            int actualDecimalPlaceCount = 0;
            
            int decimalLocation = value.IndexOf(".");
            if (decimalLocation > 0)
            {
                actualDecimalPlaceCount = value.Substring(decimalLocation + 1).Length;
            }
            
            return actualDecimalPlaceCount >= expectedDecimalPlaceCount;
        }
    }
}

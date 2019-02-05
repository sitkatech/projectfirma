/*-----------------------------------------------------------------------
<copyright file="TestFramework.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class LoginConstants
        {
            public const int PersonID = 1;
            public const string LogonName = "matt@sitkatech.com";
            public static string Password = "password#1";
            public static string FirstName = "Matt";
            public static string LastName = "Deniston";
        }

        private static readonly Random Random = new Random();

        /// <summary>
        /// Use when trying to test what happens when a 3rd party web service is not responding
        /// </summary>
        public static Uri TestingUrlServerNotThere = new Uri("http://ServerNotThere.example.com");

        /// <summary>
        /// Makes a unique name that provides some traceability about where the test data came from.
        /// Namely, what *test* might have created the data
        /// </summary>
        public static string MakeTestName(string baseName)
        {
            return String.Format("_{0} {1} Test {2} at {3} on {4}",
                baseName,
                Guid.NewGuid(),
                MethodInfoToClassDotMethodString(FirstTestMethodInCallStack()),
                DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                Environment.MachineName.Substring(0, Math.Min(Environment.MachineName.Length, 8)));
        }

        public static MethodBase FirstTestMethodInCallStack()
        {
            var stack = new StackTrace();
            var testFrame = (stack.GetFrames() ?? new StackFrame[0]).FirstOrDefault(x => x.GetMethod().GetCustomAttributes(typeof(TestAttribute), true).Any());
            return testFrame == null ? null : testFrame.GetMethod();
        }

        public static string MethodInfoToClassDotMethodString(MethodBase mi)
        {
            return mi == null ? String.Empty : String.Format("{0}.{1}", mi.DeclaringType.Name, mi.Name);
        }

        public static string MakeTestName(string baseName, int maximumLength)
        {
            var testName = MakeTestName(baseName);
            return testName.Substring(0, Math.Min(maximumLength, testName.Length)).Trim();
        }

        public static string MakeTestNameWithoutCertainCharacters(string baseName, int maximumLength, string regExCharactersToRemove)
        {            
            var testName = MakeTestName(baseName, maximumLength);
            testName = Regex.Replace(testName, regExCharactersToRemove, string.Empty);

            return testName;
        }

        public static string MakeTestToken(string baseName, int maximumLength)
        {
            var testName = baseName + Guid.NewGuid().ToString("N");
            return testName.Substring(0, Math.Min(maximumLength, testName.Length)).Trim();
        }

        public static string MakeTestNameLongerThan(string baseName, int minimumLength)
        {
            var testName = MakeTestName(baseName);
            if (testName.Length <= minimumLength)
            {
                var makeTestNameLongerThan = testName.PadRight(minimumLength + 1, '*');
                return makeTestNameLongerThan;
            }
            return testName;
        }

        public static string MakeTestEmail(string baseName)
        {
            var safeForEmail = Regex.Replace(baseName, "\b", String.Empty).Replace("@", String.Empty);
            return String.Format("{0}_{1}@example.com", safeForEmail, Guid.NewGuid());
        }

        private static readonly HashSet<int> AlreadyIssuedIDs = new HashSet<int>();

        /// <summary>
        /// Returns new ID for use in in-memory objects. Keeps track of used IDs to prevent any possible collisions between objects in a test session.
        /// Wanted a range of numbers that is not likely to really be in the database
        /// </summary>
        public static int RandomInMemoryOnlyUniqueID()
        {
            int nextID;
            lock (AlreadyIssuedIDs)
            {
                do
                {
                    nextID = Random.Next(735700000, 735799999);
                }
                while (AlreadyIssuedIDs.Contains(nextID));
                AlreadyIssuedIDs.Add(nextID);
            }
            return nextID;
        }

        public static void AssertFieldRequired(IEnumerable<ValidationResult> validationResults, string propertyName)
        {
            Assert.That(validationResults.Any(x => x.ErrorMessage.Contains($"The {propertyName} field is required")), Is.True, "Should have error message");
        }

        public static void AssertFieldStringLength(IEnumerable<ValidationResult> validationResults, string propertyName, int maxLength)
        {
            Assert.That(validationResults.Any(x => x.ErrorMessage.Contains(
                    $"The field {propertyName} must be a string with a maximum length of {maxLength}.")),
                Is.True,
                "Should have error message");
        }

        public static void AssertInvalidCharacters(IEnumerable<ValidationResult> validationResults)
        {
            Assert.That(validationResults.Any(x => x.ErrorMessage.Contains("Only letters, numbers, spaces, dashes and underscores are allowed.")),
                Is.True,
                "Should have error message");
        }
    }
}

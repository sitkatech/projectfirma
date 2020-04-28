/*-----------------------------------------------------------------------
<copyright file="Check.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LtInfo.Common.DesignByContract
{
    /// <summary>
    /// Design By Contract Checks.
    ///
    /// Each method generates an exception or
    /// a Trace assertion if the contract is broken.
    ///
    /// If you wish to use Trace statements rather than exception handling then call the methods ending in Trace
    /// e.g., Check.RequireTrace(a > 1, "a must be > 1");
    /// Then output will be directed to a Trace listener. For example, you could insert
    ///
    /// Trace.Listeners.Clear();
    /// Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    /// 
    /// </summary>
    public class Check
    {
        // abstract class - No creation
        private Check()
        {
        }

        #region Require

        /// <summary>
        /// Pinch point for all the throwing
        /// </summary>
        private static void ThrowThisException(Exception ex)
        {
            throw ex;
        }

        public static void RequireThrowNotAuthorized(bool assertion, string message)
        {
            if (!assertion)
                ThrowThisException(new SitkaRecordNotAuthorizedException(message));
        }

        public static void Require(bool assertion)
        {
            if (!assertion)
                ThrowThisException(new PreconditionException());
        }

        public static void Require(bool assertion, string message)
        {
            if (!assertion)
                ThrowThisException(new PreconditionException(message));
        }

        public static void Require(bool assertion, string message, Exception inner)
        {
            if (!assertion)
                ThrowThisException(new PreconditionException(message, inner));
        }

        public static void Require(bool assertion, Exception ex)
        {
            if (!assertion)
                throw ex;
        }

        public static void Require(bool assertion, Func<Exception> func)
        {
            if (!assertion)
                throw func();
        }

        public static void RequireGreaterThanZero(int value, string message)
        {
            if (value <= 0)
                ThrowThisException(new PreconditionException(message));
        }

        public static void RequireNotDisposed(bool isDisposed, object thisObject)
        {
            if (isDisposed)
            {
                ThrowThisException(new ObjectDisposedException(thisObject.GetType().ToString()));
            }
        }

        public static void RequireNotNull(object thisObject)
        {
            if (thisObject == null)
            {
                ThrowThisException(new NullReferenceException());
            }
        }

        public static void RequireNotNull(object thisObject, string message)
        {
            if (thisObject == null)
            {
                ThrowThisException(new NullReferenceException(message));
            }
        }

        public static void RequireNotNull(object thisObject, Exception exception)
        {
            if (thisObject == null)
            {
                throw exception;
            }
        }

        public static void RequireNotNull(object thisObject, Func<Exception> func)
        {
            if (thisObject == null)
            {
                throw func();
            }
        }

        public static void RequireNotNullNotEmpty(string stringToCheck, string message)
        {
            RequireNotNull(stringToCheck, message);
            if (string.IsNullOrEmpty(stringToCheck))
            {
                ThrowThisException(new ArgumentException(message + " String is empty, expected non-empty string."));
            }
        }

        public static void RequireNotNullNotEmpty<T>(IEnumerable<T> itemsToCheck, string message)
        {
            RequireNotNull(itemsToCheck, message);
            if (!itemsToCheck.Any())
            {
                ThrowThisException(new ArgumentException(message + " Item list is empty, expected non-empty list."));
            }
        }

        public static void RequireNotNullNotEmptyNotWhitespace(string stringToCheck, string message)
        {
            RequireNotNull(stringToCheck, message);
            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(stringToCheck))
            {
                ThrowThisException(new ArgumentException(message + " String is empty or only blank, expected non-empty string with some non-whitespace characters."));
            }
        }

        public static void RequireNoWhitespace(string stringToExamine, string message)
        {
            if (Regex.IsMatch(stringToExamine, @"\s"))
            {
                ThrowThisException(new ArgumentException(message + " String \"{0}\" contains one or more whitespace characters and isn't allowed to contain whitespace."));
            }
        }

        public static void RequireDirectoryExists(string path)
        {
            string problem;
            if (!DirectoryExists(path, out problem))
            {
                ThrowThisException(new DirectoryNotFoundException(problem));
            }
        }

        public static void RequireDirectoryExists(DirectoryInfo dir)
        {
            string problem;
            if (!DirectoryExists(dir, out problem))
            {
                ThrowThisException(new DirectoryNotFoundException(problem));
            }
        }
        public static void RequireDirectoryExists(string path, string message)
        {
            string problem;
            if (!DirectoryExists(path, out problem))
            {
                ThrowThisException(new DirectoryNotFoundException(message + "\r\n" + problem + "\r\n" + "Directory: " + path));
            }
        }


        public static void RequireFileExists(FileInfo file, string message)
        {
            string problem;
            if (!FileExists(file, out problem))
            {
                var messageFormatted = (String.IsNullOrEmpty(message) || message.Trim() == String.Empty) ? string.Empty : message + "\r\n";
                ThrowThisException(new FileNotFoundException(messageFormatted + problem, file.FullName));
            }
        }

        public static void RequireFileExists(FileInfo file)
        {
            RequireFileExists(file, String.Empty);
        }

        public static void RequireFileExists(string file)
        {
            RequireFileExists(new FileInfo(file), String.Empty);
        }

        public static void RequireFileExists(string file, string message)
        {
            RequireFileExists(new FileInfo(file), message);
        }

        public static void RequireFileExists(FileInfo[] files)
        {
            string problem;
            if (!FileExists(files, out problem))
            {
                ThrowThisException(new FileNotFoundException(problem));
            }
        }

        #endregion

        #region Ensure

        public static void Ensure(bool assertion)
        {
            if (!assertion)
            {
                throw new PostconditionException();
            }
        }

        public static void Ensure(bool assertion, string message)
        {
            if (!assertion)
            {
                throw new PostconditionException(message);
            }
        }

        public static void Ensure(bool assertion, string message, Exception inner)
        {
            if (!assertion)
            {
                throw new PostconditionException(message, inner);
            }
        }

        public static void Ensure(bool assertion, Exception ex)
        {
            if (!assertion)
            {
                throw ex;
            }
        }

        public static void EnsureNotNull(object thisObject)
        {
            if (thisObject == null)
            {
                throw new NullReferenceException();
            }
        }

        public static void EnsureNotNull(object thisObject, string message)
        {
            if (thisObject == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void EnsureNull(object thisObject)
        {
            if (thisObject != null)
            {
                throw new PostconditionException();
            }
        }

        public static void EnsureNull(object thisObject, string message)
        {
            if (thisObject != null)
            {
                throw new PostconditionException(message);
            }
        }

        public static void EnsureFileExists(FileInfo file)
        {
            string problem;
            if (!FileExists(file, out problem))
            {
                throw new FileNotFoundException(problem);
            }
        }


        public static void EnsureFileExists(FileInfo[] files)
        {
            string problem;
            if (!FileExists(files, out problem))
            {
                throw new FileNotFoundException(problem);
            }
        }

        public static void EnsureFileExists(string file)
        {
            string problem;
            if (!FileExists(new FileInfo(file), out problem))
            {
                throw new FileNotFoundException(problem);
            }
        }

        public static void EnsureFileExists(string file, string message)
        {
            string problem;
            if (!FileExists(new FileInfo(file), out problem))
            {
                throw new FileNotFoundException(message + "\r\n" + problem, file);
            }
        }

        #endregion
        #region Invariant

        public static void Invariant(bool assertion)
        {
            if (!assertion)
                ThrowThisException(new InvariantException());
        }

        public static void Invariant(bool assertion, string message)
        {
            if (!assertion)
                ThrowThisException(new InvariantException(message));
        }

        public static void Invariant(bool assertion, string message, Exception inner)
        {
            if (!assertion)
                ThrowThisException(new InvariantException(message, inner));
        }

        public static void Invariant(bool assertion, Exception ex)
        {
            if (!assertion)
                throw ex;
        }

        public static void InvariantNotNull(object thisObject)
        {
            if (thisObject == null)
                ThrowThisException(new NullReferenceException());
        }

        #endregion

        #region Assert

        public static void Assert(bool assertion)
        {
            if (!assertion)
                ThrowThisException(new AssertionException());
        }

        public static void Assert(bool assertion, string message)
        {
            if (!assertion)
            {
                ThrowThisException(new AssertionException(message));
            }
        }

        public static void Assert(bool assertion, string message, Exception inner)
        {
            if (!assertion)
                ThrowThisException(new AssertionException(message, inner));
        }

        public static void Assert(bool assertion, Exception ex)
        {
            if (!assertion)
                throw ex;
        }

        #endregion

        #region RequireTrace

        public static void RequireTrace(bool assertion)
        {
            Trace.Assert(assertion, "Precondition failed.");
        }

        public static void RequireTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Precondition: " + message);
        }

        #endregion

        #region EnsureTrace

        public static void EnsureTrace(bool assertion)
        {
            Trace.Assert(assertion, "Postcondition failed.");
        }

        public static void EnsureTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Postcondition: " + message);
        }

        #endregion

        #region InvariantTrace

        public static void InvariantTrace(bool assertion)
        {
            Trace.Assert(assertion, "Invariant failed.");
        }

        public static void InvariantTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Invariant: " + message);
        }

        #endregion

        #region AssertTrace

        public static void AssertTrace(bool assertion)
        {
            Trace.Assert(assertion, "Assertion failed.");
        }

        public static void AssertTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Assertion: " + message);
        }

        #endregion

        private static bool FileExists(FileInfo[] files, out string problem)
        {
            bool exists = true;
            problem = String.Empty;
            if (files == null)
            {
                exists = false;
                problem = "FileInfo[] object is null.\n";
            }
            else
            {
                foreach (FileInfo file in files)
                {
                    string thisProblem;
                    bool thisExists = FileExists(file, out thisProblem);
                    exists = exists && thisExists;
                    problem += thisProblem;
                }
            }
            return exists;
        }

        private static bool FileExists(FileInfo file, out string problem)
        {
            bool exists = true;
            problem = String.Empty;
            if (file == null)
            {
                exists = false;
                problem = "FileInfo object is null.\n";
            }
            else if (!File.Exists(file.FullName))
            {
                exists = false;
                problem = String.Format("File \"{0}\" not found.\n", file.FullName);
            }
            return exists;
        }

        private static bool DirectoryExists(string dirName, out string problem)
        {
            bool exists = true;
            problem = String.Empty;
            if (dirName == null)
            {
                exists = false;
                problem = "Directory Name is null.\n";
            }
            else if (!Directory.Exists(dirName))
            {
                exists = false;
                problem = String.Format("Directory \"{0}\" not found.\n", dirName);
            }
            return exists;
        }

        private static bool DirectoryExists(DirectoryInfo dir, out string problem)
        {
            bool exists;
            if (dir == null)
            {
                exists = false;
                problem = "DirectoryInfo object is null.\n";
            }
            else
            {
                exists = DirectoryExists(dir.FullName, out problem);
            }
            return exists;
        }


        public static void RequireType<T>(object objectRequiringType, string message)
        {
            string fullMessage = String.Format("Expected object of type {0} but got type {1}", typeof(T).Name, objectRequiringType.GetType().Name);
            if (!(String.IsNullOrEmpty(message)))
            {
                fullMessage = string.Format("{0} {1}", message, fullMessage);
            }
            Require(objectRequiringType is T, fullMessage);
        }

        public static void RequireNotNullUserDisplayable(object o, string message)
        {
            if (o == null)
            {
                ThrowThisException(new SitkaDisplayErrorException(message));
            }
        }

        public static void RequireUserDisplayable(bool condition, string message)
        {
            Require(condition, new SitkaDisplayErrorException(message));
        }

        public static void RequireNotNullThrowNotFound(object theObject, string objectType, string objectID)
        {
            if (theObject == null)
            {
                ThrowThisException(new SitkaRecordNotFoundException(objectType, objectID));
            }
        }

        public static void RequireNotNullThrowNotFound(object theObject, string objectType, int objectID)
        {
            if (theObject == null)
            {
                ThrowThisException(new SitkaRecordNotFoundException(objectType, objectID));
            }
        }

        public static void RequireNotNullThrowNotFound(object theObject, string objectType, Guid objectGuid)
        {
            if (theObject == null)
            {
                ThrowThisException(new SitkaRecordNotFoundException(objectType, objectGuid));
            }
        }

        public static void RequireNotNullThrowNotFound<T>(T theObject, int objectID)
        {
            RequireNotNullThrowNotFound(theObject, typeof(T).Name, objectID);
        }

        public static void RequireNotNullThrowNotFound<T>(T theObject, string criteria)
        {
            RequireNotNullThrowNotFound(theObject, typeof(T).Name, criteria);
        }

        public static void RequireNotNullThrowNotAuthorized(object theObject, string message)
        {
            if (theObject == null)
            {
                ThrowThisException(new SitkaRecordNotAuthorizedException(message));
            }
        }

        public static void RequireThrowUserDisplayable(bool predicate, string message)
        {
            if (!predicate)
            {
                ThrowThisException(new SitkaDisplayErrorException(message));
            }
        }

        public static void RequireTrueThrowNotFound(bool condition, string message)
        {
            if (!condition)
            {
                ThrowThisException(new SitkaRecordNotFoundException(message));
            }
        }

    } // End Contract

} // End Design By Contract

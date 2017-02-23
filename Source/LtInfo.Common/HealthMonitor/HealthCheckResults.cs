/*-----------------------------------------------------------------------
<copyright file="HealthCheckResults.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LtInfo.Common.HealthMonitor
{
    public class HealthCheckResults
    {
        protected readonly List<HealthCheckResult> Results = new List<HealthCheckResult>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public HealthCheckResults()
        {
        }

        /// <summary>
        /// Make a single HealthCheckResults out of other sets of HealthCheckResults
        /// </summary>
        /// <param name="listOfHealthCheckResults"></param>
        public HealthCheckResults(IEnumerable<HealthCheckResults> listOfHealthCheckResults )
        {
            foreach (var healthCheckResults in listOfHealthCheckResults)
            {
               Results.AddRange(healthCheckResults.Results);
            }
        }

        public bool Success
        {
            // Are all the results successful?
            get { return Results.All(x => x.Success); }   
        }

        protected bool GetSuccess(List<String> checkNamesToLimitTo)
        {
            // Once limited to the checkNames passed, are all of them Successful?
            return Results.Where(res => checkNamesToLimitTo.Contains(res.CheckName)).All(res => res.Success);
        }


        /// <summary>
        /// Were all the test names requested valid? (Were they part of our results set?)
        /// </summary>
        /// <param name="checkNamesToLimitTo"></param>
        /// <returns></returns>
        protected bool AllTestNamesRequestedValid(List<String> checkNamesToLimitTo)
        {
            // If no limiting, we assume everything is OK
            if (checkNamesToLimitTo == null )
            {
                return true;
            }

            var testNamesRun = Results.Select(res => res.CheckName).ToList();

            return checkNamesToLimitTo.Select(testName => !testNamesRun.Contains(testName)).All(testNameNotFound => !testNameNotFound);
        }

        protected string[] FailedTestsNames
        {
            get { return Results.Where(x => !x.Success).Select(x => x.CheckName).ToArray(); }
        }

        public ContentResult GetHealthCheckResultsAsPlainTextResponse(Uri uriToShowInStatus)
        {
            return GetHealthCheckResultsAsPlainTextResponseImpl(uriToShowInStatus, null);
        }

        public ContentResult GetHealthCheckResultsAsPlainTextResponse(Uri uriToShowInStatus, List<String> checkNamesToLimitTo)
        {
            return GetHealthCheckResultsAsPlainTextResponseImpl(uriToShowInStatus, checkNamesToLimitTo);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriToShowInStatus">URI that is displaying these results. This URL will be put into emails, so it ideally should be a URL the user can </param>
        /// <param name="optionalCheckNamesToLimitTo"></param>
        /// <returns></returns>
        private ContentResult GetHealthCheckResultsAsPlainTextResponseImpl(Uri uriToShowInStatus, List<String> optionalCheckNamesToLimitTo)
        {
            var responseString = string.Empty;

            if (!AllTestNamesRequestedValid(optionalCheckNamesToLimitTo))
            {
                string statusDescription = string.Format("FAIL - Bad test name: {0}", string.Join(", ", optionalCheckNamesToLimitTo));
                responseString += String.Format("{0} {1}", statusDescription, MakeHtmlLinkToThisPage(uriToShowInStatus));
            }
            else
            {
                bool checkSuccess = optionalCheckNamesToLimitTo != null ? GetSuccess(optionalCheckNamesToLimitTo) : Success;
                if (checkSuccess)
                {
                    const string statusDescription = "OK - all tests passed";
                    responseString += String.Format("{0} {1}", statusDescription, MakeHtmlLinkToThisPage(uriToShowInStatus));
                }
                else
                {
                    const string statusDescription = "FAIL - At least one test failed";
                    responseString += String.Format("{0} {1}", statusDescription, MakeHtmlLinkToThisPage(uriToShowInStatus));
                }
            }

            // Add all the individual results
            responseString += GetResultListText(optionalCheckNamesToLimitTo);

            var content = new ContentResult();
            content.Content = responseString;
            //content.ContentType = "text/plain ";

            return content;
        }

        private string GetResultListText(ICollection<string> optionalCheckNamesToLimitTo)
        {
            var all = new StringBuilder();
            var resultsToExamine = optionalCheckNamesToLimitTo != null ? Results.Where(res => optionalCheckNamesToLimitTo.Contains(res.CheckName)) : Results;
            foreach (var result in resultsToExamine)
            {
                all.Append(result.ResponseBody);
                all.AppendLine();
                all.AppendLine();
            }
            return all.ToString();
        }

        /// <summary>
        /// Make HTML link to this very page for use in display on the HTTP status line. This way monitoring systems
        /// can use the HTTP status line to provide a quick way for support people to get back to this page and see
        /// the full output of the problem.
        /// 
        /// <a href="http://www.example.com"> http://www.example.com </a>
        ///                                  ^                      ^
        ///                                  |                      |
        ///                                  White space before and after tags
        /// 
        /// Important is the "space" between the anchor tags so that the link is still clickable in emails that end up
        /// getting sent out in "text" mode
        /// </summary>
        protected static string MakeHtmlLinkToThisPage(Uri uriToShowInStatus)
        {
            return String.Format("<a href=\"{0}\"> {0} </a>", uriToShowInStatus.AbsoluteUri);
        }

        public void Add(HealthCheckResult result)
        {
            Results.Add(result);
        }
    }
}

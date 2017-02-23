/*-----------------------------------------------------------------------
<copyright file="HealthCheckResult.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common.HealthMonitor
{
    public class HealthCheckResult
    {
        private readonly List<string> _resultMessages;
        public readonly string CheckName;
        public bool Success;

        public HealthCheckResult(string checkName)
        {
            Success = true;
            CheckName = checkName;
            _resultMessages = new List<string>();
        }

        public string ResponseBody
        {
            get
            {
                var title = string.Format("{0}Check {1}: {2}{0}\t", Environment.NewLine, CheckName, Success ? "Pass" : "Fail");
                var messageList = String.Join(Environment.NewLine + "\t", _resultMessages.ToArray());
                return string.Format("{0}{1}{2}{3}", title, messageList, Environment.NewLine, Environment.NewLine);
            }
        }

        public void AddResultMessage(string message)
        {
            _resultMessages.Add(message);
        }
    }
}

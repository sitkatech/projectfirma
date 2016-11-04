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
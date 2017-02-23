/*-----------------------------------------------------------------------
<copyright file="SitkaHttpApplication.cs" company="Sitka Technology Group">
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
using System.Threading;
using System.Web;
using log4net;

namespace LtInfo.Common
{
    public class SitkaHttpApplication : HttpApplication
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(SitkaHttpApplication));

        private static readonly object _launchBackgroundThreadIfNeededLock = new object();
        protected static void LaunchBackgroundThreadIfNeeded(ref Thread thread, ThreadStart threadStart, string threadName)
        {
            lock (_launchBackgroundThreadIfNeededLock)
            {
                if (thread != null)
                {
                    return;
                }

                // start up a background thread for running scheduled tasks 
                // IsBackground is set to true so that when IIS is unloading the ASP.NET Application Domain the ThreadAbort exception can shutdown the thread
                var worker = new Thread(threadStart) { Name = threadName, IsBackground = true };
                worker.Start();
                thread = worker;

                Logger.Info(string.Format("Started new background scheduled task thread: {0} {1}", worker.Name, worker.ManagedThreadId));
            }
        }
    }
}

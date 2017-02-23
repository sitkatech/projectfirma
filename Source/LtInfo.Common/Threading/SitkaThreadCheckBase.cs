/*-----------------------------------------------------------------------
<copyright file="SitkaThreadCheckBase.cs" company="Sitka Technology Group">
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
using LtInfo.Common.HealthMonitor;

namespace LtInfo.Common.Threading
{
    public abstract class SitkaThreadCheckBase
    {
        protected static void CheckIndividualThread(HealthCheckResult returnHealthCheck, Thread thread, string threadName)
        {
            if (thread == null)
            {
                returnHealthCheck.Success = false;
                returnHealthCheck.AddResultMessage(string.Format("Error! {0} background thread is not working properly.  Thread reference is null.", threadName));
            }
            else if (ThreadUtility.IsValidThreadState(thread.ThreadState))
            {
                returnHealthCheck.AddResultMessage(string.Format("{0} background thread is working properly. Thread ID: {1}, Thread Name: {2}, Thread State: {3}", threadName,  thread.ManagedThreadId, thread.Name, thread.ThreadState));
            }
            else
            {
                returnHealthCheck.Success = false;
                returnHealthCheck.AddResultMessage(string.Format("Error! {0} background thread is not working properly. Thread ID: {1}, Thread Name: {2}, Thread State: {3}", threadName, thread.ManagedThreadId, thread.Name, thread.ThreadState));
            }
        }
    }
}

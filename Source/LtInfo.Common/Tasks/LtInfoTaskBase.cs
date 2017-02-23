/*-----------------------------------------------------------------------
<copyright file="LtInfoTaskBase.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common.Tasks
{
    /// <summary>
    /// All LtInfo Tasks should inherit from this not <see cref="SitkaTaskBase"/>
    /// </summary>
    public abstract class LtInfoTaskBase : SitkaTaskBase
    {
        public override TimeSpan TimeBetweenRuns
        {
            get { return TimeSpan.FromHours(1); }
        }

        public override DateTime GetTimeOfNextRun(DateTime dateTimeOfLastRun)
        {
            return TruncateToTheHour(dateTimeOfLastRun + TimeBetweenRuns);
        }

        /// <summary>
        /// For manually performed operations from UI threads
        /// </summary>
        public void PerformWork(DateTime timeOfThisRun)
        {
            Action<string> messageLoggingFunction = message =>
            {
                Logger.Info(message);
                //taurusContext.AddMessage(message);
            };

            // We lock here because we manually invoke PerformScheduledWork via a button, and therefore we could have a collison between
            // that and a background thread. This is separate from and in addition to the lock on the background thread launcher.
            lock (PerformWorkImplLock)
            {
                PerformWorkImpl(timeOfThisRun, messageLoggingFunction);
            }
        }

    }
}

/*-----------------------------------------------------------------------
<copyright file="RemoteSyslogAppenderWithMessageSpanningTest.cs" company="Sitka Technology Group">
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
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class RemoteSyslogAppenderWithMessageSpanningTest
    {
        [Test]
        public void CanSplitLongMessage()
        {
            string body = "BeginBody " + new string('x', 2000) + " EndBody";

            var sampleMessage = new RemoteSyslogAppenderWithMessageSpanning.SysLogMessage
                                {
                                    Priority = 171,
                                    Header = new RemoteSyslogAppenderWithMessageSpanning.SysLogHeader
                                             {
                                                 HostName = "My Host Name",
                                                 TimeStamp = DateTime.Now
                                             },
                                    Body = body
                                };

            List<RemoteSyslogAppenderWithMessageSpanning.SysLogMessage> messages = RemoteSyslogAppenderWithMessageSpanning.SplitLongMessagesAsNeeded(sampleMessage);
            Assert.That(messages.Count, Is.GreaterThan(1), "Should have split this large message");

            string bodyFromParts = messages.Aggregate("", (s, message) => s + Regex.Replace(message.Body, @" \[SplitMessageID.*", String.Empty));

            Assert.That(body, Is.EqualTo(bodyFromParts), "Should have gotten the whole body into the split messages");
        }

        [Test]
        public void ShouldNotSplitShortMessage()
        {
            string body = "BeginBody " + new string('x', 100) + " EndBody";

            var sampleMessage = new RemoteSyslogAppenderWithMessageSpanning.SysLogMessage
                                {
                                    Priority = 171,
                                    Header = new RemoteSyslogAppenderWithMessageSpanning.SysLogHeader
                                             {
                                                 HostName = "My Host Name",
                                                 TimeStamp = DateTime.Now
                                             },
                                    Body = body
                                };

            List<RemoteSyslogAppenderWithMessageSpanning.SysLogMessage> messages = RemoteSyslogAppenderWithMessageSpanning.SplitLongMessagesAsNeeded(sampleMessage);
            Assert.That(messages.Count, Is.EqualTo(1), "Should not have split short message");

            RemoteSyslogAppenderWithMessageSpanning.SysLogMessage message = messages[0];
            Assert.That(message.Body, Is.EqualTo(body), "Should have the whole body at the end after the header");
        }
    }
}

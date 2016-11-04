using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;

namespace LtInfo.Common
{
    /// <summary>
    /// This function is an alternate way to get Syslog working that has "message spanning" for long messages to span across
    /// multiple UDP packets in syslog as a way to overcome the 1024 byte limit of UDP
    /// </summary>
    public class RemoteSyslogAppenderWithMessageSpanning : RemoteSyslogAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                var syslogMessage = new SysLogMessage
                                    {
                                        Priority = GeneratePriority(Facility, GetSeverity(loggingEvent.Level)),
                                        Header = new SysLogHeader
                                                 {
                                                     TimeStamp = DateTime.Now,
                                                     HostName = CalculateHostName(Identity, loggingEvent)
                                                 },
                                        Body = CalculateBody(loggingEvent),
                                    };

                List<SysLogMessage> packets = SplitLongMessagesAsNeeded(syslogMessage);

                foreach (SysLogMessage packet in packets)
                {
                    string packetContents = packet.AsUdpString();
                    Byte[] buffer = Encoding.GetBytes(packetContents.ToCharArray());
                    Client.Send(buffer, buffer.Length, RemoteEndPoint);
                }
            }
            catch (Exception e)
            {
                ErrorHandler.Error(
                    "Unable to send logging event to remote syslog " +
                    RemoteAddress +
                    " on port " +
                    RemotePort + ".",
                    e,
                    ErrorCode.WriteFailure);
            }
        }

        private string CalculateBody(LoggingEvent loggingEvent)
        {
            var bodyOfMessage = new StringWriter(CultureInfo.InvariantCulture);
            RenderLoggingEvent(bodyOfMessage, loggingEvent);

            // Tag the message with special marker for SWATCH to skip if it';s
            string markAsAlreadyEmailedPrefix = IsUsingSmtpAppender() ? "~SwatchDoesntNeedToEmail~ " : String.Empty;
            string logMessage = loggingEvent.MessageObject.ToString();
            string logMessageWithTag = markAsAlreadyEmailedPrefix + logMessage;
            string body = bodyOfMessage.ToString();
            body = body.Replace(logMessage, logMessageWithTag);

            // Replace newlines with \n so that it is smoother when filtering syslog events
            body = body.Replace("\r\n", "\\n");
            body = body.Replace("\n", "\\n");

            return GeneralUtility.TrimWhitespaceMapNullToEmptyString(body);
        }

        private static string CalculateHostName(ILayout identity, LoggingEvent loggingEvent)
        {
            var writer = new StringWriter();
            if (identity != null)
                identity.Format(writer, loggingEvent);
            else
                writer.Write(loggingEvent.Domain);
            return String.Format("{0}:", writer);
        }

        private static bool IsUsingSmtpAppender()
        {
            ILoggerRepository[] repositories = LogManager.GetAllRepositories();
            var allAppenders = new List<IAppender>();

            foreach (ILoggerRepository repository in repositories)
                allAppenders.AddRange(repository.GetAppenders());

            IEnumerable<string> allAppenderTypes = allAppenders.Select(a => a.GetType().FullName);

            bool isUsingSmtpAppender = allAppenderTypes.Where( x => x.Contains(typeof(SmtpAppender).Name)).Any();

            return isUsingSmtpAppender;
        }

        public static List<SysLogMessage> SplitLongMessagesAsNeeded(SysLogMessage message)
        {
            const int maxUdpLength = 1000;

            if (message.AsUdpString().Length < maxUdpLength)
                return new List<SysLogMessage> {message};

            const string splitBodySuffix = " [SplitMessageID {0} part {1:000} of {2:000}]";
            string messageGuidAsString = Guid.NewGuid().ToString("B").ToUpperInvariant();


            string sampleSuffix = String.Format(splitBodySuffix, messageGuidAsString, 0, 0);
            int bodyLengthPerMessage = maxUdpLength - message.PriAndHeaderLength - sampleSuffix.Length;

            if (bodyLengthPerMessage < 0) throw new ArgumentException("Cannot log message with splitting because header is longer than message length.");
            var numberOfSplits = (int) Math.Ceiling((double) message.Body.Length / bodyLengthPerMessage);

            var messages = new List<SysLogMessage>();
            for (int i = 0; i < numberOfSplits; ++i)
            {
                int startingIndex = i * bodyLengthPerMessage;

                int lengthOfFragment = Math.Min(bodyLengthPerMessage, message.Body.Length - startingIndex);

                string pieceOfOriginalBody = message.Body.Substring(startingIndex, lengthOfFragment);
                string splitMessageMarker = string.Format(splitBodySuffix, messageGuidAsString, i + 1, numberOfSplits);
                string bodyFragment = String.Format("{0}{1}", pieceOfOriginalBody, splitMessageMarker);

                var messageFragment = new SysLogMessage(message) {Body = bodyFragment};

                messages.Add(messageFragment);
            }

            return messages;
        }

        public struct SysLogHeader
        {
            public string HostName;
            public DateTime TimeStamp;

            public string AsUdpString()
            {
                return String.Format("{0:MMM} {1} {2:HH:mm:ss} {3}", TimeStamp, (TimeStamp.Day > 9) ? TimeStamp.Day.ToString() : " " + TimeStamp.Day, TimeStamp, HostName);
            }
        }

        public struct SysLogMessage
        {
            public string Body;
            public SysLogHeader Header;
            public int Priority;

            public SysLogMessage(SysLogMessage message)
            {
                Body = message.Body;
                Priority = message.Priority;
                Header = message.Header;
            }

            public int TotalLength
            {
                get { return AsUdpString().Length; }
            }

            public int PriAndHeaderLength
            {
                get { return FirstPart().Length; }
            }

            private string FirstPart()
            {
                return String.Format("<{0}>{1}", Priority, Header.AsUdpString());
            }

            public string AsUdpString()
            {
                return String.Format("{0} {1}", FirstPart(), Body);
            }
        }
    }
}
/*-----------------------------------------------------------------------
<copyright file="TcpUtility.cs" company="Sitka Technology Group">
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
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace LtInfo.Common
{
    /// <summary>
    /// Utility to help with connecting to TCP sockets and exchanging data
    /// </summary>
    public class TcpUtility
    {
        /// <summary>
        /// Make a simple TCP exchange, sending data over a port and receiving a result
        /// </summary>
        public static string SendThenReceiveDataThroughTcp(HostAndPort hostAndPort, string dataToSend)
        {
            return SendThenReceiveDataThroughTcp(hostAndPort.Hostname, hostAndPort.Port, dataToSend);
        }

        /// <summary>
        /// Make a simple TCP exchange, sending data over a port and receiving a result
        /// </summary>
        public static string SendThenReceiveDataThroughTcp(string hostToSendTo, int tcpPortToConnectTo, string dataToSend)
        {
            var resultLines = new List<string>();
            using (var tcp = new TcpClient(hostToSendTo, tcpPortToConnectTo))
            {
                var tcpDataToSendAsBytes = Encoding.ASCII.GetBytes(dataToSend.ToCharArray());
                using (var s = tcp.GetStream())
                {
                    s.Write(tcpDataToSendAsBytes, 0, tcpDataToSendAsBytes.Length);
                    using (var sr = new StreamReader(s, Encoding.ASCII))
                    {
                        string strLine;
                        while (null != (strLine = sr.ReadLine()))
                        {
                            resultLines.Add(strLine);
                        }
                        sr.Close();
                    }
                    s.Close();
                }
                tcp.Close();
            }
            return String.Join(Environment.NewLine, resultLines);
        }
    }
}

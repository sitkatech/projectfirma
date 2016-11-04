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
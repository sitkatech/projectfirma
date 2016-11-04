namespace LtInfo.Common
{
    public class HostAndPort
    {
        public readonly string Hostname;
        public readonly int Port;

        public HostAndPort(string hostname, int port)
        {
            Hostname = hostname;
            Port = port;
        }
    }
}
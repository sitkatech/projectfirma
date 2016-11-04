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

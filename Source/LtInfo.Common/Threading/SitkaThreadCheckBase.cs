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
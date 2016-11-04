using System.Threading;

namespace LtInfo.Common.Threading
{
    public static class ThreadUtility
    {
        public static bool IsValidThreadState(ThreadState ts)
        {
            return ((ts & ThreadState.Background) == ThreadState.Background ||
                    (ts & ThreadState.WaitSleepJoin) == ThreadState.WaitSleepJoin ||
                    (ts & ThreadState.Running) == ThreadState.Running)
                   &&
                   (
                       (ts & ThreadState.Stopped) != ThreadState.Stopped &&
                       (ts & ThreadState.Suspended) != ThreadState.Suspended &&
                       (ts & ThreadState.Unstarted) != ThreadState.Unstarted &&
                       (ts & ThreadState.Aborted) != ThreadState.Aborted
                   );
        }
    }
}

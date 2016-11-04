namespace LtInfo.Common
{
    public class ProcessUtilityResult
    {
        public ProcessUtilityResult(int returnCode, string stdOut, string stdOutAndStdErr)
        {
            ReturnCode = returnCode;
            StdOut = stdOut;
            StdOutAndStdErr = stdOutAndStdErr;
        }
        public readonly int ReturnCode;
        public readonly string StdOut;
        public readonly string StdOutAndStdErr;
    }
}
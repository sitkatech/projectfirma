using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class AthenaPDFUtility
    {
        public static void ConvertURLToPDFWithAthena(Uri url, FileInfo outputFile, AthenaPdfConversionSettings settings)
        {
            const string dockerExeName = "docker";

            // Settings should be provided
            Check.RequireNotNull(settings);
            // Docker and Athena should be set up correctly
            ConfirmAthenaCanBeRunInDocker();
            // Output directory must exist
            Check.RequireDirectoryExists(outputFile.DirectoryName);

            var commandLineArguments = settings.BuildAthenaCommandLineArguments(url, outputFile);

            var result = ProcessUtility.ShellAndWaitImpl(outputFile.DirectoryName, dockerExeName, commandLineArguments,
                true, Convert.ToInt32(settings.ExecutionTimeout.TotalMilliseconds));
            var retCode = result.ReturnCode;

            var argumentsAsString = String.Join(" ",
                commandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var fullProcessAndArguments =
                $"{ProcessUtility.EncodeArgumentForCommandLine(dockerExeName)} {argumentsAsString}";
            Check.Ensure(retCode == 0,
                $"Process {dockerExeName} returned with exit code {retCode}, expected exit code 0.\r\nProcess Command Line:\r\n{fullProcessAndArguments}\r\nProcess Working Directory: {outputFile.DirectoryName}\r\nStdErr and StdOut:\r\n{result.StdOutAndStdErr}");
        }

        /// <summary>
        /// Throws an exception if Athena is ready to be run in Docker
        /// </summary>
        public static void ConfirmAthenaCanBeRunInDocker()
        {
            // Does nothing for now -- no checking. TODO.
        }



        public class AthenaPdfConversionSettings
        {
            public TimeSpan ExecutionTimeout;
            public readonly IEnumerable<HttpCookie> SecurityCookies;

            public AthenaPdfConversionSettings(HttpCookieCollection cookies)
                : this(
                    ((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime"))
                    .ExecutionTimeout, cookies)
            {
            }

            public AthenaPdfConversionSettings(TimeSpan executionTimeout, HttpCookieCollection cookies)
            {
                ExecutionTimeout = executionTimeout;

                // TODO: Circle back to pass all cookies and update the PageRenderer to escape cookies to be used on the command line. If we ever do this, make sure to exclude SessionState.CookieName to avoid the synchronous nature of session aware actions. http://weblogs.asp.net/imranbaloch/archive/2010/07/10/concurrent-requests-in-asp-net-mvc.aspx

                // DO NOT pass the "ASP.NET_SessionId" cookie. It forces this request to block on obtaining write access to the user session, which our parent request currently holds. 
                SecurityCookies = CookieHelper.GetAllCookiesExceptSessionCookie(cookies);
            }

            public List<string> BuildAthenaCommandLineArguments(Uri url, FileInfo outputFile)
            {
                var args = new List<string>();

                string outputFileDirectory = outputFile.DirectoryName;
                string outputFilename = outputFile.Name;

                //docker run --security - opt seccomp: unconfined--rm - v % cd %:/ converted / arachnysdocker / athenapdf athenapdf https://www.arachnys.com/the-long-road-to-achieving-true-perpetual-kyc/
                args.Add("run");
                args.Add("--security-opt");
                args.Add("seccomp:unconfined");
                args.Add("--rm");
                args.Add("-v");
                args.Add("%cd%:/converted/");
                args.Add("arachnysdocker/athenapdf");
                args.Add("athenapdf");
                args.Add(url.ToString());
                args.Add(outputFilename);

                return args;

                // Notice no cookies here.. we'll see if we need them. TODO.
            }


        }



    }
}
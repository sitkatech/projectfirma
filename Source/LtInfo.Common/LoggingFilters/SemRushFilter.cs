using System;

namespace LtInfo.Common.LoggingFilters
{
    /// <summary>
    /// IP Address: 46.229.168.80
    /// Hostname: crawl16.bl.semrush.com
    /// Whois Info: 
    /// inetnum:        46.229.168.0 - 46.229.169.255
    /// netname:        ADVANCEDHOSTERS-NET
    /// descr:          Advanced Hosters B.V.
    /// country:        US
    /// admin-c:        AH36-RIPE
    /// tech-c:         AH36-RIPE
    /// status:         ASSIGNED PA
    /// remarks:        INFRA-AW
    /// remarks:        Send abuse reports to abuse @advancedhosters.com
    /// mnt-by:         ADVANCEDHOSTERS-MNT
    /// mnt-lower:      ADVANCEDHOSTERS-MNT
    /// mnt-routes:     ADVANCEDHOSTERS-MNT
    /// created:        2013-01-20T18:14:49Z
    /// last-modified:  2015-03-31T08:16:18Z
    /// source:         RIPE
    /// role:           Advanced Hosters B.V.
    /// address:        Ganzenstraat 1
    /// address:        3815 JA, Amersfoort, Nederland
    /// org:            ORG-AH11-RIPE
    /// abuse-mailbox:  abuse @advancedhosters.com
    /// nic-hdl:        AH36-RIPE
    /// mnt-by:         ADVANCEDHOSTERS-MNT
    /// created:        2009-03-31T09:52:43Z
    /// last-modified:  2015-03-19T12:49:43Z
    /// source:         RIPE # Filtered
    /// route:          46.229.160.0/20
    /// descr:          Hosting segment
    /// origin:         AS39572
    /// mnt-by:         ADVANCEDHOSTERS-MNT
    /// created:        2011-03-10T10:07:32Z
    /// last-modified:  2011-03-10T10:07:32Z
    /// source:         RIPE
    /// </summary>
    public class SemRushFilter : ISitkaLoggingFilter
    {
        public bool ShouldRequestBeFiltered(SitkaRequestInfo requestInfo)
        {
            return requestInfo.DebugInfo.Hostname.EndsWith(".semrush.com", StringComparison.InvariantCultureIgnoreCase) ||
                   requestInfo.DebugInfo.WhoIsInfo.Contains("abuse@advancedhosters.com", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
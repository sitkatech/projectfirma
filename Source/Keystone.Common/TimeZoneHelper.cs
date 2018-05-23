using System;
using System.Linq;

namespace Keystone.Common
{
    public static class TimeZoneHelper
    {
        
        public static DateTime ToUserLocalTime(this DateTime dateTime, IKeystoneUserClaims userClaims)
        {
            return userClaims != null ? TimeZoneInfo.ConvertTimeFromUtc(dateTime, userClaims.TimeZoneInfo) : TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        }

        public static DateTime? ToUserLocalTime(this DateTime? dateTime, IKeystoneUserClaims userClaims)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToUserLocalTime(userClaims) : dateTime;
        }

        public static string IanaToWindows(string ianaZoneId)
        {
            var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
            var mappings = tzdbSource.WindowsMapping.MapZones;
            var item = mappings.FirstOrDefault(x => x.TzdbIds.Contains(ianaZoneId));
            return item == null ? null : item.WindowsId;
        }

        public static string WindowsToIana(string windowsZoneId)
        {
            var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(windowsZoneId);
            return tzdbSource.MapTimeZoneId(tzi);
        }
    }
}
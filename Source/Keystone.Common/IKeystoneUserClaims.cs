using System;

namespace Keystone.Common
{
    public interface IKeystoneUserClaims
    {
        // core
        Guid UserGuid { get; }
        string DisplayName { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string LoginName { get; }
        Guid? OrganizationGuid { get; }
        string OrganizationName { get; }
        TimeZoneInfo TimeZoneInfo { get; }

        // address info
        string Address1 { get; }
        string City { get; }
        string StateName { get; }
        string PostalCode { get; }
        string CountryName { get; }
        string PrimaryPhone { get; }

        // misc
        string PersonalURL { get; }
    }
}

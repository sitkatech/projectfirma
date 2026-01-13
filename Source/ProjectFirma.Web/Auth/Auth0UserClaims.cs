using Newtonsoft.Json;
using System;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Auth
{
    public class Auth0UserClaims : IAuth0UserClaims
    {
        [JsonProperty("subject")]
        public String Subject { get; set; }

        [JsonProperty("userGuid")]
        public Guid UserGuid { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("loginName")]
        public string LoginName { get; set; }

        [JsonProperty("organizationGuid")]
        public Guid? OrganizationGuid { get; set; }

        [JsonProperty("organizationName")]
        public string OrganizationName { get; set; }

        [JsonProperty("organizationShortName")]
        public string OrganizationShortName { get; set; }

        [JsonProperty("timeZoneInfo")]
        public TimeZoneInfo TimeZoneInfo { get; set; }

        [JsonProperty("timeZoneIana")]
        public string TimeZoneIana { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateName")]
        public string StateName { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("primaryPhone")]
        public string PrimaryPhone { get; set; }

        [JsonProperty("personalURL")]
        public string PersonalURL { get; set; }
    }
}
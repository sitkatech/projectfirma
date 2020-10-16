using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Common
{
    public class KeystoneService
    {
        private readonly string _token;

        public class KeystoneInviteModel
        {
            public virtual string FirstName { get; set; }
            public virtual string LastName { get; set; }
            public virtual string Email { get; set; }
            public string Subject { get; set; }
            public string WelcomeText { get; set; }
            public string RedirectURL { get; set; }
            public string SiteName { get; set; }
            public string SignatureBlock { get; set; }
            public string SupportURL { get; set; }
            public string SupportEmail { get; set; }
            public string SupportBlock { get; set; }
            public Guid? OrganizationGuid { get; set; }
        }

        public class KeystoneApiResponse<T>
        {
            public HttpStatusCode StatusCode { get; set; }
            public KeystoneErrorModel Error { get; set; }
            public T Payload { get; set; }
        }

        public class KeystoneErrorModel
        {
            public string Message { get; set; }
            public Dictionary<string, string[]> ModelState { get; set; }
        }
        public class KeystoneNewUserModel
        {
            public bool Created { get; set; }
            public KeystoneUserClaims Claims { get; set; }
        }

        public class KeystoneProfileModel
        {
            public Guid UserGuid { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Prefix { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Suffix { get; set; }
            public string JobTitle { get; set; }
            public string PrimaryPhone { get; set; }
            public string PrimaryPhoneExtension { get; set; }
            public string Bio { get; set; }
            public string Publications { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string PersonalURL { get; set; }
            public string FacebookURL { get; set; }
            public string TwitterURL { get; set; }
            public string LinkedInURL { get; set; }
            public string FacultyURL { get; set; }
            public string CountryID { get; set; }
            public string OrganizationName { get; set; }
            public string StateID { get; set; }
            public int TimezoneID { get; set; }

        }
        public class KeystoneUserClaims
        {
            public Guid UserGuid { get; set; }
            public string DisplayName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string LoginName { get; set; }
            public Guid? OrganizationGuid { get; set; }
            public string OrganizationName { get; set; }
            public string OrganizationShortName { get; set; }
            public TimeZoneInfo TimeZoneInfo { get; set; }
            public string TimeZoneIana { get; set; }
            public string Address1 { get; set; }
            public string City { get; set; }
            public string StateName { get; set; }
            public string PostalCode { get; set; }
            public string CountryName { get; set; }
            public string PrimaryPhone { get; set; }
            public string PersonalURL { get; set; }
        }

        public KeystoneService(IPrincipal principal)
        {
            var requestHeader = (ClaimsIdentity)principal.Identity;
            var accessToken = requestHeader.Claims.FirstOrDefault(x => x.Type == "access_token");
            _token = $"Bearer {accessToken?.Value}"; //this includes the word "Bearer"
        }

        public KeystoneApiResponse<KeystoneNewUserModel> Invite(KeystoneInviteModel inviteModel)
        {
            var client = CreateClientWithAuthHeader();
            var content = new StringContent(JsonConvert.SerializeObject(inviteModel), Encoding.UTF8, "application/json");
            var response = client.PostAsync(FirmaWebConfiguration.KeystoneInviteUserUrl, content).Result;

            return ProcessRepsonse<KeystoneNewUserModel>(response);
        }

        private HttpClient CreateClientWithAuthHeader()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _token);
            return client;
        }

        private static KeystoneApiResponse<T> ParseError<T>(HttpResponseMessage response)
        {
            using (var sr = new StreamReader(response.Content.ReadAsStreamAsync().Result))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();

                    var data = serializer.Deserialize<KeystoneErrorModel>(jsonTextReader);

                    return new KeystoneApiResponse<T> { StatusCode = response.StatusCode, Error = data };
                }
            }
        }


        private static KeystoneApiResponse<T> ProcessRepsonse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return ParseError<T>(response);
            }

            using (var sr = new StreamReader(response.Content.ReadAsStreamAsync().Result))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();

                    var data = serializer.Deserialize<T>(jsonTextReader);

                    return new KeystoneApiResponse<T> { StatusCode = response.StatusCode, Payload = data };
                }
            }
        }
    }
}
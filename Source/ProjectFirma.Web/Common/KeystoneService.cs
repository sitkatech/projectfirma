using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Common
{
    public class KeystoneService
    {
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

        public KeystoneApiResponse<KeystoneNewUserModel> Invite(KeystoneInviteModel inviteModel)
        {
            var httpClient = CreateHttpClientWithClientCert();
            var content = new StringContent(JsonConvert.SerializeObject(inviteModel), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(FirmaWebConfiguration.KeystoneInviteUserUrl, content).Result;
            return ProcessRepsonse<KeystoneNewUserModel>(response);
        }

        public HttpClient CreateHttpClientWithClientCert()
        {
            var webRequestHandler = new WebRequestHandler();
            webRequestHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            webRequestHandler.ClientCertificates.Add(GetProjectFirmaKeystoneApiClientCertificate());
            webRequestHandler.UseProxy = false;
            return new HttpClient(webRequestHandler);
        }

        private static X509Certificate2 GetProjectFirmaKeystoneApiClientCertificate()
        {
            try
            {
                var trimmedBase64 = FirmaWebConfiguration.ProjectFirmaKeystoneApiClientCertificatePfxBase64.Trim();
                var bytes = Convert.FromBase64String(trimmedBase64);
                var clientCert = new X509Certificate2(bytes, FirmaWebConfiguration.ProjectFirmaKeystoneApiClientCertificatePfxPassword);
                return clientCert;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Had problem loading Keystone API Client Certificate, check configuration for valid values for {nameof(FirmaWebConfiguration.ProjectFirmaKeystoneApiClientCertificatePfxBase64)} and {nameof(FirmaWebConfiguration.ProjectFirmaKeystoneApiClientCertificatePfxPassword)}", ex);
            }
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
using System;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Controllers
{
    /// <summary>
    /// Maintains the logic of being a valid web service token, including the ASP.NET MVC <see cref="IModelBinder"/> stuff for binding in from a URL string.
    /// Also includes what is a legal token.
    /// </summary>
    [ModelBinder(typeof(WebServiceTokenModelBinder))] // ModelBinder is for Action parameter parsing
    public class WebServiceToken
    {
        /// <summary>
        /// The Unit Test GUID as a web service token
        /// </summary>
        public static readonly WebServiceToken WebServiceTokenForUnitTests;

        /// <summary>
        /// The Unit Test GUID which can be used to make the web service token
        /// </summary>
        public static readonly Guid WebServiceTokenGuidForUnitTests = new Guid("0677587B-2E44-42c2-8E2A-8CE3056B3FB3"); // corresponds to Ray Lee, PersonID = 3

        static WebServiceToken()
        {
            const bool isBeingCalledByStaticConstructor = true;
            WebServiceTokenForUnitTests = new WebServiceToken(WebServiceTokenGuidForUnitTests.ToString(), isBeingCalledByStaticConstructor);
        }

        /// <summary>
        /// Indicates if the token is valid in these circumstances as a unit test token, has to be the same GUID as <see cref="WebServiceTokenGuidForUnitTests"/>
        /// </summary>
        private static bool IsValidAsUnitTestToken(Guid tokenGuidToCheck, bool isBeingCalledByStaticConstructor)
        {
            return (tokenGuidToCheck == WebServiceTokenGuidForUnitTests && (isBeingCalledByStaticConstructor || FirmaWebConfiguration.FirmaEnvironment.IsUnitTestWebServiceTokenOkInThisEnvironment));
        }

        /// <summary>
        ///Throws an exception if the string <param name="allegedWebServiceToken"/> is not valid as a <see cref="WebServiceToken"/>
        /// </summary>
        private static Guid DemandValidWebServiceToken(string allegedWebServiceToken, bool isBeingCalledByStaticConstructor)
        {
            Guid tokenGuid;

            Check.Require(GuidUtility.TryParseGuid(allegedWebServiceToken, out tokenGuid), string.Format("The provided token {0} = \"{1}\" is not a GUID."
                , WebServiceTokenModelBinder.WebServiceTokenParameterName
                , allegedWebServiceToken));

            if (IsValidAsUnitTestToken(tokenGuid, isBeingCalledByStaticConstructor))
            {
                return tokenGuid;
            }

            Check.Require(tokenGuid != WebServiceTokenGuidForUnitTests, "Code appears to be trying to use the unit test web service token inappropriately, check environments and callers - that GUID is restricted use.");

            Check.RequireNotNull(HttpRequestStorage.DatabaseEntities.People.GetPersonByWebServiceAccessToken(tokenGuid), string.Format("The provided token {0} = \"{1}\" is not associated with a person."
                , WebServiceTokenModelBinder.WebServiceTokenParameterName
                , allegedWebServiceToken));
            return tokenGuid;
        }

        private readonly Person _person;
        private readonly Guid _tokenGuid;

        public WebServiceToken(string allegedWebServiceToken)
            : this(allegedWebServiceToken, false)
        {
        }

        private WebServiceToken(string allegedWebServiceToken, bool isBeingCalledByStaticConstructor)
        {
            var guidPassedIn = DemandValidWebServiceToken(allegedWebServiceToken, isBeingCalledByStaticConstructor);
            _tokenGuid = guidPassedIn;

            if (IsValidAsUnitTestToken(_tokenGuid, isBeingCalledByStaticConstructor))
            {
                _person = HttpRequestStorage.DatabaseEntities.People.GetPerson(3); // TODO: Ray Lee's ID; might want to make a system person?
            }
            else
            {
                _person = HttpRequestStorage.DatabaseEntities.People.GetPersonByWebServiceAccessToken(_tokenGuid);
            }
            Check.EnsureNotNull(_person, string.Format("Could not find valid person for WebServiceToken {0}", _tokenGuid));
        }

        /// <summary>
        /// Returns the <see cref="ProjectFirma.Web.Models.Person.PersonID"/> associated with this <see cref="WebServiceToken"/>.
        /// In unit test situation using <see cref="WebServiceTokenGuidForUnitTests"/> that would be Ray Lee's person ID for now
        /// Might want to introduce a system person at some point.
        /// </summary>
        public Person Person
        {
            get { return _person; }
        }

        public bool IsWebServiceTokenForUnitTests
        {
            get { return _tokenGuid == WebServiceTokenGuidForUnitTests; }
        }

        public override string ToString()
        {
            return _tokenGuid.ToString();
        }

        /// <summary>
        /// Throws an exception if the <see cref="Person"/> associated with this <see cref="WebServiceToken"/> does not have access to <see cref="FirmaBaseFeature" />
        /// In a unit test using <see cref="WebServiceTokenGuidForUnitTests"/> this will always pass, and <see cref="Person"/> will return Ray Lee's person ID for now
        /// Might want to introduce a system person at some point.
        /// </summary>
        /// <param name="feature"></param>
        public void DemandHasPermission(FirmaBaseFeature feature)
        {
            if (IsValidAsUnitTestToken(_tokenGuid, false))
            {
                // We consider the Unit Test one good if it's in the right environment
                return;
            }
            Check.RequireNotNull(_person, string.Format("The provided token {0} = \"{1}\" is not associated with a person. Cannot check for access to feature \"{2}\"", WebServiceTokenModelBinder.WebServiceTokenParameterName, _tokenGuid, feature.FeatureName));
            var hasPermission = feature.HasPermissionByPerson(_person);
            Check.Require(hasPermission, string.Format("Web service token \"{0}\" is for person \"{1}\" PersonID={2}, but that person does not have access to feature \"{3}\""
                , _tokenGuid, _person.FullNameFirstLast, _person.PersonID
                , feature.FeatureName));
        }

        public class WebServiceTokenModelBinder : SitkaModelBinder
        {
            /// <summary>
            /// Name of the required parameters on the controller actions
            /// </summary>
            public const string WebServiceTokenParameterName = "webServiceToken";
            public WebServiceTokenModelBinder() : base(s => new WebServiceToken(s)) { }
        }
    }
}
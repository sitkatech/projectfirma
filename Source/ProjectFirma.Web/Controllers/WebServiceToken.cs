/*-----------------------------------------------------------------------
<copyright file="WebServiceToken.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

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

        public static readonly WebServiceToken WebServiceTokenForParameterizedReplacements;

        /// <summary>
        /// The Unit Test GUID which can be used to make the web service token
        /// </summary>
        public static readonly Guid WebServiceTokenGuidForUnitTests = new Guid("4B261809-3D67-4A6A-A807-06B0044E6665"); // corresponds to Stewart Gordon, PersonID = 5920

        public static readonly Guid WebServiceTokenGuidForParameterizedReplacement = new Guid("11111222-3344-5566-7777-888889999999"); 

        static WebServiceToken()
        {
            const bool isBeingCalledByStaticConstructor = true;
            // this can be null in run-time depending on tenant, but we should only be using it for unit tests
            WebServiceTokenForUnitTests = new WebServiceToken(WebServiceTokenGuidForUnitTests.ToString(), isBeingCalledByStaticConstructor);
            // this should always be available, but it's also not a real web service token, we only use it for replacements
            WebServiceTokenForParameterizedReplacements = new WebServiceToken(WebServiceTokenGuidForParameterizedReplacement.ToString(), isBeingCalledByStaticConstructor);
        }

        /// <summary>
        /// Indicates if the token is valid in these circumstances as a unit test token, has to be the same GUID as <see cref="WebServiceTokenGuidForUnitTests"/>
        /// </summary>
        private static bool IsValidAsUnitTestToken(Guid tokenGuidToCheck, bool isBeingCalledByStaticConstructor)
        {
            return (tokenGuidToCheck == WebServiceTokenGuidForUnitTests && (isBeingCalledByStaticConstructor || FirmaWebConfiguration.FirmaEnvironment.IsUnitTestWebServiceTokenOkInThisEnvironment));
        }

        /// <summary>
        /// Indicates if the token is valid in these circumstances as a parameter replacement token, has to be the same GUID as <see cref="WebServiceTokenGuidForParameterizedReplacement"/>
        /// </summary>
        private static bool IsValidAsParameterizedReplacementToken(Guid tokenGuidToCheck)
        {
            return (tokenGuidToCheck == WebServiceTokenGuidForParameterizedReplacement);
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

            // Token is valid if we are in a unit-test type situation
            if (IsValidAsUnitTestToken(tokenGuid, isBeingCalledByStaticConstructor))
            {
                return tokenGuid;
            }

            // Parameterzied replacement tokens are valid too (although they result in a WebServiceToken that is deliberately half-baked and person-less. This should be OK
            // since we don't really want to use it for anything, just immediately replace it after we've generated routes and method signatures.
            if (IsValidAsParameterizedReplacementToken(tokenGuid))
            {
                return tokenGuid;
            }

            Check.Require(tokenGuid != WebServiceTokenGuidForUnitTests, "Code appears to be trying to use the unit test web service token inappropriately, check environments and callers - that GUID is restricted use.");
            //Check.Require(tokenGuid != WebServiceTokenGuidForParameterizedReplacements, "Code appears to be trying to use the parameterized replacement web service token inappropriately, check environments and callers - that GUID is restricted use.");

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
                _person = HttpRequestStorage.DatabaseEntities.People.GetPerson(5920, false); // TODO: Stewart Gordon's ID; might want to make a system person?
            }
            else
            {
                _person = HttpRequestStorage.DatabaseEntities.People.GetPersonByWebServiceAccessToken(_tokenGuid);
            }
            Debugger.Log(0, null,$"Creating WebServiceToken for \"{allegedWebServiceToken}\"");

            // Don't enforce person if this is for parameterized replacements
            // It also OK if person is null for the unit test one when running as a normal web site.
            // We only need the Unit Test one to work in actual unit test context. 
            // Unfortunately, there's no way (yet) to determine which way we are running, normal web site or unit tests -- SLG & SG
            if (!IsValidAsParameterizedReplacementToken(_tokenGuid) && !IsValidAsUnitTestToken(_tokenGuid, isBeingCalledByStaticConstructor))
            {
                Check.EnsureNotNull(_person, $"Could not find valid person for WebServiceToken {_tokenGuid}");
            }
        }

        /// <summary>
        /// Returns the <see cref="ProjectFirmaModels.Models.Person.PersonID"/> associated with this <see cref="WebServiceToken"/>.
        /// In unit test situation using <see cref="WebServiceTokenGuidForUnitTests"/> that would be Stewart Gordon's person ID for now
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

        public bool IsWebServiceTokenForParameterizedReplacement
        {
            get { return _tokenGuid == WebServiceTokenGuidForParameterizedReplacement; }
        }

        public override string ToString()
        {
            return _tokenGuid.ToString();
        }

        /// <summary>
        /// Throws an exception if the <see cref="Person"/> associated with this <see cref="WebServiceToken"/> does not have access to <see cref="FirmaBaseFeature" />
        /// In a unit test using <see cref="WebServiceTokenGuidForUnitTests"/> this will always pass, and <see cref="Person"/> will return Stewart Gordon's person ID for now
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
                , _tokenGuid, _person.GetFullNameFirstLast(), _person.PersonID
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

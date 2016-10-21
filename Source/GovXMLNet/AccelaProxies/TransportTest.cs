using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GovXMLNet.AccelaProxies
{
    [TestFixture]
    public class TransportTest
    {
        [Test]
        public void CanDeserializeErrorMessage()
        {
            // Arrange
            // -------

            const string govXmlResponseString = @"<?xml version=""1.0"" encoding=""us-ascii""?>
<GovXML xmlns=""http://www.accela.com/schema/AccelaWirelessXML"">
<FSystemOut><System><XMLVersion>GovXML-6.6.0</XMLVersion>
<ApplicationState>96793248589156583919</ApplicationState>
<Error><ErrorCode>0001</ErrorCode><ErrorMessage> : com.accela.aa.aaxml.govxml.operations.OperationCreationException:  at com.accela.aa.aaxml.govxml.operations.GovXMLOperationFactory.getOperation(GovXMLOperationFactory.java:105)</ErrorMessage></Error>
</System></FSystemOut>
</GovXML>";

            var t = new Transport(new Uri("http://www.example.org"));
            var response = new GovXML();
            clsError clsError;

            // Act
            // ---
            var success = t.deserialize(govXmlResponseString, ref response, out clsError);

            // Assert
            // ------
            Assert.That(success, Is.False, "Should fail because there was an error");
            Assert.That(clsError, Is.Not.Null, "Should get the error");
            Assert.That(clsError.ErrorCode, Is.EqualTo("0001"), "Should get the error code");
            Assert.That(clsError.ErrorMessage,
                        Is.EqualTo(
                            " : com.accela.aa.aaxml.govxml.operations.OperationCreationException:  at com.accela.aa.aaxml.govxml.operations.GovXMLOperationFactory.getOperation(GovXMLOperationFactory.java:105)"),
                        "Should get the error message");
        }

        [Test]
        public void CanDeserializeAuthenticationResponse()
        {
            // Arrange
            // -------

            const string govXmlResponseString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<GovXML xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://www.accela.com/schema/AccelaOpenSystemInterfaceXML"">
    <AuthenticateUserResponse>
        <System>
            <XMLVersion>730</XMLVersion>
            <ServiceProviderCode>MyServiceProviderCode</ServiceProviderCode>
            <Username>MyUsername</Username>
            <MaxRows>0</MaxRows>
            <StartRow>0</StartRow>
            <ApplicationState>68804593671798564013</ApplicationState>
            <Context>AccelaWirelessInspection</Context>
        </System>
        <InspectorId>
            <Keys>
                <Key>MyUsername</Key>
            </Keys>
        </InspectorId>
        <AboutExpiredDays>-1</AboutExpiredDays>
        <AllowChangePassword>true</AllowChangePassword>
        <ActiveInspector>false</ActiveInspector>
    </AuthenticateUserResponse>
</GovXML>";

            var t = new Transport(new Uri("http://www.example.org"));
            var response = new GovXML();
            clsError clsError;

            // Act
            // ---
            var success = t.deserialize(govXmlResponseString, ref response, out clsError);

            // Assert
            // ------
            Assert.That(success, Is.True, "Should succeed - no error");
            Assert.That(clsError, Is.Null, "Should not get an error");
            Assert.That(response.AuthenticateUserResponse, Is.Not.Null, "Should get user AuthenticateUserResponse");
            Assert.That(response.AuthenticateUserResponse.system, Is.Not.Null, "Should get user AuthenticateUserResponse.System");
            Assert.That(response.AuthenticateUserResponse.system.XMLVersion, Is.EqualTo("730"), "Should get user AuthenticateUserResponse.System.XMLVersion");
        }

        [Test]
        public void CanDeserializeInitiateCapResponse()
        {
            // Arrange
            // -------

            const string govXmlResponseString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<GovXML xmlns=""http://www.accela.com/schema/AccelaOpenSystemInterfaceXML"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
    <InitiateCAPResponse>
        <System>
            <XMLVersion>730</XMLVersion>
            <ServiceProviderCode>MyServiceProviderCode</ServiceProviderCode>
            <Username>MyUsername</Username>
            <MaxRows>10</MaxRows>
            <StartRow>1</StartRow>
            <ApplicationState>35755395625513120759</ApplicationState>
            <Context>AccelaWirelessInspection</Context>
            <Messages>
                <Message>
                    <Code>0</Code>
                </Message>
            </Messages>
            <Error>
                <ErrorCode>0</ErrorCode>
            </Error>
        </System>
        <CAPId>
            <Keys>
                <Key>14HIS</Key>
                <Key>00000</Key>
                <Key>00936</Key>
            </Keys>
            <IdentifierDisplay>ALLC2014-0931</IdentifierDisplay>
            <TrackingNumber>11395132363</TrackingNumber>
        </CAPId>
    </InitiateCAPResponse>
</GovXML>        
";

            var t = new Transport(new Uri("http://www.example.org"));
            var response = new GovXML();
            clsError clsError;

            // Act
            // ---
            var success = t.deserialize(govXmlResponseString, ref response, out clsError);

            // Assert
            // ------
            Assert.That(success, Is.True, "Should succeed - no error");
            Assert.That(clsError, Is.Not.Null, "Should find the error");
            Assert.That(clsError.ErrorCode, Is.EqualTo("0"), "Should find the ErrorCode is 0");
            Assert.That(response.InitiateCAPResponse, Is.Not.Null, "Should get user InitiateCAPResponse");
            Assert.That(response.InitiateCAPResponse.system, Is.Not.Null, "Should get user InitiateCAPResponse.system");
            Assert.That(response.InitiateCAPResponse.system.XMLVersion, Is.EqualTo("730"), "Should get user InitiateCAPResponse.system.XMLVersion");
            Assert.That(response.InitiateCAPResponse.CAPId, Is.Not.Null, "Should get user InitiateCAPResponse.CAPId");
            Assert.That(response.InitiateCAPResponse.CAPId.IdentifierDisplay, Is.EqualTo("ALLC2014-0931"), "Should get user InitiateCAPResponse.CAPId.IdentifierDisplay");
        }

        [Test]
        public void CanDeserializeGetParcelsResponse()
        {
            // Arrange
            // -------

            const string govXmlResponseString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<GovXML xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://www.accela.com/schema/AccelaOpenSystemInterfaceXML"">
    <GetParcelsResponse>
        <System>
            <XMLVersion>730</XMLVersion>
            <ServiceProviderCode>MyServiceProviderCode</ServiceProviderCode>
            <Username>MyUsername</Username>
            <MaxRows>1</MaxRows>
            <StartRow>1</StartRow>
            <EndRow>1</EndRow>
            <TotalRows>1</TotalRows>
            <ApplicationState>19982641138511549413</ApplicationState>
            <Error>
                <ErrorCode>0</ErrorCode>
            </Error>
        </System>
        <Parcels>
            <Parcel>
                <Keys>
                    <Key>550-601-00</Key>
                </Keys>
                <IdentifierDisplay>550-601-00</IdentifierDisplay>
                <contextType>Reference</contextType>
                <SpatialDescriptors>
                    <BookPageParcel/>
                    <LegalDescription/>
                    <MapReference>
                        <township/>
                        <range/>
                    </MapReference>
                </SpatialDescriptors>
                <CompactAddresses>
                    <CompactAddress>
                        <Keys>
                            <Key>3745139</Key>
                        </Keys>
                        <addressLines>
                            <String>0 NONE</String>
                        </addressLines>
                        <City>NONE</City>
                        <State>NV</State>
                        <PostalCode>0</PostalCode>
                        <Alias>Y</Alias>
                    </CompactAddress>
                </CompactAddresses>
                <Contacts>
                    <Contact isPrimary=""true"">
                        <Keys>
                            <Key>3139716</Key>
                        </Keys>
                        <Person xmlns=""http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL"">
                            <fullName>MyServiceProviderCode</fullName>
                            <roles>
                                <ActorRole>
                                    <role>owner</role>
                                </ActorRole>
                            </roles>
                            <addresses>
                                <PostalAddress>
                                    <addressLines/>
                                    <town/>
                                    <region/>
                                    <postalCode/>
                                    <country>United States</country>
                                </PostalAddress>
                                <TelecomAddress>
                                    <telephoneNumbers>
                                        <String/>
                                    </telephoneNumbers>
                                    <facsimileNumbers>
                                        <String/>
                                    </facsimileNumbers>
                                    <phoneCountryCodes>
                                        <String/>
                                    </phoneCountryCodes>
                                    <facsimileCountryCodes>
                                        <String/>
                                    </facsimileCountryCodes>
                                </TelecomAddress>
                            </addresses>
                            <OwnerAddress>
                                <addressLines/>
                                <country>United States</country>
                            </OwnerAddress>
                            <MailingAddress>
                                <addressLines/>
                                <country>United States</country>
                            </MailingAddress>
                            <OwnerTitle>MyServiceProviderCode</OwnerTitle>
                        </Person>
                    </Contact>
                </Contacts>
                <AdditionalInformation>
                    <AdditionalInformationGroup>
                        <Keys>
                            <Key>PARCEL</Key>
                        </Keys>
                        <IdentifierDisplay>PARCEL</IdentifierDisplay>
                        <AdditionalInformationSubGroup action=""Existing"">
                            <AdditionalItems>
                                <AdditionalItem>
                                    <Keys>
                                        <Key>Land Value</Key>
                                    </Keys>
                                    <IdentifierDisplay>Land Value</IdentifierDisplay>
                                    <DataType>
                                        <type>String</type>
                                    </DataType>
                                    <Name>Land Value</Name>
                                    <Value/>
                                    <drillDown>false</drillDown>
                                </AdditionalItem>
                            </AdditionalItems>
                        </AdditionalInformationSubGroup>
                    </AdditionalInformationGroup>
                </AdditionalInformation>
                <IsPrimary>N</IsPrimary>
                <Status>
                    <Keys/>
                    <Value>A</Value>
                    <IdentifierDisplay>Enabled</IdentifierDisplay>
                </Status>
                <LegalDescription/>
            </Parcel>
        </Parcels>
    </GetParcelsResponse>
</GovXML>";

            var t = new Transport(new Uri("http://www.example.org"));
            var response = new GovXML();
            clsError clsError;

            // Act
            // ---
            var success = t.deserialize(govXmlResponseString, ref response, out clsError);

            // Assert
            // ------
            Assert.That(success, Is.True, "Should succeed - no error");
            Assert.That(clsError, Is.Not.Null, "Should find the error");
            Assert.That(clsError.ErrorCode, Is.EqualTo("0"), "Should find the ErrorCode is 0");
            Assert.That(response.GetParcelsResponse, Is.Not.Null, "Should get user GetParcelsResponse");
            Assert.That(response.GetParcelsResponse.system, Is.Not.Null, "Should get user GetParcelsResponse.system");
            Assert.That(response.GetParcelsResponse.system.XMLVersion, Is.EqualTo("730"), "Should get user GetParcelsResponse.system.XMLVersion");
        }


        [Test]
        public void CanSerializeWithCorrectNamespaceInMessage()
        {
            // Arrange
            // -------
            const string expected = "<?xml version=\"1.0\" encoding=\"us-ascii\"?><GovXML xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.accela.com/schema/AccelaOpenSystemInterfaceXML\"><GetParcels><System><XMLVersion>730</XMLVersion><ServiceProviderCode>MyServiceProviderCode</ServiceProviderCode><Username>MyUsername</Username><MaxRows>10</MaxRows><ApplicationState>11463255371547667258</ApplicationState></System><collectionsLevelQueryLogic>OR</collectionsLevelQueryLogic><collectionLevelQueryLogic>OR</collectionLevelQueryLogic><ParcelIds><ParcelId><Keys><Key>014-247-09</Key></Keys></ParcelId></ParcelIds><withOpenInspectionsOnly>false</withOpenInspectionsOnly><withUnassignedInspectionsOnly>false</withUnassignedInspectionsOnly><returnDisabledParcels>false</returnDisabledParcels><returnRefParcels>false</returnRefParcels></GetParcels></GovXML>";
            var msgGetParcels = new msgGetParcels
            {
                system = new clsSystem {XMLVersion = "730", ServiceProviderCode = "MyServiceProviderCode", Username = "MyUsername", MaxRows = 10, ApplicationState = "11463255371547667258"},
                collectionsLevelQueryLogic = queryLogicEnum.OR,
                collectionLevelQueryLogic = queryLogicEnum.OR,
                ParcelIds = new clsParcelIds {ParcelId = new List<clsParcelId> {new clsParcelId {Keys = new clsKeys(new[] {"014-247-09"})}}},
                withOpenInspectionsOnly = false,
                withUnassignedInspectionsOnly = false,
                returnDisabledParcels = false,
                returnRefParcels = false
            };

            var govXml = new GovXML {GetParcels = msgGetParcels};
            var t = new Transport(new Uri("http://www.example.org"));

            // Act
            // ---

            var result = t.serialize(govXml);

            // Assert
            // ------
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
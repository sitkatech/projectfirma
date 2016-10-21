using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.3.3
<xsd:complexType name="Person">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="Identifier" minOccurs="0" name="id"/>
				<xsd:element type="Label" minOccurs="0" name="familyName"/>
				<xsd:element type="Label" minOccurs="0" name="givenName"/>
				<xsd:element minOccurs="0" name="middleNames">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="Label" minOccurs="0" name="fullName" />
				<xsd:element minOccurs="0" name="prefixTitles">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="suffixTitles">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element type="Label" name="String"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="roles">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="ActorRole"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="addresses">
					<xsd:complexType>
						<xsd:choice maxOccurs="unbounded" minOccurs="1">
							<xsd:element ref="Address"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
                <xsd:element minOccurs="0" name="OwnerAddress">
                    <xsd:complexType>
                        <xsd:choice maxOccurs="unbounded" minOccurs="1">
                            <xsd:element ref="PostalAddress"/>
                        </xsd:choice>
                    </xsd:complexType>
                </xsd:element>
                <xsd:element minOccurs="0" name="MailingAddress">
                    <xsd:complexType>
                        <xsd:choice maxOccurs="unbounded" minOccurs="1">
                            <xsd:element ref="PostalAddress"/>
                        </xsd:choice>
                    </xsd:complexType>
                </xsd:element>
                <xsd:element name="OwnerTitle" type="Label" minOccurs="0" />
				<xsd:element name="salutation" type="Label" minOccurs="0"/>
				<xsd:element name="gender" type="Label" minOccurs="0" />
				<xsd:element name="postOfficeBox" type="Label" minOccurs="0" />
				<xsd:element name="birthDate" type="Label" minOccurs="0" />
				<xsd:element name="busName2" type="Label" minOccurs="0" />
				<xsd:element name="countryCode" type="Label" minOccurs="0" />
				<xsd:element name="email" type="Label" minOccurs="0" />
				<xsd:element name=" businessName1" type=" xsd:string " />
				<xsd:element name=" businessName2" type=q xsd:stringq/>
				<xsd:element name=" BirthCity" ref=qIdentifierq/>
				<xsd:element name=" BirthState" ref=qIdentifier" >
				<xsd:element name=" BirthRegion" ref=qIdentifier" >
				<xsd:element name=" Race" ref=qIdentifier" >
				<xsd:element name=" deceasedDate " type=" xsd:string " />
				<xsd:element name=" passportNumber" type=" xsd:string " />
				<xsd:element name=" driverLicenseNbr" ref=" Identifier " />
				<xsd:element name=" driverLicenseState" ref=qIdentifierq/>
				<xsd:element name=" stateIDNbr" type=" xsd:string " />
				<xsd:element name=" startDate" type=" xsd:string " />
				<xsd:element name=" endDate" type=" xsd:string " />
				<xsd:element name=" contactTitle" type=" xsd:string " />
				<xsd:element name=" SalutationIdentifier" ref=qIdentifier" >
				<xsd:element name=" GenderIdentifier" ref=qIdentifier" >
				<xsd:element name="socialSecurityNumber"type="xsd:stringq/>
				<xsd:element name="PreferredChannel "ref=qIdentifier" >
				<xsd:element name=" Relation" ref=qIdentifier" >
				<xsd:element name=" status" type=" xsd:string " />
				<xsd:element name=" contactTypeFlag " type="String" />
				<xsd:element name=" suffix " type=" xsd:string " />
				<xsd:element name=" comment " type=" xsd:string " />

            </xsd:sequence>
		</xsd:extension>
	</xsd:complexContent>
</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsIFCPerson : clsIFCelementID
    {
        // Members
        public clsIdentifier id { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }

        [XmlArray("middleNames")]
        [XmlArrayItem("String")]
        public List<string> middleNames { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        [XmlArray("prefixTitles")]
        [XmlArrayItem("String")]
        public List<string> prefixTitles { get; set; }

        [XmlArray("suffixTitles")]
        [XmlArrayItem("String")]
        public List<string> suffixTitles { get; set; }

        [XmlArray("roles")]
        [XmlArrayItem("ActorRole")]
        public List<clsIFCActorRole> roles { get; set; }

        public clsIFCAddresses addresses { get; set; }

        [XmlArray("OwnerAddress")]
        public List<clsIFCPostalAddress> OwnerAddress { get; set; }

        [XmlArray("MailingAddress")]
        public List<clsIFCPostalAddress> MailingAddress { get; set; }

        public string OwnerTitle { get; set; }
        public string salutation { get; set; }
        public string gender { get; set; }
        public string postOfficeBox { get; set; }
        public string birthDate { get; set; }
        public string busName2 { get; set; }
        public string countryCode { get; set; }
        public string businessName1 { get; set; }
        public string businessName2 { get; set; }
        public string BirthCity { get; set; }
        public string BirthState { get; set; }
        public string BirthRegion { get; set; }
        public clsIdentifier Race { get; set; }
        public string deceasedDate { get; set; }
        public string passportNumber { get; set; }
        public clsIdentifier driverLicenseNbr { get; set; }
        public clsIdentifier driverLicenseState { get; set; }
        public string stateIDNbr { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string contactTitle { get; set; }
        public clsIdentifier SalutationIdentifier { get; set; }
        public clsIdentifier GenderIdentifier { get; set; }
        public string socialSecurityNumber { get; set; }
        public clsIdentifier PreferredChannel { get; set; }
        public clsIdentifier Relation { get; set; }
        public string status { get; set; }
        public string contactTypeFlag { get; set; }
        public string suffix { get; set; }
        public string comment { get; set; }

        // Constructors
        public clsIFCPerson()
        {
            id = null;
            familyName = null;
            givenName = null;
            middleNames = null;
            fullName = null;
            email = null;
            prefixTitles = null;
            suffixTitles = null;
            roles = null;
            addresses = null;
            OwnerAddress = null;
            MailingAddress = null;
            OwnerTitle = null;
            salutation = null;
            gender = null;
            postOfficeBox = null;
            birthDate = null;
            busName2 = null;
            countryCode = null;
            businessName1 = null;
            businessName2 = null;
            BirthCity = null;
            BirthState = null;
            BirthRegion = null;
            Race = null;
            deceasedDate = null;
            passportNumber = null;
            driverLicenseNbr = null;
            driverLicenseState = null;
            stateIDNbr = null;
            startDate = null;
            endDate = null;
            contactTitle = null;
            SalutationIdentifier = null;
            GenderIdentifier = null;
            socialSecurityNumber = null;
            PreferredChannel = null;
            Relation = null;
            status = null;
            contactTypeFlag = null;
            suffix = null;
            comment = null;
        }
    }
}

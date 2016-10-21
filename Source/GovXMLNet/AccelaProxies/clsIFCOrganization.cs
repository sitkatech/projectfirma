using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.3.3
<xsd:complexType name="Organization">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="Identifier" minOccurs="0" name="id"/>
				<xsd:element type="Label" name="name"/>
				<xsd:element type="Text" minOccurs="0" name="description"/>
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
				<xsd:element type="xsd:string" minOccurs="0" name="contactBusinessName"/>                    				
				<xsd:element name=" businessName2" type=q xsd:stringq/>
				<xsd:element name=" tradeName" type=q xsd:stringq/>
				<xsd:element name=" status" type=q xsd:stringq/>
				<xsd:element name=" startDate" type=q xsd:stringq/>
				<xsd:element name=" endDate" type=q xsd:stringq/>
				<xsd:element name=" fein" type=q xsd:stringq/>
				<xsd:element name=" comment" type=q xsd:stringq/>
				<xsd:element name=" Relation" ref=q Identifierq/>
				<xsd:element name=" postOfficeBox" type=q xsd:stringq/>
				<xsd:element name=" PreferedChannel" ref=q Identifierq/>
				<xsd:element name=" suffix" type=q xsd:stringq/>

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
    public class clsIFCOrganization : clsIFCelementID
    {
        public clsIdentifier id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        [XmlArray("roles")]
        [XmlArrayItem("ActorRole")]
        public List<clsIFCActorRole> roles { get; set; }

        [XmlElement(ElementName = "addresses")]
        public List<clsIFCAddress> addresses { get; set; }

        public string contactBusinessName { get; set; }
        public string businessName2 { get; set; }
        public string tradeName { get; set; }
        public string status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string fein { get; set; }
        public string comment { get; set; }
        public clsIdentifier Relation { get; set; }
        public string postOfficeBox { get; set; }
        public clsIdentifier PreferedChannel { get; set; }
        public string suffix { get; set; }

        public bool rolesSpecified
        {
            get { return roles != null && roles.Count > 0; }
        }

        public bool addressesSpecified
        {
            get { return addresses != null && addresses.Count > 0; }
        }

        public bool idSpecified
        {
            get { return id != null; }
        }

        public clsIFCOrganization()
        {
            id = null;
            name = null;
            description = null;
            roles = null;
            addresses = null;
            contactBusinessName = null;
            businessName2 = null;
            tradeName = null;
            status = null;
            startDate = null;
            endDate = null;
            fein = null;
            comment = null;
            Relation = null;
            postOfficeBox = null;
            PreferedChannel = null;
            suffix = null;
        }
    }
}

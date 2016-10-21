// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
	<xsd:complexType name="CompactAddress">
		<xsd:complexContent>
			<xsd:extension base="Address">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element name="addressLines" type="StringList" form="qualified" id="gov_address_addresslines"/>
					<xsd:element ref="City"/>
					<xsd:element ref="County" minOccurs="0"/>
					<xsd:element ref="State" minOccurs="0"/>
					<xsd:element ref="PostalCode" minOccurs="0"/>
					<xsd:element ref="Country" minOccurs="0"/>
					<xsd:element ref="Alias" minOccurs="0"/>
					<xsd:element ref="Contacts" minOccurs="0"/>
					<xsd:element ref="Parcels" minOccurs="0"/>
					<xsd:element ref="SpatialDescriptors" minOccurs="0"/>
					<xsd:element ref="SpatialObjects" minOccurs="0"/>
					<xsd:element ref="GISObjectIds" minOccurs="0"/>
					<xsd:element ref="AdditionalInformation" minOccurs="0"/>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsCompactAddress : clsAddress
    {
        // Members
        public clsKeys Keys { get; set; }

        string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsStringList addressLines { get; set; }

        string _City = null;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public clsCityIdentifier CityIdentifier { get; set; }

        string _County = null;
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }

        string _State = null;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        string _PostalCode = null;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        string _Country = null;  // Max length is 3
        public string Country
        {
            get { return _Country; }
            set 
            { 
                if (value != null && value.Length > 3)
                {
                    _Country = value.Substring(0, 3);
                }
                else
                {
                    _Country = value;
                }
            }
        }
        
        string _Alias = null;
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public clsContacts Contacts { get; set; }
        public clsParcels Parcels { get; set; }
        public clsSpatialDescriptors SpatialDescriptors { get; set; }
        public clsSpatialObjects SpatialObjects { get; set; }
        public clsGISObjectIds GISObjectIds { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsCompactAddress()
        {
        }
    }
}

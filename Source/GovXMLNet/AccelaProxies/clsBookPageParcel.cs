// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="BookPageParcel">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence>
					<xsd:element name="book" type="text" form="qualified"/>
					<xsd:element name="page" type="text" form="qualified"/>
					<xsd:element name="parcel" type="text" form="qualified"/>
					<xsd:element name="referenceAddress" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceEntity" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceLandType" type="text" form="qualified" minOccurs="0"/>
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
    public class clsBookPageParcel : clsSpatialDescriptor
    {
        // Members
        private string _book = null;
        public string book
        {
            get { return _book; }
            set { _book = value; }
        }

        private string _page = null;
        public string page
        {
            get { return _page; }
            set { _page = value; }
        }

        private string _parcel = null;
        public string parcel
        {
            get { return _parcel; }
            set { _parcel = value; }
        }

        private string _referenceAddress = null;
        public string referenceAddress
        {
            get { return _referenceAddress; }
            set { _referenceAddress = value; }
        }

        private string _referenceEntity = null;
        public string referenceEntity
        {
            get { return _referenceEntity; }
            set { _referenceEntity = value; }
        }

        private string _referenceLandType = null;
        public string referenceLandType
        {
            get { return _referenceLandType; }
            set { _referenceLandType = value; }
        }

        // Constructors
        public clsBookPageParcel()
        {
        }

    }
}

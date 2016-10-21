// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GISObjectType">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element ref="GISLayerId" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element ref="GeometryType" minOccurs="0"/>
					<xsd:element ref="Attributes" minOccurs="0"/>
					<xsd:element ref="Extent" minOccurs="0"/>
					<xsd:element ref="Projection" minOccurs="0"/>
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
    public class clsGISObjectType : clsElement
    {
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsGISLayerId GISLayerId { get; set; }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private gisGeometryTypeEnum? _GeometryType = null;
        public gisGeometryTypeEnum? GeometryType
        {
            get
            {
                if (_GeometryType.HasValue)
                {
                    return _GeometryType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _GeometryType = value; }
        }
        public bool GeometryTypeSpecified
        {
            get { return _GeometryType != null; }
        }


        public clsAttributes Attributes { get; set; }
        public clsExtent Extent { get; set; }

        private string _Projection = null;
        public string Projection
        {
            get { return _Projection; }
            set { _Projection = value; }
        }

        // Constructors
        public clsGISObjectType()
        {
        }
    }
}

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GeographicalDescriptor">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence>
					<xsd:element ref="Name"/>
					<xsd:element ref="Value"/>
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
    public class clsGeographicalDescriptor : clsSpatialDescriptor
    {
        // Members
        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        // Constructors
        public clsGeographicalDescriptor()
        {
        }
    }
}

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="MapService">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element name="type" type="gisMapServiceTypeEnum" form="qualified"/>
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
    public class clsMapService
    {
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;        
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private gisMapServiceTypeEnum mType;
        public gisMapServiceTypeEnum type
        {
            get { return mType; }
            set { mType = value; }
        }
        
        // TODO need example
        // Constructors
        public clsMapService()
        {
        }
    }
}

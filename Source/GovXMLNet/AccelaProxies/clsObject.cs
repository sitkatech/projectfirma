using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Object" abstract="true">
		<xsd:complexContent>
			<xsd:extension base="ifc:Object">
				<xsd:attribute name="action" type="dataitemChangeEnum" use="optional"/>
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
    public class clsObject : clsIFCObject
    {
        // Members
        // Note an attribute can't have a nullable object type so have to use ForceExclusion
        private dataitemChangeEnum _action = dataitemChangeEnum.ForceExclusion;
        [XmlAttribute("Action")]
        public dataitemChangeEnum action
        {
            get { return _action; }
            set { _action = value; }

        }
        public bool actionSpecified
        {
            get { return _action != dataitemChangeEnum.ForceExclusion; }
        }

        // Constructors
        public clsObject()
        {
        }
    }
}

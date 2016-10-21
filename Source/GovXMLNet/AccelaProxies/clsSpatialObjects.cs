using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialObjects">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:group ref="SpatialObjectSelect"/>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
	<xsd:group name="SpatialObjectSelect">
		<xsd:choice>
			<xsd:element ref="Establishment"/>
			<xsd:element ref="Parcel"/>
			<xsd:element ref="SpatialObject"/>
			<xsd:element ref="Structure"/>
		</xsd:choice>
	</xsd:group>

 */
/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsSpatialObjects : clsElementList
    {
        // Members
        // TODO this is probably wrong and should use a struct, neeed example       
        [XmlElement(ElementName = "Establishment")]
        public List<clsEstablishment> Establishment { get; set; }

        [XmlElement(ElementName = "Parcel")]
        public List<clsParcel> Parcel { get; set; }

        [XmlElement(ElementName = "SpatialObject")]
        public List<clsSpatialObject> SpatialObject { get; set; }

        [XmlElement(ElementName = "Structure")]
        public List<clsStructure> Structure { get; set; }

        // Constructors
        public clsSpatialObjects()
        {
        }
    }
}

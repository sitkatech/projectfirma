using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

// SpatialDescriptor is an abstract so we need to substitue all of its aliases
/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialDescriptors">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="SpatialDescriptor"/>
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
    public class clsSpatialDescriptors : clsElementList
    {
        // Members
        [XmlElement(ElementName = "MapReference")]
        public List<clsMapReference> MapReference { get; set; }

        [XmlElement(ElementName = "BookPageParcel")]
        public List<clsBookPageParcel> BookPageParcel { get; set; }

        [XmlElement(ElementName = "GISLineSegment")]
        public List<clsGISLineSegment> GISLineSegment { get; set; }

        [XmlElement(ElementName = "GISReference")]
        public List<clsGISReference> GISReference { get; set; }

        [XmlElement(ElementName = "GeographicalDescriptor")]
        public List<clsGeographicalDescriptor> GeographicalDescriptor { get; set; }

        [XmlElement(ElementName = "GPSReference")]
        public List<clsGPSReference> GPSReference { get; set; }

        [XmlElement(ElementName = "LegalDescription")]
        public List<clsLegalDescription> LegalDescription { get; set; }

        [XmlElement(ElementName = "PIN")]
        public List<clsPIN> PIN { get; set; }

        [XmlElement(ElementName = "PLSS")]
        public List<clsPLSS> PLSS { get; set; }     
        
        // Constructors
        public clsSpatialDescriptors()
        {
        }
    }
}

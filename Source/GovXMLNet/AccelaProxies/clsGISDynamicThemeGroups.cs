using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GISDynamicThemeGroups">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="GISDynamicThemeGroup"/>
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
    public class clsGISDynamicThemeGroups : clsElementList
    {
        // Members
        [XmlElement(ElementName = "GISDynamicThemeGroup")]
        public List<clsGISDynamicThemeGroup> GISDynamicThemeGroup { get; set; }

        // Constructors
        public clsGISDynamicThemeGroups()
        {
        }
    }
}

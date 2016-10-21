using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="AssetTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="AssetTypeId"/>
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
    class clsAssetTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "AssetTypeId")]
        public List<clsAssetTypeId> AssetTypeId { get; set; }

        // Constructors
        public clsAssetTypeIds()
        {
        }
    }
}

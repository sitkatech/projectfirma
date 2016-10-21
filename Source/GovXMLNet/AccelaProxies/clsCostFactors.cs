using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CostFactors">
		<xsd:complexContent>
		  <xsd:extension base="elementList">
			<xsd:sequence minOccurs="1" maxOccurs="unbounded">
			  <xsd:element ref="CostFactor" />
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
    public class clsCostFactors : clsElementList
    {
        // Members
        [XmlElement(ElementName = "CostFactor")]
        public List<clsCostFactor> CostFactor { get; set; }

        // Constructors
        public clsCostFactors()
        {
        }
    }
}

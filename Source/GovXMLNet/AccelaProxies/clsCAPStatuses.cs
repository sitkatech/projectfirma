using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="CAPStatuses">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element name="CAPStatus" type="CAPStatus"/>
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
    public class clsCAPStatuses : clsElementList
    {
        [XmlElement(ElementName = "CAPStatus")]
        public List<clsCAPStatus> CAPStatus { get; set; }

        // Constructors
        public clsCAPStatuses()
        {
        }

        // Methods
        public void Add(string pB1ApplStatus = null)
        {
            if (CAPStatus == null)
            {
                CAPStatus = new List<clsCAPStatus>();
            }
            CAPStatus.Add(new clsCAPStatus(pB1ApplStatus));
        }
    }
}

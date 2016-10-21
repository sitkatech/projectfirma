using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Process">
    <xsd:complexContent>
      <xsd:extension base="Entity">
        <xsd:sequence maxOccurs="1">
          <xsd:element ref="TaskItems"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsProcess : clsEntity
    {
        // Members
        [XmlElement("task-items")]
        public clsTaskItems TaskItems { get; set; }

        // Constructors
        public clsProcess()
        {
        }
    }
}

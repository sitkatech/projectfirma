// Defined in AccelaSystemDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="Signature">
    <xsd:sequence>
      <xsd:any/>
    </xsd:sequence>
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
    public class clsSignature
    {
        // Members
        //TODO not sure how this is used, need real world example
        public System.Xml.XmlElement Any { get; set; }

        //Constructors
        public clsSignature()
        {
        }
    }
}

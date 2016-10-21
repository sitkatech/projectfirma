// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
   <xsd:complexType name="Message">
    <xsd:sequence>
      <xsd:element ref="Code" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="Text" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="Detail" minOccurs="0" maxOccurs="1"/>
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
    public class clsMessage
    {
        // Members
        private string _Code = null;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _Detail = null;
        public string Detail
        {
            get { return _Detail; }
            set { _Detail = value; }
        }


        // Constructors
        public clsMessage()
        {
        }


        public clsMessage(string pCode, string pText = "", string pDetail = "")
        {
            Code = pCode;
            Text = pText;
            Detail = pDetail;
        }

    }
}

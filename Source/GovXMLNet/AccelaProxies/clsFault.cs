using System.Runtime.Remoting.Metadata.W3cXsd2001;



// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
 <xsd:complexType name="Fault">
    <xsd:sequence minOccurs="1" maxOccurs="unbounded">
      <xsd:element name="faultcode" type="xsd:QName" form="qualified"/>
      <xsd:element name="faultstring" type="xsd:string" form="qualified"/>
      <xsd:element name="faultactor" type="xsd:anyURI" minOccurs="0" form="qualified"/>
      <xsd:element name="detail" type="FaultDetail" minOccurs="0" form="qualified"/>
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
    public class clsFault
    {
        // Members
        private SoapQName _faultcode = null;
        public SoapQName faultcode
        {
            get { return _faultcode; }
            set { _faultcode = value; }
        }

        private string _faultstring = null;
        public string faultstring
        {
            get { return _faultstring; }
            set { _faultstring = value; }
        }

        private SoapAnyUri _faultactor;
        public SoapAnyUri faultactor
        {
            get { return _faultactor; }
            set { _faultactor = value; }
        }

        private string _detail = null;
        public string detail
        {
            get { return _detail; }
            set { _detail = value; }
        }


        // Constructors
        public clsFault()
        {
        }

    }
}

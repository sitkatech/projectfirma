// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Supply">
    <xsd:complexContent>
      <xsd:extension base="Identifier">
        <xsd:sequence>
          <xsd:element name="locationSeq" type="xsd:nonNegativeInteger" minOccurs="0"/>
          <xsd:element name="locationName" type="xsd:string" minOccurs="0"/>
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
    public class clsSupply : clsIdentifier
    {
        // Members
        private uint? _locationSeq = null;
        public uint? locationSeq
        {
            get
            {
                if (_locationSeq.HasValue)
                {
                    return _locationSeq.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _locationSeq = value; }
        }
        public bool locationSeqSpecified
        {
            get { return _locationSeq != null; }
        }

        private string _locationName = null;
        public string locationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        // Constructors
        public clsSupply()
        {
        }
    }
}

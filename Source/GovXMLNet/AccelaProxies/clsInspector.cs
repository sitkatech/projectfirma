// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Inspector">
    <xsd:complexContent>
      <xsd:extension base="People">
        <xsd:sequence>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element name="Active" type="xsd:boolean" minOccurs="0"/>
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
    public class clsInspector : clsPeople
    {
        // Members
        public clsAdditionalInformation AdditionalInformation { get; set; }

        private bool? _Active = null;
        public bool? Active
        {
            get
            {
                if (_Active.HasValue)
                {
                    return _Active.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _Active = value; }
        }
        public bool ActiveSpecified
        {
            get { return _Active != null; }
        }


        // Constructors
        public clsInspector()
        {
        }
    }
}

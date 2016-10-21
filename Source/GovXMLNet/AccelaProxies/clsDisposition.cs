// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Disposition">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element name="resolutionType" type="resolutionTypeEnum" form="qualified" id="gov_cap_disposition_resolutiontype" minOccurs="0"/>
          <xsd:element ref="StatusGroup"/>
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
    public class clsDisposition : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private resolutionTypeEnum? _resolutionType = null;
        public resolutionTypeEnum? resolutionType
        {
            get
            {
                if (_resolutionType.HasValue)
                {
                    return _resolutionType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _resolutionType = value; }
        }
        public bool resolutionTypeSpecified
        {
            get { return _resolutionType != null; }
        }

        public clsStatusGroup StatusGroup { get; set; }

        // Constructors
        public clsDisposition()
        {
        }
    }
}

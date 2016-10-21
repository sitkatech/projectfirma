// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="ValueRange">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="startingValue" type="xsd:double" form="qualified" minOccurs="0"/>
          <xsd:element name="endingValue" type="xsd:double" form="qualified" minOccurs="0"/>
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
    public class clsValueRange : clsElement
    {
        // Members
        private double? _startingValue = null;
        public double? startingValue
        {
            get
            {
                if (_startingValue.HasValue)
                {
                    return _startingValue.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _startingValue = value; }
        }
        public bool startingValueSpecified
        {
            get { return _startingValue != null; }
        }

        private double? _endingValue = null;
        public double? endingValue
        {
            get
            {
                if (_endingValue.HasValue)
                {
                    return _endingValue.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _endingValue = value; }
        }
        public bool endingValueSpecified
        {
            get { return _endingValue != null; }
        }

        // Constructors
        public clsValueRange()
        {
        }
    }
}

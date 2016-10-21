// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Range">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:sequence minOccurs="0">
            <xsd:element name="minValue" type="xsd:double" form="qualified"/>
            <xsd:element name="minConstraint" type="rangeConstraintEnum" form="qualified" minOccurs="0"/>
          </xsd:sequence>
          <xsd:sequence minOccurs="0">
            <xsd:element name="maxValue" type="xsd:double" form="qualified"/>
            <xsd:element name="maxConstraint" type="rangeConstraintEnum" form="qualified" minOccurs="0"/>
          </xsd:sequence>
          <xsd:element name="processValue" type="rangeProcessValueEnum" form="qualified" minOccurs="0"/>
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
    public class clsRange
    {
        // Members
        private double? _minValue = null;
        public double? minValue
        {
            get
            {
                if (_minValue.HasValue)
                {
                    return _minValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _minValue = value; }
        }
        public bool minValueSpecified
        {
            get { return _minValue != null; }
        }

        private rangeConstraintEnum? _minConstraint = null;
        public rangeConstraintEnum? minConstraint
        {
            get
            {
                if (_minConstraint.HasValue)
                {
                    return _minConstraint.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _minConstraint = value; }
        }
        public bool minConstraintSpecified
        {
            get { return _minConstraint != null; }
        }


        private double? _maxValue = null;
        public double? maxValue
        {
            get
            {
                if (_maxValue.HasValue)
                {
                    return _maxValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _maxValue = value; }
        }
        public bool maxValueSpecified
        {
            get { return _maxValue != null; }
        }


        private rangeConstraintEnum? _maxConstraint = null;
        public rangeConstraintEnum? maxConstraint
        {
            get
            {
                if (_maxConstraint.HasValue)
                {
                    return _maxConstraint.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _maxConstraint = value; }
        }
        public bool maxConstraintSpecified
        {
            get { return _maxConstraint != null; }
        }



        private rangeProcessValueEnum? _processValue = null;
        public rangeProcessValueEnum? processValue
        {
            get
            {
                if (_processValue.HasValue)
                {
                    return _processValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _processValue = value; }
        }
        public bool processValueSpecified
        {
            get { return _processValue != null; }
        }

        // Constructors
        public clsRange()
        {
        }
    }
}

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="AdditionalItem">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element name="contextType" type="dataitemChangeEnum" form="qualified" minOccurs="0"/>
          <xsd:element ref="DataType" minOccurs="0"/>
          <xsd:element ref="Name"/>
          <xsd:element ref="Value"/>
          <xsd:element ref="UnitOfMeasurement" minOccurs="0"/>
          <xsd:element name="security" type="xsd:string" form="qualified" minOccurs="0"/>
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
    public class clsAdditionalItem : clsElement
    {
        // Members

        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private dataitemChangeEnum? _contextType = null;
        public dataitemChangeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        private clsDataType _dataType;
        public clsDataType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private string _UnitOfMeasurement = null;
        public string UnitOfMeasurement
        {
            get { return _UnitOfMeasurement; }
            set { _UnitOfMeasurement = value; }
        }

        private string _security = null;
        public string security
        {
            get { return _security; }
            set { _security = value; }
        }

        // Constructors
        public clsAdditionalItem()
        {
        }
    }
}

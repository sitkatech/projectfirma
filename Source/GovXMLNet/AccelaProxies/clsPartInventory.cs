// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="PartInventory">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Status" minOccurs="0"/>
          <xsd:element name="unitCost" type="xsd:double" minOccurs="0"/>
          <xsd:element name="unitOfMeasure" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="UnitOfMeasureIdentifier" minOccurs="0"/>
          <xsd:element name="partNumber" type="xsd:string" minOccurs="0"/>
          <xsd:element name="totalSupply" type="xsd:double" minOccurs="0"/>
          <xsd:element ref="Supplies" minOccurs="0"/>
          <xsd:element ref="Comments" minOccurs="0"/>
          <xsd:element name="taxable" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="partDescription" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="DescriptionIdentifier" minOccurs="0"/>
          <xsd:element name="partBrand" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="PartBrandIdentifier" minOccurs="0"/>
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
    public class clsPartInventory : clsAttachment
    {
        // Members
        public clsType Type { get; set; }
        public clsStatus Status { get; set; }

        private double? _unitCost = null;
        public double? unitCost
        {
            get
            {
                if (_unitCost.HasValue)
                {
                    return _unitCost.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _unitCost = value; }
        }
        public bool unitCostSpecified
        {
            get { return _unitCost != null; }
        }

        private string _unitOfMeasure = null;
        public string unitOfMeasure
        {
            get { return _unitOfMeasure; }
            set { _unitOfMeasure = value; }
        }

        public clsUnitOfMeasureIdentifier UnitOfMeasureIdentifier { get; set; }

        private string _partNumber = null;
        public string partNumber
        {
            get { return _partNumber; }
            set { _partNumber = value; }
        }

        private double? _totalSupply = null;
        public double? totalSupply
        {
            get
            {
                if (_totalSupply.HasValue)
                {
                    return _totalSupply.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _totalSupply = value; }
        }
        public bool totalSupplySpecified
        {
            get { return _totalSupply != null; }
        }

        public clsSupplies Supplies { get; set; }

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        private string _taxable = null;
        public string taxable
        {
            get { return _taxable; }
            set { _taxable = value; }
        }

        private string _partDescription = null;
        public string partDescription
        {
            get { return _partDescription; }
            set { _partDescription = value; }
        }

        public clsDescriptionIdentifier DescriptionIdentifier { get; set; }

        private string _partBrand = null;
        public string partBrand
        {
            get { return _partBrand; }
            set { _partBrand = value; }
        }

        public clsPartBrandIdentifier PartBrandIdentifier { get; set; }

        // Constructors
        public clsPartInventory()
        {
        }
    }
}

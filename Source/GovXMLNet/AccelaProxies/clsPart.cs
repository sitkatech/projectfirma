using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Part">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Status" minOccurs="0"/>
          <xsd:element ref="PartInventoryId" minOccurs="0"/>
          <xsd:element name="unitCost" type="xsd:double" minOccurs="0"/>
          <xsd:element name="unitOfMeasure" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="UnitOfMeasureIdentifier" minOccurs="0"/>
          <xsd:element name="partNumber" type="xsd:string" minOccurs="0"/>
          <xsd:element name="quantity" type="xsd:double" minOccurs="0"/>
          <xsd:element name="TransactionDate" type="calendarDate" minOccurs="0"/>
          <xsd:element ref="Comments" minOccurs="0"/>
          <xsd:element ref="Supplies" minOccurs="0"/>
          <xsd:element name="bin" type="xsd:string" minOccurs="0"/>
          <xsd:element name="partDescription" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="DescriptionIdentifier" minOccurs="0"/>
          <xsd:element name="partBrand" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="PartBrandIdentifier" minOccurs="0"/>
          <xsd:element name="taxable" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="altID" type="xsd:string" minOccurs="0" maxOccurs="1" />
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
    public class clsPart : clsAttachment
    {
        // Members
        public clsType Type { get; set; }
        public clsStatus Status { get; set; }
        public clsPartInventoryId PartInventoryId { get; set; }

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

        private double? _quantity = null;
        public double? quantity
        {
            get
            {
                if (_quantity.HasValue)
                {
                    return _quantity.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _quantity = value; }
        }
        public bool quantitySpecified
        {
            get { return _quantity != null; }
        }


        [XmlIgnore]
        public DateTime? TransactionDate { get; set; }
        [XmlElement("TransactionDate")]
        public string TransactionDateString
        {
            get
            {
                if (TransactionDate.HasValue)
                {
                    return TransactionDate.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    TransactionDate = td;
                }
                else
                {
                    TransactionDate = null;
                }
            }
        }
        public bool TransactionDateStringSpecified
        {
            get { return TransactionDate != null; }
        }

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        public clsSupplies Supplies { get; set; }

        private string _bin = null;
        public string bin
        {
            get { return _bin; }
            set { _bin = value; }
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

        private string _taxable = null;
        public string taxable
        {
            get { return _taxable; }
            set { _taxable = value; }
        }

        private string _altID = null;
        public string altID
        {
            get { return _altID; }
            set { _altID = value; }
        }

        // Constructors
        public clsPart()
        {
        }
    }
}

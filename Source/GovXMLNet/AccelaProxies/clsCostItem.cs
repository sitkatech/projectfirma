using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="CostItem">
    <xsd:complexContent>
      <xsd:extension base="Attachment">
        <xsd:sequence>
          <xsd:element name="contextType" type="dataitemChangeEnum" form="qualified"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="CostItemTypeId" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="Status" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="costItem" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="CostDate" type="calendarDate" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="quantity" type="xsd:double" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="unitCost" type="xsd:double" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="unitOfMeasure" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element ref="CostUnitOfMeasureIdentifier" minOccurs="0"/>
          <xsd:element name="totalCost" type="xsd:double" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="costAccount" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element ref="CostAccountIdentifier" minOccurs="0"/>
          <xsd:element name="costFix" type="xsd:double" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="costFactor" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="formula" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="subgroup" type="xsd:string" minOccurs="0" maxOccurs="1"/>
          <xsd:element ref="Comments" minOccurs="0" maxOccurs="1"/>
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
    public class clsCostItem : clsAttachment
    {
        // Members
        private dataitemChangeEnum _contextType;
        public dataitemChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsType Type { get; set; }

        private string _costItem = null;
        public string costItem
        {
            get { return _costItem; }
            set { _costItem = value; }
        }

        [XmlIgnore]
        public DateTime? CostDate { get; set; }
        [XmlElement("CostDate")]
        public string CostDateString
        {
            get
            {
                if (CostDate.HasValue)
                {
                    return CostDate.Value.ToString(Constants.cDateFormat); ;
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
                    CostDate = td;
                }
                else
                {
                    CostDate = null;
                }
            }
        }
        public bool CostDateStringSpecified
        {
            get { return CostDate != null; }
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

        public clsCostUnitOfMeasureIdentifier CostUnitOfMeasureIdentifier { get; set; }

        private double? _totalCost = null;
        public double? totalCost
        {
            get
            {
                if (_totalCost.HasValue)
                {
                    return _totalCost.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _totalCost = value; }
        }
        public bool totalCostSpecified
        {
            get { return _totalCost != null; }
        }

        private string _costAccount = null;
        public string costAccount
        {
            get { return _costAccount; }
            set { _costAccount = value; }
        }

        public clsCostAccountIdentifier CostAccountIdentifier { get; set; }

        private double? _costFix = null;
        public double? costFix
        {
            get
            {
                if (_costFix.HasValue)
                {
                    return _costFix.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _costFix = value; }
        }
        public bool costFixSpecified
        {
            get { return _costFix != null; }
        }

        private string _costFactor = null;
        public string costFactor
        {
            get { return _costFactor; }
            set { _costFactor = value; }
        }

        private string _formula = null;
        public string formula
        {
            get { return _formula; }
            set { _formula = value; }
        }

        private string _subgroup = null;
        public string subgroup
        {
            get { return _subgroup; }
            set { _subgroup = value; }
        }

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        // Constructors
        public clsCostItem()
        {
        }
    }
}

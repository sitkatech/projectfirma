using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="Asset">
    <xsd:complexContent>
      <xsd:extension base="Entity">
        <xsd:sequence>
          <xsd:element name="contextType" type="capTypeEnum" form="qualified" minOccurs="0"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="Status"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="DescriptionIdentifier" minOccurs="0"/>
          <xsd:element ref="Comments" minOccurs="0"/>
          <xsd:element ref="CommentsIdentifier" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element name="startValue" type="xsd:double" minOccurs="0"/>
          <xsd:element name="usefulLife" type="xsd:double" minOccurs="0"/>
          <xsd:element name="dateOfServiceRange" type="DateRange" minOccurs="0"/>
          <xsd:element name="salvageValue" type="xsd:double" minOccurs="0"/>
          <xsd:element name="currentValue" type="xsd:double" minOccurs="0"/>
          <xsd:element name="startDate" type="calendarDate" minOccurs="0"/>
          <xsd:element name="statusDates" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="endDate" type="calendarDate" minOccurs="0"/>
          <xsd:element name="depreciationAmount" type="xsd:double" minOccurs="0"/>
          <xsd:element name="depreciationValue" type="xsd:double" minOccurs="0"/>
          <xsd:element ref="GISObjects" minOccurs="0" maxOccurs="1" />
          <xsd:element name="CompletedDate" type="calendarDate" minOccurs="0" maxOccurs="1" />
          <xsd:element name="Order" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="PartInventoryIds" />
          <xsd:element name="size" type="xsd:string" minOccurs="0"/>
          <xsd:element name="SizeUnit" ref="Identifier" minOccurs="0"/>
          <xsd:element name="costLTD" type="xsd:string " minOccurs="0"/>
          <xsd:element name="classType" type="xsd:string" minOccurs="0"/>
          <xsd:element name="AssetParentID" ref="AssetId" minOccurs="0"/>
          <xsd:element ref="Usages" minOccurs="0"/>
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
    public class clsAsset : clsEntity
    {
        // Members
        private capTypeEnum? _contextType = null;
        public capTypeEnum? contextType
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


        public clsType Type { get; set; }
        public clsStatus Status { get; set; }

        // TODO need example to see if it is indented or on the same level in XML
        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public clsDescriptionIdentifier DescriptionIdentifier { get; set; }

        private string _Comments = null;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        public clsCommentsIdentifier CommentsIdentifier { get; set; }

        public clsAdditionalInformation AdditionalInformation { get; set; }

        private double? _startValue = null;
        public double? startValue
        {
            get
            {
                if (_startValue.HasValue)
                {
                    return _startValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _startValue = value; }
        }
        public bool startValueSpecified
        {
            get { return _startValue != null; }
        }

        private double? _usefulLife = null;
        public double? usefulLife
        {
            get
            {
                if (_usefulLife.HasValue)
                {
                    return _usefulLife.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _usefulLife = value; }
        }
        public bool usefulLifeSpecified
        {
            get { return _usefulLife != null; }
        }

        public clsDateRange dateOfServiceRange { get; set; }

        private double? _salvageValue = null;
        public double? salvageValue
        {
            get
            {
                if (_salvageValue.HasValue)
                {
                    return _salvageValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _salvageValue = value; }
        }
        public bool salvageValueSpecified
        {
            get { return _salvageValue != null; }
        }

        private double? _currentValue = null;
        public double? currentValue
        {
            get
            {
                if (_currentValue.HasValue)
                {
                    return _currentValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _currentValue = value; }
        }
        public bool currentValueSpecified
        {
            get { return _currentValue != null; }
        }

        [XmlIgnore]
        public DateTime? startDate { get; set; }
        [XmlElement("startDate")]
        public string startDateString
        {
            get
            {
                if (startDate.HasValue)
                {
                    return startDate.Value.ToString(Constants.cDateFormat); ;
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
                    startDate = td;
                }
                else
                {
                    startDate = null;
                }
            }
        }
        public bool startDateStringSpecified
        {
            get { return startDate != null; }
        }

        private string _statusDates = null;
        public string statusDates
        {
            get { return _statusDates; }
            set { _statusDates = value; }
        }

        [XmlIgnore]
        public DateTime? endDate { get; set; }
        [XmlElement("endDate")]
        public string endDateString
        {
            get
            {
                if (endDate.HasValue)
                {
                    return endDate.Value.ToString(Constants.cDateFormat); ;
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
                    endDate = td;
                }
                else
                {
                    endDate = null;
                }
            }
        }
        public bool endDateStringSpecified
        {
            get { return endDate != null; }
        }

        private double? _depreciationAmount = null;
        public double? depreciationAmount
        {
            get
            {
                if (_depreciationAmount.HasValue)
                {
                    return _depreciationAmount.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _depreciationAmount = value; }
        }
        public bool depreciationAmountSpecified
        {
            get { return _depreciationAmount != null; }
        }

        private double? _depreciationValue = null;
        public double? depreciationValue
        {
            get
            {
                if (_depreciationValue.HasValue)
                {
                    return _depreciationValue.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _depreciationValue = value; }
        }
        public bool depreciationValueSpecified
        {
            get { return _depreciationValue != null; }
        }

        public clsGISObjects GISObjects { get; set; }

        [XmlIgnore]
        public DateTime? CompletedDate { get; set; }
        [XmlElement("CompletedDate")]
        public string CompletedDateString
        {
            get
            {
                if (CompletedDate.HasValue)
                {
                    return CompletedDate.Value.ToString(Constants.cDateFormat); ;
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
                    CompletedDate = td;
                }
                else
                {
                    CompletedDate = null;
                }
            }
        }
        public bool CompletedDateStringSpecified
        {
            get { return CompletedDate != null; }
        }

        private string _Order = null;
        public string Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        public clsPartInventoryIds PartInventoryIds { get; set; }

        private string _size = null;
        public string size
        {
            get { return _size; }
            set { _size = value; }
        }

        public clsIdentifier SizeUnit { get; set; }

        private string _costLTD = null;
        public string costLTD
        {
            get { return _costLTD; }
            set { _costLTD = value; }
        }

        private string _classType = null;
        public string classType
        {
            get { return _classType; }
            set { _classType = value; }
        }

        public clsAssetId AssetParentID { get; set; }

        public clsUsages Usages { get; set; }


        //Constructors
        public clsAsset()
        {
        }

    }
}

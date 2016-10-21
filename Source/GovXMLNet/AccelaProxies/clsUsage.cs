using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="Usage">
    <xsd:complexContent>
      <xsd:extension base="Entity">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="AssetId" minOccurs="0"/>
          <xsd:element name="reading" type="xsd:double" minOccurs="0"/>
          <xsd:element name="difference" type="xsd:double" minOccurs="0"/>
          <xsd:element name="UnitType" ref="Type" minOccurs="0"/>
          <xsd:element name="readingDate" type="xsd:string" minOccOURS="0"/>
          <xsd:element name="ReadingByDepartment" ref="Department" minOccurs="0"/>
          <xsd:element name="CapId" ref="CAPId" minOccurs="0"/>
          <xsd:element name="comments" type="xsd:string" minOccurs="0"/>
          <xsd:element name="generatedWO" type="xsd:string" minOccurs="0"/>
          <xsd:attribute name="action" type="dataitemChangeEnum" use="optional">
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
    public class clsUsage : clsEntity
    {
        // Members
        // public clsKeys Keys { get; set; } Should be part of clsEntity
        public clsAssetId AssetId { get; set; }

        private double? _reading = null;
        public double? reading
        {
            get
            {
                if (_reading.HasValue)
                {
                    return _reading.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _reading = value; }
        }
        public bool readingSpecified
        {
            get { return _reading != null; }
        }

        private double? _difference = null;
        public double? difference
        {
            get
            {
                if (_difference.HasValue)
                {
                    return _difference.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _difference = value; }
        }
        public bool differenceSpecified
        {
            get { return _difference != null; }
        }

        public clsType UnitType;

        [XmlIgnore]
        public DateTime? readingDate  { get; set; }
        [XmlElement("readingDate")]
        public string readingDateString
        {
            get
            {
                if (readingDate.HasValue)
                {
                    return readingDate.Value.ToString(Constants.cDateFormat); ;
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
                    readingDate = td;
                }
                else
                {
                    readingDate = null;
                }
            }
        }
        public bool readingDateStringSpecified
        {
            get { return readingDate != null; }
        }

        public clsDepartment ReadingByDepartment { get; set; }

        public clsCAPId CAPId { get; set; }

        private string _comments;
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        private string _generatedWO;
        public string generatedWO
        {
            get { return _generatedWO; }
            set { _generatedWO = value; }
        }

        /* Should be inherited from clsObject which gets it from clsObject
        private dataitemChangeEnum _action = dataitemChangeEnum.ForceExclusion;  // Attribute so can't use nullable type
        [XmlAttribute("action")]
        public dataitemChangeEnum action
        {
            get { return _action; }
            set { _action = value; }
        }
        public bool actionSpecified
        {
            get { return _action != dataitemChangeEnum.ForceExclusion; }
        }
        */
        // Constructors
        public clsUsage()
        {
        }
    }
}

using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Department">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:sequence maxOccurs="unbounded">
            <xsd:element name="agencyCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="bureauCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="divisionCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="sectionCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="groupCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="officeCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="subgroupCode" type="xsd:string" minOccurs="0"/>
            <xsd:element name="subgroupDesc" type="xsd:string" minOccurs="0"/>
            <xsd:element ref="Staff" minOccurs="0"/>
          </xsd:sequence>
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
    public class clsDepartment : clsElement
    {
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _agencyCode = null;
        public string agencyCode
        {
            get { return _agencyCode; }
            set { _agencyCode = value; }
        }

        private string _bureauCode = null;
        public string bureauCode
        {
            get { return _bureauCode; }
            set { _bureauCode = value; }
        }

        private string _divisionCode = null;
        public string divisionCode
        {
            get { return _divisionCode; }
            set { _divisionCode = value; }
        }

        private string _sectionCode = null;
        public string sectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        private string _groupCode = null;
        public string groupCode
        {
            get { return _groupCode; }
            set { _groupCode = value; }
        }

        private string _officeCode = null;
        public string officeCode
        {
            get { return _officeCode; }
            set { _officeCode = value; }
        }

        private string _subgroupCode = null;
        public string subgroupCode
        {
            get { return _subgroupCode; }
            set { _subgroupCode = value; }
        }

        private string _subgroupCodeDesc = null;
        public string subgroupCodeDesc
        {
            get { return _subgroupCodeDesc; }
            set { _subgroupCodeDesc = value; }
        }

        public clsStaff Staff { get; set; }

        // Constructors
        public clsDepartment()
        {
        }

        public clsDepartment(string pAgencyCode, string pBureauCode = "NA", string pDivisionCode = "NA", string pSectionCode = "NA", string pGroupCode = "NA", string pSubgroupCode = "NA")
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pAgencyCode, pBureauCode , pDivisionCode , pSectionCode , pGroupCode, pSubgroupCode });
            }
            else
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                else
                {
                    Keys.Key.Clear();
                }
                Keys.Key.AddRange(new string[] { pAgencyCode, pBureauCode, pDivisionCode, pSectionCode, pGroupCode, pSubgroupCode });
            }

        }

    }
}

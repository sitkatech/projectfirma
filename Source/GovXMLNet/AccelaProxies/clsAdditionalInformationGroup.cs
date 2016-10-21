using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="AdditionalInformationGroup">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys" minOccurs="0"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element name="contextType" type="datasetChangeEnum" form="qualified" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element name="addRemoveSubGroups" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:sequence maxOccurs="unbounded">
            <xsd:element ref="AdditionalInformationSubGroup"/>
          </xsd:sequence>
          <xsd:element name="security" type="xsd:string" form="qualified" minOccurs="0"/>
          <xsd:element ref="EnumerationLists" minOccurs="0"/>
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
    public class clsAdditionalInformationGroup : clsElement
    {
        // members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private datasetChangeEnum? _contextType = null;
        public datasetChangeEnum? contextType
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

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool? _addRemoveSubGroups = null;
        public bool? addRemoveSubGroups
        {
            get
            {
                if (_addRemoveSubGroups.HasValue)
                {
                    return _addRemoveSubGroups.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _addRemoveSubGroups = value; }
        }
        public bool addRemoveSubGroupsSpecified
        {
            get { return _addRemoveSubGroups != null;  }
        }

        [XmlElementAttribute("AdditionalInformationSubGroup")]
        public List<clsAdditionalInformationSubGroup> AdditionalInformationSubGroup { get; set; }

        private string _security = null;
        public string security
        {
            get { return _security; }
            set { _security = value; }
        }

        public clsEnumerationLists EnumerationLists { get; set; }

        // Constructors
        public clsAdditionalInformationGroup()
        {
        }
    }
}

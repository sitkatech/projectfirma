using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="InspectionDistrict">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element ref="City" minOccurs="0"/>
          <xsd:element ref="County" minOccurs="0"/>
          <xsd:element ref="State" minOccurs="0"/>
          <xsd:element ref="PostalCode" minOccurs="0"/>
          <xsd:element ref="Country" minOccurs="0"/>
          <xsd:element ref="Alias" minOccurs="0"/>
          <xsd:element ref="SpatialDescriptors" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsInspectionDistrict : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _City = null;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private string _County = null;
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }

        private string _State = null;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _PostalCode = null;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        string _Country = null;  // Max length is 3
        public string Country
        {
            get { return _Country; }
            set
            {
                if (value != null && value.Length > 3)
                {
                    _Country = value.Substring(0, 3);
                }
                else
                {
                    _Country = value;
                }
            }
        }

        private string _Alias = null;
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }

        public clsSpatialDescriptors SpatialDescriptors { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsInspectionDistrict()
        {
        }

        public clsInspectionDistrict(string pInspectionDistrict)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pInspectionDistrict });
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
                Keys.Key.AddRange(new string[] { pInspectionDistrict });
            }
        }
    }
}

using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="CAPStatus">
    <xsd:complexContent>
      <xsd:extension base="Status">
        <xsd:sequence>
          <xsd:element ref="CapStatusGroup"/>
          <xsd:element ref ="IdentifierDisplay"/>
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
    public class clsCAPStatus : clsStatus
    {
        public clsCapStatusGroup CapStatusGroup { get; set; }

        /*  This is inherited from clsStatus
        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }
        */
        // Constructors
        public clsCAPStatus()
        {
        }


        public clsCAPStatus(string pB1ApplStatus)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1ApplStatus });
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
                Keys.Key.AddRange(new string[] { pB1ApplStatus });
            }
        }
    }
}

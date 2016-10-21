// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="ParcelRelations ">
    <xsd:complexContent>
      <xsd:extension base="elementList">
        <xsd:sequence maxOccurs="unbounded">
          <xsd:element ref="ParcelRelation"/>
          <xsd:element name="transactionTime" type="xsd:string" minOccurs="0" />
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
    public class clsParcelRelations : clsElementList
    {
        // Methods
        public clsParcelRelation ParcelRelation { get; set; }

        // TODO these probably need to be combined into a struct
        private string _transactionTime = null;
        public string transactionTime
        {
            get { return _transactionTime; }
            set { _transactionTime = value; }
        }

        // Constructors
        public clsParcelRelations()
        {
        }

    }
}

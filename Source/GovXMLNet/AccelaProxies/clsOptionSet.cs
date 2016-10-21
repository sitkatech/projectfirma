// Defined in AccelaSharedDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="OptionSet">
    <xsd:sequence>
      <xsd:element name="contextType" type="datasetChangeEnum" minOccurs="0" maxOccurs="1" form="qualified"/>
      <xsd:element name="Name" type="xsd:string" form="qualified"/>
      <xsd:element name="Options" minOccurs="0" maxOccurs="1"/>
    </xsd:sequence>
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
    public class clsOptionSet
    {
        // Members
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

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public clsOptions Options { get; set; }


        // Constructors
        public clsOptionSet()
        {            
        }
    }
}

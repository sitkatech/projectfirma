using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="PhysicalDocumentLocator">
		<xsd:complexContent>
			<xsd:extension base="DocumentLocator">
				<xsd:sequence>
					<xsd:element name="location" type="xsd:string" form="qualified"/>
					<xsd:element ref="Date" minOccurs="0"/>
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
    public class clsPhysicalDocumentLocator : clsDocumentLocator
    {
        // Members
        private string _location = null;
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }

        [XmlIgnore]
        public DateTime? Date { get; set; }
        [XmlElement("Date")]
        public string DateString
        {
            get
            {
                if (Date.HasValue)
                {
                    return Date.Value.ToString(Constants.cDateFormat); ;
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
                    Date = td;
                }
                else
                {
                    Date = null;
                }
            }
        }
        public bool DateStringSpecified
        {
            get { return Date != null; }
        }

        // Constructors
        public clsPhysicalDocumentLocator()
        {
        }
    }
}

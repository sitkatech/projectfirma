using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="GISGenealogicEvent">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element name="actionId" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="actionDateTime" type="xsd:dateTime" form="qualified" minOccurs="0"/>
					<xsd:element name="before" form="qualified">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element ref="GISObjectIds"/>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="after" form="qualified">
						<xsd:complexType>
							<xsd:sequence>
								<xsd:element ref="GISObjectIds"/>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
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
    public class clsGISGenealogicEvent : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _actionId = null;
        public string actionId
        {
            get { return _actionId; }
            set { _actionId = value; }
        }

        [XmlIgnore]
        public DateTime? actionDateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("actionDateTime")]
        public string actionDateTimeString
        {
            get
            {
                if (actionDateTime.HasValue)
                {
                    return actionDateTime.Value.ToString(Constants.cDateTimeFormat);
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
                    actionDateTime = td;
                }
            }
        }
        public bool actionDateTimeStringSpecified
        {
            get { return actionDateTime != null; }
        }

        public clsGISObjectIds before { get; set; }

        public clsGISObjectIds after { get; set; }

        // Constructors
        public clsGISGenealogicEvent()
        {
        }
    }
}

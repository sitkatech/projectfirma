using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="SetGISObjectsGenealogy">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
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
    public class msgSetGISObjectsGenealogy : clsOperationRequest
    {
        // Members
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

        private DateTime? _actionDateTime = null;
        [XmlIgnore]
        public DateTime? actionDateTime 
        {
            get { return _actionDateTime; }
            set { _actionDateTime = value; }
        }
        [XmlElement("actionDateTime")]
        public string actionDateTimeString
        {
            get
            {
                if (_actionDateTime.HasValue)
                {
                    return _actionDateTime.Value.ToString(Constants.cDateFormat); ;
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
                    _actionDateTime = td;
                }
                else
                {
                    _actionDateTime = null;
                }
            }
        }
        public bool actionDateTimeStringSpecified
        {
            get { return _actionDateTime != null; }
        }

        public clsGISObjectIds before { get; set; }

        public clsGISObjectIds after { get; set; }

        // Constructors
        public msgSetGISObjectsGenealogy()
        {
        }
    }
}

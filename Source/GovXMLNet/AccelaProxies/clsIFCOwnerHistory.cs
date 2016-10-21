using System;
using System.Xml.Serialization;

// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="OwnerHistory">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element name="owningUser">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="PersonAndOrganization"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element name="owningApplication">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Application"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="StateEnum" minOccurs="0" name="state"/>
				<xsd:element type="ChangeActionEnum" name="changeAction"/>
				<xsd:element type="TimeStamp" minOccurs="0" name="lastModifiedDate"/>
				<xsd:element minOccurs="0" name="lastModifyingUser">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="PersonAndOrganization"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element minOccurs="0" name="lastModifyingApplication">
					<xsd:complexType>
						<xsd:choice>
							<xsd:element ref="Application"/>
						</xsd:choice>
					</xsd:complexType>
				</xsd:element>
				<xsd:element type="TimeStamp" name="creationDate"/>
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
    public class clsIFCOwnerHistory : clsIFCelementID
    {
        // Members
        public clsIFCPersonAndOrganization owningUser { get; set; }

        public clsIFCApplication owningApplication { get; set; }

        private StateEnum? _state = null;
        public StateEnum? state
        {
            get
            {
                if (_state.HasValue)
                {
                    return _state.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _state = value; }
        }
        public bool stateSpecified
        {
            get { return _state != null; }
        }

        private ChangeActionEnum? _changeAction = null;
        public ChangeActionEnum? changeAction
        {
            get
            {
                if (_changeAction.HasValue)
                {
                    return _changeAction.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _changeAction = value; }
        }
        public bool changeActionSpecified
        {
            get { return _changeAction != null; }
        }

        [XmlIgnore]
        public DateTime? lastModifiedDate { get; set; }
        [XmlElement("lastModifiedDate")]
        public string lastModifiedDateString
        {
            get { return lastModifiedDate.Value.ToString(Constants.cDateTimeFormat); }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    lastModifiedDate = td;
                }
                else
                {
                    lastModifiedDate = null;
                }
            }
        }
        public bool lastModifiedDateStringSpecified
        {
            get
            {
                if (lastModifiedDate == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public clsIFCPersonAndOrganization lastModifyUser { get; set; }

        public clsIFCApplication lastModifyingApplication { get; set; }

        [XmlIgnore]
        public DateTime? creationDate { get; set; }
        [XmlElement("creationDate")]
        public string creationDateString
        {
            get { return creationDate.Value.ToString(Constants.cDateTimeFormat); }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    creationDate = td;
                }
                else
                {
                    creationDate = null;
                }
            }
        }
        public bool creationDateStringSpecified
        {
            get
            {
                if (creationDate == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        
        // Constructors
        public clsIFCOwnerHistory()
        {
        }
    }
}

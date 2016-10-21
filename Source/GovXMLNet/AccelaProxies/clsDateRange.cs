using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DateRange">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:sequence minOccurs="0">
						<xsd:element name="from" type="calendarDate" form="qualified"/>
						<xsd:element name="fromConstraint" type="rangeConstraintEnum" form="qualified" minOccurs="0"/>
					</xsd:sequence>
					<xsd:sequence minOccurs="0">
						<xsd:element name="to" type="calendarDate" form="qualified"/>
						<xsd:element name="toConstraint" type="rangeConstraintEnum" form="qualified" minOccurs="0"/>
					</xsd:sequence>
					<xsd:element name="processValue" type="rangeProcessValueEnum" form="qualified" minOccurs="0"/>
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
    public class clsDateRange : clsElement
    {
        // Members
        [XmlIgnore]
        public DateTime? from { get; set; }
        [XmlElement("from")]
        public string fromString
        {
            get
            {
                if (from.HasValue)
                {
                    return from.Value.ToString(Constants.cDateFormat); ;
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
                    from = td;
                }
                else
                {
                    from = null;
                }
            }
        }
        public bool fromStringSpecified
        {
            get { return from != null; }
        }

        private rangeConstraintEnum? _fromConstraint = null;
        public rangeConstraintEnum? fromConstraint
        {
            get
            {
                if (_fromConstraint.HasValue)
                {
                    return _fromConstraint.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _fromConstraint = value; }
        }
        public bool fromConstraintSpecified
        {
            get { return _fromConstraint != null; }
        }

        [XmlIgnore]
        public DateTime? to { get; set; }
        [XmlElement("to")]
        public string toString
        {
            get
            {
                if (to.HasValue)
                {
                    return to.Value.ToString(Constants.cDateFormat); ;
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
                    to = td;
                }
                else
                {
                    to = null;
                }
            }
        }
        public bool toStringSpecified
        {
            get { return to != null; }
        }

        private rangeConstraintEnum? _toConstraint = null;
        public rangeConstraintEnum? toConstraint
        {
            get
            {
                if (_toConstraint.HasValue)
                {
                    return _toConstraint.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _toConstraint = value; }
        }
        public bool toConstraintSpecified
        {
            get { return _toConstraint != null; }
        }

        private rangeConstraintEnum? _processValue = null;
        public rangeConstraintEnum? processValue
        {
            get
            {
                if (_processValue.HasValue)
                {
                    return _processValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _processValue = value; }
        }
        public bool processValueSpecified
        {
            get { return _processValue != null; }
        }

        // Constructors
        public clsDateRange()
        {
        }

        public clsDateRange(DateTime pFrom, DateTime pTo)
        {
            from = pFrom;
            to = pTo;
        }
    }
}

using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjectsGenealogy">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:choice>
					<xsd:element name="actionId" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="actionDateTime" type="xsd:dateTime" form="qualified" minOccurs="0"/>
					<xsd:element ref="GISObjectIds" minOccurs="0"/>
				</xsd:choice>
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
    public class msgGetGISObjectsGenealogy : clsOperationRequest
    {
        // Members
        // Start choice eChoiceGetGISObjectsGenealogy
        private string _actionId = null;
        public string actionId
        {
            get { return _actionId; }
            set 
            { 
                _actionId = value;
                ChoiceClearAllBut(eChoiceGetGISObjectsGenealogy.scActionId);
            }
        }

        private DateTime? _actionDateTime = null;
        [XmlIgnore]
        public DateTime? actionDateTime
        {
            get { return _actionDateTime; }
            set 
            { 
                _actionDateTime = value; 
            }
        }
        [XmlElement("actionDateTime")]
        public string actionDateTimeString
        {
            get
            {
                if (_actionDateTime.HasValue)
                {
                    return _actionDateTime.Value.ToString(Constants.cDateTimeFormat); ;
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
                ChoiceClearAllBut(eChoiceGetGISObjectsGenealogy.scActionDateTime);
            }
        }
        public bool actionDateTimeStringSpecified
        {
            get { return _actionDateTime != null; }
        }

        private clsGISObjectIds _GISObjectIds = null;
        public clsGISObjectIds GISObjectIds 
        {
            get { return _GISObjectIds; }
            set 
            {
                _GISObjectIds = value;
                ChoiceClearAllBut(eChoiceGetGISObjectsGenealogy.scGISObjectIds);
            }
        }
        // Start choice eChoiceGetGISObjectsGenealogy

        // Constructors
        public msgGetGISObjectsGenealogy()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceGetGISObjectsGenealogy pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGetGISObjectsGenealogy.scActionId)
            {
                _actionId = null;
            }
            if (pSelectedChoice != eChoiceGetGISObjectsGenealogy.scActionDateTime)
            {
                _actionDateTime = null;
            }
            if (pSelectedChoice != eChoiceGetGISObjectsGenealogy.scGISObjectIds)
            {
                _GISObjectIds = null;
            }
        }
    }
}

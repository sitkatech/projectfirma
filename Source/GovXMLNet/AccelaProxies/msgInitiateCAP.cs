using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="InitiateCAP">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="validatingLicenses" type="Licenses" form="qualified" minOccurs="0"/>
          <xsd:element ref="CAPTypeId"/>
          <xsd:element ref="CAPId" minOccurs="0"/>
          <xsd:element ref="FileDate" minOccurs="0"/>
          <xsd:element name="Status" type="CAPStatus" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="Name" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:element ref="CompactAddressId"/>
            <xsd:element ref="DetailAddress"/>
          </xsd:choice>
          <xsd:element ref="DetailAddresses" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:element ref="GISObjectIds"/>
            <xsd:element ref="GISObjects"/>
          </xsd:choice>
          <xsd:choice minOccurs="0">
            <xsd:element ref="ParcelIds"/>
            <xsd:element ref="Parcels"/>
          </xsd:choice>
          <xsd:element ref="Applicant" minOccurs="0"/>
          <xsd:element ref="CAPRelations" minOccurs="0"/>
          <xsd:element ref="Contacts" minOccurs="0"/>
          <xsd:element ref="Licenses" minOccurs="0"/>
          <xsd:element ref="SpatialDescriptors" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element name="parentCAPIds" type="CAPIds" form="qualified" minOccurs="0"/>
          <xsd:element name="finalizeNow" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
          <xsd:element ref="Assets" minOccurs="0"/>
          <xsd:element ref="Parts" minOccurs="0"/>
          <xsd:element ref="CostItems" minOccurs="0"/>
          <xsd:element ref="Department" minOccurs="0"/>
          <xsd:element ref="StaffPerson" minOccurs="0"/>
          <xsd:element name="assignedDate" type="xsd:string" minOccurs="0"/>
          <xsd:element name="scheduleDate" type="xsd:string" minOccurs="0"/>
          <xsd:element name="scheduleTime" type="xsd:string" minOccurs="0"/>
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
    public class msgInitiateCAP : clsOperationRequest
    {
        // Members
        public clsLicenses validatingLicenses { get; set; }

        public clsCAPTypeId CAPTypeId { get; set; }

        public clsCAPId CAPId { get; set; }

        private DateTime? _FileDate = null;
        [XmlIgnore]
        public DateTime? FileDate
        {
            get { return _FileDate; }
            set { _FileDate = value; }
        }
        [XmlElement("FileDate")]
        public string FileDateString
        {
            get
            {
                if (_FileDate.HasValue)
                {
                    return _FileDate.Value.ToString(Constants.cDateTimeFormat); ;
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
                    _FileDate = td;
                }
                else
                {
                    _FileDate = null;
                }
            }
        }
        public bool FileDateStringSpecified
        {
            get { return _FileDate != null; }
        }

        public clsCAPStatus Status { get; set; }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        // Begin Choice
        private clsDetailAddress _DetailAddress = null;
        public clsDetailAddress DetailAddress
        {
            get { return _DetailAddress; }
            set
            {
                _DetailAddress = value;
                ChoiceClearAllButAddress(eChoiceInitiateCAPAddress.scDetailAddress);
            }
        }
        // End choice


        public clsDetailAddresses DetailAddresses { get; set; }


        // Begin Choice
        private clsGISObjectIds _GISObjectIds = null;
        public clsGISObjectIds GISObjectIds
        {
            get { return _GISObjectIds; }
            set
            {
                _GISObjectIds = value;
                ChoiceClearAllButGIS(eChoiceInitiateCAPGIS.scGISObjectIds);
            }
        }

        private clsGISObjects _GISObjects = null;
        public clsGISObjects GISObjects
        {
            get { return _GISObjects; }
            set
            {
                _GISObjects = value;
                ChoiceClearAllButGIS(eChoiceInitiateCAPGIS.scGISObjects);
            }
        }
        // End choice


        // Begin Choice
        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllButParcel(eChoiceInitiateCAPParcel.scParcelIds);
            }
        }

        private clsParcels _Parcels = null;
        public clsParcels Parcels
        {
            get { return _Parcels; }
            set
            {
                _Parcels = value;
                ChoiceClearAllButParcel(eChoiceInitiateCAPParcel.scParcels);
            }
        }
        // End choice


        public clsApplicant Applicant { get; set; }

        public clsCAPRelations CAPRelations { get; set; }

        public clsContacts Contacts { get; set; }

        public clsLicenses Licenses { get; set; }

        public clsSpatialDescriptors SpatialDescriptors { get; set; }

        public clsAdditionalInformation AdditionalInformation { get; set; }

        public clsCAPIds parentCAPIds { get; set; }

        private bool? _finalizeNow = false;
        public bool? finalizeNow
        {
            get
            {
                if (_finalizeNow.HasValue)
                {
                    return _finalizeNow.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _finalizeNow = value; }
        }
        public bool _finalizeNowSpecified
        {
            get { return _finalizeNow != null; }
        }

        public clsAssets Assets { get; set; }

        public clsParts Parts { get; set; }

        public clsCostItems CostItems { get; set; }

        public clsDepartment Department { get; set; }

        public clsStaffPerson StaffPerson{ get; set; }

        private DateTime? _assignedDate = null;
        [XmlIgnore]
        public DateTime? assignedDate
        {
            get { return _assignedDate; }
            set { _assignedDate = value; }
        }
        [XmlElement("assignedDate")]
        public string assignedDateString
        {
            get
            {
                if (_assignedDate.HasValue)
                {
                    return _assignedDate.Value.ToString(Constants.cDateFormat); ;
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
                    _assignedDate = td;
                }
                else
                {
                    _assignedDate = null;
                }
            }
        }
        public bool assignedDateStringSpecified
        {
            get { return _assignedDate != null; }
        }

        private DateTime? _ScheduledDateTime = null;  // This member is used for both the date and time fields
        [XmlIgnore]
        public DateTime? ScheduledDateTime
        {
            get { return _ScheduledDateTime; }
            set { _ScheduledDateTime = value; }
        }
        [XmlElement("ScheduleDate")]
        public string ScheduleDateString
        {
            get
            {
                if (_ScheduledDateTime.HasValue)
                {
                    return _ScheduledDateTime.Value.ToString(Constants.cDateFormat);
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
                    if (_ScheduledDateTime != null)
                    {
                        _ScheduledDateTime = td + ScheduledDateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        _ScheduledDateTime = td;
                    }
                }
            }
        }
        public bool ScheduleDateStringSpecified
        {
            get { return _ScheduledDateTime != null; }
        }

        [XmlElement("ScheduleTime")]
        public string ScheduleTimeString
        {
            get
            {
                if (_ScheduledDateTime.HasValue)
                {
                    return _ScheduledDateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (_ScheduledDateTime != null)
                    {
                        _ScheduledDateTime = ScheduledDateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        _ScheduledDateTime = td;
                    }
                }

            }
        }
        public bool ScheduleTimeStringSpecified
        {
            get { return _ScheduledDateTime != null; }
        }

        // Constructors
        public msgInitiateCAP()
        {
        }

        // Methods
        private void ChoiceClearAllButAddress(eChoiceInitiateCAPAddress pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInitiateCAPAddress.scDetailAddress)
            {
                _DetailAddress = null;
            }
        }

        private void ChoiceClearAllButGIS(eChoiceInitiateCAPGIS pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInitiateCAPGIS.scGISObjectIds)
            {
                _GISObjectIds = null;
            }
            if (pSelectedChoice != eChoiceInitiateCAPGIS.scGISObjects)
            {
                _GISObjects = null;
            }
        }

        private void ChoiceClearAllButParcel(eChoiceInitiateCAPParcel pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInitiateCAPParcel.scParcelIds)
            {
                _ParcelIds = null;
            }
            if (pSelectedChoice != eChoiceInitiateCAPParcel.scParcels)
            {
                _Parcels = null;
            }
        }
    }
}

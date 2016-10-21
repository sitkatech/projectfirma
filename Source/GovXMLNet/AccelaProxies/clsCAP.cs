using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="CAP">
    <xsd:complexContent>
      <xsd:extension base="Entity">
        <xsd:sequence>
          <xsd:element name="contextType" type="capTypeEnum" form="qualified" minOccurs="0"/>
          <xsd:element ref="Restricted" minOccurs="0"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element name="module" type="xsd:string" minOccurs="0"/>
          <xsd:element ref="ApprovalDate" minOccurs="0"/>
          <xsd:element ref="EffectiveDate" minOccurs="0"/>
          <xsd:element ref="ExpirationDate" minOccurs="0"/>
          <xsd:element ref="FileDate" minOccurs="0"/>
          <xsd:element name="Status" type="CAPStatus"/>
          <xsd:element ref="Dispositions" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element ref="Name" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:element ref="Addresses"/>
            <xsd:element ref="CompactAddresses"/>
          </xsd:choice>
          <xsd:element ref="Parcels" minOccurs="0"/>
          <xsd:element ref="CAPRelations" minOccurs="0"/>
          <xsd:element ref="Checklist" minOccurs="0"/>
          <xsd:element ref="Conditions" minOccurs="0"/>
          <xsd:element ref="Contacts" minOccurs="0"/>
          <xsd:element ref="ElectronicSignatures" minOccurs="0"/>
          <xsd:element ref="GISObjects" minOccurs="0"/>
          <xsd:element ref="Inspections" minOccurs="0"/>
          <xsd:element ref="Holds" minOccurs="0"/>
          <xsd:element ref="SpatialDescriptors" minOccurs="0"/>
          <xsd:element ref="SpatialObjects" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
          <xsd:element ref="Assets" minOccurs="0"/>
          <xsd:element ref="CostItems" minOccurs="0"/>
          <xsd:element ref="Parts" minOccurs="0"/>
          <xsd:element ref="StatusesDetail" minOccurs="0"/>
          <xsd:element name="pmScheduleSeq" type="xsd:nonNegativeInteger" minOccurs="0"/>
          <xsd:element name="priority" type="xsd:nonNegativeInteger" minOccurs="0"/>
          <xsd:element name="totalJobCost" type="xsd:double" minOccurs="0"/>
          <xsd:element ref="Department" minOccurs="0"/>
          <xsd:element ref="StaffPerson" minOccurs="0"/>
          <xsd:element name="ScheduleDate" type="xsd:string" minOccurs="0"/>
          <xsd:element name="ScheduleTime" type="xsd:string" minOccurs="0"/>
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
    public class clsCAP : clsEntity
    {
        enum eChoiceCAP
        {
            scAddresses,
            scCompactAddresses
        }

        // Members
        private capTypeEnum? _contextType = null;
        public capTypeEnum? contextType
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

        private bool? _Restricted = false;
        [XmlIgnore]
        public bool? Restricted
        {
            get
            {
                if (_Restricted.HasValue)
                {
                    return _Restricted.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _Restricted = value; }
        }
        [XmlElement("Restricted")]
        public string RestrictedString
        {
            get 
            {
                if (_Restricted.HasValue && _Restricted.Value == true)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            set 
            {
                if (value == "1")
                {
                    _Restricted = true;
                }
                else
                {
                    _Restricted = false;
                }
            }
        }
        public bool RestrictedStringSpecified
        {
            get { return _Restricted != null; }
        }

        public clsType Type { get; set; }

        private string _module = null;
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }

        [XmlIgnore]
        public DateTime? ApprovalDate { get; set; }
        [XmlElement("ApprovalDate")]
        public string ApprovalDateString
        {
            get
            {
                if (ApprovalDate.HasValue)
                {
                    return ApprovalDate.Value.ToString(Constants.cDateFormat);
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
                    ApprovalDate = td;
                }
                else
                {
                    ApprovalDate = null;
                }
            }
        }
        public bool ApprovalDateStringSpecified
        {
            get { return ApprovalDate != null; }
        }

        [XmlIgnore]
        public DateTime? EffectiveDate { get; set; }
        [XmlElement("EffectiveDate")]
        public string EffectiveDateString
        {
            get
            {
                if (EffectiveDate.HasValue)
                {
                    return EffectiveDate.Value.ToString(Constants.cDateFormat);
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
                    EffectiveDate = td;
                }
                else
                {
                    EffectiveDate = null;
                }
            }
        }
        public bool EffectiveDateStringSpecified
        {
            get { return EffectiveDate != null; }
        }

        [XmlIgnore]
        public DateTime? ExpirationDate { get; set; }
        [XmlElement("ExpirationDate")]
        public string ExpirationDateString
        {
            get
            {
                if (ExpirationDate.HasValue)
                {
                    return ExpirationDate.Value.ToString(Constants.cDateFormat);
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
                    ExpirationDate = td;
                }
                else
                {
                    ExpirationDate = null;
                }
            }
        }
        public bool ExpirationDateStringSpecified
        {
            get { return ExpirationDate != null; }
        }

        [XmlIgnore]
        public DateTime? FileDate { get; set; }
        [XmlElement("FileDate")]
        public string FileDateString
        {
            get
            {
                if (FileDate.HasValue)
                {
                    return FileDate.Value.ToString(Constants.cDateFormat);
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
                    FileDate = td;
                }
                else
                {
                    FileDate = null;
                }
            }
        }
        public bool FileDateStringSpecified
        {
            get { return FileDate != null; }
        }

        public clsCAPStatus Status { get; set; }

        public clsDispositions Dispositions { get; set; }

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
        
        // Begin choice
        private clsAddresses _Addresses = null;
        public clsAddresses Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                ChoiceClearAllBut(eChoiceCAP.scAddresses);
            }
        }

        private clsCompactAddresses _CompactAddresses = null;
        public clsCompactAddresses CompactAddresses
        {
            get { return _CompactAddresses; }
            set
            {
                _CompactAddresses = value;
                ChoiceClearAllBut(eChoiceCAP.scCompactAddresses);
            }
        }
        // End choice
        public clsParcels Parcels { get; set; }
        public clsCAPRelations CAPRelations { get; set; }
        public clsCheckList Checklist { get; set; }
        public clsConditions Conditions { get; set; }
        public clsContacts Contacts { get; set; }
        public clsElectronicSignatures ElectronicSignatures { get; set; }
        public clsGISObjects GISObjects { get; set; }
        public clsInspections Inspections { get; set; }
        public clsHolds Holds { get; set; }
        public clsSpatialDescriptors SpatialDescriptors { get; set; }
        public clsSpatialObjects SpatialObjects { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }
        public clsAssets Assets { get; set; }
        public clsCostItems CostItems { get; set; }
        public clsParts Parts { get; set; }
        public clsStatusesDetail StatusesDetail { get; set; }
        

        private uint? _pmScheduleSeq = null;
        public uint? pmScheduleSeq
        {
            get
            {
                if (_pmScheduleSeq.HasValue)
                {
                    return _pmScheduleSeq.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _pmScheduleSeq = value; }
        }
        public bool pmScheduleSeqSpecified
        {
            get { return _pmScheduleSeq != null; }
        }

        private uint? _priority = null;
        public uint? priority
        {
            get
            {
                if (_priority.HasValue)
                {
                    return _priority.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _priority = value; }
        }
        public bool prioritySpecified
        {
            get { return _priority != null; }
        }

        private double? _totalJobCost = null;
        public double? totalJobCost
        {
            get
            {
                if (_totalJobCost.HasValue)
                {
                    return _totalJobCost.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _totalJobCost = value; }
        }
        public bool totalJobCostSpecified
        {
            get { return _totalJobCost != null; }
        }

        public clsDepartment Department { get; set; }
        public clsStaffPerson StaffPerson { get; set; }

        [XmlIgnore]
        public DateTime? ScheduledDateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("ScheduleDate")]
        public string ScheduleDateString
        {
            get
            {
                if (ScheduledDateTime.HasValue)
                {
                    return ScheduledDateTime.Value.ToString(Constants.cDateFormat);
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
                    if (ScheduledDateTime != null)
                    {
                        ScheduledDateTime = td + ScheduledDateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        ScheduledDateTime = td;
                    }
                }
            }
        }
        public bool ScheduleDateStringSpecified
        {
            get { return ScheduledDateTime != null; }
        }

        [XmlElement("ScheduleTime")]
        public string ScheduleTimeString
        {
            get
            {
                if (ScheduledDateTime.HasValue)
                {
                    return ScheduledDateTime.Value.ToString(Constants.cTimeFormat);
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
                    if (ScheduledDateTime != null)
                    {
                        ScheduledDateTime = ScheduledDateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        ScheduledDateTime = td;
                    }
                }

            }
        }
        public bool ScheduleTimeStringSpecified
        {
            get { return ScheduledDateTime != null; }
        }

        public undCAPDetail CAPDetail { get; set; }

        // Constructors
        public clsCAP()
        {
        }


        // Methods
        private void ChoiceClearAllBut(eChoiceCAP pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCAP.scAddresses)
            {
                _Addresses = null;
            }
            if (pSelectedChoice != eChoiceCAP.scCompactAddresses)
            {
                _CompactAddresses = null;
            }
        }
    }

}

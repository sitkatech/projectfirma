using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Inspection">
    <xsd:complexContent>
      <xsd:extension base="Activity">
        <xsd:sequence>
          <xsd:element name="contextType" type="inspectionTypeEnum" form="qualified"/>
          <xsd:element name="priority" type="xsd:double" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:element ref="CAP"/>
            <xsd:element ref="CAPId"/>
          </xsd:choice>
          <xsd:element ref="CompactAddress" minOccurs="0"/>
          <xsd:element ref="DetailAddress" minOccurs="0"/>
          <xsd:element ref="Type" minOccurs="0"/>
          <xsd:element ref="InspectionStatus"/>
          <xsd:element ref="Dispositions" minOccurs="0"/>
          <xsd:element ref="InspectionDate" minOccurs="0"/>
          <xsd:element ref="InspectionTime" minOccurs="0"/>
          <xsd:choice minOccurs="0">
            <xsd:element ref="Inspector"/>
            <xsd:element ref="InspectorId"/>
          </xsd:choice>
          <xsd:element ref="RequestComment" minOccurs="0"/>
          <xsd:element ref="RequestPhoneNum" minOccurs="0"/>
          <xsd:element ref="ResultComment" minOccurs="0"/>
          <xsd:element ref="Contacts" minOccurs="0"/>
          <xsd:element ref="Checklist" minOccurs="0"/>
          <xsd:element ref="Conditions" minOccurs="0"/>
          <xsd:element ref="DistanceAndTimes" minOccurs="0"/>
          <xsd:element ref="ElectronicSignatures" minOccurs="0"/>
          <xsd:element ref="Guidesheets" minOccurs="0"/>
          <xsd:element ref="Holds" minOccurs="0"/>
          <xsd:element ref="SpatialDescriptors" minOccurs="0"/>
          <xsd:element ref="RecordedBy"/>
          <xsd:element name="autoAssign" type="xsd:boolean" minOccurs="0"/>
          <xsd:element name="inspectionUnit" type="xsd:double" minOccurs="0"/>
          <xsd:element ref="InspectionUnitNumber" minOccurs="0"/>
          <xsd:element ref="InspectionUnitNumberIdentifier" minOccurs="0"/>
          <xsd:element ref="WorkflowSequence" minOccurs="0"/>
          <xsd:element ref="WorkflowAvailable" minOccurs="0"/>
          <xsd:element ref="GISObjects" minOccurs="0"/>
          <xsd:element ref="DispositionHistories" minOccurs="0" />
          <xsd:element name="carryOverFlag" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="allowFailedGuidesheet" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="overTime" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="inspBillable" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="confirmationNumber" type="xsd:long" minOccurs="0" maxOccurs="1" />
          <xsd:element name="guideSheetSecurity" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element ref="InspectionRelations" minOccurs="0" />
          <xsd:element ref="TimeAccountings" minOccurs="0"/>
          <xsd:element ref="Districts" minOccurs="0"/>
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
    public class clsInspection : clsActivity
    {
        enum eChoiceInspectionCAP
        {
            scCAP,
            scCAPId
        }
        enum eChoiceInspectionInspector
        {
            scInspector,
            scInspectorId
        }

        // Members

        private inspectionTypeEnum _contextType;
        public inspectionTypeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        private double? _priority = null;
        public double? priority
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


        // Begin Choice
        // Disabled choice because both appear in schedule inspection response
        private clsCAP _CAP = null;
        public clsCAP CAP
        {
            get { return _CAP; }
            set
            {
                _CAP = value;
                //ChoiceCAPClearAllBut(eChoiceInspectionCAP.scCAP);
            }
        }

        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
        {
            get { return _CAPId; }
            set
            {
                _CAPId = value;
                //ChoiceCAPClearAllBut(eChoiceInspectionCAP.scCAPId);
            }
        }

        // End Choice

        public clsCompactAddress CompactAddress { get; set; }
        public clsDetailAddress DetailAddress { get; set; }
        public clsType Type { get; set; }
        public clsInspectionStatus InspectionStatus { get; set; }
        public clsDispositions Dispositions { get; set; }

        [XmlIgnore]
        public DateTime? InspectionDateTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("InspectionDate")]
        public string InspectionDateString
        {
            get
            {
                if (InspectionDateTime.HasValue)
                {
                    return InspectionDateTime.Value.ToString(Constants.cDateFormat);
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
                    if (InspectionDateTime != null)
                    {
                        InspectionDateTime = td + InspectionDateTime.Value.TimeOfDay;
                    }
                    else
                    {
                        InspectionDateTime = td;
                    }
                }
            }
        }
        public bool InspectionDateSpecified
        {
            get { return InspectionDateTime != null; }
        }

        [XmlElement("InspectionTime")]
        public string InspectionTimeString
        {
            get
            {
                if (InspectionDateTime.HasValue)
                {
                    return InspectionDateTime.Value.ToString(Constants.cInspectionTimeFormat);
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
                    if (InspectionDateTime != null)
                    {
                        InspectionDateTime = InspectionDateTime.Value.Date + td.TimeOfDay;
                    }
                    else
                    {
                        InspectionDateTime = td;
                    }
                }
            }
        }
        public bool InspectionTimeStringSpecified
        {
            get { return InspectionDateTime != null && InspectionDateTime.Value.TimeOfDay.Ticks > 0; }
        }

        // Begin Choice
        private clsInspector _Inspector = null;
        public clsInspector Inspector
        {
            get { return _Inspector; }
            set
            {
                _Inspector = value;
                ChoiceInspectorClearAllBut(eChoiceInspectionInspector.scInspector);
            }
        }
        private clsInspectorId _InspectorId = null;
        public clsInspectorId InspectorId
        {
            get { return _InspectorId; }
            set
            {
                _InspectorId = value;
                ChoiceInspectorClearAllBut(eChoiceInspectionInspector.scInspectorId);
            }
        }
        // End Choice

        private string _RequestComment = null;
        public string RequestComment
        {
            get { return _RequestComment; }
            set { _RequestComment = value; }
        }

        private string _RequestPhoneNum = null;
        public string RequestPhoneNum
        {
            get { return _RequestPhoneNum; }
            set { _RequestPhoneNum = value; }
        }

        private string _ResultComment = null;
        public string ResultComment
        {
            get { return _ResultComment; }
            set { _ResultComment = value; }
        }

        public clsContacts Contacts { get; set; }
        public clsCheckList Checklist { get; set; }
        public clsConditions Conditions { get; set; }
        public clsDistanceAndTimes DistanceAndTimes { get; set; }
        public clsElectronicSignatures ElectronicSignatures { get; set; }
        public clsGuidesheets Guidesheets { get; set; }
        public clsHolds Holds { get; set; }
        public clsSpatialDescriptors SpatialDescriptors { get; set; }

        private string _RecordedBy = null;
        public string RecordedBy
        {
            get { return _RecordedBy; }
            set { _RecordedBy = value; }
        }

        private bool? _autoAssign = null;
        public bool? autoAssign
        {
            get
            {
                if (_autoAssign.HasValue)
                {
                    return _autoAssign.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _autoAssign = value; }
        }
        public bool autoAssignSpecified
        {
            get { return _autoAssign != null; }
        }

        private double? _inspectionUnit = null;
        public double? inspectionUnit
        {
            get
            {
                if (_inspectionUnit.HasValue)
                {
                    return _inspectionUnit.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _inspectionUnit = value; }
        }
        public bool inspectionUnitSpecified
        {
            get { return _inspectionUnit != null; }
        }

        private string vInspectionUnitNumber = null;
        public string InspectionUnitNumber
        {
            get { return vInspectionUnitNumber; }
            set { vInspectionUnitNumber = value; }
        }

        public clsInspectionUnitNumberIdentifier inspectionUnitNumberIdentifier { get; set; }

        private uint? _WorkflowSequence = null;
        public uint? WorkflowSequence
        {
            get
            {
                if (_WorkflowSequence.HasValue)
                {
                    return _WorkflowSequence.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _WorkflowSequence = value; }
        }
        public bool WorkflowSequenceSpecified
        {
            get { return _WorkflowSequence != null; }
        }

        private bool? _WorkflowAvailable = null;
        public bool? WorkflowAvailable
        {
            get
            {
                if (_WorkflowAvailable.HasValue)
                {
                    return _WorkflowAvailable.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _WorkflowAvailable = value; }
        }
        public bool WorkflowAvailableSpecified
        {
            get { return _WorkflowAvailable != null; }
        }


        public clsGISObjects GISObjects { get; set; }

        public clsDispositionHistories DispositionHistories { get; set; }

        private string _carryOverFlag = null;
        public string carryOverFlag
        {
            get { return _carryOverFlag; }
            set { _carryOverFlag = value; }
        }

        private string _allowFailedGuidesheet = null;
        public string allowFailedGuidesheet
        {
            get { return _allowFailedGuidesheet; }
            set { _allowFailedGuidesheet = value; }
        }

        private string _overTime = null;
        public string overTime
        {
            get { return _overTime; }
            set { _overTime = value; }
        }

        private string _inspBillable = null;
        public string inspBillable
        {
            get { return _inspBillable; }
            set { _inspBillable = value; }
        }

        private long? _confirmationNumber = null;
        public long? confirmationNumber
        {
            get
            {
                if (_confirmationNumber.HasValue)
                {
                    return _confirmationNumber.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _confirmationNumber = value; }
        }
        public bool confirmationNumberSpecified
        {
            get { return _confirmationNumber != null; }
        }

        private string _guideSheetSecurity = null;
        public string guideSheetSecurity
        {
            get { return _guideSheetSecurity; }
            set { _guideSheetSecurity = value; }
        }

        public clsInspectionRelations InspectionRelations { get; set; }
        public clsTimeAccountings TimeAccountings { get; set; }
        public clsDistricts Districts { get; set; }


        // Constructors
        public clsInspection()
        {
        }

        // Methods
        private void ChoiceCAPClearAllBut(eChoiceInspectionCAP pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInspectionCAP.scCAP)
            {
                _CAP = null;
            }
            if (pSelectedChoice != eChoiceInspectionCAP.scCAPId)
            {
                _CAPId = null;
            }
        }
        private void ChoiceInspectorClearAllBut(eChoiceInspectionInspector pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceInspectionInspector.scInspector)
            {
                _Inspector = null;
            }
            if (pSelectedChoice != eChoiceInspectionInspector.scInspectorId)
            {
                _InspectorId = null;
            }
        }
    }
}

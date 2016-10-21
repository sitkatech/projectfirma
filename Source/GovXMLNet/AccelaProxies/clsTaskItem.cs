using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="TaskItem">
    <xsd:complexContent>
      <xsd:extension base="Entity">
        <xsd:sequence>
          <xsd:element name="stepNumber" type="xsd:integer"  minOccurs="0"/>
          <xsd:element name="processID" type="xsd:long"  minOccurs="0"/>
          <xsd:element name="processCode" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="taskDescription" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="assignmentDate" type="calendarDate"  minOccurs="0"/>
          <xsd:element name="dueDate" type="calendarDate"  minOccurs="0"/>
          <xsd:element name="disposition" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="statusDate" type="calendarDate"  minOccurs="0"/>
          <xsd:element name="startTime" type="dateAndTime"  minOccurs="0"/>
          <xsd:element name="endTime" type="dateAndTime"  minOccurs="0"/>
          <xsd:element name="hoursSpent" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="billable " type="xsd:string"  minOccurs="0"/>
          <xsd:element name="overTime" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="estimatedDueDate" type="calendarDate"  minOccurs="0"/>
          <xsd:element name="isRestrictView4ACA" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="restrictRole" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="inPossessionTime" type="xsd:double"  minOccurs="0"/>
          <xsd:element name="trackStartDate" type="calendarDate"  minOccurs="0"/>
          <xsd:element name="assignDepartmentName" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="assignedUserName" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="actionBy" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="actionDepartmentName" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="hoursSpentRequired" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="activeFlag" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="completeFlag" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="daysDue" type="xsd:integer"  minOccurs="0"/>
          <xsd:element name="calendarID" type="xsd:long"  minOccurs="0"/>
          <xsd:element name="approval" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="dispositionComment" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="dispositionNote" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="asgnEmailDisp" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="standardComment" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="standardCommentI18n" type="xsd:string"  minOccurs="0"/>
          <xsd:element name="relationSeqId" type="xsd:long"  minOccurs="0"/>
          <xsd:element ref="StaffPerson" minOccurs="0"/>
          <xsd:element ref="Department" minOccurs="0"/>
          <xsd:element ref="Process" minOccurs="0"/>
          <xsd:element ref="AdditionalInformation" minOccurs="0"/>
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsTaskItem : clsEntity
    {
        // Members
        private int? _stepNumber = null;
        public int? stepNumber
        {
            get
            {
                if (_stepNumber.HasValue)
                {
                    return _stepNumber.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _stepNumber = value; }
        }
        public bool stepNumberSpecified
        {
            get { return _stepNumber != null; }
        }

        private long? _processID = null;
        public long? processID
        {
            get
            {
                if (_processID.HasValue)
                {
                    return _processID.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _processID = value; }
        }
        public bool processIDSpecified
        {
            get { return _processID != null; }
        }

        private string _processCode = null;
        public string processCode
        {
            get { return _processCode; }
            set { _processCode = value; }
        }

        private string _taskDescription = null;
        public string taskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; }
        }

        [XmlIgnore]
        public DateTime? assignmentDate  { get; set; }
        [XmlElement("assignmentDate")]
        public string assignmentDateString
        {
            get
            {
                if (assignmentDate.HasValue)
                {
                    return assignmentDate.Value.ToString(Constants.cDateFormat); ;
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
                    assignmentDate = td;
                }
                else
                {
                    assignmentDate = null;
                }
            }
        }
        public bool assignmentDateStringSpecified
        {
            get { return assignmentDate != null; }
        }

        [XmlIgnore]
        public DateTime? dueDate { get; set; }
        [XmlElement("dueDate")]
        public string dueDateString
        {
            get
            {
                if (dueDate.HasValue)
                {
                    return dueDate.Value.ToString(Constants.cDateFormat); ;
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
                    dueDate = td;
                }
                else
                {
                    dueDate = null;
                }
            }
        }
        public bool dueDateStringSpecified
        {
            get { return dueDate != null; }
        }

        private string _disposition = null;
        public string disposition
        {
            get { return _disposition; }
            set { _disposition = value; }
        }

        [XmlIgnore]
        public DateTime? statusDate { get; set; } 
        [XmlElement("statusDate")]
        public string statusDateString
        {
            get
            {
                if (statusDate.HasValue)
                {
                    return statusDate.Value.ToString(Constants.cDateFormat);
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
                    if (statusDate != null)
                    {
                        statusDate = td + statusDate.Value.TimeOfDay;
                    }
                    else
                    {
                        statusDate = td;
                    }
                }
            }
        }
        public bool statusDateStringSpecified
        {
            get { return statusDate != null; }
        }

        [XmlIgnore]
        public DateTime? startTime { get; set; } 
        [XmlElement("startTime")]
        public string startTimeString
        {
            get
            {
                if (startTime.HasValue)
                {
                    return startTime.Value.ToString(Constants.cDateTimeFormat);
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
                        startTime = td;
                }
            }
        }
        public bool startTimeStringSpecified
        {
            get { return startTime != null; }
        }

        [XmlIgnore]
        public DateTime? endTime { get; set; }  // This member is used for both the date and time fields
        [XmlElement("endTime")]
        public string endTimeString
        {
            get
            {
                if (endTime.HasValue)
                {
                    return endTime.Value.ToString(Constants.cDateTimeFormat);
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
                    startTime = td;
                }
            }
        }
        public bool endTimeStringSpecified
        {
            get { return endTime != null; }
        }

        private string _hoursSpent = null;
        public string hoursSpent
        {
            get { return _hoursSpent; }
            set { _hoursSpent = value; }
        }

        private string _billable = null;
        public string billable
        {
            get { return _billable; }
            set { _billable = value; }
        }

        private string _overTime = null;
        public string overTime
        {
            get { return _overTime; }
            set { _overTime = value; }
        }

        [XmlIgnore]
        public DateTime? estimatedDueDate { get; set; }
        [XmlElement("estimatedDueDate")]
        public string estimatedDueDateString
        {
            get
            {
                if (estimatedDueDate.HasValue)
                {
                    return estimatedDueDate.Value.ToString(Constants.cDateFormat); ;
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
                    estimatedDueDate = td;
                }
                else
                {
                    estimatedDueDate = null;
                }
            }
        }
        public bool estimatedDueDateStringSpecified
        {
            get { return estimatedDueDate != null; }
        }

        private string _isRestrictView4ACA = null;
        public string isRestrictView4ACA
        {
            get { return _isRestrictView4ACA; }
            set { _isRestrictView4ACA = value; }
        }

        private string _restrictRole = null;
        public string restrictRole
        {
            get { return _restrictRole; }
            set { _restrictRole = value; }
        }

        private double? _inPossessionTime = null;
        public double? inPossessionTime
        {
            get
            {
                if (_inPossessionTime.HasValue)
                {
                    return _inPossessionTime.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _inPossessionTime = value; }
        }
        public bool inPossessionTimeSpecified
        {
            get { return _inPossessionTime != null; }
        }

        [XmlIgnore]
        public DateTime? trackStartDate { get; set; }
        [XmlElement("trackStartDate")]
        public string trackStartDateString
        {
            get
            {
                if (trackStartDate.HasValue)
                {
                    return trackStartDate.Value.ToString(Constants.cDateFormat); ;
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
                    trackStartDate = td;
                }
                else
                {
                    trackStartDate = null;
                }
            }
        }
        public bool trackStartDateStringSpecified
        {
            get { return trackStartDate != null; }
        }

        private string _assignDepartmentName = null;
        public string assignDepartmentName
        {
            get { return _assignDepartmentName; }
            set { _assignDepartmentName = value; }
        }

        private string _assignedUserName = null;
        public string assignedUserName
        {
            get { return _assignedUserName; }
            set { _assignedUserName = value; }
        }

        private string _actionBy = null;
        public string actionBy
        {
            get { return _actionBy; }
            set { _actionBy = value; }
        }

        private string _actionDepartmentName = null;
        public string actionDepartmentName
        {
            get { return _actionDepartmentName; }
            set { _actionDepartmentName = value; }
        }

        private string _hoursSpentRequired = null;
        public string hoursSpentRequired
        {
            get { return _hoursSpentRequired; }
            set { _hoursSpentRequired = value; }
        }

        private string _activeFlag = null;
        public string activeFlag
        {
            get { return _activeFlag; }
            set { _activeFlag = value; }
        }

        private string _completeFlag = null;
        public string completeFlag
        {
            get { return _completeFlag; }
            set { _completeFlag = value; }
        }

        private int? _daysDue = null;
        public int? daysDue
        {
            get
            {
                if (_daysDue.HasValue)
                {
                    return _daysDue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _daysDue = value; }
        }
        public bool daysDueSpecified
        {
            get { return _daysDue != null; }
        }


        private long? _calendarID = null;
        public long? calendarID
        {
            get
            {
                if (_calendarID.HasValue)
                {
                    return _calendarID.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _calendarID = value; }
        }
        public bool calendarIDSpecified
        {
            get { return _calendarID != null; }
        }

        private string _approval = null;
        public string approval
        {
            get { return _approval; }
            set { _approval = value; }
        }

        private string _dispositionComment = null;
        public string dispositionComment
        {
            get { return _dispositionComment; }
            set { _dispositionComment = value; }
        }

        private string _dispositionNote = null;
        public string dispositionNote
        {
            get { return _dispositionNote; }
            set { _dispositionNote = value; }
        }

        private string _asgnEmailDisp = null;
        public string asgnEmailDisp
        {
            get { return _asgnEmailDisp; }
            set { _asgnEmailDisp = value; }
        }

        private string _standardComment = null;
        public string standardComment
        {
            get { return _standardComment; }
            set { _standardComment = value; }
        }

        private string _standardCommentI18n = null;
        public string standardCommentI18n
        {
            get { return _standardCommentI18n; }
            set { _standardCommentI18n = value; }
        }

        private long? _relationSeqId = null;
        public long? relationSeqId
        {
            get
            {
                if (_relationSeqId.HasValue)
                {
                    return _relationSeqId.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _relationSeqId = value; }
        }
        public bool relationSeqIdSpecified
        {
            get { return _relationSeqId != null; }
        }

        public clsStaffPerson StaffPerson { get; set; }
        public clsDepartment Department { get; set; }
        public clsProcess Process { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsTaskItem()
        {
        }
    }
}

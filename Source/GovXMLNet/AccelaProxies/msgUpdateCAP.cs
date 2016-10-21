using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateCAP">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="ContextType" type="datasetChangeEnum" form="qualified"/>
					<xsd:element ref="CAPId"/>
					<xsd:choice maxOccurs="unbounded">
						<xsd:group ref="CAPUpdateCollectionSelect"/>
					</xsd:choice>
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
    public class msgUpdateCAP : clsOperationRequest
    {
        // Members
        private datasetChangeEnum _contextType;
        public datasetChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsCAPId CAPId { get; set; }

        // Begin group CAPUpdateCollectionSelect
        // Start choice
        private clsAdditionalInformation _AdditionalInformation = null;
        public clsAdditionalInformation AdditionalInformation
        {
            get { return _AdditionalInformation; }
            set
            {
                _AdditionalInformation = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scAdditionalInformation);
            }
        }

        private clsAddresses _Addresses = null;
        public clsAddresses Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scAddresses);
            }
        }

        private DateTime? _ApprovalDate = null;
        [XmlIgnore]
        public DateTime? ApprovalDate
        {
            get { return _ApprovalDate; }
            set
            {
                _ApprovalDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scApprovalDate);
            }
        }

        [XmlElement("ApprovalDate")]
        public string ApprovalDateString
        {
            get
            {
                if (_ApprovalDate.HasValue)
                {
                    return _ApprovalDate.Value.ToString(Constants.cDateFormat);
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
                    _ApprovalDate = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scApprovalDate);
                }
                else
                {
                    _ApprovalDate = null;
                }
            }
        }
        public bool ApprovalDateStringSpecified
        {
            get { return _ApprovalDate != null; }
        }

        private clsCAPRelations _CAPRelations = null;
        public clsCAPRelations CAPRelations
        {
            get { return _CAPRelations; }
            set
            {
                _CAPRelations = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scCAPRelations);
            }
        }

        private clsCheckList _Checklist = null;
        public clsCheckList Checklist
        {
            get { return _Checklist; }
            set
            {
                _Checklist = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scChecklist);
            }
        }

        private clsCompactAddresses _CompactAddresses = null;
        public clsCompactAddresses CompactAddresses
        {
            get { return _CompactAddresses; }
            set
            {
                _CompactAddresses = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scCompactAddresses);
            }
        }

        private clsConditions _Conditions = null;
        public clsConditions Conditions
        {
            get { return _Conditions; }
            set
            {
                _Conditions = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scConditions);
            }
        }

        private clsContacts _Contacts = null;
        public clsContacts Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scContacts);
            }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scDescription);
            }
        }

        private DateTime? _EffectiveDate = null;
        [XmlIgnore]
        public DateTime? EffectiveDate
        {
            get { return _EffectiveDate; }
            set
            {
                _EffectiveDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scEffectiveDate);
            }
        }
        [XmlElement("EffectiveDate")]
        public string EffectiveDateString
        {
            get
            {
                if (_EffectiveDate.HasValue)
                {
                    return _EffectiveDate.Value.ToString(Constants.cDateFormat);
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
                    _EffectiveDate = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scEffectiveDate);
                }
                else
                {
                    _EffectiveDate = null;
                }
            }
        }
        public bool EffectiveDateStringSpecified
        {
            get { return _EffectiveDate != null; }
        }

        private DateTime? _expirationDate;
        [XmlIgnore]
        public DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scExpirationDate);
            }
        }
        [XmlElement("ExpirationDate")]
        public string ExpirationDateString
        {
            get
            {
                if (_expirationDate.HasValue)
                {
                    return _expirationDate.Value.ToString(Constants.cDateFormat);
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
                    _expirationDate = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scExpirationDate);
                }
                else
                {
                    _expirationDate = null;
                }
            }
        }
        public bool ExpirationDateStringSpecified
        {
            get { return _expirationDate != null; }
        }

        private clsElectronicSignatures _electronicSignatures;
        public clsElectronicSignatures ElectronicSignatures
        {
            get { return _electronicSignatures; }
            set
            {
                _electronicSignatures = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scElectronicSignatures);
            }
        }

        private DateTime? _fileDate;
        [XmlIgnore]
        public DateTime? FileDate
        {
            get { return _fileDate; }
            set
            {
                _fileDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scFileDate);
            }
        }
        [XmlElement("FileDate")]
        public string FileDateString
        {
            get
            {
                if (_fileDate.HasValue)
                {
                    return _fileDate.Value.ToString(Constants.cDateTimeFormat);
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
                    _fileDate = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scFileDate);
                }
                else
                {
                    _fileDate = null;
                }
            }
        }
        public bool startDateStringSpecified
        {
            get { return _fileDate != null; }
        }

        private clsGISObjects _GISObjects = null;
        public clsGISObjects GISObjects
        {
            get { return _GISObjects; }
            set
            {
                _GISObjects = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scGISObjects);
            }
        }

        private clsGISObjectIds _GISObjectIds = null;
        public clsGISObjectIds GISObjectIds
        {
            get { return _GISObjectIds; }
            set
            {
                _GISObjectIds = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scGISObjectIds);
            }
        }

        private clsHolds _Holds = null;
        public clsHolds Holds
        {
            get { return _Holds; }
            set
            {
                _Holds = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scHolds);
            }
        }

        private clsParcelIds _ParcelIds = null;
        public clsParcelIds ParcelIds
        {
            get { return _ParcelIds; }
            set
            {
                _ParcelIds = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scParcelIds);
            }
        }

        private clsParcels _Parcels = null;
        public clsParcels Parcels
        {
            get { return _Parcels; }
            set
            {
                _Parcels = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scParcels);
            }
        }

        private clsSpatialDescriptors _SpatialDescriptors = null;
        public clsSpatialDescriptors SpatialDescriptors
        {
            get { return _SpatialDescriptors; }
            set
            {
                _SpatialDescriptors = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scSpatialDescriptors);
            }
        }

        private clsSpatialObjects _SpatialObjects = null;
        public clsSpatialObjects SpatialObjects
        {
            get { return _SpatialObjects; }
            set
            {
                _SpatialObjects = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scSpatialObjects);
            }
        }

        private clsCAPStatus _Status = null;
        public clsCAPStatus Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scStatus);
            }
        }

        private clsType _Type = null;
        public clsType Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scType);
            }
        }

        private clsWorksheets _Worksheets = null;
        public clsWorksheets Worksheets
        {
            get { return _Worksheets; }
            set
            {
                _Worksheets = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scWorksheets);
            }
        }

        private clsAssets _Assets = null;
        public clsAssets Assets
        {
            get { return _Assets; }
            set
            {
                _Assets = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scAssets);
            }
        }

        private clsParts _Parts = null;
        public clsParts Parts
        {
            get { return _Parts; }
            set
            {
                _Parts = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scParts);
            }
        }

        private clsCostItems _CostItems = null;
        public clsCostItems CostItems
        {
            get { return _CostItems; }
            set
            {
                _CostItems = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scCostItems);
            }
        }

        private clsCAPIds _parentCAPIds = null;
        public clsCAPIds parentCAPIds
        {
            get { return _parentCAPIds; }
            set
            {
                _parentCAPIds = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scParentCAPIds);
            }
        }

        private clsDepartment _Department = null;
        public clsDepartment Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scDepartment);
            }
        }

        private clsStaffPerson _StaffPerson = null;
        public clsStaffPerson StaffPerson
        {
            get { return _StaffPerson; }
            set
            {
                _StaffPerson = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scStaffPerson);
            }
        }

        private DateTime? _assignedDate = null;
        [XmlIgnore]
        public DateTime? assignedDate
        {
            get { return _assignedDate; }
            set
            {
                _assignedDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scAssignedDate);
            }
        }
        [XmlElement("assignedDate")]
        public string assignedDateString
        {
            get
            {
                if (_assignedDate.HasValue)
                {
                    return _assignedDate.Value.ToString(Constants.cDateFormat);
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
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scAssignedDate);
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

        private DateTime? _scheduleDate;
        [XmlIgnore]
        public DateTime? ScheduleDate
        {
            get { return _scheduleDate; }
            set
            {
                _scheduleDate = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scScheduleDate);
            }
        }
        [XmlElement("ScheduleDate")]
        public string ScheduleDateString
        {
            get
            {
                if (_scheduleDate.HasValue)
                {
                    return _scheduleDate.Value.ToString(Constants.cDateFormat);
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
                    _scheduleDate = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scScheduleDate);
                }
                else
                {
                    _scheduleDate = null;
                }
            }
        }
        public bool ScheduleDateStringSpecified
        {
            get { return _scheduleDate != null; }
        }

        private DateTime? _scheduleTime;
        [XmlIgnore]
        public DateTime? ScheduleTime
        {
            get { return _scheduleTime; }
            set
            {
                _scheduleTime = value;
                ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scScheduleTime);
            }
        }
        [XmlElement("ScheduleTime")]
        public string ScheduleTimeString
        {
            get
            {
                if (_scheduleTime.HasValue)
                {
                    return _scheduleTime.Value.ToString(Constants.cTimeFormat);
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
                    _scheduleTime = td;
                    ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect.scScheduleTime);
                }
                else
                {
                    _scheduleTime = null;
                }
            }
        }
        public bool ScheduleTimeStringSpecified
        {
            get { return _scheduleTime != null; }
        }
        // End choice
        // End group CAPUpdateCollectionSelect

        // Constructors
        public msgUpdateCAP()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCAPUpdateCollectionSelect pSelectedChoice)
        {
            return;
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scAdditionalInformation)
            //{
            //    _AdditionalInformation = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scAddresses)
            //{
            //    _Addresses = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scApprovalDate)
            //{
            //    _ApprovalDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scCAPRelations)
            //{
            //    _CAPRelations = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scChecklist)
            //{
            //    _Checklist = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scCompactAddresses)
            //{
            //    _CompactAddresses = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scConditions)
            //{
            //    _Conditions = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scContacts)
            //{
            //    _Contacts = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scDescription)
            //{
            //    _Description = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scEffectiveDate)
            //{
            //    _EffectiveDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scExpirationDate)
            //{
            //    _ExpirationDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scElectronicSignatures)
            //{
            //    _ElectronicSignatures = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scFileDate)
            //{
            //    _FileDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scGISObjects)
            //{
            //    _GISObjects = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scGISObjectIds)
            //{
            //    _GISObjectIds = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scHolds)
            //{
            //    _Holds = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scParcelIds)
            //{
            //    _ParcelIds = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scParcels)
            //{
            //    _Parcels = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scSpatialDescriptors)
            //{
            //    _SpatialDescriptors = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scSpatialObjects)
            //{
            //    _SpatialObjects = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scStatus)
            //{
            //    _Status = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scType)
            //{
            //    _Type = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scWorksheets)
            //{
            //    _Worksheets = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scAssets)
            //{
            //    _Assets = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scParts)
            //{
            //    _Parts = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scCostItems)
            //{
            //    _CostItems = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scParentCAPIds)
            //{
            //    _parentCAPIds = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scDepartment)
            //{
            //    _Department = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scStaffPerson)
            //{
            //    _StaffPerson = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scAssignedDate)
            //{
            //    _assignedDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scScheduleDate)
            //{
            //    _ScheduleDate = null;
            //}
            //if (pSelectedChoice != eChoiceCAPUpdateCollectionSelect.scScheduleTime)
            //{
            //    _ScheduleTime = null;
            //}
        }

    }
}

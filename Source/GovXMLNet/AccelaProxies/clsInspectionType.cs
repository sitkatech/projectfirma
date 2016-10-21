using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="InspectionType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
          <xsd:element ref="InspectionStatus" minOccurs="0"/>
          <xsd:element ref="Dispositions" minOccurs="0"/>
          <xsd:element ref="GuidesheetIds" minOccurs="0"/>
          <xsd:element ref="GuidesheetGroups" minOccurs="0"/>
          <xsd:element name="autoAssign" type="xsd:boolean" minOccurs="0"/>
          <xsd:element name="inspectionUnit" type="xsd:double" minOccurs="0"/>
          <xsd:element name="maxTotalGuidesheetsValue" type="xsd:double" minOccurs="0"/>
          <xsd:element name="useDefaultGuidesheets" type="xsd:boolean" minOccurs="0"/>
          <xsd:element ref="StandardCommentsGroupIds" minOccurs="0"/>
          <xsd:element ref="IVRCode" minOccurs="0" maxOccurs="1"/>
          <xsd:element name="carryOverFlag" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="allowFailedGuidesheet" type="xsd:string" minOccurs="0" maxOccurs="1" />
          <xsd:element name="timeAccountSecurity" type="xsd:string" minOccurs="0" maxOccurs="1" />
        </xsd:sequence>
      </xsd:extension>
    </xsd:complexContent>
  </xsd:complexType>
*/


/*
   From Accela
   Note: Key[0] is the sequence number of inspection type, 
         Key[1] is GroupCode of inspection type, 
         Key[2] is the Name of inspection type. 
   This is different from the Keys defined in other requests, in other requests, 
   the Key[0] is GroupCode, Key[1] is Inspection Type Name, Key[2] is sequence number. 
   
   I think this should be fixed in feature release(in AA7.2 or AA 7.3).
   However, we can identify it as a know issue so far, and distinguish the keys definition as 
   “Key[0] is the sequence number of inspection type, Key[1] is GroupCode of inspection type, Key[2] is the Name of inspection type” 
   for this request.
 */
/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsInspectionType : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsInspectionStatus InspectionStatus { get; set; }
        public clsDispositions Dispositions { get; set; }
        public clsGuidesheetIds GuidesheetIds { get; set; }
        public clsGuidesheetGroups GuidesheetGroups { get; set; }

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

        private double? _maxTotalGuidesheetsValue = null;
        public double? maxTotalGuidesheetsValue
        {
            get
            {
                if (_maxTotalGuidesheetsValue.HasValue)
                {
                    return _maxTotalGuidesheetsValue.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _maxTotalGuidesheetsValue = value; }
        }
        public bool maxTotalGuidesheetsValueSpecified
        {
            get { return _maxTotalGuidesheetsValue != null; }
        }

        private bool? _useDefaultGuidesheets = null;
        public bool? useDefaultGuidesheets
        {
            get
            {
                if (_useDefaultGuidesheets.HasValue)
                {
                    return _useDefaultGuidesheets.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _useDefaultGuidesheets = value; }
        }
        public bool useDefaultGuidesheetsSpecified
        {
            get { return _useDefaultGuidesheets != null; }
        }

        public clsStandardCommentsGroupIds StandardCommentsGroupIds { get; set; }

        private int? _IVRCode = null;
        public int? IVRCode
        {
            get
            {
                if (IVRCode.HasValue)
                {
                    return IVRCode.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _IVRCode = value; }
        }
        public bool IVRCodeSpecified
        {
            get { return _IVRCode != null; }
        }

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

        private string _timeAccountSecurity = null;
        public string timeAccountSecurity
        {
            get { return _timeAccountSecurity; }
            set { _timeAccountSecurity = value; }
        }
      
        // Constructors
        public clsInspectionType()
        {
        }

        public clsInspectionType(string pInspectionType)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pInspectionType });
            }
            else
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                else
                {
                    Keys.Key.Clear();
                }
                Keys.Key.AddRange(new string[] { pInspectionType });
            }
        }

        public clsInspectionType(string pInspectionGroupCode, string pInspectionType, int pInspectionTypeSeqNbr)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pInspectionGroupCode, pInspectionType, pInspectionTypeSeqNbr.ToString() });
            }
            else
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                else
                {
                    Keys.Key.Clear();
                }
                Keys.Key.AddRange(new string[] { pInspectionGroupCode, pInspectionType, pInspectionTypeSeqNbr.ToString() });
            }
        }
    }
}

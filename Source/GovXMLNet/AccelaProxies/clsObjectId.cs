using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ObjectId">
		<xsd:complexContent>
			<xsd:extension base="Identifier">
				<xsd:sequence>
					<xsd:element name="contextType" type="objectContextTypeEnum" form="qualified" minOccurs="0"/>
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
    public class clsObjectId : clsIdentifier
    {
        // Members
        private objectContextTypeEnum? _contextType = null;
        public objectContextTypeEnum? contextType
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

        // Constructors
        public clsObjectId()
        {
        }

        public clsObjectId(string pB1PerId1, string pB1PerId2, string pB1PerId3)
        {
            contextType = objectContextTypeEnum.CAP;

            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1PerId1, pB1PerId2, pB1PerId3 });
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
                Keys.Key.AddRange(new string[] { pB1PerId1, pB1PerId2, pB1PerId3 });
            }
        }

        public clsObjectId(string pB1PerId1, string pB1PerId2, string pB1PerId3, long pInspectionNbr)
        {
            contextType = objectContextTypeEnum.Inspection;

            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1PerId1, pB1PerId2, pB1PerId3, pInspectionNbr.ToString() });
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
                Keys.Key.AddRange(new string[] { pB1PerId1, pB1PerId2, pB1PerId3, pInspectionNbr.ToString() });
            }
        }

        public clsObjectId(string pParcelNbr)
        {
            contextType = objectContextTypeEnum.Parcel;

            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pParcelNbr });
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
                Keys.Key.AddRange(new string[] { pParcelNbr });
            }
        }

    }
}

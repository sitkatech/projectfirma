using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPId">
		<xsd:complexContent>
			<xsd:extension base="Identifier">
				<xsd:sequence minOccurs="0">
					<xsd:element name="TrackingNumber" type="xsd:nonNegativeInteger" form="qualified" minOccurs="0"/>
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
    public class clsCAPId : clsIdentifier
    {
        // Members
        private ulong? _TrackingNumber = null;
        public ulong? TrackingNumber
        {
            get
            {
                if (_TrackingNumber.HasValue)
                {
                    return _TrackingNumber.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _TrackingNumber = value; }
        }
        public bool TrackingNumberSpecified
        {
            get { return _TrackingNumber != null; }
        }


        // Constructors
        public clsCAPId()
        {
        }

        public clsCAPId(string pB1PerID1, string pB1PerID2, string pB1PerID3)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1PerID1, pB1PerID2, pB1PerID3 });
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
                Keys.Key.AddRange(new string[] { pB1PerID1, pB1PerID2, pB1PerID3 });
            }
        }

        /*
        public clsCAPId(string pB1AltId)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1AltId });
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
                Keys.Key.AddRange(new string[] { pB1AltId });
            }
        }
        */
    }
}

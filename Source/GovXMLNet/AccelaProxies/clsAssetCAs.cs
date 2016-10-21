using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
 * Only defined as
 * 
 * <xsd:element name="AssetCAs" type="Identifier" abstract="true" nillable="true" id="gov_assetCAs"/>
 * 
 * but should probably be a list
 */

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsAssetCAs : clsElementList
    {
        [XmlElement(ElementName = "AssetCA")]
        public List<clsAssetCA> AssetCA { get; set; }

        // Constructors
        public clsAssetCAs()
        {
        }
    }
}

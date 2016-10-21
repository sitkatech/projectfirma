using System.Collections.Generic;
using System.Xml.Serialization;

// Found in getCapTypes response

/* Version Last Modified: 6.7
        <DocumentGroupIds>
          <DocumentGroupId>
            <Keys>
              <Key>CEVEHICLE</Key>
            </Keys>
            <IdentifierDisplay>CEVEHICLE</IdentifierDisplay>
          </DocumentGroupId>
        </DocumentGroupIds>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class undDocumentGroupIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "DocumentGroupId")]
        public List<clsDocumentId> DocumentGroupId { get; set; }

        // Constructors
        public undDocumentGroupIds()
        {
        }
    }
}

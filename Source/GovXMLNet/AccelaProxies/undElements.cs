using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
 * Can't find any definition
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class undElements : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Element")]
        public List<clsElement> Element { get; set; }

        // Constructors
        public undElements()
        {
        }
    }
}

using System.Xml.Serialization;

// Not Defined in xsd files that I can find, but documented is the output of the error packet

/* Version Last Modified: 6.7
 <GovXML xmlns="http://www.accela.com/schema/AccelaOpenSystemInterfaceXML">
   <FSystemOut>
     <System>
      <XMLVersion>GovXML-6.6.0</XMLVersion> <ApplicationState/> -<Error>
        <ErrorCode>0001</ErrorCode>
        <ErrorMessage>Not a supported function : java.lang.Exception: Not a supported function at com.accela.aa.aaxml.govxml.operations.GovXMLSwitch.XMLService(GovXMLSwitch.java:2855)</ErrorMessage>
      </Error>
    </System>
  </FSystemOut>
</GovXML>*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class undFSystemOut
    {
        // Members
        [XmlElement(ElementName = "System")]
        public clsSystem System { get; set; }

        // Constructors
        public undFSystemOut()
        {
            //System.Error = new clsError();
        }
    }
}

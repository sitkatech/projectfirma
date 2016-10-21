using System;
using System.Xml.Serialization;

// Not Defined in xsd files that I can find, but documented is the output of section found in CAP

/* Version Last Modified: 6.7
      <CAPDetail>
        <TotalJobCost>0.0</TotalJobCost>
        <ClosedDept>ACFW/FTWAYNE/CE/OFFICE/NA/NA/NA</ClosedDept>
        <ClosedDate>2010-08-16</ClosedDate>
        <CompleteDept>ACFW/FTWAYNE/CE/OFFICE/NA/NA/NA</CompleteDept>
        <CompleteStaff>Diane E McCrady</CompleteStaff>
        <CompleteDate>2010-07-28</CompleteDate>
      </CAPDetail>
 */

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class undCAPDetail
    {
        // Members
        private decimal _TotalJobCost = 0;
        public decimal TotalJobCost
        {
            get { return _TotalJobCost; }
            set { _TotalJobCost = value; }
        }

        private string _ClosedDept = null;
        public string ClosedDept
        {
            get { return _ClosedDept; }
            set { _ClosedDept = value; }
        }

        [XmlIgnore]
        public DateTime? ClosedDate { get; set; }
        [XmlElement("ClosedDate")]
        public string ClosedDateString
        {
            get
            {
                if (ClosedDate.HasValue)
                {
                    return ClosedDate.Value.ToString(Constants.cDateFormat); ;
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
                    ClosedDate = td;
                }
                else
                {
                    ClosedDate = null;
                }
            }
        }
        public bool ClosedDateStringSpecified
        {
            get { return ClosedDate != null; }
        }

        private string vCompleteDept = null;
        public string CompleteDept
        {
            get { return vCompleteDept; }
            set { vCompleteDept = value; }
        }

        private string vCompleteStaff = null;
        public string CompleteStaff
        {
            get { return vCompleteStaff; }
            set { vCompleteStaff = value; }
        }

        [XmlIgnore]
        public DateTime? CompleteDate { get; set; }
        [XmlElement("CompleteDate")]
        public string CompleteDateString
        {
            get
            {
                if (CompleteDate.HasValue)
                {
                    return CompleteDate.Value.ToString(Constants.cDateFormat); ;
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
                    CompleteDate = td;
                }
                else
                {
                    CompleteDate = null;
                }
            }
        }
        public bool CompleteDateStringSpecified
        {
            get { return CompleteDate != null; }
        }


        // Constructors 
        public undCAPDetail()
        {
        }
    }
}

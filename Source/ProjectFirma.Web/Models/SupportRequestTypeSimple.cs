namespace ProjectFirma.Web.Models
{
    public class SupportRequestTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public SupportRequestTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SupportRequestTypeSimple(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder)
            : this()
        {
            SupportRequestTypeID = supportRequestTypeID;
            SupportRequestTypeName = supportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestTypeSortOrder;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public SupportRequestTypeSimple(SupportRequestType supportRequestType)
            : this()
        {
            SupportRequestTypeID = supportRequestType.SupportRequestTypeID;
            SupportRequestTypeName = supportRequestType.SupportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestType.SupportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestType.SupportRequestTypeSortOrder;
        }

        public int SupportRequestTypeID { get; set; }
        public string SupportRequestTypeName { get; set; }
        public string SupportRequestTypeDisplayName { get; set; }
        public int SupportRequestTypeSortOrder { get; set; }
    }
}
//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    [Table("[dbo].[FirmaPageType]")]
    public partial class FirmaPageType : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaPageType()
        {
            this.FirmaPages = new HashSet<FirmaPage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPageType(int firmaPageTypeID, string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : this()
        {
            this.FirmaPageTypeID = firmaPageTypeID;
            this.FirmaPageTypeName = firmaPageTypeName;
            this.FirmaPageTypeDisplayName = firmaPageTypeDisplayName;
            this.FirmaPageRenderTypeID = firmaPageRenderTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaPageType(string firmaPageTypeName, string firmaPageTypeDisplayName, int firmaPageRenderTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FirmaPageTypeName = firmaPageTypeName;
            this.FirmaPageTypeDisplayName = firmaPageTypeDisplayName;
            this.FirmaPageRenderTypeID = firmaPageRenderTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FirmaPageType(string firmaPageTypeName, string firmaPageTypeDisplayName, FirmaPageRenderType firmaPageRenderType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaPageTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FirmaPageTypeName = firmaPageTypeName;
            this.FirmaPageTypeDisplayName = firmaPageTypeDisplayName;
            this.FirmaPageRenderTypeID = firmaPageRenderType.FirmaPageRenderTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaPageType CreateNewBlank(FirmaPageRenderType firmaPageRenderType)
        {
            return new FirmaPageType(default(string), default(string), firmaPageRenderType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FirmaPages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaPageType).Name, typeof(FirmaPage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FirmaPageTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in FirmaPages.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FirmaPageTypeID { get; set; }
        public string FirmaPageTypeName { get; set; }
        public string FirmaPageTypeDisplayName { get; set; }
        public int FirmaPageRenderTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaPageTypeID; } set { FirmaPageTypeID = value; } }

        public virtual ICollection<FirmaPage> FirmaPages { get; set; }
        public FirmaPageRenderType FirmaPageRenderType { get { return FirmaPageRenderType.AllLookupDictionary[FirmaPageRenderTypeID]; } }

        public static class FieldLengths
        {
            public const int FirmaPageTypeName = 100;
            public const int FirmaPageTypeDisplayName = 100;
        }
    }

    
    public enum FirmaPageTypeEnum
    {
        HomePage = 1,
        DemoScript = 4,
        InternalSetupNotes = 5,
        FullProjectList = 6,
        PerformanceMeasuresList = 9,
        TaxonomyLeafList = 11,
        TaxonomyBranchList = 13,
        TaxonomyTrunkList = 14,
        FundingSourcesList = 15,
        OrganizationsList = 16,
        MyProjects = 18,
        ProjectResults = 20,
        ProjectMap = 22,
        HomeMapInfo = 24,
        HomeAdditionalInfo = 25,
        FeaturedProjectList = 26,
        CostParameterSet = 31,
        FullProjectListSimple = 33,
        Taxonomy = 34,
        TagList = 36,
        SpendingByPerformanceMeasureByProject = 37,
        Proposals = 38,
        MyOrganizationsProjects = 39,
        ManageUpdateNotifications = 41,
        ProposeProjectInstructions = 45,
        ProjectStewardOrganizationList = 46,
        EnterHistoricProjectInstructions = 47,
        PendingProjects = 48,
        Training = 49,
        ProjectCreateImportExternal = 50,
        CustomFooter = 51,
        ManageProjectCustomAttributeTypeInstructions = 52,
        ManageProjectCustomAttributeTypesList = 53,
        FactSheetCustomText = 54,
        UsersList = 55,
        ProjectUpdateInstructions = 56,
        TechnicalAssistanceInstructions = 57,
        TechnicalAssistanceReport = 58,
        InviteUser = 59,
        ManageFundingSourceCustomAttributeTypeInstructions = 60,
        ManageFundingSourceCustomAttributeTypesList = 61,
        FundingStatusHeader = 62,
        FundingStatusFooter = 63,
        ManageProjectCustomGrids = 64,
        ManageProjectCustomAttributeGroupInstructions = 65,
        ManageProjectCustomAttributeGroupsList = 66,
        ProjectStatusFromTimelineDialog = 67,
        ProjectStatusFromGridDialog = 68,
        ProjectStatusListEditor = 69,
        ExternalMapLayers = 70
    }
}
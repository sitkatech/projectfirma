//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditure]
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
    // Table [dbo].[ProjectFundingSourceExpenditure] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectFundingSourceExpenditure]")]
    public partial class ProjectFundingSourceExpenditure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceExpenditure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceExpenditure(int projectFundingSourceExpenditureID, int projectID, int fundingSourceID, int calendarYear, decimal expenditureAmount, int? costTypeID) : this()
        {
            this.ProjectFundingSourceExpenditureID = projectFundingSourceExpenditureID;
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.CostTypeID = costTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceExpenditure(int projectID, int fundingSourceID, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceExpenditure(Project project, FundingSource fundingSource, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectFundingSourceExpenditures.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceExpenditures.Add(this);
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceExpenditure CreateNewBlank(Project project, FundingSource fundingSource)
        {
            return new ProjectFundingSourceExpenditure(project, fundingSource, default(int), default(decimal));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceExpenditure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectFundingSourceExpenditures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectFundingSourceExpenditureID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int CalendarYear { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public int? CostTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectFundingSourceExpenditureID; } set { ProjectFundingSourceExpenditureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public virtual CostType CostType { get; set; }

        public static class FieldLengths
        {

        }
    }
}
//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateConfiguration : EntityTypeConfiguration<ProjectUpdate>
    {
        public ProjectUpdateConfiguration() : this("dbo"){}

        public ProjectUpdateConfiguration(string schema)
        {
            ToTable("ProjectUpdate", schema);
            HasKey(x => x.ProjectUpdateID);
            Property(x => x.ProjectUpdateID).HasColumnName(@"ProjectUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStageID).HasColumnName(@"ProjectStageID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectDescription).HasColumnName(@"ProjectDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.ImplementationStartYear).HasColumnName(@"ImplementationStartYear").HasColumnType("int").IsOptional();
            Property(x => x.CompletionYear).HasColumnName(@"CompletionYear").HasColumnType("int").IsOptional();
            Property(x => x.EstimatedTotalCost).HasColumnName(@"EstimatedTotalCost").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ProjectLocationPoint).HasColumnName(@"ProjectLocationPoint").HasColumnType("geometry").IsOptional();
            Property(x => x.ProjectLocationNotes).HasColumnName(@"ProjectLocationNotes").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.PlanningDesignStartYear).HasColumnName(@"PlanningDesignStartYear").HasColumnType("int").IsOptional();
            Property(x => x.ProjectLocationSimpleTypeID).HasColumnName(@"ProjectLocationSimpleTypeID").HasColumnType("int").IsRequired();
            Property(x => x.EstimatedAnnualOperatingCost).HasColumnName(@"EstimatedAnnualOperatingCost").HasColumnType("decimal").IsOptional();
            Property(x => x.PrimaryContactPersonID).HasColumnName(@"PrimaryContactPersonID").HasColumnType("int").IsOptional();
            Property(x => x.FundingTypeID).HasColumnName(@"FundingTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasOptional(a => a.PrimaryContactPerson).WithMany(b => b.ProjectUpdatesWhereYouAreThePrimaryContactPerson).HasForeignKey(c => c.PrimaryContactPersonID).WillCascadeOnDelete(false); // FK_ProjectUpdate_Person_PrimaryContactPersonID_PersonID
        }
    }
}
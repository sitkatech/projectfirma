//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ImportExternalProjectStaging]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImportExternalProjectStagingConfiguration : EntityTypeConfiguration<ImportExternalProjectStaging>
    {
        public ImportExternalProjectStagingConfiguration() : this("dbo"){}

        public ImportExternalProjectStagingConfiguration(string schema)
        {
            ToTable("ImportExternalProjectStaging", schema);
            HasKey(x => x.ImportExternalProjectStagingID);
            Property(x => x.ImportExternalProjectStagingID).HasColumnName(@"ImportExternalProjectStagingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ProjectName).HasColumnName(@"ProjectName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(140);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(4000);
            Property(x => x.PlanningDesignStartYear).HasColumnName(@"PlanningDesignStartYear").HasColumnType("smallint").IsOptional();
            Property(x => x.ImplementationStartYear).HasColumnName(@"ImplementationStartYear").HasColumnType("smallint").IsOptional();
            Property(x => x.EndYear).HasColumnName(@"EndYear").HasColumnType("smallint").IsOptional();
            Property(x => x.EstimatedCost).HasColumnName(@"EstimatedCost").HasColumnType("float").IsOptional();

            // Foreign keys
            HasRequired(a => a.CreatePerson).WithMany(b => b.ImportExternalProjectStagingsWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ImportExternalProjectStaging_Person_CreatePersonID_PersonID
        }
    }
}
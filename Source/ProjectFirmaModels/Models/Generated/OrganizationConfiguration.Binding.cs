//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration() : this("dbo"){}

        public OrganizationConfiguration(string schema)
        {
            ToTable("Organization", schema);
            HasKey(x => x.OrganizationID);
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationGuid).HasColumnName(@"OrganizationGuid").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.OrganizationName).HasColumnName(@"OrganizationName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.OrganizationShortName).HasColumnName(@"OrganizationShortName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.PrimaryContactPersonID).HasColumnName(@"PrimaryContactPersonID").HasColumnType("int").IsOptional();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            Property(x => x.OrganizationUrl).HasColumnName(@"OrganizationUrl").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.LogoFileResourceInfoID).HasColumnName(@"LogoFileResourceInfoID").HasColumnType("int").IsOptional();
            Property(x => x.OrganizationTypeID).HasColumnName(@"OrganizationTypeID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationBoundary).HasColumnName(@"OrganizationBoundary").HasColumnType("geometry").IsOptional();
            Property(x => x.ShortDescription).HasColumnName(@"ShortDescription").HasColumnType("varchar").IsOptional();

            // Foreign keys
            HasOptional(a => a.PrimaryContactPerson).WithMany(b => b.OrganizationsWhereYouAreThePrimaryContactPerson).HasForeignKey(c => c.PrimaryContactPersonID).WillCascadeOnDelete(false); // FK_Organization_Person_PrimaryContactPersonID_PersonID
            HasOptional(a => a.LogoFileResourceInfo).WithMany(b => b.OrganizationsWhereYouAreTheLogoFileResourceInfo).HasForeignKey(c => c.LogoFileResourceInfoID).WillCascadeOnDelete(false); // FK_Organization_FileResourceInfo_LogoFileResourceInfoID_FileResourceInfoID
            HasRequired(a => a.OrganizationType).WithMany(b => b.Organizations).HasForeignKey(c => c.OrganizationTypeID).WillCascadeOnDelete(false); // FK_Organization_OrganizationType_OrganizationTypeID
        }
    }
}
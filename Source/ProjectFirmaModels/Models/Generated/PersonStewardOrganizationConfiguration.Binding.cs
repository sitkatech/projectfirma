//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardOrganization]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonStewardOrganizationConfiguration : EntityTypeConfiguration<PersonStewardOrganization>
    {
        public PersonStewardOrganizationConfiguration() : this("dbo"){}

        public PersonStewardOrganizationConfiguration(string schema)
        {
            ToTable("PersonStewardOrganization", schema);
            HasKey(x => x.PersonStewardOrganizationID);
            Property(x => x.PersonStewardOrganizationID).HasColumnName(@"PersonStewardOrganizationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonStewardOrganizations).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonStewardOrganization_Person_PersonID
            HasRequired(a => a.Organization).WithMany(b => b.PersonStewardOrganizations).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_PersonStewardOrganization_Organization_OrganizationID
        }
    }
}
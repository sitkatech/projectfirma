//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardTaxonomyBranch]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonStewardTaxonomyBranchConfiguration : EntityTypeConfiguration<PersonStewardTaxonomyBranch>
    {
        public PersonStewardTaxonomyBranchConfiguration() : this("dbo"){}

        public PersonStewardTaxonomyBranchConfiguration(string schema)
        {
            ToTable("PersonStewardTaxonomyBranch", schema);
            HasKey(x => x.PersonStewardTaxonomyBranchID);
            Property(x => x.PersonStewardTaxonomyBranchID).HasColumnName(@"PersonStewardTaxonomyBranchID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.TaxonomyBranchID).HasColumnName(@"TaxonomyBranchID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonStewardTaxonomyBranches).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonStewardTaxonomyBranch_Person_PersonID
            HasRequired(a => a.TaxonomyBranch).WithMany(b => b.PersonStewardTaxonomyBranches).HasForeignKey(c => c.TaxonomyBranchID).WillCascadeOnDelete(false); // FK_PersonStewardTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID
        }
    }
}
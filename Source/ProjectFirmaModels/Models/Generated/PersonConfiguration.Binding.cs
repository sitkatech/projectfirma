//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Person]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration() : this("dbo"){}

        public PersonConfiguration(string schema)
        {
            ToTable("Person", schema);
            HasKey(x => x.PersonID);
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonGuid).HasColumnName(@"PersonGuid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.PasswordPdfK2SaltHash).HasColumnName(@"PasswordPdfK2SaltHash").HasColumnType("nvarchar").IsOptional().HasMaxLength(1000);
            Property(x => x.RoleID).HasColumnName(@"RoleID").HasColumnType("int").IsRequired();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LastActivityDate).HasColumnName(@"LastActivityDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.ReceiveSupportEmails).HasColumnName(@"ReceiveSupportEmails").HasColumnType("bit").IsRequired();
            Property(x => x.WebServiceAccessToken).HasColumnName(@"WebServiceAccessToken").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.LoginName).HasColumnName(@"LoginName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(128);
            Property(x => x.ContactTypeID).HasColumnName(@"ContactTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.People).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_Person_Organization_OrganizationID
            HasOptional(a => a.ContactType).WithMany(b => b.People).HasForeignKey(c => c.ContactTypeID).WillCascadeOnDelete(false); // FK_Person_ContactType_ContactTypeID
        }
    }
}
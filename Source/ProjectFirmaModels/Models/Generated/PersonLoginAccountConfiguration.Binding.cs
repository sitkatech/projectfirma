//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonLoginAccount]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonLoginAccountConfiguration : EntityTypeConfiguration<PersonLoginAccount>
    {
        public PersonLoginAccountConfiguration() : this("dbo"){}

        public PersonLoginAccountConfiguration(string schema)
        {
            ToTable("PersonLoginAccount", schema);
            HasKey(x => x.PersonLoginAccountID);
            Property(x => x.PersonLoginAccountID).HasColumnName(@"PersonLoginAccountID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.PersonLoginAccountName).HasColumnName(@"PersonLoginAccountName").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();
            Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.PasswordSalt).HasColumnName(@"PasswordSalt").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
            Property(x => x.LoginActive).HasColumnName(@"LoginActive").HasColumnType("bit").IsRequired();
            Property(x => x.LastLoginDate).HasColumnName(@"LastLoginDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LastLogoutDate).HasColumnName(@"LastLogoutDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LoginCount).HasColumnName(@"LoginCount").HasColumnType("int").IsRequired();
            Property(x => x.FailedLoginCount).HasColumnName(@"FailedLoginCount").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonLoginAccounts).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonLoginAccount_Person_PersonID
        }
    }
}
//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSession]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FirmaSessionConfiguration : EntityTypeConfiguration<FirmaSession>
    {
        public FirmaSessionConfiguration() : this("dbo"){}

        public FirmaSessionConfiguration(string schema)
        {
            ToTable("FirmaSession", schema);
            HasKey(x => x.FirmaSessionID);
            Property(x => x.FirmaSessionID).HasColumnName(@"FirmaSessionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FirmaSessionGuid).HasColumnName(@"FirmaSessionGuid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalPersonID).HasColumnName(@"OriginalPersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasOptional(a => a.Person).WithMany(b => b.FirmaSessions).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_FirmaSession_Person_PersonID
            HasOptional(a => a.OriginalPerson).WithMany(b => b.FirmaSessionsWhereYouAreTheOriginalPerson).HasForeignKey(c => c.OriginalPersonID).WillCascadeOnDelete(false); // FK_FirmaSession_Person_OriginalPersonID_PersonID
        }
    }
}
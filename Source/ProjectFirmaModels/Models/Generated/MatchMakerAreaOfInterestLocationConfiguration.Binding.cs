//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchMakerAreaOfInterestLocation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class MatchMakerAreaOfInterestLocationConfiguration : EntityTypeConfiguration<MatchMakerAreaOfInterestLocation>
    {
        public MatchMakerAreaOfInterestLocationConfiguration() : this("dbo"){}

        public MatchMakerAreaOfInterestLocationConfiguration(string schema)
        {
            ToTable("MatchMakerAreaOfInterestLocation", schema);
            HasKey(x => x.MatchMakerAreaOfInterestLocationID);
            Property(x => x.MatchMakerAreaOfInterestLocationID).HasColumnName(@"MatchMakerAreaOfInterestLocationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsRequired();
            Property(x => x.MatchMakerAreaOfInterestLocationGeometry).HasColumnName(@"MatchMakerAreaOfInterestLocationGeometry").HasColumnType("geometry").IsRequired();
            Property(x => x.Annotation).HasColumnName(@"Annotation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.Organization).WithMany(b => b.MatchMakerAreaOfInterestLocations).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_MatchMakerAreaOfInterestLocation_Organization_OrganizationID
        }
    }
}
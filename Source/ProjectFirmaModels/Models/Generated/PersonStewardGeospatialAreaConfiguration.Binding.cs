//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardGeospatialArea]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PersonStewardGeospatialAreaConfiguration : EntityTypeConfiguration<PersonStewardGeospatialArea>
    {
        public PersonStewardGeospatialAreaConfiguration() : this("dbo"){}

        public PersonStewardGeospatialAreaConfiguration(string schema)
        {
            ToTable("PersonStewardGeospatialArea", schema);
            HasKey(x => x.PersonStewardGeospatialAreaID);
            Property(x => x.PersonStewardGeospatialAreaID).HasColumnName(@"PersonStewardGeospatialAreaID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Person).WithMany(b => b.PersonStewardGeospatialAreas).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_PersonStewardGeospatialArea_Person_PersonID
            HasRequired(a => a.GeospatialArea).WithMany(b => b.PersonStewardGeospatialAreas).HasForeignKey(c => c.GeospatialAreaID).WillCascadeOnDelete(false); // FK_PersonStewardGeospatialArea_GeospatialArea_GeospatialAreaID
        }
    }
}
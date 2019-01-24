//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocument]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectDocumentConfiguration : EntityTypeConfiguration<ProjectDocument>
    {
        public ProjectDocumentConfiguration() : this("dbo"){}

        public ProjectDocumentConfiguration(string schema)
        {
            ToTable("ProjectDocument", schema);
            HasKey(x => x.ProjectDocumentID);
            Property(x => x.ProjectDocumentID).HasColumnName(@"ProjectDocumentID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceID).HasColumnName(@"FileResourceID").HasColumnType("int").IsRequired();
            Property(x => x.DisplayName).HasColumnName(@"DisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectDocuments).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectDocument_Project_ProjectID
            HasRequired(a => a.FileResource).WithMany(b => b.ProjectDocuments).HasForeignKey(c => c.FileResourceID).WillCascadeOnDelete(false); // FK_ProjectDocument_FileResource_FileResourceID
        }
    }
}
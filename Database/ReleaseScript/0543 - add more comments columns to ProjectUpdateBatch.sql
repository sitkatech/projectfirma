alter table dbo.ProjectUpdateBatch add PhotosComment varchar(1000)
alter table dbo.ProjectUpdateBatch add AttachmentsAndNotesComment varchar(1000)
alter table dbo.ProjectUpdateBatch add ExternalLinksComment varchar(1000)

alter table dbo.Project add ExternalLinksComment varchar(1000)
/* 
select * from TrainingVideo
select * from Tenant
*/

ALTER TABLE dbo.TrainingVideo
ALTER COLUMN VideoDescription varchar(1000)

go

insert into dbo.TrainingVideo (TenantID, VideoName, VideoDescription, VideoUploadDate, VideoURL)
select TenantID, 
'Custom Reporting with Microsoft Word' as VideoName,
'Learn the basics of the Custom Report functionality available to users in ProjectFirma. With Custom Reports, you are able to insert Project data from ProjectFirma into custom formatted Word documents. This video covers the full webcast, see links below for specific chapters. <ul><li><a target="_blank" href="https://youtu.be/pjfkxURu5xg">Introduction and Overview (7 minutes 41 seconds)</a></li><li><a target="_blank" href="https://youtu.be/2N4V89y6uj4">Interactive Demo (43 minutes 31 seconds)</a></li><li><a target="_blank" href="https://youtu.be/jbtyqis1nAA">Q & A (4 minutes 33 seconds)</a></li></ul>' as VideoDescription,
'2020-06-25 00:00:00.000' as VideoUploadDate,
'https://youtube.com/embed/2gA1NcTgebI' as VideoURL
 from dbo.Tenant


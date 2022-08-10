
update dbo.TrainingVideo set 
VideoURL = 'https://www.youtube.com/embed/ijIxiMiFeJM'
, VideoDescription = 'This is a ProjectFirma training video on how to create an account in the NCRP Project Tracker.'
, VideoUploadDate = '2022-08-05'
where TenantID = 4 and VideoName = 'Account Management and User Details'

update dbo.TrainingVideo set
VideoURL = 'https://www.youtube.com/embed/E76BJL8rniY'
, VideoDescription = 'This is a ProjectFirma training video on how to add a new project in the NCRP Project Tracker.'
, VideoUploadDate = '2022-08-05'
where TenantID = 4 and VideoName = 'Adding a New Project'

update dbo.TrainingVideo set 
VideoURL = 'https://www.youtube.com/embed/l7GnFBcEJmc'
, VideoDescription = 'This is the ProjectFirma training video on how to update a project in the NCRP Project Tracker.'
, VideoUploadDate = '2022-08-05'
where TenantID = 4 and VideoName = 'Updating an Existing Project'

insert into dbo.TrainingVideo (TenantID, VideoName, VideoDescription, VideoUploadDate, VideoURL)
values
(4, 'Requesting Support', 'This is a ProjectFirma training video on how to request support in the NCRP Project Tracker.', '2022-08-05', 'https://www.youtube.com/embed/CE4OBFXqiSI'),
(4, 'Summary Pages Overview', 'This is the ProjectFirma training video on how project information is can be explored through the NCRP Project Tracker Summary Pages.', '2022-08-05', 'https://www.youtube.com/embed/x6ZnP-8M7XY')
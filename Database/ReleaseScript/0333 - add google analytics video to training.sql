insert into dbo.TrainingVideo (TenantID, VideoName, VideoDescription, VideoUploadDate, VideoURL)
select 
    TenantID, 
    'ProjectFirma Google Analytics', 
    'This video is a high level overview of the ProjectFirma Google Analytics integration. The video covers basics on how to use it, and what ProjectFirma users might gain from using it.', 
    '2019-11-06 00:00:00.000', 
    'https://www.youtube.com/embed/J4Cp_7sizAo' 
    from Tenant
go
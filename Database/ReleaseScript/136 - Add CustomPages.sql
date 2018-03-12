CREATE TABLE dbo.CustomPageDisplayType(
	CustomPageDisplayTypeID int NOT NULL CONSTRAINT PK_CustomPageDisplayType_CustomPageDisplayTypeID PRIMARY KEY,
	CustomPageDisplayTypeName varchar(100) NOT NULL CONSTRAINT AK_CustomPageDisplayType_CustomPageDisplayTypeName UNIQUE,
	CustomPageDisplayTypeDisplayName varchar(100) NOT NULL CONSTRAINT AK_CustomPageDisplayType_CustomPageDisplayTypeDisplayName UNIQUE,
	CustomPageDisplayTypeDescription varchar(250) not null
)

go

insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (1, 'Disabled', 'Disabled', 'Not visible to any users')
insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (2, 'Public', 'Public', 'Visible to all users')
insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (3, 'Protected', 'Protected', 'Visible to logged in users only')


CREATE TABLE dbo.CustomPage(
	CustomPageID int IDENTITY(1, 1) NOT NULL,
	TenantID int NOT NULL,
	CustomPageDisplayName varchar(100) not null,
	CustomPageVanityUrl varchar(100) not null,
	CustomPageDisplayTypeID int not null,
	CustomPageContent html null,
 CONSTRAINT PK_CustomPage_CustomPageID PRIMARY KEY CLUSTERED 
(
	CustomPageID ASC
),
 CONSTRAINT AK_CustomPage_CustomPageID_TenantID UNIQUE NONCLUSTERED 
(
	CustomPageID ASC,
	TenantID ASC
)
)
GO


ALTER TABLE dbo.CustomPage  WITH CHECK ADD  CONSTRAINT FK_CustomPage_CustomPageDisplayType_CustomPageDisplayTypeID FOREIGN KEY(CustomPageDisplayTypeID)
REFERENCES dbo.CustomPageDisplayType (CustomPageDisplayTypeID)
GO

ALTER TABLE dbo.CustomPage CHECK CONSTRAINT FK_CustomPage_CustomPageDisplayType_CustomPageDisplayTypeID
GO


ALTER TABLE dbo.CustomPage  WITH CHECK ADD  CONSTRAINT FK_CustomPage_Tenant_TenantID FOREIGN KEY(TenantID)
REFERENCES dbo.Tenant (TenantID)
GO

ALTER TABLE dbo.CustomPage CHECK CONSTRAINT FK_CustomPage_Tenant_TenantID
GO


ALTER TABLE dbo.CustomPage ADD  CONSTRAINT AK_CustomPage_CustomPageVanityUrl_TenantID UNIQUE NONCLUSTERED 
(
	CustomPageVanityUrl ASC,
	TenantID ASC
)
GO

ALTER TABLE dbo.CustomPage ADD  CONSTRAINT AK_CustomPage_CustomPageDisplayName_TenantID UNIQUE NONCLUSTERED 
(
	CustomPageDisplayName ASC,
	TenantID ASC
)
GO

CREATE TABLE dbo.CustomPageImage(
	CustomPageImageID int IDENTITY(1,1) NOT NULL,
	TenantID int NOT NULL,
	CustomPageID int NOT NULL,
	FileResourceID int NOT NULL,
 CONSTRAINT PK_CustomPageImage_CustomPageImageID PRIMARY KEY CLUSTERED 
(
	CustomPageImageID ASC
),
 CONSTRAINT AK_CustomPageImage_CustomPageImageID_FileResourceID UNIQUE NONCLUSTERED 
(
	CustomPageImageID ASC,
	FileResourceID ASC
)
)
GO

ALTER TABLE dbo.CustomPageImage  WITH CHECK ADD  CONSTRAINT FK_CustomPageImage_FileResource_FileResourceID FOREIGN KEY(FileResourceID)
REFERENCES dbo.FileResource (FileResourceID)
GO

ALTER TABLE dbo.CustomPageImage CHECK CONSTRAINT FK_CustomPageImage_FileResource_FileResourceID
GO

ALTER TABLE dbo.CustomPageImage  WITH CHECK ADD  CONSTRAINT FK_CustomPageImage_FileResource_FileResourceID_TenantID FOREIGN KEY(FileResourceID, TenantID)
REFERENCES dbo.FileResource (FileResourceID, TenantID)
GO

ALTER TABLE dbo.CustomPageImage CHECK CONSTRAINT FK_CustomPageImage_FileResource_FileResourceID_TenantID
GO

ALTER TABLE dbo.CustomPageImage  WITH CHECK ADD  CONSTRAINT FK_CustomPageImage_CustomPage_CustomPageID FOREIGN KEY(CustomPageID)
REFERENCES dbo.CustomPage (CustomPageID)
GO

ALTER TABLE dbo.CustomPageImage CHECK CONSTRAINT FK_CustomPageImage_CustomPage_CustomPageID
GO

ALTER TABLE dbo.CustomPageImage  WITH CHECK ADD  CONSTRAINT FK_CustomPageImage_CustomPage_CustomPageID_TenantID FOREIGN KEY(CustomPageID, TenantID)
REFERENCES dbo.CustomPage (CustomPageID, TenantID)
GO

ALTER TABLE dbo.CustomPageImage CHECK CONSTRAINT FK_CustomPageImage_CustomPage_CustomPageID_TenantID
GO

ALTER TABLE dbo.CustomPageImage  WITH CHECK ADD  CONSTRAINT FK_CustomPageImage_Tenant_TenantID FOREIGN KEY(TenantID)
REFERENCES dbo.Tenant (TenantID)
GO

ALTER TABLE dbo.CustomPageImage CHECK CONSTRAINT FK_CustomPageImage_Tenant_TenantID
GO


insert into dbo.CustomPage
select fp.TenantID, fpt.FirmaPageTypeDisplayName, 'About', 2, fp.FirmaPageContent
from dbo.FirmaPage fp
join dbo.FirmaPageType fpt
on fp.FirmaPageTypeID = fpt.FirmaPageTypeID
where fpt.FirmaPageTypeID = 2

insert into dbo.CustomPage
select fp.TenantID, fpt.FirmaPageTypeDisplayName, 'MeetingsAndDocuments', 2, fp.FirmaPageContent
from dbo.FirmaPage fp
join dbo.FirmaPageType fpt
on fp.FirmaPageTypeID = fpt.FirmaPageTypeID
where fpt.FirmaPageTypeID = 3 and TenantID = 2

go

DECLARE @customPageID int
SET @customPageID = 
(select cp.CustomPageID
from dbo.CustomPage cp
where cp.TenantID = 2 and cp.CustomPageDisplayName = 'Meetings and Documents')

insert into dbo.CustomPageImage
select fp.TenantID, @customPageID, fpi.FileResourceID
from dbo.FirmaPage fp
join dbo.FirmaPageType fpt
on fp.FirmaPageTypeID = fpt.FirmaPageTypeID
join dbo.FirmaPageImage fpi 
on fp.FirmaPageID = fpi.FirmaPageID
where fpt.FirmaPageTypeID in (2) and fp.TenantID = 2

go


delete from dbo.FirmaPageImage where FirmaPageID in 
(select fp.FirmaPageID
from dbo.FirmaPage fp
join dbo.FirmaPageType fpt
on fp.FirmaPageTypeID = fpt.FirmaPageTypeID
where fpt.FirmaPageTypeID in (2, 3))

go

delete from dbo.FirmaPage where FirmaPageTypeID in (2, 3)

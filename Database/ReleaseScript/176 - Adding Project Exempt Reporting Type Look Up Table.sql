CREATE TABLE dbo.ProjectExemptReportingType 
(
	ProjectExemptReportingTypeID int not null constraint PK_ProjectExemptReportingType_ProjectExemptReportingTypeID primary key,
	ProjectExemptReportingTypeName varchar(50) not null constraint AK_ProjectExemptReportingType_ProjectExemptReportingTypeName unique,
	ProjectExemptReportingTypeDisplayName varchar(50) not null constraint AK_ProjectExemptReportingType_ProjectExemptReportingTypeDisplayName unique
)
GO


INSERT INTO dbo.ProjectExemptReportingType (ProjectExemptReportingTypeID, ProjectExemptReportingTypeName, ProjectExemptReportingTypeDisplayName) 
VALUES (1, 'PerformanceMeasures', 'Performance Measures'),
 (2, 'Expenditures', 'Expenditures');


ALTER TABLE dbo.ProjectExemptReportingYear ADD ProjectExemptReportingTypeID INT null;
ALTER TABLE dbo.ProjectExemptReportingYear ADD CONSTRAINT FK_ProjectExemptReportingYear_ProjectExemptReportingType_ProjectExemptReportingTypeID FOREIGN KEY (ProjectExemptReportingTypeID) REFERENCES dbo.ProjectExemptReportingType (ProjectExemptReportingTypeID);

GO


UPDATE dbo.ProjectExemptReportingYear 
SET ProjectExemptReportingTypeID = 1;



Alter TABLE dbo.ProjectExemptReportingYear
alter column ProjectExemptReportingTypeID INT not null;





ALTER TABLE dbo.ProjectExemptReportingYearUpdate ADD ProjectExemptReportingTypeID INT null;
ALTER TABLE dbo.ProjectExemptReportingYearUpdate ADD CONSTRAINT FK_ProjectExemptReportingYearUpdate_ProjectExemptReportingType_ProjectExemptReportingTypeID FOREIGN KEY (ProjectExemptReportingTypeID) REFERENCES dbo.ProjectExemptReportingType (ProjectExemptReportingTypeID);

GO


UPDATE dbo.ProjectExemptReportingYearUpdate 
SET ProjectExemptReportingTypeID = 1;



Alter TABLE dbo.ProjectExemptReportingYearUpdate
alter column ProjectExemptReportingTypeID INT not null;



alter table dbo.ProjectExemptReportingYear drop constraint AK_ProjectExemptReportingYear_ProjectID_CalendarYear


alter table dbo.ProjectExemptReportingYear add constraint  AK_ProjectExemptReportingYear_ProjectID_CalendarYear_ProjectExemptReportingTypeID unique (ProjectID, CalendarYear, ProjectExemptReportingTypeID) 







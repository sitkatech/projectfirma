alter table dbo.PerformanceMeasure drop column Importance

alter table dbo.TenantAttribute add SetTargetsByGeospatialArea bit null
go
update dbo.TenantAttribute set SetTargetsByGeospatialArea = 1
alter table dbo.TenantAttribute alter column SetTargetsByGeospatialArea bit not null


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(380, N'SetTargetsByGeospatialArea', N'Set Targets By Geospatial Area?')

insert into FieldDefinitionDefault ([FieldDefinitionID], DefaultDefinition)
values
(380, 'If set to ''Yes'', then the Targets tab is visible on the Performance Measure detail page')


insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(88, 'PerformanceMeasureExpectedAccomplishments', 'Performance Measure Expected Accomplishments', 2),
(89, 'PerformanceMeasureReportedAccomplishments', 'Performance Measure Reported Accomplishments', 2),
(90, 'PerformanceMeasureTargetsTabIntro', 'Performance Measure Targets Tab Intro', 1)


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 88, ''),
(1, 89, ''),
(1, 90, ''),
(2, 88, ''),
(2, 89, ''),
(2, 90, ''),
(3, 88, ''),
(3, 89, ''),
(3, 90, ''),
(4, 88, ''),
(4, 89, ''),
(4, 90, ''),
(5, 88, ''),
(5, 89, ''),
(5, 90, ''),
(6, 88, ''),
(6, 89, ''),
(6, 90, ''),
(7, 88, ''),
(7, 89, ''),
(7, 90, ''),
(9, 88, ''),
(9, 89, ''),
(9, 90, ''),
(13, 88, ''),
(13, 89, ''),
(13, 90, '')


--select * 

--from 
--	dbo.PerformanceMeasure as pm
--	--join dbo.PerformanceMeasureActual as pma on pm.PerformanceMeasureID = pma.PerformanceMeasureID
--	join dbo.PerformanceMeasureReportingPeriod as pmrp on pm.PerformanceMeasureID = pmrp.PerformanceMeasureID
--where 
--	pm.PerformanceMeasureID = 3401




--select * from dbo.PerformanceMeasureSubcategory where PerformanceMeasureID = 3401





--select * from dbo.PerformanceMeasureActual where PerformanceMeasureID = 2180

--select * from dbo.PerformanceMeasureActualUpdate where PerformanceMeasureID = 2180

--select * from dbo.PerformanceMeasureReportingPeriod where PerformanceMeasureReportingPeriodID = 994

--select top 100 * from dbo.GeospatialArea



CREATE TABLE [dbo].[PerformanceMeasureTarget](
	[PerformanceMeasureTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL constraint FK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID foreign key references dbo.PerformanceMeasureReportingPeriod(PerformanceMeasureReportingPeriodID),
	[PerformanceMeasureTargetValue] [float] not NULL,
	[PerformanceMeasureTargetValueLabel] [varchar](100) NULL,
 CONSTRAINT [PK_PerformanceMeasureTarget_PerformanceMeasureTargetID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriodID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureTarget_PerformanceMeasureTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget] CHECK CONSTRAINT [FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget] CHECK CONSTRAINT [FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[PerformanceMeasureTarget] CHECK CONSTRAINT [FK_PerformanceMeasureTarget_Tenant_TenantID]
GO


alter table dbo.PerformanceMeasureTarget add constraint FK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID foreign key (PerformanceMeasureReportingPeriodID, TenantID) references dbo.PerformanceMeasureReportingPeriod(PerformanceMeasureReportingPeriodID, TenantID)


INSERT INTO dbo.PerformanceMeasureTarget( TenantID, PerformanceMeasureID, PerformanceMeasureReportingPeriodID, PerformanceMeasureTargetValue, PerformanceMeasureTargetValueLabel )
SELECT 
	pmrp.TenantID as TenantID,
	pmrp.PerformanceMeasureID as PerformanceMeasureID,
	pmrp.PerformanceMeasureReportingPeriodID as PerformanceMeasureReportingPeriodID,
	pmrp.TargetValue as PerformanceMeasureTargetValue,
	pmrp.TargetValueLabel as PerformanceMeasureTargetValueLabel
FROM
	dbo.PerformanceMeasureReportingPeriod as pmrp
where
	pmrp.TargetValue is not null


alter table dbo.PerformanceMeasureReportingPeriod drop constraint FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID_TenantID
alter table dbo.PerformanceMeasureReportingPeriod drop constraint FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID
alter table dbo.PerformanceMeasureReportingPeriod drop constraint AK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodCalendarYear_PerformanceMeasureID
go

alter table dbo.PerformanceMeasureReportingPeriod
drop column TargetValue, TargetValueLabel, PerformanceMeasureID
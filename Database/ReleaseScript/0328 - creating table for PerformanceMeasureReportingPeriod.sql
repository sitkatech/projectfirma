
CREATE TABLE [dbo].[PerformanceMeasureReportingPeriod](
	[PerformanceMeasureReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodCalendarYear] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodLabel] [varchar](100) NOT NULL,
	[TargetValue] [float] NULL,
	[TargetValueLabel] [varchar](100) NULL,
 CONSTRAINT [PK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportingPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodCalendarYear_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodCalendarYear] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT AK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID UNIQUE NONCLUSTERED 
(
	PerformanceMeasureReportingPeriodID ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO




--Setup the regular performance measure actuals
alter table dbo.PerformanceMeasureActual
add [PerformanceMeasureReportingPeriodID] [int] NULL;
go

ALTER TABLE [dbo].PerformanceMeasureActual ADD CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])

go

insert into dbo.PerformanceMeasureReportingPeriod
    SELECT 
		pma.TenantID as TenantID,
		pma.PerformanceMeasureID as PerformanceMeasureID,
		pma.CalendarYear as PerformanceMeasureReportingPeriodCalendarYear,
		pma.CalendarYear as PerformanceMeasureReportingPeriodLabel,
		null as TargetValue,
		null as TargetValueLabel
    FROM 
		dbo.PerformanceMeasureActual as pma
    group by pma.TenantID, pma.CalendarYear, pma.PerformanceMeasureID


UPDATE
	dbo.PerformanceMeasureActual
SET
	PerformanceMeasureReportingPeriodID = pmrp.PerformanceMeasureReportingPeriodID
FROM
	dbo.PerformanceMeasureReportingPeriod as pmrp
	join dbo.PerformanceMeasureActual as pma on pmrp.TenantID = pma.TenantID and pmrp.PerformanceMeasureID = pma.PerformanceMeasureID and pmrp.PerformanceMeasureReportingPeriodCalendarYear = pma.CalendarYear


alter table dbo.PerformanceMeasureActual
drop column CalendarYear;
go

alter table dbo.PerformanceMeasureActual
alter column [PerformanceMeasureReportingPeriodID] [int] NOT NULL;
go



--Setup the update performance measure actuals
alter table dbo.PerformanceMeasureActualUpdate
add [PerformanceMeasureReportingPeriodID] [int] NULL;
go

ALTER TABLE [dbo].PerformanceMeasureActualUpdate  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualUpdate_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
go

insert into dbo.PerformanceMeasureReportingPeriod
    SELECT 
		pmau.TenantID as TenantID,
		pmau.PerformanceMeasureID as PerformanceMeasureID,
		pmau.CalendarYear as PerformanceMeasureReportingPeriodCalendarYear,
		pmau.CalendarYear as PerformanceMeasureReportingPeriodLabel,
		null as TargetValue,
		null as TargetValueLabel
    FROM 
		dbo.PerformanceMeasureActualUpdate as pmau
	where
		NOT EXISTS (SELECT 
						pmrp.TenantID,
						pmrp.PerformanceMeasureID,
						pmrp.PerformanceMeasureReportingPeriodCalendarYear,
						pmrp.PerformanceMeasureReportingPeriodLabel
					FROM dbo.PerformanceMeasureReportingPeriod as pmrp
					WHERE pmrp.PerformanceMeasureID = pmau.PerformanceMeasureID and pmrp.TenantID = pmau.TenantID and pmrp.PerformanceMeasureReportingPeriodCalendarYear = pmau.CalendarYear
					)
    group by pmau.TenantID, pmau.CalendarYear, pmau.PerformanceMeasureID


UPDATE
	dbo.PerformanceMeasureActualUpdate
SET
	PerformanceMeasureReportingPeriodID = pmrp.PerformanceMeasureReportingPeriodID
FROM
	dbo.PerformanceMeasureReportingPeriod as pmrp
	join dbo.PerformanceMeasureActualUpdate as pmau on pmrp.TenantID = pmau.TenantID and pmrp.PerformanceMeasureID = pmau.PerformanceMeasureID and pmrp.PerformanceMeasureReportingPeriodCalendarYear = pmau.CalendarYear

alter table dbo.PerformanceMeasureActualUpdate
drop column CalendarYear;
go

alter table dbo.PerformanceMeasureActualUpdate
alter column [PerformanceMeasureReportingPeriodID] [int] NOT NULL;
go

alter table dbo.PerformanceMeasure
drop column SwapChartAxes


alter table dbo.PerformanceMeasureActual add constraint FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID foreign key (PerformanceMeasureReportingPeriodID, TenantID) references dbo.PerformanceMeasureReportingPeriod(PerformanceMeasureReportingPeriodID, TenantID)

alter table dbo.PerformanceMeasureActualUpdate add constraint FK_PerformanceMeasureActualUpdate_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID foreign key (PerformanceMeasureReportingPeriodID, TenantID) references dbo.PerformanceMeasureReportingPeriod(PerformanceMeasureReportingPeriodID, TenantID)

alter table dbo.PerformanceMeasureReportingPeriod add constraint FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID_TenantID foreign key (PerformanceMeasureID, TenantID) references dbo.PerformanceMeasure(PerformanceMeasureID, TenantID)
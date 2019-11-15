SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureActual](
	[PerformanceMeasureActualID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureActual_PerformanceMeasureActualID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureActualID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureActual_PerformanceMeasureActualID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureActualID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureActual_PerformanceMeasureActualID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureActualID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID] FOREIGN KEY([PerformanceMeasureReportingPeriodID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_Project_ProjectID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActual] CHECK CONSTRAINT [FK_PerformanceMeasureActual_Tenant_TenantID]
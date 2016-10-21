SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorMonitoringProgram](
	[IndicatorMonitoringProgramID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[MonitoringProgramID] [int] NOT NULL,
 CONSTRAINT [PK_IndicatorMonitoringProgram_IndicatorMonitoringProgramID] PRIMARY KEY CLUSTERED 
(
	[IndicatorMonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorMonitoringProgram_IndicatorID_MonitoringProgramID] UNIQUE NONCLUSTERED 
(
	[IndicatorID] ASC,
	[MonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[IndicatorMonitoringProgram]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorMonitoringProgram_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[IndicatorMonitoringProgram] CHECK CONSTRAINT [FK_IndicatorMonitoringProgram_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[IndicatorMonitoringProgram]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorMonitoringProgram_MonitoringProgram_MonitoringProgramID] FOREIGN KEY([MonitoringProgramID])
REFERENCES [dbo].[MonitoringProgram] ([MonitoringProgramID])
GO
ALTER TABLE [dbo].[IndicatorMonitoringProgram] CHECK CONSTRAINT [FK_IndicatorMonitoringProgram_MonitoringProgram_MonitoringProgramID]
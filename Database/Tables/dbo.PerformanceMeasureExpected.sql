SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpected](
	[PerformanceMeasureExpectedID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpected_PerformanceMeasureExpectedID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureExpected_PerformanceMeasureExpectedID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureExpectedID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureExpected_PerformanceMeasureExpectedID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureExpectedID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected] CHECK CONSTRAINT [FK_PerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected] CHECK CONSTRAINT [FK_PerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpected_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected] CHECK CONSTRAINT [FK_PerformanceMeasureExpected_Project_ProjectID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpected_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected] CHECK CONSTRAINT [FK_PerformanceMeasureExpected_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpected_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpected] CHECK CONSTRAINT [FK_PerformanceMeasureExpected_Tenant_TenantID]
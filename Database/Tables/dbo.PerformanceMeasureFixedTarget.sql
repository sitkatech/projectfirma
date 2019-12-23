SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureFixedTarget](
	[PerformanceMeasureFixedTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureTargetValue] [float] NULL,
	[PerformanceMeasureTargetValueLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PerformanceMeasureFixedTarget_PerformanceMeasureFixedTargetID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureFixedTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureFixedTarget_PerformanceMeasureFixedTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureFixedTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget] CHECK CONSTRAINT [FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget] CHECK CONSTRAINT [FK_PerformanceMeasureFixedTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureFixedTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureFixedTarget] CHECK CONSTRAINT [FK_PerformanceMeasureFixedTarget_Tenant_TenantID]
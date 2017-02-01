SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassificationPerformanceMeasure](
	[ClassificationPerformanceMeasureID] [int] NOT NULL,
	[ClassificationID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryChart] [bit] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ClassificationPerformanceMeasure_ClassificationPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[ClassificationPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ClassificationPerformanceMeasure_ClassificationID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[ClassificationID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationPerformanceMeasure_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure] CHECK CONSTRAINT [FK_ClassificationPerformanceMeasure_Classification_ClassificationID]
GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure] CHECK CONSTRAINT [FK_ClassificationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationPerformanceMeasure_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ClassificationPerformanceMeasure] CHECK CONSTRAINT [FK_ClassificationPerformanceMeasure_Tenant_TenantID]
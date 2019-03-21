SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyLeafPerformanceMeasure](
	[TaxonomyLeafPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomyLeafID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryTaxonomyLeaf] [bit] NOT NULL,
 CONSTRAINT [PK_TaxonomyLeafPerformanceMeasure_TaxonomyLeafPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyLeafPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyLeafPerformanceMeasure_TaxonomyLeafID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[TaxonomyLeafID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID] FOREIGN KEY([TaxonomyLeafID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID])
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID]
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID_TenantID] FOREIGN KEY([TaxonomyLeafID], [TenantID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyLeafPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyLeafPerformanceMeasure_Tenant_TenantID]
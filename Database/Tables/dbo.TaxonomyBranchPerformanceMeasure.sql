SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyBranchPerformanceMeasure](
	[TaxonomyBranchPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomyBranchID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryTaxonomyBranch] [bit] NOT NULL,
 CONSTRAINT [PK_TaxonomyBranchPerformanceMeasure_TaxonomyBranchPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyBranchPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyBranchPerformanceMeasure_TaxonomyBranchID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[TaxonomyBranchID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_TaxonomyBranch_TaxonomyBranchID] FOREIGN KEY([TaxonomyBranchID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID])
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_TaxonomyBranch_TaxonomyBranchID]
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_TaxonomyBranch_TaxonomyBranchID_TenantID] FOREIGN KEY([TaxonomyBranchID], [TenantID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_TaxonomyBranch_TaxonomyBranchID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyBranchPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyBranchPerformanceMeasure_Tenant_TenantID]
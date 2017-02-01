SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed](
	[PerformanceMeasureExpectedSubcategoryOptionProposedID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureExpectedProposedID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedSubcategoryOptionProposedID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedSubcategoryOptionProposedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID] FOREIGN KEY([PerformanceMeasureExpectedProposedID])
REFERENCES [dbo].[PerformanceMeasureExpectedProposed] ([PerformanceMeasureExpectedProposedID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureExpectedProposed_PerformanceMeasureExpectedProposedID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOptionProposed_Tenant_TenantID]
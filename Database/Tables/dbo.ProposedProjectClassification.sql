SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectClassification](
	[ProposedProjectClassificationID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[ClassificationID] [int] NOT NULL,
	[ProposedProjectClassificationNotes] [varchar](600) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectClassification_ProposedProjectClassificationID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectClassification_ProposedProjectID_ClassificationID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[ClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectClassification_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO
ALTER TABLE [dbo].[ProposedProjectClassification] CHECK CONSTRAINT [FK_ProposedProjectClassification_Classification_ClassificationID]
GO
ALTER TABLE [dbo].[ProposedProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectClassification_Classification_ClassificationID_TenantID] FOREIGN KEY([ClassificationID], [TenantID])
REFERENCES [dbo].[Classification] ([ClassificationID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectClassification] CHECK CONSTRAINT [FK_ProposedProjectClassification_Classification_ClassificationID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectClassification_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectClassification] CHECK CONSTRAINT [FK_ProposedProjectClassification_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectClassification]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectClassification_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectClassification] CHECK CONSTRAINT [FK_ProposedProjectClassification_Tenant_TenantID]
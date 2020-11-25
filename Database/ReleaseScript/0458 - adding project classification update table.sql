

CREATE TABLE [dbo].[ProjectClassificationUpdate](
	[ProjectClassificationUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ClassificationID] [int] NOT NULL,
	[ProjectClassificationUpdateNotes] [varchar](600) NULL,
 CONSTRAINT [PK_ProjectClassificationUpdate_ProjectClassificationUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectClassificationUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassificationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate] CHECK CONSTRAINT [FK_ProjectClassificationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassificationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate] CHECK CONSTRAINT [FK_ProjectClassificationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassificationUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate] CHECK CONSTRAINT [FK_ProjectClassificationUpdate_Tenant_TenantID]
GO


ALTER TABLE [dbo].[ProjectClassificationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectClassificationUpdate_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO

ALTER TABLE [dbo].[ProjectClassificationUpdate] CHECK CONSTRAINT [FK_ProjectClassificationUpdate_Classification_ClassificationID]
GO

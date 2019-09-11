SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeUpdate](
	[ProjectCustomAttributeUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectCustomAttributeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeUpdate_TenantID_ProjectUpdateBatchID_ProjectCustomAttributeTypeID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[ProjectUpdateBatchID] ASC,
	[ProjectCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID] FOREIGN KEY([ProjectCustomAttributeTypeID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate] CHECK CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID] FOREIGN KEY([ProjectCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[ProjectCustomAttributeType] ([ProjectCustomAttributeTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate] CHECK CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate] CHECK CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate] CHECK CONSTRAINT [FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectCustomAttributeUpdate] CHECK CONSTRAINT [FK_ProjectCustomAttributeUpdate_Tenant_TenantID]
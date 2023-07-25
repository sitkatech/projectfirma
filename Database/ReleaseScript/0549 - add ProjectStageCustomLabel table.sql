
CREATE TABLE [dbo].[ProjectStageCustomLabel](
	[ProjectStageCustomLabelID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectStageLabel] [varchar](300) NOT NULL,
 CONSTRAINT [PK_ProjectStageCustomLabel_ProjectStageCustomLabelID] PRIMARY KEY CLUSTERED 
(
	[ProjectStageCustomLabelID] ASC
),
 CONSTRAINT [AK_ProjectStageCustomLabel_ProjectStageCustomLabelID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectStageCustomLabelID] ASC,
	[TenantID] ASC
),
 CONSTRAINT [AK_ProjectStageCustomLabel_ProjectStageID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectStageID] ASC,
	[TenantID] ASC
)
) 
GO

ALTER TABLE [dbo].[ProjectStageCustomLabel] ADD  CONSTRAINT [FK_ProjectStageCustomLabel_ProjectStage_ProjectStageID] FOREIGN KEY([ProjectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO


ALTER TABLE [dbo].[ProjectStageCustomLabel] ADD  CONSTRAINT [FK_ProjectStageCustomLabel_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO


ALTER TABLE [dbo].[ProjectStageCustomLabel] ADD  CONSTRAINT [CK_ProjectStageCustomLabel_ProjectStageLabel_IsNotEmptyString] CHECK  (([ProjectStageLabel]<>''))
GO

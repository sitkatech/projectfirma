SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStageCustomLabel](
	[ProjectStageCustomLabelID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectStageLabel] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectStageCustomLabel_ProjectStageCustomLabelID] PRIMARY KEY CLUSTERED 
(
	[ProjectStageCustomLabelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStageCustomLabel_ProjectStageCustomLabelID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectStageCustomLabelID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStageCustomLabel_ProjectStageID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectStageID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectStageCustomLabel]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStageCustomLabel_ProjectStage_ProjectStageID] FOREIGN KEY([ProjectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[ProjectStageCustomLabel] CHECK CONSTRAINT [FK_ProjectStageCustomLabel_ProjectStage_ProjectStageID]
GO
ALTER TABLE [dbo].[ProjectStageCustomLabel]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStageCustomLabel_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectStageCustomLabel] CHECK CONSTRAINT [FK_ProjectStageCustomLabel_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectStageCustomLabel]  WITH CHECK ADD  CONSTRAINT [CK_ProjectStageCustomLabel_ProjectStageLabel_IsNotEmptyString] CHECK  (([ProjectStageLabel]<>''))
GO
ALTER TABLE [dbo].[ProjectStageCustomLabel] CHECK CONSTRAINT [CK_ProjectStageCustomLabel_ProjectStageLabel_IsNotEmptyString]
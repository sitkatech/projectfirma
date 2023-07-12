SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingVideoRole](
	[TrainingVideoRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TrainingVideoID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_TrainingVideoRole_TrainingVideoRoleID] PRIMARY KEY CLUSTERED 
(
	[TrainingVideoRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TrainingVideoRole]  WITH CHECK ADD  CONSTRAINT [FK_TrainingVideoRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[TrainingVideoRole] CHECK CONSTRAINT [FK_TrainingVideoRole_Role_RoleID]
GO
ALTER TABLE [dbo].[TrainingVideoRole]  WITH CHECK ADD  CONSTRAINT [FK_TrainingVideoRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TrainingVideoRole] CHECK CONSTRAINT [FK_TrainingVideoRole_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TrainingVideoRole]  WITH CHECK ADD  CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID] FOREIGN KEY([TrainingVideoID])
REFERENCES [dbo].[TrainingVideo] ([TrainingVideoID])
GO
ALTER TABLE [dbo].[TrainingVideoRole] CHECK CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID]
GO
ALTER TABLE [dbo].[TrainingVideoRole]  WITH CHECK ADD  CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID_TenantID] FOREIGN KEY([TrainingVideoID], [TenantID])
REFERENCES [dbo].[TrainingVideo] ([TrainingVideoID], [TenantID])
GO
ALTER TABLE [dbo].[TrainingVideoRole] CHECK CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID_TenantID]
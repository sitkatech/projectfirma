SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationProject](
	[NotificationProjectID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_NotificationProject_NotificationProjectID] PRIMARY KEY CLUSTERED 
(
	[NotificationProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NotificationProject_NotificationID_ProjectID] UNIQUE NONCLUSTERED 
(
	[NotificationID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[NotificationProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProject_Notification_NotificationID] FOREIGN KEY([NotificationID])
REFERENCES [dbo].[Notification] ([NotificationID])
GO
ALTER TABLE [dbo].[NotificationProject] CHECK CONSTRAINT [FK_NotificationProject_Notification_NotificationID]
GO
ALTER TABLE [dbo].[NotificationProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[NotificationProject] CHECK CONSTRAINT [FK_NotificationProject_Project_ProjectID]
GO
ALTER TABLE [dbo].[NotificationProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProject_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[NotificationProject] CHECK CONSTRAINT [FK_NotificationProject_Tenant_TenantID]
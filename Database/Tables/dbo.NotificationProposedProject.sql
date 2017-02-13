SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationProposedProject](
	[NotificationProposedProjectID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[NotificationID] [int] NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
 CONSTRAINT [PK_NotificationProposedProject_NotificationProposedProjectID] PRIMARY KEY CLUSTERED 
(
	[NotificationProposedProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NotificationProposedProject_NotificationID_ProposedProjectID] UNIQUE NONCLUSTERED 
(
	[NotificationID] ASC,
	[ProposedProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[NotificationProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProposedProject_Notification_NotificationID] FOREIGN KEY([NotificationID])
REFERENCES [dbo].[Notification] ([NotificationID])
GO
ALTER TABLE [dbo].[NotificationProposedProject] CHECK CONSTRAINT [FK_NotificationProposedProject_Notification_NotificationID]
GO
ALTER TABLE [dbo].[NotificationProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProposedProject_Notification_NotificationID_TenantID] FOREIGN KEY([NotificationID], [TenantID])
REFERENCES [dbo].[Notification] ([NotificationID], [TenantID])
GO
ALTER TABLE [dbo].[NotificationProposedProject] CHECK CONSTRAINT [FK_NotificationProposedProject_Notification_NotificationID_TenantID]
GO
ALTER TABLE [dbo].[NotificationProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProposedProject_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[NotificationProposedProject] CHECK CONSTRAINT [FK_NotificationProposedProject_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[NotificationProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProposedProject_ProposedProject_ProposedProjectID_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[NotificationProposedProject] CHECK CONSTRAINT [FK_NotificationProposedProject_ProposedProject_ProposedProjectID_TenantID]
GO
ALTER TABLE [dbo].[NotificationProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_NotificationProposedProject_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[NotificationProposedProject] CHECK CONSTRAINT [FK_NotificationProposedProject_Tenant_TenantID]
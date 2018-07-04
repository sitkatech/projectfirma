SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateConfiguration](
	[ProjectUpdateConfigurationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateKickOffDate] [datetime] NULL,
	[ProjectUpdateCloseOutDate] [datetime] NULL,
	[ProjectUpdateReminderInterval] [int] NULL,
	[EnableProjectUpdateReminders] [bit] NOT NULL,
	[SendPeriodicReminders] [bit] NOT NULL,
	[SendCloseOutNotification] [bit] NOT NULL,
	[ProjectUpdateKickOffIntroContent] [dbo].[html] NULL,
	[ProjectUpdateReminderIntroContent] [dbo].[html] NULL,
	[ProjectUpdateCloseOutIntroContent] [dbo].[html] NULL,
 CONSTRAINT [PK_ProjectUpdateConfiguration_ProjectUpdateConfigurationID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateConfigurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateConfiguration_Tenant] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateConfiguration_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateConfiguration] CHECK CONSTRAINT [FK_ProjectUpdateConfiguration_Tenant_TenantID]
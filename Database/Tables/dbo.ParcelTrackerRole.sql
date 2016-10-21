SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelTrackerRole](
	[ParcelTrackerRoleID] [int] NOT NULL,
	[ParcelTrackerRoleName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParcelTrackerRoleDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParcelTrackerRoleDescription] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LTInfoAreaID] [int] NOT NULL,
 CONSTRAINT [PK_ParcelTrackerRole_ParcelTrackerRoleID] PRIMARY KEY CLUSTERED 
(
	[ParcelTrackerRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelTrackerRole_ParcelTrackerRoleDisplayName] UNIQUE NONCLUSTERED 
(
	[ParcelTrackerRoleDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelTrackerRole_ParcelTrackerRoleName] UNIQUE NONCLUSTERED 
(
	[ParcelTrackerRoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelTrackerRole]  WITH CHECK ADD  CONSTRAINT [FK_ParcelTrackerRole_LTInfoArea_LTInfoAreaID] FOREIGN KEY([LTInfoAreaID])
REFERENCES [dbo].[LTInfoArea] ([LTInfoAreaID])
GO
ALTER TABLE [dbo].[ParcelTrackerRole] CHECK CONSTRAINT [FK_ParcelTrackerRole_LTInfoArea_LTInfoAreaID]
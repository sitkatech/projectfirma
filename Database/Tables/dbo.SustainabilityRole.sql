SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityRole](
	[SustainabilityRoleID] [int] NOT NULL,
	[SustainabilityRoleName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SustainabilityRoleDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SustainabilityRoleDescription] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LTInfoAreaID] [int] NOT NULL,
 CONSTRAINT [PK_SustainabilityRole_SustainabilityRoleID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityRole_SustainabilityRoleDisplayName] UNIQUE NONCLUSTERED 
(
	[SustainabilityRoleDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityRole_SustainabilityRoleName] UNIQUE NONCLUSTERED 
(
	[SustainabilityRoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityRole]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityRole_LTInfoArea_LTInfoAreaID] FOREIGN KEY([LTInfoAreaID])
REFERENCES [dbo].[LTInfoArea] ([LTInfoAreaID])
GO
ALTER TABLE [dbo].[SustainabilityRole] CHECK CONSTRAINT [FK_SustainabilityRole_LTInfoArea_LTInfoAreaID]
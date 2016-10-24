SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[PersonGuid] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Phone] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PasswordPdfK2SaltHash] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EIPRoleID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[LTInfoRoleID] [int] NOT NULL,
	[WebServiceAccessToken] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Person_PersonID] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Person_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_EIPRole_EIPRoleID] FOREIGN KEY([EIPRoleID])
REFERENCES [dbo].[EIPRole] ([EIPRoleID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_EIPRole_EIPRoleID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_LTInfoRole_LTInfoRoleID] FOREIGN KEY([LTInfoRoleID])
REFERENCES [dbo].[LTInfoRole] ([LTInfoRoleID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_LTInfoRole_LTInfoRoleID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Organization_OrganizationID]
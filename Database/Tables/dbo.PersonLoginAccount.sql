SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLoginAccount](
	[PersonLoginAccountID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[PersonLoginAccountName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[PasswordHash] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordSalt] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LoginActive] [bit] NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[LastLogoutDate] [datetime] NULL,
	[LoginCount] [int] NOT NULL,
	[FailedLoginCount] [int] NOT NULL,
 CONSTRAINT [PK_PersonLoginAccount_PersonLoginAccountID] PRIMARY KEY CLUSTERED 
(
	[PersonLoginAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PersonLoginAccount_PersonID] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonLoginAccount]  WITH CHECK ADD  CONSTRAINT [FK_PersonLoginAccount_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLoginAccount] CHECK CONSTRAINT [FK_PersonLoginAccount_Person_PersonID]
GO
ALTER TABLE [dbo].[PersonLoginAccount]  WITH CHECK ADD  CONSTRAINT [FK_PersonLoginAccount_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[PersonLoginAccount] CHECK CONSTRAINT [FK_PersonLoginAccount_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[PersonLoginAccount]  WITH CHECK ADD  CONSTRAINT [FK_PersonLoginAccount_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonLoginAccount] CHECK CONSTRAINT [FK_PersonLoginAccount_Tenant_TenantID]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLoginAccount](
	[PersonLoginAccountID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[PersonLoginAccountName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Password] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordSalt] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LoginActive] [bit] NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[LastLogoutDate] [datetime] NULL,
	[LoginCount] [int] NOT NULL,
	[FailedLoginCount] [int] NOT NULL,
 CONSTRAINT [PK_PersonLoginAccount_PersonLoginAccountID] PRIMARY KEY CLUSTERED 
(
	[PersonLoginAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

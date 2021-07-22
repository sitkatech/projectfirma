SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaSystemAuthenticationType](
	[FirmaSystemAuthenticationTypeID] [int] NOT NULL,
	[FirmaSystemAuthenticationTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirmaSystemAuthenticationTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeID] PRIMARY KEY CLUSTERED 
(
	[FirmaSystemAuthenticationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[FirmaSystemAuthenticationTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

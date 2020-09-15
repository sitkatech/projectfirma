

CREATE TABLE dbo.MatchmakerKeyword
(
    MatchmakerKeywordID [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] NOT NULL,
    MatchmakerKeywordName [varchar](100) NOT NULL,
    MatchmakerKeywordDescription [varchar](1000) NULL,
 CONSTRAINT [PK_MatchmakerKeyword_MatchmakerKeywordID] PRIMARY KEY CLUSTERED 
(
    [MatchmakerKeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerKeyword_MatchmakerKeywordID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerKeywordID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerKeyword_MatchmakerKeywordName_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerKeywordName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerKeyword_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[MatchmakerKeyword] CHECK CONSTRAINT [FK_MatchmakerKeyword_Tenant_TenantID]
GO


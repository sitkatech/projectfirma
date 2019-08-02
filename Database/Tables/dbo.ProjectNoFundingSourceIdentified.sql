SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectNoFundingSourceIdentified](
	[ProjectNoFundingSourceIdentifiedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[CalendarYear] [int] NULL,
	[NoFundingSourceIdentifiedYet] [money] NULL,
 CONSTRAINT [PK_ProjectNoFundingSourceIdentified_ProjectNoFundingSourceIdentifiedID] PRIMARY KEY CLUSTERED 
(
	[ProjectNoFundingSourceIdentifiedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectNoFundingSourceIdentified_ProjectID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentified_Tenant_TenantID]
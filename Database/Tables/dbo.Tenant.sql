SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantID] [int] NOT NULL,
	[TenantName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanonicalHostNameLocal] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanonicalHostNameQa] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanonicalHostNameProd] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportingYearStartDate] [datetime] NOT NULL,
	[UseFiscalYears] [bit] NOT NULL,
	[UsesTechnicalAssistanceParameters] [bit] NOT NULL,
	[ArePerformanceMeasuresExternallySourced] [bit] NOT NULL,
	[AreOrganizationsExternallySourced] [bit] NOT NULL,
	[AreFundingSourcesExternallySourced] [bit] NOT NULL,
 CONSTRAINT [PK_Tenant_TenantID] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Tenant_TenantName] UNIQUE NONCLUSTERED 
(
	[TenantName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [CK_OnlyIdahoUsesTechnicalAssistanceParameters] CHECK  (([UsesTechnicalAssistanceParameters]=(0) OR [TenantID]=(9)))
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [CK_OnlyIdahoUsesTechnicalAssistanceParameters]
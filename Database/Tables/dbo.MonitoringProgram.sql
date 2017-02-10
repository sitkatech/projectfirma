SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitoringProgram](
	[MonitoringProgramID] [int] IDENTITY(1,1) NOT NULL,
	[MonitoringProgramName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MonitoringApproach] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MonitoringProgramUrl] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_MonitoringProgram_MonitoringProgramID] PRIMARY KEY CLUSTERED 
(
	[MonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MonitoringProgram_MonitoringProgramName] UNIQUE NONCLUSTERED 
(
	[MonitoringProgramName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MonitoringProgram]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgram_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MonitoringProgram] CHECK CONSTRAINT [FK_MonitoringProgram_Tenant_TenantID]
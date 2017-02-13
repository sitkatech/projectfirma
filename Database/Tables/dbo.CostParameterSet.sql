SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostParameterSet](
	[CostParameterSetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[InflationRate] [decimal](9, 6) NOT NULL,
	[CurrentYearForPVCalculations] [int] NOT NULL,
	[Comment] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CostParameterSet_CostParameterSetID] PRIMARY KEY CLUSTERED 
(
	[CostParameterSetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CostParameterSet]  WITH CHECK ADD  CONSTRAINT [FK_CostParameterSet_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[CostParameterSet] CHECK CONSTRAINT [FK_CostParameterSet_Tenant_TenantID]
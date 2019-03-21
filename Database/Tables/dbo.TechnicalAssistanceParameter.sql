SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicalAssistanceParameter](
	[TechnicalAssistanceParameterID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[EngineeringHourlyCost] [money] NULL,
	[OtherAssistanceHourlyCost] [money] NULL,
 CONSTRAINT [PK_TechnicalAssistanceParameter_TechnicalAssistanceParameterID] PRIMARY KEY CLUSTERED 
(
	[TechnicalAssistanceParameterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TechnicalAssistanceParameter]  WITH CHECK ADD  CONSTRAINT [FK_TechnicalAssistanceParameter_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TechnicalAssistanceParameter] CHECK CONSTRAINT [FK_TechnicalAssistanceParameter_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TechnicalAssistanceParameter]  WITH CHECK ADD  CONSTRAINT [CK_OnlyIdahoUsesThisFeatureNoExceptionsOkay] CHECK  (([TenantID]=(9)))
GO
ALTER TABLE [dbo].[TechnicalAssistanceParameter] CHECK CONSTRAINT [CK_OnlyIdahoUsesThisFeatureNoExceptionsOkay]
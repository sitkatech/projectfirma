SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationAreaStateProvince](
	[ProjectLocationAreaStateProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectLocationAreaID] [int] NOT NULL,
	[StateProvinceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationAreaStateProvince_ProjectLocationAreaStateProvinceID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaStateProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaStateProvince_ProjectLocationAreaID_StateProvinceID] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaID] ASC,
	[StateProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaStateProvince_ProjectLocationArea_ProjectLocationAreaID] FOREIGN KEY([ProjectLocationAreaID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince] CHECK CONSTRAINT [FK_ProjectLocationAreaStateProvince_ProjectLocationArea_ProjectLocationAreaID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaStateProvince_ProjectLocationArea_ProjectLocationAreaID_TenantID] FOREIGN KEY([ProjectLocationAreaID], [TenantID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince] CHECK CONSTRAINT [FK_ProjectLocationAreaStateProvince_ProjectLocationArea_ProjectLocationAreaID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaStateProvince_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince] CHECK CONSTRAINT [FK_ProjectLocationAreaStateProvince_StateProvince_StateProvinceID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaStateProvince_StateProvince_StateProvinceID_TenantID] FOREIGN KEY([StateProvinceID], [TenantID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince] CHECK CONSTRAINT [FK_ProjectLocationAreaStateProvince_StateProvince_StateProvinceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaStateProvince_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaStateProvince] CHECK CONSTRAINT [FK_ProjectLocationAreaStateProvince_Tenant_TenantID]
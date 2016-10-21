SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccelaJurisdictionToJurisdictionMapping](
	[AccelaJurisdictionToJurisdictionMappingID] [int] NOT NULL,
	[AccelaJurisdictionName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JurisdictionID] [int] NULL,
 CONSTRAINT [PK_AccelaJurisdictionToJurisdictionMapping_AccelaJurisdictionToJurisdictionMappingID] PRIMARY KEY CLUSTERED 
(
	[AccelaJurisdictionToJurisdictionMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AccelaJurisdictionToJurisdictionMapping_AccelaJurisdictionName] UNIQUE NONCLUSTERED 
(
	[AccelaJurisdictionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccelaJurisdictionToJurisdictionMapping]  WITH CHECK ADD  CONSTRAINT [FK_AccelaJurisdictionToJurisdictionMapping_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[AccelaJurisdictionToJurisdictionMapping] CHECK CONSTRAINT [FK_AccelaJurisdictionToJurisdictionMapping_Jurisdiction_JurisdictionID]
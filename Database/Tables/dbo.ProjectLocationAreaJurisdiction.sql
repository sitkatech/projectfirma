SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationAreaJurisdiction](
	[ProjectLocationAreaJurisdictionID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectLocationAreaID] [int] NOT NULL,
	[JurisdictionID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationAreaJurisdiction_ProjectLocationAreaJurisdictionID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaJurisdictionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaJurisdiction_ProjectLocationAreaID_JurisdictionID] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaID] ASC,
	[JurisdictionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationAreaJurisdiction]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaJurisdiction_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaJurisdiction] CHECK CONSTRAINT [FK_ProjectLocationAreaJurisdiction_Jurisdiction_JurisdictionID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaJurisdiction]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaJurisdiction_ProjectLocationArea_ProjectLocationAreaID] FOREIGN KEY([ProjectLocationAreaID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaJurisdiction] CHECK CONSTRAINT [FK_ProjectLocationAreaJurisdiction_ProjectLocationArea_ProjectLocationAreaID]
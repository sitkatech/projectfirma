SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocalAndRegionalPlan](
	[ProjectLocalAndRegionalPlanID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[LocalAndRegionalPlanID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocalAndRegionalPlan_ProjectLocalAndRegionalPlanID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocalAndRegionalPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocalAndRegionalPlan_ProjectID_LocalAndRegionalPlanID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[LocalAndRegionalPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocalAndRegionalPlan]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocalAndRegionalPlan_LocalAndRegionalPlan_LocalAndRegionalPlanID] FOREIGN KEY([LocalAndRegionalPlanID])
REFERENCES [dbo].[LocalAndRegionalPlan] ([LocalAndRegionalPlanID])
GO
ALTER TABLE [dbo].[ProjectLocalAndRegionalPlan] CHECK CONSTRAINT [FK_ProjectLocalAndRegionalPlan_LocalAndRegionalPlan_LocalAndRegionalPlanID]
GO
ALTER TABLE [dbo].[ProjectLocalAndRegionalPlan]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocalAndRegionalPlan_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectLocalAndRegionalPlan] CHECK CONSTRAINT [FK_ProjectLocalAndRegionalPlan_Project_ProjectID]
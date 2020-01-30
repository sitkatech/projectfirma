ALTER TABLE [dbo].[ProjectProjectStatus] ADD  CONSTRAINT [AK_ProjectProjectStatus_ProjectProjectStatusID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectProjectStatusID] ASC,
	[TenantID] ASC
)
--begin tran

--ALTER TABLE dbo.[ProjectCustomAttributeGroup] 
--ADD ProjectTypeID int not null DEFAULT 1
--GO

--ALTER TABLE [dbo].[ProjectCustomAttributeGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroup_ProjectType_ProjectTypeID] FOREIGN KEY([ProjectTypeID])
--REFERENCES [dbo].[ProjectType] ([ProjectTypeID])
--GO

--ALTER TABLE [dbo].[ProjectCustomAttributeGroup] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroup_ProjectType_ProjectTypeID]
--GO


create table dbo.ProjectCustomAttributeGroupProjectType(
	ProjectCustomAttributeGroupProjectTypeID int identity(1,1) not null constraint PK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroupProjectTypeID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeGroupProjectType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectCustomAttributeGroupID int not null constraint FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID foreign key references dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID),
	ProjectTypeID int not null constraint FK_ProjectCustomAttributeGroupProjectType_ProjectType_ProjectTypeID foreign key references dbo.ProjectType(ProjectTypeID)
)


alter table dbo.ProjectCustomAttributeGroupProjectType add constraint FK_ProjectCustomAttributeGroupProjectType_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID foreign key (ProjectCustomAttributeGroupID, TenantID) references dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID, TenantID)



insert into dbo.ProjectCustomAttributeGroupProjectType (TenantID, ProjectCustomAttributeGroupID, ProjectTypeID)
	select 
			 pcag.TenantID as TenantID,
			 pcag.ProjectCustomAttributeGroupID as ProjectCustomAttributeGroupID,
			 1 as ProjectTypeID
	from 
		dbo.ProjectCustomAttributeGroup as pcag



--rollback tran


--begin tran

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


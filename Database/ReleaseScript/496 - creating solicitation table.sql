
create table dbo.Solicitation
(
	SolicitationID int not null identity(1,1) constraint PK_Solicitation_SolicitationID primary key,
	TenantID int not null constraint FK_Solicitation_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	SolicitationName varchar(200) not null,
	Instructions html,
	IsActive bit not null
);


ALTER TABLE [dbo].Solicitation ADD  CONSTRAINT [AK_Solicitation_SolicitationID_TenantID] UNIQUE NONCLUSTERED 
(
	[SolicitationID] ASC,
	[TenantID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].Solicitation ADD  CONSTRAINT [AK_Solicitation_SolicitationName_TenantID] UNIQUE NONCLUSTERED 
(
	[SolicitationName] ASC,
	[TenantID] ASC
) ON [PRIMARY]
GO


alter table dbo.Project
add SolicitationID int null constraint FK_Project_Solicitation_SolicitationID foreign key references dbo.Solicitation(SolicitationID);


alter table dbo.TenantAttribute
add EnableSolicitations bit null;
go

update dbo.TenantAttribute
set EnableSolicitations = 0;

update dbo.TenantAttribute
set EnableSolicitations = 1
where TenantID = 4;

alter table dbo.TenantAttribute
alter column EnableSolicitations bit not null;

create table dbo.Solicitation
(
	SolicitationID int not null identity(1,1) constraint PK_Solicitation_SolicitationID primary key,
	SolicitationName varchar(200) not null,
	Instructions varchar(200),
	IsActive bit not null
);


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
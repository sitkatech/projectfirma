--begin tran

alter table dbo.Organization
add IsUnknownOrUnspecified bit null
GO

update dbo.Organization
set IsUnknownOrUnspecified = 0
GO

update dbo.Organization
set IsUnknownOrUnspecified = 1
where OrganizationName like '%Unknown or Unspecified Organization%'
GO

alter table dbo.Organization
alter column IsUnknownOrUnspecified bit not null
GO

USE [ProjectFirma]
GO

ALTER TABLE [dbo].[Organization]  WITH CHECK 
ADD  CONSTRAINT CK_Organization_Unknown_or_Unspecified_bit_set_when_needed
CHECK (((OrganizationName not like '%Unknown or Unspecified Organization%') and (IsUnknownOrUnspecified = 0)) or ((OrganizationName like '%Unknown or Unspecified Organization%') and (IsUnknownOrUnspecified = 1) )  )
GO


--rollback tran






/*


select * from dbo.Organization
where TenantID  = 3

select * from dbo.Tenant

select * from dbo.Organization
where IsActive = 0

select * from OrganizationType
where OrganizationTypeID in (8,3,11,23,27,59,35,43,1060,57,1076,1081) 

*/
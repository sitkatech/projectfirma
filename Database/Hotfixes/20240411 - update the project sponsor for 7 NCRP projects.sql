-- select * from dbo.Organization where tenantid = 4 and OrganizationName like '%Coast ridge community forest%'
-- select * from dbo.Organization where tenantid = 4 and OrganizationName like '%Coast Ridge forest council%'
-- select * from dbo.ProjectOrganization where OrganizationID = 6856

update dbo.ProjectOrganization set OrganizationID = 7025 where tenantid = 4 and OrganizationID = 6856

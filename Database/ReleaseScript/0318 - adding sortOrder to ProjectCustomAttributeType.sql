alter table dbo.ProjectCustomAttributeType
add SortOrder int null;

GO

-- even though the application uses a different magic number to sort, 
-- creating an initial sort order that is based off of their incrementing ID will
-- preserve the order that the Tenants currently have in Project Firma
update dbo.ProjectCustomAttributeType
set SortOrder = ProjectCustomAttributeTypeID;

GO
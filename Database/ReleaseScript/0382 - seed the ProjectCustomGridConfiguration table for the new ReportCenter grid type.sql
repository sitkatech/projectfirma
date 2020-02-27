--begin tran

insert into dbo.ProjectCustomGridType(ProjectCustomGridTypeID, ProjectCustomGridTypeName, ProjectCustomGridTypeDisplayName)
values
(3, 'Reports', 'Reports')

insert into dbo.ProjectCustomGridConfiguration (TenantID, ProjectCustomGridTypeID, ProjectCustomGridColumnID, ProjectCustomAttributeTypeID, GeospatialAreaTypeID, IsEnabled, SortOrder)
    select 
        TenantID, 
        3, 
        ProjectCustomGridColumnID, 
        ProjectCustomAttributeTypeID, 
        GeospatialAreaTypeID, 
        IsEnabled, 
        SortOrder 
    from ProjectCustomGridConfiguration 
    where ProjectCustomGridTypeID = 1



--rollback tran

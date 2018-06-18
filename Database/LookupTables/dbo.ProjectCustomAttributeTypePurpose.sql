delete from dbo.ProjectCustomAttributeTypePurpose
go
Insert Into dbo.ProjectCustomAttributeTypePurpose(ProjectCustomAttributeTypePurposeID, ProjectCustomAttributeTypePurposeName, ProjectCustomAttributeTypePurposeDisplayName)
values
(1, 'PerformanceAndModelingAttributes', 'Performance / Modeling Attributes'),
(2, 'OtherDesignAttributes', 'Other Design Attributes'),
(3, 'Maintenance', 'Maintenance Attributes')

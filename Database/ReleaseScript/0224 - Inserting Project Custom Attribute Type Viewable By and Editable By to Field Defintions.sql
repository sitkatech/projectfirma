Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
Values
(271, N'ProjectCustomAttributeTypeEditableBy', 'Editable By' , N'This field definition is in reference to who can edit a specific custom attribute, Admins and Sitka Admins can edit any custom attribute'),
(272, N'ProjectCustomAttributeTypeViewableBy', 'Viewable By', N'This field definition is in reference to who can view a specific custom attribute, Admins and Sitka Admins can view any custom attribute')

Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
Select TenantID, 271, N'', N'' From dbo.Tenant
Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
Select TenantID, 272, N'', N'' From dbo.Tenant
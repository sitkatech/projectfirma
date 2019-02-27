Insert Into dbo.FieldDefinition ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition])
Values
(269, N'ProjectPrimaryContactEmail', N'Project Primary Contact Email', N'<p>The email of the individual responsible for reporting accomplishments and expenditures achieved by the project, and who should be contacted when there are questions related to the project.</p>')

Insert Into dbo.FieldDefinitionData([TenantID], [FieldDefinitionID])
select TenantID, 269 from dbo.Tenant
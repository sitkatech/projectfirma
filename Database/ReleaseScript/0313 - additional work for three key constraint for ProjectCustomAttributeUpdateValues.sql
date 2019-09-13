IF OBJECT_ID('dbo.[AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID]', 'UQ') IS NOT NULL
begin

    ALTER TABLE [dbo].ProjectCustomAttributeUpdateValue DROP CONSTRAINT AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID 

    ALTER TABLE [dbo].ProjectCustomAttributeUpdateValue ADD CONSTRAINT AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID_AttributeValue UNIQUE NONCLUSTERED
    (
        TenantID ASC,
        ProjectCustomAttributeUpdateID ASC,
        AttributeValue ASC
    ) ON [PRIMARY]

end

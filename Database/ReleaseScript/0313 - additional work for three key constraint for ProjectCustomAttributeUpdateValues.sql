
IF OBJECT_ID('dbo.[AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID]', 'UQ') IS NOT NULL
begin
    -- AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID wasn't quite right; since 
    -- we have multi-selects there can in fact be multiple values selected for a given ProjectCustomAttributeUpdateValueID
    ALTER TABLE [dbo].ProjectCustomAttributeUpdateValue DROP CONSTRAINT AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID
end


IF OBJECT_ID('dbo.[AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID_AttributeValue]', 'UQ') IS NULL
begin
    -- But what is enforcable, and bad, is to have the exact SAME value. This IS a problem, and we'll trap for that.
    ALTER TABLE [dbo].ProjectCustomAttributeUpdateValue ADD CONSTRAINT AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID_AttributeValue UNIQUE NONCLUSTERED
    (
        TenantID ASC,
        ProjectCustomAttributeUpdateID ASC,
        AttributeValue ASC
    ) ON [PRIMARY]
end

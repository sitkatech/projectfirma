---- Aha, here is the dupe. 49 twice.
--select * 
--from ProjectCustomAttributeUpdate as pcau
--where pcau.ProjectUpdateBatchID = 6478

--select * from ProjectCustomAttributeType


-- Here we use the presence of the much-needed AK as a way to detect if this hotfix has already been applied.
-- Looks like the equivalent AK already exists for ProjectCustomAttribute. -- SLG 9/10/2019
IF OBJECT_ID('dbo.[AK_ProjectCustomAttributeUpdate_TenantID_ProjectUpdateBatchID_ProjectCustomAttributeTypeID]', 'UQ') IS NULL 
begin
    -- Delete the dupe record first
    delete from ProjectCustomAttributeUpdateValue
    where ProjectCustomAttributeUpdateID = 5257

    delete from ProjectCustomAttributeUpdate
    where ProjectCustomAttributeUpdateID = 5257

    -- Now we can add the AK to prevent recurrence - or, at least, trigger a crash when the user hits the condition to try again.
    ALTER TABLE [dbo].ProjectCustomAttributeUpdate ADD  CONSTRAINT [AK_ProjectCustomAttributeUpdate_TenantID_ProjectUpdateBatchID_ProjectCustomAttributeTypeID] UNIQUE NONCLUSTERED 
    (
            [TenantID] ASC,
            ProjectUpdateBatchID ASC,
            ProjectCustomAttributeTypeID ASC
    ) ON [PRIMARY]
end






--select * from dbo.ProjectCustomAttribute





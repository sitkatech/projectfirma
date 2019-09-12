
-- Here we use the presence of the much-needed AK as a way to detect if this hotfix has already been applied.
-- Looks like the equivalent AK already exists for ProjectCustomAttribute. -- SLG 9/10/2019
IF OBJECT_ID('dbo.[AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID]', 'UQ') IS NULL
begin

    -- We know of 4845 and 5516 right now, but they are multiplying so we are going to go after all affected
    delete from ProjectCustomAttributeUpdateValue
    where ProjectCustomAttributeUpdateID in (
        select
            --pcauv.TenantID,
            pcauv.ProjectCustomAttributeUpdateID
            --count(*)
        from ProjectCustomAttributeUpdateValue as pcauv
        group by TenantID, ProjectCustomAttributeUpdateID
        having count(*) > 1
    )

    delete from ProjectCustomAttributeUpdate
    where ProjectCustomAttributeUpdateID in (
        select
            --pcauv.TenantID,
            pcauv.ProjectCustomAttributeUpdateID
            --count(*)
        from ProjectCustomAttributeUpdateValue as pcauv
        group by TenantID, ProjectCustomAttributeUpdateID
        having count(*) > 1
    )

    -- Now we can add the AK to prevent recurrence - or, at least, trigger a crash when the user hits the condition to try again.
    ALTER TABLE [dbo].ProjectCustomAttributeUpdateValue ADD  CONSTRAINT AK_ProjectCustomAttributeUpdateValue_TenantID_ProjectCustomAttributeUpdateID UNIQUE NONCLUSTERED
    (
            TenantID ASC,
            ProjectCustomAttributeUpdateID ASC
    ) ON [PRIMARY]


end





/*
select
    pcauv.TenantID,
    pcauv.ProjectCustomAttributeUpdateID,
    count(*)
from ProjectCustomAttributeUpdateValue as pcauv
group by TenantID, ProjectCustomAttributeUpdateID
having count(*) > 1
*/



/*

    -- Delete more dupe records first
    delete from ProjectCustomAttributeUpdateValue
    where ProjectCustomAttributeUpdateID = 4845

    delete from ProjectCustomAttributeUpdate
    where ProjectCustomAttributeUpdateID = 4845

    delete from ProjectCustomAttributeUpdateValue
    where ProjectCustomAttributeUpdateID = 5516

    delete from ProjectCustomAttributeUpdate
    where ProjectCustomAttributeUpdateID = 5516


select * from dbo.Person

update dbo.Person set RoleID = 8 where FirstName = 'Stewart'
*/


--    --delete from ProjectCustomAttributeUpdateValueValue
--    --where ProjectCustomAttributeUpdateValueID = 5257

--    --delete from ProjectCustomAttributeUpdateValue
--    --where ProjectCustomAttributeUpdateValueID = 5257


--    -- Delete the dupe record first
--select * from ProjectCustomAttributeUpdateValue
--where ProjectCustomAttributeUpdateValueID = 4845

--select * from ProjectCustomAttributeUpdateValueValue
--where  ProjectCustomAttributeUpdateValueID = 4845




--    -- Delete the dupe value records first
--    delete from ProjectCustomAttributeUpdateValueValue
--    where ProjectCustomAttributeUpdateValueID = 4845

--    delete from ProjectCustomAttributeUpdateValue
--    where ProjectCustomAttributeUpdateValueID = 4845



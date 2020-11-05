--begin tran

update dbo.ProjectLocation 
set ProjectLocationGeometry = ProjectLocationGeometry.MakeValid()  where ProjectLocationGeometry.STIsValid() = 0

--rollback tran


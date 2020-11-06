--begin tran
 
-- commented out because I realized there was another story for this
--update dbo.ProjectLocation 
--set ProjectLocationGeometry = ProjectLocationGeometry.MakeValid()  where ProjectLocationGeometry.STIsValid() = 0

--rollback tran


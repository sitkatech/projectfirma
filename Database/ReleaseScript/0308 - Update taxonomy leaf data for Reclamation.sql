Declare @branchID int
Declare @Admin varchar(50)
Declare @Nepa varchar(50)
Declare @Flow varchar(50)
Declare @Screens varchar(50)
Declare @Barriers varchar(50)
Declare @Complexity varchar(50)
Declare @TaxBranchName varchar(50)
Declare @TaxBranchNameSubString varchar(50)

Set @branchID = 116
Set @Admin = '100 Admin / Coord'
Set @Nepa = '110 NEPA'
Set @Flow = '200 Flow'
Set @Screens = '300 Screens'
Set @Barriers = '400 Barriers'
Set @Complexity = '500 Complexity'

delete from TaxonomyLeafPerformanceMeasure where TaxonomyLeafID = 2336
delete from TaxonomyLeafPerformanceMeasure where TaxonomyLeafID = 2337
delete from TaxonomyLeaf where TaxonomyLeafID = 2336
delete from TaxonomyLeaf where TaxonomyLeafID = 2337


while @branchID <=137
begin


set @TaxBranchName = (select TaxonomyBranch.TaxonomyBranchName from TaxonomyBranch where TaxonomyBranchID = @branchID and TenantID = 12)
if @TaxBranchName is not null and @branchID != 127 begin
set @TaxBranchNameSubString = (select SUBSTRING(@TaxBranchName, 0, 5))

insert into  TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Admin) , @Admin)
insert into TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Nepa), @Nepa)
insert into TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Flow), @Flow)
insert into TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Screens), @Screens)
insert into TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Barriers), @Barriers)
insert into TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
values(12, @branchID, concat(@TaxBranchNameSubString, '.', @Complexity), @Complexity)

end -- end of if statement

set @branchID += 1
end -- end of while loop


select tt.TaxonomyTrunkID
,tt.TaxonomyTrunkName
,tb.TaxonomyBranchID
,tb.TaxonomyBranchName
,tl.TaxonomyLeafID
,tl.TaxonomyLeafName
from ProjectFirma.dbo.TaxonomyTrunk tt
join TaxonomyBranch tb on tb.TaxonomyTrunkID = tt.TaxonomyTrunkID
join TaxonomyLeaf tl on tb.TaxonomyBranchID = tl.TaxonomyBranchID
where tt.TaxonomyTrunkID = 36





--select tt.TaxonomyTrunkID
--,tt.TaxonomyTrunkName
--,tb.TaxonomyBranchID
--,tb.TaxonomyBranchName
--,tl.TaxonomyLeafID
--,tl.TaxonomyLeafName
--from ProjectFirma.dbo.TaxonomyTrunk tt
--join TaxonomyBranch tb on tb.TaxonomyTrunkID = tt.TaxonomyTrunkID
--join TaxonomyLeaf tl on tb.TaxonomyBranchID = tl.TaxonomyBranchID
--where tt.TaxonomyTrunkID = 36
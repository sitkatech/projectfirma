
delete from dbo.ProjectCostType

insert dbo.ProjectCostType (ProjectCostTypeID, ProjectCostTypeName, ProjectCostTypeDisplayName, SortOrder) 
values 
(1, 'PreliminaryEngineering', 'Preliminary Engineering', 10),
(2, 'RightOfWay', 'Right of Way (aka Land Acquisition)', 20),
(3, 'Construction', 'Construction', 30)

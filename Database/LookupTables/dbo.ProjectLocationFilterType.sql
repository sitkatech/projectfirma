
delete from dbo.ProjectLocationFilterType

insert dbo.ProjectLocationFilterType (ProjectLocationFilterTypeID, ProjectLocationFilterTypeName, ProjectLocationFilterTypeDisplayName, ProjectLocationFilterTypeNameWithIdentifier, SortOrder, DisplayGroup) values 
(1, 'FocusArea', 'EIP Focus Area', 'FocusAreaID', 10, 1),
(2, 'Program', 'EIP Program', 'ProgramID', 20, 1),
(3, 'ActionPriority', 'EIP Action Priority', 'ActionPriorityID', 30, 1),
(4, 'ThresholdCategory', 'Threshold Category', 'ThresholdCategoryID', 40, 3),
(5, 'ProjectStage', 'Project Stage', 'ProjectStageID', 50, 3),
(6, 'ImplementingOrganization', 'Implementing Organization', 'ImplementingOrganizationID', 60, 4),
(7, 'FundingOrganization', 'Funding Organization', 'FundingOrganizationID', 70, 4),
(8, 'TransportationStrategy', 'Transportation Strategy', 'TransportationStrategyID', 35, 2),
(9, 'TransportationObjective', 'Transportation Objective', 'TransportationObjectiveID', 36, 2)

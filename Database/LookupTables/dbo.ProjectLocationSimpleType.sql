
delete from dbo.ProjectLocationSimpleType

INSERT dbo.ProjectLocationSimpleType(ProjectLocationSimpleTypeID, ProjectLocationSimpleTypeName, DisplayInstructions, DisplayOrder)
VALUES 
(1, 'PointOnMap', 'Plot a point on the map', 1),
(3, 'None', 'No location', 3)
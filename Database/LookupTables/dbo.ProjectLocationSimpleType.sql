
delete from dbo.ProjectLocationSimpleType

INSERT dbo.ProjectLocationSimpleType(ProjectLocationSimpleTypeID, ProjectLocationSimpleTypeName, DisplayInstructions, DisplayOrder)
VALUES 
(1, 'PointOnMap', 'Plot a point on the map', 1),
(2, 'LatLngInput', 'Enter lat/lng coordinates (DD)', 2),
(3, 'None', 'No location', 3)
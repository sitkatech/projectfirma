DELETE FROM dbo.SnapshotProjectType
GO

INSERT INTO dbo.SnapshotProjectType(SnapshotProjectTypeID, SnapshotProjectTypeName, SnapshotProjectTypeDisplayName)
VALUES
	(1, 'Added', 'Added'),
	(2, 'Updated', 'Updated')

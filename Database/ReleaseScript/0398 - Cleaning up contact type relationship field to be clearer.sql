


EXEC sp_rename 'dbo.ContactRelationshipType.CanOnlyBeRelatedOnceToAProject', 'IsContactRelationshipTypeRequired', 'COLUMN';
go
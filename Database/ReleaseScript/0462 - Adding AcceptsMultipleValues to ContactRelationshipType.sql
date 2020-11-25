
--begin tran

alter table dbo.ContactRelationshipType
add ContactRelationshipTypeAcceptsMultipleValues bit null
GO

-- Initially, all those that are required take a single value,
-- and all those that are optional take multiple. That's what IsContactRelationshipTypeRequired meant before
-- the additional of the AcceptsMultipleValues bool.
update  dbo.ContactRelationshipType
set ContactRelationshipTypeAcceptsMultipleValues = 0 
where IsContactRelationshipTypeRequired = 1
GO

update  dbo.ContactRelationshipType
set ContactRelationshipTypeAcceptsMultipleValues = 1 
where IsContactRelationshipTypeRequired = 0
GO

alter table dbo.ContactRelationshipType
alter column ContactRelationshipTypeAcceptsMultipleValues bit not null
GO

--rollback tran


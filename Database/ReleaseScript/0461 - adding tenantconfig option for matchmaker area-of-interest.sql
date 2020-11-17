--begin tran

ALTER TABLE dbo.TenantAttribute
add MatchmakerAlgorithmIncludesProjectGeospatialAreas bit not null DEFAULT(0)

--rollback tran
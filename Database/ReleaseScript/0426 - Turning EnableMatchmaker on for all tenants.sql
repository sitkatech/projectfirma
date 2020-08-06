-- If we trust the feature flag, there's no reason not to do this for all tenants while we are testing in Local/QA.
-- Eventually we may want to make it opt in, before release.
--
-- But if anyone disagrees strongly, let me know.
--
-- SLG 8/5/2020
update dbo.TenantAttribute
set EnableMatchmaker = 1
go

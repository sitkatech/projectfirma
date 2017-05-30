update dbo.Watershed
set WatershedFeature = WatershedFeature.Reduce(0.0005)
where TenantID = 1
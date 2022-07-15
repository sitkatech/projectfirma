
insert into dbo.[Classification] (TenantID, ClassificationSystemID, ClassificationSortOrder, ThemeColor, DisplayName)
values
(4, 17, 1, '#b6430f', 'Climate Action'),
(4, 17, 2, '#2e6580', 'Community Engagement'),
(4, 17, 3, '#ffe293', 'Economic Development'),
(4, 17, 4, '#e0871a', 'Fire Prevention'),
(4, 17, 6, '#738c1f', 'Forest Health'),
(4, 17, 7, '#7d3951', 'Infrastructure Improvements'),
(4, 17, 8, '#94c5e3', 'Regional and Local Planning'),
(4, 17, 9, '#4b5c14', 'Watershed Enhancement')

update dbo.[Classification] set ClassificationSortOrder = 5 where ClassificationID = 2193

declare @newClassifictionID int
declare @projectIDs table (projectID int)
declare @projectID int

-- climate action old ids: 2159, 2160, 2161
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Climate Action'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2159, 2160, 2161)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2159, 2160, 2161) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end


-- Community Engagement old ids: 2162, 2163, 2164, 2165
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Community Engagement'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2162, 2163, 2164, 2165)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2162, 2163, 2164, 2165) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Economic Development old ids: 2166, 2167
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Economic Development'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2166, 2167)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2166, 2167) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Fire Prevention old ids: 2168, 2169, 2170, 2171
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Fire Prevention'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2168, 2169, 2170, 2171)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2168, 2169, 2170, 2171) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Fire Preparedness old ids: 2172, 2173, 2174
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Fire Preparedness'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2172, 2173, 2174)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2172, 2173, 2174) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Forest Health old ids: 2175, 2176, 2177, 2178
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Forest Health'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2175, 2176, 2177, 2178)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2175, 2176, 2177, 2178) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Infrastructure Improvements old ids: 2179, 2180, 2181
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Infrastructure Improvements'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2179, 2180, 2181)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2179, 2180, 2181) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Regional and Local Planning old ids: 2182, 2183, 2184, 2185, 2186
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Regional and Local Planning'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2182, 2183, 2184, 2185, 2186)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2182, 2183, 2184, 2185, 2186) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

--  Watershed Enhancement old ids: 2187, 2188, 2189, 2190
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Watershed Enhancement'
insert into @projectIDs select distinct ProjectID from dbo.ProjectClassification where ClassificationID in (2187, 2188, 2189, 2190)
while ((select count(*) from @projectIDs) > 0)
begin
	set @projectID = (select top 1 projectID from @projectIDs)
	insert into dbo.ProjectClassification (TenantID, ClassificationID, ProjectID, ProjectClassificationNotes)
	values
	(4, @newClassifictionID, @projectID, (select  left( string_agg(ProjectClassificationNotes, '; '), 600) from dbo.ProjectClassification where ProjectID = @projectID and ClassificationID in (2187, 2188, 2189, 2190) group by ProjectID))

	delete from @projectIDs where projectID = @projectID
end

-- project update
declare @projectUpdateBatchIDs table (projectUpdateBatchID int)
declare @projectUpdateBatchID int

-- climate action old ids: 2159, 2160, 2161
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Climate Action'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2159, 2160, 2161)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2159, 2160, 2161) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end


-- Community Engagement old ids: 2162, 2163, 2164, 2165
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Community Engagement'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2162, 2163, 2164, 2165)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2162, 2163, 2164, 2165) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Economic Development old ids: 2166, 2167
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Economic Development'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2166, 2167)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2166, 2167) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Fire Prevention old ids: 2168, 2169, 2170, 2171
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Fire Prevention'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2168, 2169, 2170, 2171)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2168, 2169, 2170, 2171) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Fire Preparedness old ids: 2172, 2173, 2174
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Fire Preparedness'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2172, 2173, 2174)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2172, 2173, 2174) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Forest Health old ids: 2175, 2176, 2177, 2178
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Forest Health'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2175, 2176, 2177, 2178)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2175, 2176, 2177, 2178) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Infrastructure Improvements old ids: 2179, 2180, 2181
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Infrastructure Improvements'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2179, 2180, 2181)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2179, 2180, 2181) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Regional and Local Planning old ids: 2182, 2183, 2184, 2185, 2186
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Regional and Local Planning'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2182, 2183, 2184, 2185, 2186)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2182, 2183, 2184, 2185, 2186) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end

--  Watershed Enhancement old ids: 2187, 2188, 2189, 2190
SELECT @newClassifictionID =  [ClassificationID] FROM dbo.[Classification] WHERE TenantID = 4 and DisplayName = 'Watershed Enhancement'
insert into @projectUpdateBatchIDs select distinct ProjectUpdateBatchID from dbo.ProjectClassificationUpdate where ClassificationID in (2187, 2188, 2189, 2190)
while ((select count(*) from @projectUpdateBatchIDs) > 0)
begin
	set @projectUpdateBatchID = (select top 1 projectUpdateBatchID from @projectUpdateBatchIDs)
	insert into dbo.ProjectClassificationUpdate (TenantID, ClassificationID, ProjectUpdateBatchID, ProjectClassificationUpdateNotes)
	values
	(4, @newClassifictionID, @projectUpdateBatchID, (select  left( string_agg(ProjectClassificationUpdateNotes, '; '), 600) from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID = @projectUpdateBatchID and ClassificationID in (2187, 2188, 2189, 2190) group by ProjectUpdateBatchID))

	delete from @projectUpdateBatchIDs where projectUpdateBatchID = @projectUpdateBatchID
end


-- delete ProjectClassification with old Project Types
delete from dbo.ProjectClassification where TenantID = 4 and ClassificationID in (
2159,
2160,
2161,
2162,
2163,
2164,
2165,
2166,
2167,
2168,
2169,
2170,
2171,
2172,
2173,
2174,
2175,
2176,
2177,
2178,
2179,
2180,
2181,
2182,
2183,
2184,
2185,
2186,
2187,
2188,
2189,
2190)

delete from dbo.ProjectClassificationUpdate where TenantID = 4 and ClassificationID in (
2159,
2160,
2161,
2162,
2163,
2164,
2165,
2166,
2167,
2168,
2169,
2170,
2171,
2172,
2173,
2174,
2175,
2176,
2177,
2178,
2179,
2180,
2181,
2182,
2183,
2184,
2185,
2186,
2187,
2188,
2189,
2190)

-- delete old project types
delete from dbo.[Classification] where TenantID = 4 and ClassificationID in (
2159,
2160,
2161,
2162,
2163,
2164,
2165,
2166,
2167,
2168,
2169,
2170,
2171,
2172,
2173,
2174,
2175,
2176,
2177,
2178,
2179,
2180,
2181,
2182,
2183,
2184,
2185,
2186,
2187,
2188,
2189,
2190)
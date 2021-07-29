alter table dbo.TenantAttribute add ShowExpectedPerformanceMeasuresOnFactSheet bit null
go
update dbo.TenantAttribute set ShowExpectedPerformanceMeasuresOnFactSheet = 0

alter table dbo.TenantAttribute alter column ShowExpectedPerformanceMeasuresOnFactSheet bit not null

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(373, N'ShowExpectedPerformanceMeasuresOnFactSheet', N'Show Expected Performance Measures on Fact Sheet?')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values (373, 'When this option is set, fact sheets for projects that are in implementation and post-implementation will show expected performance measures if the project does not have reported performance measures. When not set fact sheets for projects in implementation and post-implementation will only display reported performance measures.')
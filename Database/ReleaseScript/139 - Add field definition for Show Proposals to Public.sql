INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], CanCustomizeLabel) 
VALUES 
(257, N'ShowProposalsToThePublic', N'Show Proposals To The Public', N'<p>When this option is set, projects in the Pending Approval state will be shown on project maps and on the Proposal page. When not set, no proposals will be visible to anonymous users. All proposals should be shown on the proposals page for Normal+ users.</p>', 1)

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 
	t.tenantid,
	257,
	null,
	null
from dbo.tenant t

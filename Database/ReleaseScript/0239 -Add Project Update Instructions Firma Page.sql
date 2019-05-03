

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(56, 'ProjectUpdateInstructions', 'Project Update Instructions', 2)
go


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 56, '<p>This Project Update wizard is used to submit annual Project updates. All Projects in the Planning/Design, Implementation, or Post-Implementation stage are required to submit annual updates.</p>
<p>The various aspects of a Project that are available for update can be seen on the left. Several of these sections are optional, but others are required:</p>
<ul>
    <li><strong>Basics:</strong> <i>You must enter the Project"s start and completion dates</i></li>
    <li><strong>Location - Simple:</strong> <i>You must input your Project"s location via an interactive map or provide a short location description </i></li>
    <li><strong>Performance Measures:</strong> <i>You must enter an accomplishment value for at least one Performance Measure per year (or indicate you have no accomplishments)</i></li>
    <li><strong>Expenditures:</strong> <i>You must enter at least one Expenditure per year (if you spent nothing, enter a $0 expenditure)</i></li>
    <li><strong>Budgets:</strong> <i>You must enter Funding Sources and Project budgets</i></li>
</ul>' from dbo.Tenant

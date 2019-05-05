

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(56, 'ProjectUpdateInstructions', 'Project Update Instructions', 2)
go


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 56, '<p>Use this Project Update workflow to submit changes or additions to the Project''s location, accomplishments, financial information, photos and more. Projects in the Planning/Design, Implementation, or Post-Implementation stage can be updated using this workflow.</p>
<p>The various aspects of a Project that are available for update can be seen on the left. Several of these sections are optional, but others are required:</p>
<ul>
    <li><strong>Basics:</strong> <i>You must enter the Project''s description, status, planning / design and implementation start dates</i></li>
    <li><strong>Simple Location:</strong> <i>You must input your Project''s location by plotting a point via an interactive map or provide a short location description, you may also provide a more detailed location in a later workflow page</i></li>
    <li><strong>Accomplishments:</strong> <i>You must enter an accomplishment value for at least one Performance Measure per year (or indicate you have no accomplishments to report)</i></li>
    <li><strong>Expenditures:</strong> <i>You must enter at least one Expenditure per year (if you spent nothing, enter a $0 expenditure)</i></li>
</ul>' from dbo.Tenant
where TenantID not in (8, 11)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values 
(8, 56, '<p>Use this Project Update workflow to submit changes or additions to the Project''s location, accomplishments, financial information, photos and more. Projects in the Planning/Design, Implementation, or Post-Implementation stage can be updated using this workflow.</p>
<p>The various aspects of a Project that are available for update can be seen on the left. Several of these sections are optional, but others are required:</p>
<ul>
    <li><strong>Basics:</strong> <i>You must enter the Project''s description, status, planning / design and implementation start dates</i></li>
    <li><strong>Simple Location:</strong> <i>You must input your Project''s location by plotting a point via an interactive map or provide a short location description, you may also provide a more detailed location in a later workflow page</i></li>
    <li><strong>Accomplishments:</strong> <i>You must enter an accomplishment value for at least one Indicator per year (or indicate you have no accomplishments to report)</i></li>
    <li><strong>Expenditures:</strong> <i>You must enter at least one Expenditure per year (if you spent nothing, enter a $0 expenditure)</i></li>
</ul>'),
(11, 56, '<p>Use this Near Term Action Update workflow to submit changes or additions to the Near Term Action''s location, accomplishments, financial information, photos and more. Near Term Actions in the Planning/Design, Implementation, or Post-Implementation stage can be updated using this workflow.</p>
<p>The various aspects of a Near Term Action that are available for update can be seen on the left. Several of these sections are optional, but others are required:</p>
<ul>
    <li><strong>Basics:</strong> <i>You must enter the Near Term Action''s description, status, planning / design and implementation start dates</i></li>
    <li><strong>Simple Location:</strong> <i>You must input your Near Term Action''s location by plotting a point via an interactive map or provide a short location description, you may also provide a more detailed location in a later workflow page</i></li>
    <li><strong>Accomplishments:</strong> <i>You must enter an accomplishment value for at least one Progress Measure per year (or indicate you have no accomplishments to report)</i></li>
    <li><strong>Expenditures:</strong> <i>You must enter at least one Expenditure per year (if you spent nothing, enter a $0 expenditure)</i></li>
</ul>')

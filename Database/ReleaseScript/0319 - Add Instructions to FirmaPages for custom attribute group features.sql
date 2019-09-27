-- 53 is the custom attributes page
Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom Attributes defined and listed here show up on the &quot;Custom Attributes&quot; step of project workflows and in activity detail pages. Keep in mind that Custom Attributes are not full-fledged attributes of a project, which means they can&#39;t be used in reports, and Sitka can&#39;t write conditional logic based on the value for a given custom attribute. Administrators should define Custom Attributes BEFORE end users start adding projects. Related custom attributes can be assigned to a Custom Attribute Group, if one has been defined. Changing a Custom Attribute&#39;s data type after projects have been added could result in data loss.</p>'
where FirmaPageTypeID = 53

GO

Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom Attributes defined and listed here show up on the &quot;Custom Attributes&quot; step of activity workflows and in activity detail pages. Keep in mind that Custom Attributes are not full-fledged attributes of an activity, which means they can&#39;t be used in reports, and Sitka can&#39;t write conditional logic based on the value for a given custom attribute. Administrators should define Custom Attributes BEFORE end users start adding activities. Related custom attributes can be assigned to a Custom Attribute Group, if one has been defined. Changing a Custom Attribute&#39;s data type after activities have been added could result in data loss.</p>'
where FirmaPageTypeID = 53 and TenantID = 11

GO

-- 52 is the instructions for adding a new custom attribute
Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom Attributes can only be created for activities. Keep in mind that changing the properties of a custom attribute here may result in all values for that attribute being deleted. By default, all custom attributes must be assigned to a Custom Attribute Group; however, if no groups have been created, they will be assigned to a default group.</p>'
where FirmaPageTypeID = 52

GO

Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom Attributes can only be created for activities. Keep in mind that changing the properties of a custom attribute here may result in all values for that attribute being deleted. By default, all custom attributes must be assigned to a Custom Attribute Group; however, if no groups have been created, they will be assigned to a default group.</p>'
where FirmaPageTypeID = 52 and TenantID = 11

GO

-- 66 is the custom attributes group page
Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom attribute groups defined and listed here are a way to separate certain custom attributes from other custom attributes, typically by theme or concern. This allows for greater flexibility and clarity when displaying and editing your project&#39;s custom attributes in all steps of the workflow. For further customization you can edit the display order of the custom attribute groups.</p>'
where FirmaPageTypeID = 66

GO

Update dbo.FirmaPage
set FirmaPageContent = '<p>Custom attribute groups defined and listed here are a way to separate certain custom attributes from other custom attributes, typically by theme or concern. This allows for greater flexibility and clarity when displaying and editing your activity&#39;s custom attributes in all steps of the workflow. For further customization you can edit the display order of the custom attribute groups.</p>'
where FirmaPageTypeID = 66 and TenantID = 11

GO

-- 65 is the custom attribute groups adding instructions
Update dbo.FirmaPage
set FirmaPageContent = '<p>Enter a new custom attribute group name below. The custom attribute group will be automatically be placed last in the sort order but you can change this after the group is added. By default, one custom attribute group must always exist.</p>'
where FirmaPageTypeID = 65

GO

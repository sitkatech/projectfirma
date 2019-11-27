INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition]) 
VALUES 
(302, N'ProjectStatus', N'Status', N'<p>The Status of a Project</p>'),
(303, N'ProjectStatusUpdate', N'Project Status Update', N'<p>An update to the status of a project</p>'),
(304, N'ProjectStatusHistory', N'Project Status History', N'<p>The history of this project''s status over the lifetime of the project. These are manually added status updates to the project.</p>'),
(305, N'ProjectUpdateHistory', N'Project Update History', N'<p>The history of major events over the lifetime of the project. The updates on this side of the timeline get added automatically as the project goes through the workflow.</p>'),
(306, N'ProjectStatusLegend', N'Project Status Legend', N'<p>This legend defines the status types and their associated colors that are displayed on the right half of the project timeline.</p>'),
(307, N'ProjectStatusUpdateCreatedBy', N'Project Status Update Created By', N'<p>The person attributed to creating this update status.</p>'),
(308, N'ProjectStatusUpdateDate', N'Project Status Update Date', N'<p>The date that will be displayed for this status update.</p>'),
(309, N'ProjectStatusComments', N'Project Status Comments', N'<p>Comments that are associated with this status update.</p>')


INSERT INTO dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionLabel, FieldDefinitionDataValue)
values 
(11, 302, 'Status', '<p>The Status of a Near Term Action</p>'),
(11, 303, 'Near Term Action Status Update', '<p>An update to the status of a Near Term Action</p>'),
(11, 304, 'Near Term Action Status History', '<p>The history of this Near Term Action''s status over the lifetime of the Near Term Action. These are manually added status updates to the Near Term Action.</p>'),
(11, 305, 'Near Term Action Update History', '<p>The history of major events over the lifetime of the Near Term Action. The updates on this side of the timeline get added automatically as the Near Term Action goes through the workflow.</p>'),
(11, 306, 'Near Term Action Status Legend', '<p>This legend defines the status types and their associated colors that are displayed on the right half of the Near Term Action timeline.</p>'),
(11, 307, 'Near Term Action Status Update Created By', '<p>The person attributed to creating this update status.</p>'),
(11, 308, 'Near Term Action Status Update Date', '<p>The date that will be displayed for this status update.</p>'),
(11, 309, 'Near Term Action Status Comments', '<p>Comments that are associated with this status update.</p>')
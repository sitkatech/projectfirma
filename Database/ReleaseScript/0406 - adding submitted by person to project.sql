

ALTER TABLE dbo.Project ADD SubmittedByPersonID int

go


ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Person_SubmittedByPersonID_PersonID] FOREIGN KEY([SubmittedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO



update dbo.Project
set SubmittedByPersonID = al.SubmittedByPersonID
from dbo.Project p
join (



select x.ProjectID, al.PersonID as SubmittedByPersonID from dbo.AuditLog al
join (


select al.ProjectID, max(al.NewValue) as MaxSubmittedDate, max(al.AuditLogDate) as MaxAuditLogDate, max(al.AuditLogID) as MaxAuditLogID
 from dbo.AuditLog al where al.TableName = 'project' and al.ColumnName = 'submissiondate'
 group by al.ProjectID ) x on al.AuditLogID = x.MaxAuditLogID
 ) al on al.ProjectID = p.ProjectID
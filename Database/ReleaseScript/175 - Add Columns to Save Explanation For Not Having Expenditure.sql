/*
Alter table dbo.Project
Add NoExpendituresToReport bit null;
go


Update dbo.Project 
Set NoExpendituresToReport = 0;



Alter Table dbo.Project Alter Column NoExpendituresToReport bit not null;
*/
 


Alter table dbo.Project
Add NoExpendituresToReportExplanation varchar(max) null;








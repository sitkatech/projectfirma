alter table dbo.CustomPageRole add constraint FK_CustomPageRole_CustomPage_CustomPageID_TenantID foreign key (CustomPageID, TenantID) references dbo.CustomPage(CustomPageID, TenantID)

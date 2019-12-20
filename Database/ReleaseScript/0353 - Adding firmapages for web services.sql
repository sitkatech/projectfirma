
insert into dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (71, 'WebServicesIndex', 'Web Services Index' , 1), (72, 'WebServicesList', 'Web Services List' , 1)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    71,
    case when TenantID = 11 
    then '<p>Web Services are functions that can be accessed over the web (using the http protocol), typically consumed by software or programs rather than humans. The services we provide here allow programmatic access to data such as lists of Near Term Actions (called "Projects" within the web services), details for a given Near Term Actions, or the list of PerformanceMeasures. The intent of these web services is to facilitate coordination and information sharing between agencies, interested parties, and the public.</p>' 
    else '<p>Web Services are functions that can be accessed over the web (using the http protocol), typically consumed by software or programs rather than humans. The services we provide here allow programmatic access to data such as lists of Projects, details for a given Project, or the list of PerformanceMeasures. The intent of these web services is to facilitate coordination and information sharing between agencies, interested parties, and the public.</p>' 
    end as FirmaPageContent
from Tenant

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    72,
    case when TenantID = 11 
    then '<p>The objective of these web services is to provide information about Near Term Actions (called "projects" within the web services) and other information. These web services require a "token" which you need to request from the Web Services page. This token is associated with your user account, allowing us to proactively communicate with you and other consumers of our web services in the event we need to change or update our services. If you have a token, this page will display example CSV and JSON URLs using your token. </p>' 
    else '<p>The objective of these web services is to provide information about projects and other information. These web services require a "token" which you need to request from the Web Services page. This token is associated with your user account, allowing us to proactively communicate with you and other consumers of our web services in the event we need to change or update our services. If you have a token, this page will display example CSV and JSON URLs using your token. </p>' 
    end as FirmaPageContent
from Tenant

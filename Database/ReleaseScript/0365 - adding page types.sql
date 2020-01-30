insert into dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(73, 'EvaluationList', 'Evaluation List' , 1),
(74, 'CreateEvaluationInstructions', 'Create Evaluation Instructions' , 2),
(75, 'CreateEvaluationCriteriaInstructions', 'Create Evaluation Criteria Instructions' , 2),
(76, 'AddProjectToEvaluationPortfolioInstructions', 'Add Project to Evaluation Portfolio Instructions' , 2)

--1/14/2020 TK - I left the case statements for a situation where the default value needs to be changed and specific to PSP and their term for project(near term actions)

--Evaluation List page type
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    73,
    case when TenantID = 11 
    then '' 
    else '' 
    end as FirmaPageContent
from Tenant

--Create Evaluation Instructions page type
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    74,
    case when TenantID = 11 
    then '<p>Define the basics of this Evaluation.</p>' 
    else '<p>Define the basics of this Evaluation.</p>' 
    end as FirmaPageContent
from Tenant

--Create Evaluation Criterion Instructions page type
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    75,
    case when TenantID = 11 
    then '<p>Define your Evaluation Criteria.</p>' 
    else '<p>Define your Evaluation Criteria.</p>' 
    end as FirmaPageContent
from Tenant

--Add Project to Evaluation Portfolio Instructions page type
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    76,
    case when TenantID = 11 
    then '<p>Create a portfolio of Near Term Actions. Near Term Actions within this portfolio can be evaluated as part of the Evaluation.</p>' 
    else '<p>Create a portfolio of Projects. Projects within this portfolio can be evaluated as part of the Evaluation.</p>' 
    end as FirmaPageContent
from Tenant
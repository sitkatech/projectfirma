-- Add "Proposal" stage to ProjectStage
Insert Into dbo.ProjectStage (ProjectStageID, ProjectStageName, ProjectStageDisplayName, SortOrder, ProjectStageColor)
VALUES (1, 'Proposal', 'Proposal', 10, '#dbbdff')

-- Add ProposedProjectStateID to Project
Alter Table dbo.Project Add ProposedProjectStateID int null, ProposingPersonID int null, ProposingDate datetime null, PerformanceMeasureNotes varchar(500) null, SubmissionDate datetime null, ApprovalDate datetime null, ReviewedByPersonID int null
Alter Table dbo.Project Add Constraint FK_Project_ProposedProjectState_ProposedProjectStateID Foreign Key (ProposedProjectStateID) References dbo.ProposedProjectState (ProposedProjectStateID)
go

Update dbo.Project
set ProposedProjectStateID = 3

Alter Table dbo.Project Alter Column ProposedProjectStateID int not null

-- Add temporary column to Project
Alter Table dbo.Project Add ProposedProjectID int null
go

-- Add all ProposedProjects that are not approved to the Project table
Insert Into dbo.Project (
 TenantID,
 TaxonomyTierOneID,
 ProjectStageID,
 ProjectName,
 ProjectDescription,
 ImplementationStartYear,
 CompletionYear,
 EstimatedTotalCost,
 SecuredFunding,
 ProjectLocationPoint,
 ProjectLocationNotes,
 PlanningDesignStartYear,
 ProjectLocationSimpleTypeID,
 EstimatedAnnualOperatingCost,
 FundingTypeID,
 PrimaryContactPersonID,
 ProjectWatershedNotes,
 ProposedProjectID,
 ProposedProjectStateID, IsFeatured)
 Select 
 TenantID,
 TaxonomyTierOneID,
 1 as ProjectStageID,
 ProjectName,
 ProjectDescription,
 ImplementationStartYear,
 CompletionYear,
 EstimatedTotalCost,
 SecuredFunding,
 ProjectLocationPoint,
 ProjectLocationNotes,
 PlanningDesignStartYear,
 ProjectLocationSimpleTypeID,
 EstimatedAnnualOperatingCost,
 FundingTypeID,
 PrimaryContactPersonID,
 ProjectWatershedNotes,
 ProposedProjectID,
 ProposedProjectStateID, 0 as IsFeatured
 From dbo.ProposedProject pp
 where pp.ProjectID is null

 update p
 set p.ProposedProjectID = pp.ProposedProjectID, p.ApprovalDate = pp.ApprovalDate, p.SubmissionDate = pp.SubmissionDate, p.PerformanceMeasureNotes = pp.PerformanceMeasureNotes, p.ProposingPersonID = pp.ProposingPersonID, p.ReviewedByPersonID = pp.ReviewedByPersonID, p.ProposingDate = pp.ProposingDate
 from dbo.Project p
 join dbo.ProposedProject pp on p.ProjectID = pp.ProjectID

 update p
 set p.ApprovalDate = pp.ApprovalDate, p.SubmissionDate = pp.SubmissionDate, p.PerformanceMeasureNotes = pp.PerformanceMeasureNotes, p.ProposingPersonID = pp.ProposingPersonID, p.ReviewedByPersonID = pp.ReviewedByPersonID, p.ProposingDate = pp.ProposingDate
 from dbo.Project p
 join dbo.ProposedProject pp on p.ProposedProjectID = pp.ProposedProjectID

 -- Migrate child entities

 insert into dbo.ProjectAssessmentQuestion(TenantID, ProjectID, AssessmentQuestionID, Answer)
 select ppaq.TenantID, p.ProjectID, ppaq.AssessmentQuestionID, ppaq.Answer
 from  dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectAssessmentQuestion ppaq on pp.ProposedProjectID = ppaq.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectClassification(TenantID, ProjectID, ClassificationID, ProjectClassificationNotes)
 select ppc.TenantID, p.ProjectID, ppc.ClassificationID, ppc.ProposedProjectClassificationNotes
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectClassification ppc on pp.ProposedProjectID = ppc.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectImage(TenantID, FileResourceID, ProjectID, ProjectImageTimingID, Caption, Credit, IsKeyPhoto, ExcludeFromFactSheet)
 select ppi.TenantID, ppi.FileResourceID, p.ProjectID, 4 as ProjectImageTimingID, ppi.Caption, ppi.Credit, 0 as IsKeyPhoto, 0 as ExcludeFromFactSheet
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectImage ppi on pp.ProposedProjectID = ppi.ProposedProjectID
 where pp.ProposedProjectStateID !=3

 insert into dbo.ProjectLocation (TenantID, ProjectID, ProjectLocationGeometry, Annotation)
 select ppl.TenantID, p.ProjectID, ppl.ProjectLocationGeometry, ppl.Annotation
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectLocation ppl on pp.ProposedProjectID = ppl.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectLocationStaging (TenantID, ProjectID, PersonID, FeatureClassName, GeoJson, SelectedProperty, ShouldImport)
 select ppls.TenantID, p.ProjectID, ppls.PersonID, ppls.FeatureClassName, ppls.GeoJson, ppls.SelectedProperty, ppls.ShouldImport
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectLocationStaging ppls on pp.ProposedProjectID = ppls.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectNote (TenantID, ProjectID, Note, CreatePersonID, CreateDate, UpdatePersonID, UpdateDate)
 select ppn.TenantID, p.ProjectID, ppn.Note, ppn.CreatePersonID, ppn.CreateDate, ppn.UpdatePersonID, ppn.UpdateDate
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectNote ppn on pp.ProposedProjectID = ppn.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectOrganization(TenantID, ProjectID, OrganizationID, RelationshipTypeID)
 select ppo.TenantID, p.ProjectID, ppo.OrganizationID, ppo.RelationshipTypeID
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectOrganization ppo on pp.ProposedProjectID = ppo.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.ProjectWatershed (TenantID, ProjectID, WatershedID)
 select ppw.TenantID, p.ProjectID, ppw.WatershedID
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.ProposedProjectWatershed ppw on pp.ProposedProjectID = ppw.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into dbo.NotificationProject(TenantID, NotificationID, ProjectID)
 select npp.TenantID, npp.NotificationID, p.ProjectID
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.NotificationProposedProject npp on pp.ProposedProjectID = npp.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 -- Add temp column to PerformanceMeasureExpected
 Alter Table dbo.PerformanceMeasureExpected Add PerformanceMeasureExpectedProposedID int null
 go

 insert into dbo.PerformanceMeasureExpected(TenantID, ProjectID, PerformanceMeasureID, ExpectedValue, PerformanceMeasureExpectedProposedID)
 select pmep.TenantID, p.ProjectID, pmep.PerformanceMeasureID, pmep.ExpectedValue, pmep.PerformanceMeasureExpectedProposedID
 from dbo.ProposedProject pp
 join dbo.Project p on pp.ProposedProjectID = p.ProposedProjectID
 join dbo.PerformanceMeasureExpectedProposed pmep on pp.ProposedProjectID = pmep.ProposedProjectID
 where pp.ProposedProjectStateID != 3

 insert into PerformanceMeasureExpectedSubcategoryOption(TenantID, PerformanceMeasureExpectedID, PerformanceMeasureSubcategoryOptionID, PerformanceMeasureID, PerformanceMeasureSubcategoryID)
 select pmesop.TenantID, pme.PerformanceMeasureExpectedID, pmesop.PerformanceMeasureSubcategoryOptionID, pmesop.PerformanceMeasureID, pmesop.PerformanceMeasureSubcategoryID
 from dbo.PerformanceMeasureExpectedProposed pmep
 join dbo.PerformanceMeasureExpected pme on pmep.PerformanceMeasureExpectedProposedID = pme.PerformanceMeasureExpectedProposedID
 join dbo.PerformanceMeasureExpectedSubcategoryOptionProposed pmesop on pmep.PerformanceMeasureExpectedProposedID = pmesop.PerformanceMeasureExpectedProposedID



if exists(
	select ProposedProjectID, TenantID, ProjectName, ProjectDescription, ProposingPersonID, ProposingDate, ImplementationStartYear, CompletionYear, EstimatedTotalCost, SecuredFunding, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProposedProjectStateID, TaxonomyTierOneID, PerformanceMeasureNotes, SubmissionDate, ApprovalDate, ReviewedByPersonID, PrimaryContactPersonID, ProjectWatershedNotes
	from dbo.Project p
	where ProjectStageID = 1
	except
	select ProposedProjectID, TenantID, ProjectName, ProjectDescription, ProposingPersonID, ProposingDate, ImplementationStartYear, CompletionYear, EstimatedTotalCost, SecuredFunding, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProposedProjectStateID, TaxonomyTierOneID, PerformanceMeasureNotes, SubmissionDate, ApprovalDate, ReviewedByPersonID, PrimaryContactPersonID, ProjectWatershedNotes
	from dbo.ProposedProject p
	where ProposedProjectStateID != 3

	union

	select ProposedProjectID, TenantID, ProjectName, ProjectDescription, ProposingPersonID, ProposingDate, ImplementationStartYear, CompletionYear, EstimatedTotalCost, SecuredFunding, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProposedProjectStateID, TaxonomyTierOneID, PerformanceMeasureNotes, SubmissionDate, ApprovalDate, ReviewedByPersonID, PrimaryContactPersonID, ProjectWatershedNotes
	from dbo.ProposedProject p
	where ProposedProjectStateID != 3
	except
	select ProposedProjectID, TenantID, ProjectName, ProjectDescription, ProposingPersonID, ProposingDate, ImplementationStartYear, CompletionYear, EstimatedTotalCost, SecuredFunding, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProposedProjectStateID, TaxonomyTierOneID, PerformanceMeasureNotes, SubmissionDate, ApprovalDate, ReviewedByPersonID, PrimaryContactPersonID, ProjectWatershedNotes
	from dbo.Project p
	where ProjectStageID = 1
)
begin
	raiserror('ProposedProject table did not migrate correctly!', 16, 1)
end

if exists(
	select
		paq.[TenantID], paq.[AssessmentQuestionID], paq.[Answer]
	from dbo.ProjectAssessmentQuestion paq
	join dbo.Project p on p.ProjectID = paq.ProjectID
	where p.ProjectStageID = 1
	except
	select
		paq.[TenantID], paq.[AssessmentQuestionID], paq.[Answer]
	from dbo.ProposedProjectAssessmentQuestion paq
	join dbo.ProposedProject p on p.ProposedProjectID = paq.ProposedProjectID
	where p.ProposedProjectStateID != 3
)
begin
	raiserror('ProposedProjectAssessmentQuestion table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pc.[TenantID], pc.[ClassificationID], pc.[ProjectClassificationNotes]
	from dbo.ProjectClassification pc
	join dbo.Project p on p.ProjectID = pc.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pc.[TenantID], pc.[ClassificationID], pc.[ProposedProjectClassificationNotes]
	from dbo.ProposedProjectClassification pc
	join dbo.ProposedProject p on p.ProposedProjectID = pc.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pc.[TenantID], pc.[ClassificationID], pc.[ProposedProjectClassificationNotes]
	from dbo.ProposedProjectClassification pc
	join dbo.ProposedProject p on p.ProposedProjectID = pc.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pc.[TenantID], pc.[ClassificationID], pc.[ProjectClassificationNotes]
	from dbo.ProjectClassification pc
	join dbo.Project p on p.ProjectID = pc.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectClassification table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pri.[TenantID], pri.[FileResourceID], pri.[Caption], pri.[Credit]
	from dbo.ProjectImage pri
	join dbo.Project p on p.ProjectID = pri.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pri.[TenantID], pri.[FileResourceID], pri.[Caption], pri.[Credit]
	from dbo.ProposedProjectImage pri
	join dbo.ProposedProject p on p.ProposedProjectID = pri.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pri.[TenantID], pri.[FileResourceID], pri.[Caption], pri.[Credit]
	from dbo.ProposedProjectImage pri
	join dbo.ProposedProject p on p.ProposedProjectID = pri.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pri.[TenantID], pri.[FileResourceID], pri.[Caption], pri.[Credit]
	from dbo.ProjectImage pri
	join dbo.Project p on p.ProjectID = pri.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectImage table did not migrate correctly!', 16, 1)
end

	

if exists(
	select
		pl.[TenantID], pl.[Annotation]
	from dbo.ProjectLocation pl
	join dbo.Project p on p.ProjectID = pl.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pl.[TenantID], pl.[Annotation]
	from dbo.ProposedProjectLocation pl
	join dbo.ProposedProject p on p.ProposedProjectID = pl.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pl.[TenantID], pl.[Annotation]
	from dbo.ProposedProjectLocation pl
	join dbo.ProposedProject p on p.ProposedProjectID = pl.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pl.[TenantID], pl.[Annotation]
	from dbo.ProjectLocation pl
	join dbo.Project p on p.ProjectID = pl.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectLocation table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pls.[TenantID], pls.[PersonID], pls.[FeatureClassName], pls.[GeoJson], pls.[SelectedProperty], pls.[ShouldImport]
	from dbo.ProjectLocationStaging pls
	join dbo.Project p on p.ProjectID = pls.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pls.[TenantID], pls.[PersonID], pls.[FeatureClassName], pls.[GeoJson], pls.[SelectedProperty], pls.[ShouldImport]
	from dbo.ProposedProjectLocationStaging pls
	join dbo.ProposedProject p on p.ProposedProjectID = pls.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pls.[TenantID], pls.[PersonID], pls.[FeatureClassName], pls.[GeoJson], pls.[SelectedProperty], pls.[ShouldImport]
	from dbo.ProposedProjectLocationStaging pls
	join dbo.ProposedProject p on p.ProposedProjectID = pls.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pls.[TenantID], pls.[PersonID], pls.[FeatureClassName], pls.[GeoJson], pls.[SelectedProperty], pls.[ShouldImport]
	from dbo.ProjectLocationStaging pls
	join dbo.Project p on p.ProjectID = pls.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectLocationStaging table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pn.[TenantID], pn.[Note], pn.[CreatePersonID], pn.[CreateDate], pn.[UpdatePersonID], pn.[UpdateDate]
	from dbo.ProjectNote pn
	join dbo.Project p on p.ProjectID = pn.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pn.[TenantID], pn.[Note], pn.[CreatePersonID], pn.[CreateDate], pn.[UpdatePersonID], pn.[UpdateDate]
	from dbo.ProposedProjectNote pn
	join dbo.ProposedProject p on p.ProposedProjectID = pn.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pn.[TenantID], pn.[Note], pn.[CreatePersonID], pn.[CreateDate], pn.[UpdatePersonID], pn.[UpdateDate]
	from dbo.ProposedProjectNote pn
	join dbo.ProposedProject p on p.ProposedProjectID = pn.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pn.[TenantID], pn.[Note], pn.[CreatePersonID], pn.[CreateDate], pn.[UpdatePersonID], pn.[UpdateDate]
	from dbo.ProjectNote pn
	join dbo.Project p on p.ProjectID = pn.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectNote table did not migrate correctly!', 16, 1)
end

if exists(
	select
		po.[TenantID], po.[OrganizationID], po.[RelationshipTypeID]
	from dbo.ProjectOrganization po
	join dbo.Project p on p.ProjectID = po.ProjectID
	where p.ProjectStageID = 1
	except
	select
		po.[TenantID], po.[OrganizationID], po.[RelationshipTypeID]
	from dbo.ProposedProjectOrganization po
	join dbo.ProposedProject p on p.ProposedProjectID = po.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		po.[TenantID], po.[OrganizationID], po.[RelationshipTypeID]
	from dbo.ProposedProjectOrganization po
	join dbo.ProposedProject p on p.ProposedProjectID = po.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		po.[TenantID], po.[OrganizationID], po.[RelationshipTypeID]
	from dbo.ProjectOrganization po
	join dbo.Project p on p.ProjectID = po.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectOrganization table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pw.[TenantID], pw.[WatershedID]
	from dbo.ProjectWatershed pw
	join dbo.Project p on p.ProjectID = pw.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pw.[TenantID], pw.[WatershedID]
	from dbo.ProposedProjectWatershed pw
	join dbo.ProposedProject p on p.ProposedProjectID = pw.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pw.[TenantID], pw.[WatershedID]
	from dbo.ProposedProjectWatershed pw
	join dbo.ProposedProject p on p.ProposedProjectID = pw.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pw.[TenantID], pw.[WatershedID]
	from dbo.ProjectWatershed pw
	join dbo.Project p on p.ProjectID = pw.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('ProposedProjectWatershed table did not migrate correctly!', 16, 1)
end

if exists(
	select
		np.[TenantID], np.[NotificationID]
	from dbo.NotificationProject np
	join dbo.Project p on p.ProjectID = np.ProjectID
	where p.ProjectStageID = 1
	except
	select
		np.[TenantID], np.[NotificationID]
	from dbo.NotificationProposedProject np
	join dbo.ProposedProject p on p.ProposedProjectID = np.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		np.[TenantID], np.[NotificationID]
	from dbo.NotificationProposedProject np
	join dbo.ProposedProject p on p.ProposedProjectID = np.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		np.[TenantID], np.[NotificationID]
	from dbo.NotificationProject np
	join dbo.Project p on p.ProjectID = np.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('NotificationProposedProject table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pme.[TenantID], pme.[PerformanceMeasureID], pme.[ExpectedValue]
	from dbo.PerformanceMeasureExpected pme
	join dbo.Project p on p.ProjectID = pme.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pme.[TenantID], pme.[PerformanceMeasureID], pme.[ExpectedValue]
	from dbo.PerformanceMeasureExpectedProposed pme
	join dbo.ProposedProject p on p.ProposedProjectID = pme.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pme.[TenantID], pme.[PerformanceMeasureID], pme.[ExpectedValue]
	from dbo.PerformanceMeasureExpectedProposed pme
	join dbo.ProposedProject p on p.ProposedProjectID = pme.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pme.[TenantID], pme.[PerformanceMeasureID], pme.[ExpectedValue]
	from dbo.PerformanceMeasureExpected pme
	join dbo.Project p on p.ProjectID = pme.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('PerformanceMeasureExpectedProposed table did not migrate correctly!', 16, 1)
end

if exists(
	select
		pmeso.[TenantID], pmeso.[PerformanceMeasureSubcategoryOptionID], pmeso.[PerformanceMeasureID], pmeso.[PerformanceMeasureSubcategoryID]
	from dbo.PerformanceMeasureExpectedSubcategoryOption pmeso 
	join dbo.PerformanceMeasureExpected pme on pme.PerformanceMeasureExpectedID = pmeso.PerformanceMeasureExpectedID
	join dbo.Project p on p.ProjectID = pme.ProjectID
	where p.ProjectStageID = 1
	except
	select
		pmeso.[TenantID], pmeso.[PerformanceMeasureSubcategoryOptionID], pmeso.[PerformanceMeasureID], pmeso.[PerformanceMeasureSubcategoryID]
	from dbo.PerformanceMeasureExpectedSubcategoryOptionProposed pmeso 
	join dbo.PerformanceMeasureExpectedProposed pme on pme.PerformanceMeasureExpectedProposedID = pmeso.PerformanceMeasureExpectedProposedID
	join dbo.ProposedProject p on p.ProposedProjectID = pme.ProposedProjectID
	where p.ProposedProjectStateID != 3
	union
	select
		pmeso.[TenantID], pmeso.[PerformanceMeasureSubcategoryOptionID], pmeso.[PerformanceMeasureID], pmeso.[PerformanceMeasureSubcategoryID]
	from dbo.PerformanceMeasureExpectedSubcategoryOptionProposed pmeso 
	join dbo.PerformanceMeasureExpectedProposed pme on pme.PerformanceMeasureExpectedProposedID = pmeso.PerformanceMeasureExpectedProposedID
	join dbo.ProposedProject p on p.ProposedProjectID = pme.ProposedProjectID
	where p.ProposedProjectStateID != 3
	except
	select
		pmeso.[TenantID], pmeso.[PerformanceMeasureSubcategoryOptionID], pmeso.[PerformanceMeasureID], pmeso.[PerformanceMeasureSubcategoryID]
	from dbo.PerformanceMeasureExpectedSubcategoryOption pmeso 
	join dbo.PerformanceMeasureExpected pme on pme.PerformanceMeasureExpectedID = pmeso.PerformanceMeasureExpectedID
	join dbo.Project p on p.ProjectID = pme.ProjectID
	where p.ProjectStageID = 1
)
begin
	raiserror('PerformanceMeasureExpectedSubcategoryOptionProposed table did not migrate correctly!', 16, 1)
end

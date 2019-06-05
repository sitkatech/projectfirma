--select * from FirmaPage
--where FirmaPageTypeID in (57, 58)

--select * from FirmaPageType

--begin tran

-- SitkaTechnologyGroup - 1
-- ========================
insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')

-- ClackamasPartnership - 2
-- ========================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(2, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(2, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')

-- RCDProjectTracker - 3
-- ========================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(3, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(3, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')

-- InternationYearOfTheSalmon - 4
-- ===============================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(4, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(4, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')

-- DemoProjectFirma - 5
-- ===============================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(5, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(5, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')



-- PeaksToPeople - 6
-- ===============================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(6, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(6, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')


-- JohnDayPartnership - 7
-- ======================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(7, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(7, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')



-- AshlandForestAllLandsRestorationInitiative - 8
-- ==============================================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(8, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(8, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')


-- ActionAgendaForPugetSound - 11
-- ===============================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(11, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(11, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')


-- BureauOfReclamation - 12
-- ===============================

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(12, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(12, 58, '<p>This report shows all Technical Assistance hours Requested, Allocated, and Provided. Data is shown for each Fiscal Year that a project has hours Requested. In addition, the value of the Technical Assistance Provided is calculated and shown here. Click a Project title to see more details.</p> ')


--rollback tran
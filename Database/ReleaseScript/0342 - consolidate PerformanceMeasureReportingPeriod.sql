
  --begin transaction


    -- PerformanceMeasureActualUpdate
    update pmau 
    set pmau.PerformanceMeasureReportingPeriodID = subQuery.newPerformanceMeasureReportingPeriodID
    from dbo.PerformanceMeasureActualUpdate pmau
    inner join 
        (
          select 
          PerformanceMeasureReportingPeriodID, 
          (
          select min(PerformanceMeasureReportingPeriodID) 
            from PerformanceMeasureReportingPeriod pmrp2 
            where 
                pmrp1.TenantID = pmrp2.TenantID 
                and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
                and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
            ) as newPerformanceMeasureReportingPeriodID
          from PerformanceMeasureReportingPeriod pmrp1 
        ) subQuery on pmau.PerformanceMeasureReportingPeriodID = subQuery.PerformanceMeasureReportingPeriodID
    
    GO

    -- PerformanceMeasureTarget
    update pmt 
    set pmt.PerformanceMeasureReportingPeriodID = subQuery.newPerformanceMeasureReportingPeriodID
    from dbo.PerformanceMeasureTarget pmt
    inner join 
        (
          select 
          PerformanceMeasureReportingPeriodID, 
          (
          select min(PerformanceMeasureReportingPeriodID) 
            from PerformanceMeasureReportingPeriod pmrp2 
            where 
                pmrp1.TenantID = pmrp2.TenantID 
                and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
                and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
            ) as newPerformanceMeasureReportingPeriodID
          from PerformanceMeasureReportingPeriod pmrp1 
        ) subQuery on pmt.PerformanceMeasureReportingPeriodID = subQuery.PerformanceMeasureReportingPeriodID

        GO

    -- PerformanceMeasureActual
    update pma 
    set pma.PerformanceMeasureReportingPeriodID = subQuery.newPerformanceMeasureReportingPeriodID
    from dbo.PerformanceMeasureActual pma
    inner join 
        (
          select 
          PerformanceMeasureReportingPeriodID, 
          (
          select min(PerformanceMeasureReportingPeriodID) 
            from PerformanceMeasureReportingPeriod pmrp2 
            where 
                pmrp1.TenantID = pmrp2.TenantID 
                and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
                and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
            ) as newPerformanceMeasureReportingPeriodID
          from PerformanceMeasureReportingPeriod pmrp1 
        ) subQuery on pma.PerformanceMeasureReportingPeriodID = subQuery.PerformanceMeasureReportingPeriodID

        GO

    -- GeospatialAreaPerformanceMeasureTarget
    update gapmt 
    set gapmt.PerformanceMeasureReportingPeriodID = subQuery.newPerformanceMeasureReportingPeriodID
    from dbo.GeospatialAreaPerformanceMeasureTarget gapmt
    inner join 
        (
          select 
          PerformanceMeasureReportingPeriodID, 
          (
          select min(PerformanceMeasureReportingPeriodID) 
            from PerformanceMeasureReportingPeriod pmrp2 
            where 
                pmrp1.TenantID = pmrp2.TenantID 
                and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
                and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
            ) as newPerformanceMeasureReportingPeriodID
          from PerformanceMeasureReportingPeriod pmrp1 
        ) subQuery on gapmt.PerformanceMeasureReportingPeriodID = subQuery.PerformanceMeasureReportingPeriodID

        GO
        
        -- Delete all of the PerformanceMeasureReportingPeriods that are no longer needed

        delete from dbo.PerformanceMeasureReportingPeriod where PerformanceMeasureReportingPeriodID not in 
        (
            select distinct sub.newPerformanceMeasureReportingPeriodID from 
            (
              select 
              PerformanceMeasureReportingPeriodID, 
              (
              select min(PerformanceMeasureReportingPeriodID) 
                from PerformanceMeasureReportingPeriod pmrp2 
                where 
                    pmrp1.TenantID = pmrp2.TenantID 
                    and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
                    and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
                ) as newPerformanceMeasureReportingPeriodID
              from PerformanceMeasureReportingPeriod pmrp1
            ) sub
        )

        GO

  --rollback transaction
  


  /*

  select * from PerformanceMeasureReportingPeriod


  select distinct sub.newPerformanceMeasureReportingPeriodID from (
      select 
      PerformanceMeasureReportingPeriodID, 
      (
      select min(PerformanceMeasureReportingPeriodID) 
        from PerformanceMeasureReportingPeriod pmrp2 
        where 
            pmrp1.TenantID = pmrp2.TenantID 
            and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
            and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
        ) as newPerformanceMeasureReportingPeriodID
      from PerformanceMeasureReportingPeriod pmrp1

  ) sub

  select 
  PerformanceMeasureReportingPeriodID, 
  (
  select min(PerformanceMeasureReportingPeriodID) 
    from PerformanceMeasureReportingPeriod pmrp2 
    where 
        pmrp1.TenantID = pmrp2.TenantID 
        and pmrp1.PerformanceMeasureReportingPeriodCalendarYear = pmrp2.PerformanceMeasureReportingPeriodCalendarYear 
        and pmrp1.PerformanceMeasureReportingPeriodLabel = pmrp2.PerformanceMeasureReportingPeriodLabel
    ) as newPerformanceMeasureReportingPeriodID
  from PerformanceMeasureReportingPeriod pmrp1 order by PerformanceMeasureReportingPeriodID


  */

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] ADD  CONSTRAINT [AK_PerformanceMeasureReportingPeriod_TenantID_PerformanceMeasureReportingPeriodCalendarYear] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[PerformanceMeasureReportingPeriodCalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
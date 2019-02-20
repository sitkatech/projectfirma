/*****************Create source data tables***************/
/****** Object:  Table [dbo].[TaxonomyBranch_Import]    Script Date: 2/19/2019 10:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyBranch_Import](
	[TaxonomyBranchID] [int] NOT NULL,
	[TaxonomyTrunkID] [int] NOT NULL,
	[TaxonomyBranchName] [nvarchar](100) NOT NULL,
	[ThemeColor] [nvarchar](7) NOT NULL,
	[TaxonomyBranchDescription] [nvarchar](max) NOT NULL,
	[TaxonomyBranchCode] [nvarchar](50) NOT NULL,
	[TaxonomyBranchSortOrder] [int] NOT NULL,
	[TaxonomyTrunkName] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxonomyLeaf_Import]    Script Date: 2/19/2019 10:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyLeaf_Import](
	[ID] [int] NOT NULL,
	[TaxonomyLeafID] [int] NOT NULL,
	[TaxonomyBranchID] [int] NOT NULL,
	[TaxonomyLeafName] [nvarchar](100) NOT NULL,
	[ThemeColor] [nvarchar](7) NOT NULL,
	[TaxonomyLeafDescription] [nvarchar](max) NOT NULL,
	[TaxonomyLeafCode] [nvarchar](50) NOT NULL,
	[TaxonomyLeafSortOrder] [int] NOT NULL,
	[TaxonomyBranchName] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (102, 32, N'BIBI1 Increase local capacity to manage stormwater programs.', N'#01B499', N'Increase local capacity to manage stormwater programs', N'BIBI1', 1, N'BIBI')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (103, 32, N'BIBI2 Provide education and incentives for legacy retrofits.', N'#01B499', N'Provide education and incentives for legacy retrofits.', N'BIBI2', 2, N'BIBI')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (104, 32, N'BIBI3 Facilitate the increased use or performance of best management practices in working/rural lan…', N'#01B499', N'Facilitate the increased use or performance of best management practices in working/rural lands.', N'BIBI3', 3, N'BIBI')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (105, 32, N'BIBI4 Identify strategies and approaches to reduce the impacts from forestry on freshwater quality.', N'#01B499', N'Identify strategies and approaches to reduce the impacts from forestry on freshwater quality.', N'BIBI4', 4, N'BIBI')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (106, 32, N'BIBI5 Conduct watershed-scale planning to protect and restore water quality.', N'#01B499', N'Conduct watershed-scale planning to protect and restore water quality.', N'BIBI5', 5, N'BIBI')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (107, 25, N'CHIN1 Protect all remaining salmon habitat, optimize a net gain in ecosystem function and habitat p…', N'#DB2365', N'Protect all remaining salmon habitat, optimize a net gain in ecosystem function and habitat productivity, and build a region-wide accountability system that is comprehensive, accessible, and transparent.', N'CHIN1', 1, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (108, 25, N'CHIN2 Establish and enforce water quantity and quality standards that protect, conserve, and restor…', N'#DB2365', N'Establish and enforce water quantity and quality standards that protect, conserve, and restore water resources for salmon.', N'CHIN2', 2, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (109, 25, N'CHIN3 Improve management of predation and mortality factors that inhibit salmon recovery.', N'#DB2365', N'Improve management of predation and mortality factors that inhibit salmon recovery.', N'CHIN3', 3, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (110, 25, N'CHIN4 Emphasize funding and implementation of science and monitoring actions to support Puget Sound…', N'#DB2365', N'Emphasize funding and implementation of science and monitoring actions to support Puget Sound salmon recovery.', N'CHIN4', 4, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (111, 25, N'CHIN5 Develop and implement a climate change mitigation and adaptation strategy for salmon recovery.', N'#DB2365', N'Develop and implement a climate change mitigation and adaptation strategy for salmon recovery.', N'CHIN5', 5, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (112, 25, N'CHIN6 Enhance preventative measures and develop integrated oil spill preparedness and response pr…', N'#DB2365', N'Enhance preventative measures and develop integrated oil spill preparedness and response programs.', N'CHIN6', 6, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (113, 25, N'CHIN7 Continue to restore degraded habitat and fish populations, via projects captured in Puget Sou…', N'#DB2365', N'Continue to restore degraded habitat and fish populations, via projects captured in Puget Sound Lead Entities’ four-year work plans.', N'CHIN7', 7, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (114, 25, N'CHIN8 Update the Puget Sound Salmon Recovery Plan and watershed chapters.', N'#DB2365', N'Update the Puget Sound Salmon Recovery Plan and watershed chapters.', N'CHIN8', 8, N'CHIN')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (115, 29, N'EST1 Enable greater local planning capacity to develop and implement multi-benefit, landscape-scale…', N'#8228BF', N'Enable greater local planning capacity to develop and implement multi-benefit, landscape-scale estuary restoration.', N'EST1', 1, N'EST')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (116, 29, N'EST2 Design landscape-scale, multi-benefit solutions for estuary restoration.', N'#8228BF', N'Design landscape-scale, multi-benefit solutions for estuary restoration.', N'EST2', 2, N'EST')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (117, 29, N'EST3 Implement landscape-scale estuary restoration plans to increase tidally inundated areas and es…', N'#8228BF', N'Implement landscape-scale estuary restoration plans to increase tidally inundated areas and estuary function while meeting the needs of diverse stakeholders.', N'EST3', 3, N'EST')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (118, 30, N'FP1 Enable greater local planning capacity to address restoration and protection.', N'#8228BF', N'Enable greater local planning capacity to address restoration and protection.', N'FP1', 1, N'FP')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (119, 30, N'FP2 Design and identify multiple-benefit solutions and strategies.', N'#8228BF', N'Design and identify multiple-benefit solutions and strategies.', N'FP2', 2, N'FP')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (120, 30, N'FP3 Implement multiple-benefit projects developed through reach-scale planning processes.', N'#8228BF', N'Implement multiple-benefit projects developed through reach-scale planning processes.', N'FP3', 3, N'FP')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (121, 35, N'FUND1 Develop a viable, effective funding and communications strategy that provides substantially…', N'#c9cacb', N'The 2017 State of the Sound notes that the funding gap for near-term actions in the 2016-2018 Action Agenda alone is hundreds of millions of dollars.  Develop a viable, effective funding and communications strategy that provides substantially increased funding for Puget Sound recovery from new and existing sources.', N'FUND1', 1, N'Fund')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (122, 28, N'LDC1 Enable protection and planning by addressing information needs on the most ecologically impor…', N'#8228BF', N'Enable protection and planning by addressing information needs on the most ecologically important areas', N'LDC1', 1, N'LCD')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (123, 28, N'LDC2 Design integrated strategies that protect and restore critical ecological functions.', N'#8228BF', N'Design integrated strategies that protect and restore critical ecological functions.', N'LDC2', 2, N'LCD')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (124, 28, N'LDC3 Implement integrated strategies and policies to protect and restore ecologically important lan…', N'#8228BF', N'Implement integrated strategies and policies to protect and restore ecologically important lands.', N'LDC3', 3, N'LCD')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (125, 26, N'SA1 Enable greater local and regional capacity to protect and restore shoreline processes.', N'#8228BF', N'Enable greater local and regional capacity to protect and restore shoreline processes.', N'SA1', 1, N'SA')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (126, 26, N'SA2 Design landscape-scale plans and improve implementation of existing regulations for the protect…', N'#8228BF', N'Design landscape-scale plans and improve implementation of existing regulations for the protection and restoration of shoreline processes.', N'SA2', 2, N'SA')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (127, 26, N'SA3 Implement landscape-scale plans and projects for the protection and restoration of shoreline pr…', N'#8228BF', N'Implement landscape-scale plans and projects for the protection and restoration of shoreline processes.', N'SA3', 3, N'SA')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (128, 31, N'SHELL1 Re-open or upgrade previously downgraded shellfish growing areas (including commercial, trib…', N'#60AA3E', N'Overarching Regional Priorities:
Upgrade the Samish and Portage Bay shellfish growing areas
Re-open or upgrade previously downgraded shellfish growing areas (including commercial, tribal and recreational growing areas)
Reverse the decline of water quality trends and protect the water quality in shellfish growing areas that are in""threatened"" or ""concerned"" status
Maintain the status of open shellfish beds that are classified as ""approved"" or ""conditionally approved""
Prevent and control fecal pollution from humans (via onsite spetic systems) and animals (livestock)', N'SHELL1', 1, N'SHELL')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (129, 24, N'TIF1 Enhance pollutant reduction programs, corrective measures and increase authorities and program…', N'#01B499', N'Enhance pollutant reduction programs, corrective measures and increase authorities and programs to prevent toxic chemicals from entering Puget Sound.', N'TIF1', 1, N'TIF')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (130, 24, N'TIF2 Address stormwater treatment.', N'#01B499', N'Address stormwater treatment.', N'TIF2', 2, N'TIF')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (131, 24, N'TIF3 Provide infrastructure and incentives to accommodate new development and redevelopment within…', N'#01B499', N'Provide infrastructure and incentives to accommodate new development and redevelopment within designated urban centers in Urban Growth Areas (UGA).', N'TIF3', 3, N'TIF')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (132, 24, N'TIF4 Reduce the impact of local air pollution on stormwater toxicity.', N'#01B499', N'Reduce the impact of local air pollution on stormwater toxicity.', N'TIF4', 4, N'TIF')
GO
INSERT [dbo].[TaxonomyBranch_Import] ([TaxonomyBranchID], [TaxonomyTrunkID], [TaxonomyBranchName], [ThemeColor], [TaxonomyBranchDescription], [TaxonomyBranchCode], [TaxonomyBranchSortOrder], [TaxonomyTrunkName]) VALUES (133, 24, N'TIF5 Develop an Implementation Strategy for Toxics in Fish.', N'#01B499', N'Develop an Implementation Strategy for Toxics in Fish.', N'TIF5', 5, N'TIF')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (2, 1002, 102, N'BIBI 1.1 Increase local capacity to manage stormwater programs.', N'#01B499', N'Increase local capacity to manage stormwater programs.
*Desired Outcome
More support for funding local stormwater programs , or decrease the burden of managing programs.
*Policy Needs

*Example Actions
•Implement a project or projects to increase the likelihood that the public would support stormwater management capacity (social marketing). Create additional political will to increase capacity. Start with barriers—explore solutions for overcoming them.                             • Increase capacity for and effectiveness of training, maintenance, and enforcement.
*Proposal Guidance
• May be most important in yet to be developed areas (incl. non-permitted areas).
• Stormwater fee structures don’t capture single family land base. Single family/residential may be underpaying for stormwater programs.
• Could also serve to increase support for protection
Project Ideas:
• Peer-to-peer training networks
• SW utility increase incentive
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality.
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.2.1 Identify opportunities to align and improve water quality protections
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections 
2.1.4.2 Decision-maker outreach on water quality protections in policy
Additional guidance:
- Engage HCCC and member jurisdictions
 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18-Table 3, 20-Table 4, 22, 23, 29, and 40. 
**San Juan
Applicable, no additional info.  
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 04.1 Outreach for Stormwater Stewardship (page 44-45), strategy 05.1 Non-point Source Assessment and Product Stewardship (page 46), and strategy 06.1 Stormwater Retrofit and LID. –Refer to 2016 NTAs that have been mapped to strategies 04.1, 05.1, and 06.1 -NTA 2016-0218) is currently being implemented. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Seek (such as, through a future NTA) to develop a program to routinely sweep arterial streets with high efficiency sweepers and enroll jurisdictions in the South Central LIO in it. Develop specific targets, including effectiveness/adaptive management monitoring (pg. 23).
o Transition current Puget Sound Starts Here to conduct more targeted outreach that results in measurable behavior change (pg. 23).
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the BIBI Vital Sign is currently associated with our Tier B Fresh Water Quality Ecosystem Component, not Tier A.  NTAs developed to benefit our Tier A Components and associated Vial Signs however, are expected to “cascade down” to those Components in lower tiers, such as this one in Tier B.  With the “cascading benefits” concept in mind, design NTAs for this BIBI Regional Priority using one or more of the Local Strategy Results Chains cited below and within one or more of the other Regional Priorities relevant to the NTA.  These “cascading benefits” should be well explained within the narrative portions of the NTA Factsheet for BIBI Regional Priority NTAs benefitting the Strait Action Area.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.

Strait Ecosystem Protection and Recovery Plan: 
o BIBI Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control); and/or
• M (education).

Special Emphasis: Identified Barriers (Table 5) to accomplishing ecosystem recovery:
• Limited staff capacity to implement actions (particularly within unincorporated areas). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.5, 26.3, and 26.5. See pages 30, 31, 32, and 84. 
**Whatcom
Applicable – See Local Context 
Relevant LIO Plan strategies and substrategies include:
• watershed-scale stormwater management plans with cross-jurisdictional coordination (WHATCOM-RC-WQ06), 
• Education and Outreach (WHATCOM-RC-CROSS07), and
• Developing a funding strategy (WHATCOM-STRAT-CROSS05).
Local and Regional NTA owners should coordinate with Whatcom LIO', N'BIBI1.1', 1, N'BIBI1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (3, 1003, 103, N'BIBI 2.1 Provide education and incentives for legacy retrofits.', N'#01B499', N'Provide education and incentives for legacy retrofits.
*Desired Outcome
Implement strategies to incentivize stormwater retrofits to better match natural hydrologic and water chemistry.
*Policy Needs
• Investigate and where prudent, remove policy barriers to creative BMP implementation, at both the state and local level
*Example Actions
• Stormwater control transfer programs                                          • Other programs to incentivize voluntary retrofits
*Proposal Guidance
• Encourage the use of Washington State Commerce''s Building Cities in the Rain Guidance to prioritze stormwater retrofits 
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality.
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.2.1 Identify opportunities to align and improve water quality protections
Additional guidance:
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan 
 http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18-Table 3, 20-Table 4, 22, 23, 29, and 40. 
**San Juan
Applicable, no additional info.  
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 06.1 Stormwater Retrofit and LID. –Refer to 2016 NTAs mapped to strategy 06.1 https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 26-27, Toxics in Fish Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Reduce toxics loading by treating 200 acres through retrofits (pg. 22).
o In WRIA 10: Implementing Depave Programs

 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the BIBI Vital Sign is currently associated with our Tier B Fresh Water Quality Ecosystem Component, not Tier A.  NTAs developed to benefit our Tier A Components and associated Vial Signs however, are expected to “cascade down” to those Components in lower tiers, such as this one in Tier B.  With the “cascading benefits” concept in mind, design NTAs for this BIBI Regional Priority using one or more of the Local Strategy Results Chains cited below and within one or more of the other Regional Priorities relevant to the NTA.  These “cascading benefits” should be well explained within the narrative portions of the NTA Factsheet for BIBI Regional Priority NTAs benefitting the Strait Action Area.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.

Strait Ecosystem Protection and Recovery Plan: 
o BIBI Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.5, 26.3, and 26.5. See pages 30, 31, 32, and 84. 
**Whatcom
Applicable – See Local Context 
Relevant LIO Plan strategies and substrategies include:
•  Education and Outreach  (WHATCOM-RC-CROSS07)
• Implementing and expanding incentive/cost share programs (WHATCOM-RC-CROSS09).
• Stormwater training and technical assistance (WHATCOM-WQ-09)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'BIBI2.1', 2, N'BIBI2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (4, 1004, 104, N'BIBI 3.1 Facilitate the increased use or performance of best management practices in working/rural…', N'#01B499', N'Facilitate the increased use or performance of best management practices in working/rural lands.
*Desired Outcome
Reduce the impact of runoff from working lands.
*Policy Needs

*Example Actions
• Establish enabling conditions (build vision and trust).
• Identify the best-suited sites and BMPs.
• Provide technical assistance.
• Develop economic incentives/remove barriers.
• Provide education and outreach so that rural landowners don’t feel as burdened and recognize the benefits that accrue to them of using BMPs. Use the following barrier reduction/increase motivators:
o Permitting
o Incentives
o Percent participation, reach-scale incentive payments
• Advocate for alternative agricultural approaches that are less environmentally problematic (such as working buffers).
*Proposal Guidance
• Community is important.
• Share the burden of achieving environmental benefits.
• Working lands can include forestry.
• Identify multi-benefit approaches.                               
• Supporting BMPs that are resilient to climate change and achieve other co-benefits would attain diversity of beneficial outcomes.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality.
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.1 Reduce impacts of stormwater runoff from transportation and service corridors, and urbanized areas
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands
Additional guidance:
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan
 http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18-Table 3, 20-Table 4, 22, 23, 29, and 40. 
**San Juan
Applicable, no additional info.  
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 04.1 Outreach for Stormwater Stewardship (page 44-45), strategy 05.1 Non-point Source Assessment and Product Stewardship (page 46). -Refer to 2016 NTAs, mapped to strategies 04.1 and 05.1 that support this work. -Private land owner outreach is a critical component of this approach. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Improve flashiness and low flows in small streams through implementation of infiltration techniques and private landowner and contractor education to 100 contractors and 1,000 landowners (>75% of contractors) on green stormwater infrastructure techniques (pg. 23).
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the BIBI Vital Sign is currently associated with our Tier B Fresh Water Quality Ecosystem Component, not Tier A.  NTAs developed to benefit our Tier A Components and associated Vial Signs however, are expected to “cascade down” to those Components in lower tiers, such as this one in Tier B.  With the “cascading benefits” concept in mind, design NTAs for this BIBI Regional Priority using one or more of the Local Strategy Results Chains cited below and within one or more of the other Regional Priorities relevant to the NTA.  These “cascading benefits” should be well explained within the narrative portions of the NTA Factsheet for BIBI Regional Priority NTAs benefitting the Strait Action Area.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.

Strait Ecosystem Protection and Recovery Plan: 
o BIBI Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• G (water resource management);
• I (climate change);
• J (stormwater management and pollutant source control);
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 21.4, 10.5, 20.2, and 26.3. See pages 30 and 84. 
**Whatcom
Applicable – See Local Context 
Relevant LIO Plan strategies and substrategies include:
• Implement and expand incentive/cost-share programs (WHATCOM-RC-CROSS09), 
• Education and Outreach (WHATCOM-RC-CROSS07), 
• Source identification and effectiveness monitoring of best management practices (WHATCOM-RC-SHELL03), 
• Develop Integrated Floodplain Management Plan (WHATCOM-RC-HAB03), 
• Provide technical assistance [to reduce bacterial pollution](WHATCOM-RC-SHELL02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'BIBI3.1', 3, N'BIBI3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (5, 1005, 105, N'BIBI 4.1 Identify strategies and approaches to reduce the impacts from forestry on freshwater quali…', N'#01B499', N'Identify strategies and approaches to reduce the impacts from forestry on freshwater quality.
*Desired Outcome
Reduce runoff and other hydrologic impacts from forestry production.
*Policy Needs
• Develop a B-IBI forestry component of the Implementation Strategy.
*Example Actions

*Proposal Guidance
• The Stormwater SI Advisory Team identified runoff and hydro-modification resulting from forest practices as significant challenges for achieving freshwater quality and B-IBI indicator targets. The SI Advisory Team recommended that the B-IBI Implementation Strategy needs to address runoff from forestry in more depth. The Stormwater SI Lead will work to build out this component of the Implementation Strategy. 
• The SI Advisory Team recommended looking for opportunities with small forest landowners, and decommissioning federal roads.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality.
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.2 Outreach to small and large forest landowners
Additional guidance:
- Engage HCCC and member jurisdictions
Utilize HCCC Stormwater Retrofit Plan
 http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18-Table 3, 20-Table 4, 22, 23, 29, and 40. 
**San Juan
Applicable, see local context
(The local focus is on improved management of the dense forested areas in SJC, working with private and governmental forest landowners to reduce wildfire risk which will reduce potential impacts on freshwater)
 
**Snohomish/Stillaguamish
Applicable, no additional info.  
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Improve flashiness and low flows in small streams through implementation of infiltration techniques and private landowner and contractor education to 100 contractors and 1,000 landowners (>75% of contractors) on green stormwater infrastructure techniques (pg. 23).
 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the BIBI Vital Sign is currently associated with our Tier B Fresh Water Quality Ecosystem Component, not Tier A.  NTAs developed to benefit our Tier A Components and associated Vial Signs however, are expected to “cascade down” to those Components in lower tiers, such as this one in Tier B.  With the “cascading benefits” concept in mind, design NTAs for this BIBI Regional Priority using one or more of the Local Strategy Results Chains cited below and within one or more of the other Regional Priorities relevant to the NTA.  These “cascading benefits” should be well explained within the narrative portions of the NTA Factsheet for BIBI Regional Priority NTAs benefitting the Strait Action Area.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.

Strait Ecosystem Protection and Recovery Plan: 
o BIBI Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment); and/or
• I (climate change). 
**West Central
Applicable, no additional info.  
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'BIBI4.1', 4, N'BIBI4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (6, 1006, 106, N'BIBI 5.1 Conduct watershed-scale planning to protect and restore water quality.', N'#01B499', N'Conduct watershed-scale planning to protect and restore water quality.
*Desired Outcome
Develop watershed-scale plans that: 
• Employ traditional water quality protection, as well as explore land use planning tools to better protect freshwater quality. 
• Prioritize where to focus restoration efforts versus protection efforts.
• Identify how to best protect freshwater resources.

*Policy Needs
Implement watershed-scale B-IBI planning processes:
• Local governments develop inter-local agreements for cross-jurisdictional landuse/water quality planning.
• State Department of Ecology to finalize and share watershed planning/stormwater control transfer guidance.
*Example Actions
Carry out watershed-scale B-IBI planning processes and activities that would facilitate planning processes:
• Establish enabling conditions (build trust, encourage buy-in and participation from local governments, recognize value, pre-planning assessments, etc.)
• Build plan/planning structure (such as the King County B-IBI planning approach).
• Develop a region-wide toolkit based on guidance from the state Department of Ecology, and incorporate opportunities for cross-jurisdictional learning.
• Reconcile/refine current plans.
• Develop new plans.
• Implement plans.
*Proposal Guidance
• Incorporate source control for pollutant load reduction where it limits B-IBI.
• Build from existing efforts, incorporating flexibility.
• Protection is vitally important and may be a more prudent consideration than restoration (the Department of Ecology Watershed Characterization may be a valuable tool to indicate where restoration and protection are most applicable).
• Washington Department of Commerce''s ''Building Cities in the Rain'' guidance on stormwater transfer control programs may be useful to NTA owners.
• Planning efforts could incorporate source control for pollutant load reduction where it limits B-IBI.
• While toxics are not intended to be the primary focus of these planning efforts, there may be instances where toxics could be integrated into planning efforts. B-IBI addresses streams rated ''excellent'', ''fair'' and ''good'', Toxics in Fish priority approaches could be employed in ‘poor’ basins or ''poor'' areas of basins.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality.
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections
Additional guidance:
- Engage HCCC and member jurisdictions
 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18-Table 3, 20-Table 4, 22, 23, 29, and 40. 
**San Juan
Not applicable (NOTE: Current in-place Stormwater Basin Plans being implemented) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 02.1 Integrated Planning (page 35, and 42). -implement actions consistent with recommendations in any applicable basin planning documents -refer to integrated planning processes (LIO Strategy 02.1) and integrated monitoring efforts. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Improve flashiness and low flows in small streams through implementation of infiltration techniques and private landowner and contractor education to 100 contractors and 1,000 landowners (>75% of contractors) on green stormwater infrastructure techniques (pg. 23).
o Survey local governments to identify which have active or completed projects & plans to restore creek reaches; consider which might be appropriate for using B-IBI as an indicator of restoration effectiveness and lend support by seeking funding for more projects and restoration plans (pg. 23).
o Further develop the Stream Benthos Database (pg. 23).
 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the BIBI Vital Sign is currently associated with our Tier B Fresh Water Quality Ecosystem Component, not Tier A.  NTAs developed to benefit our Tier A Components and associated Vial Signs however, are expected to “cascade down” to those Components in lower tiers, such as this one in Tier B.  With the “cascading benefits” concept in mind, design NTAs for this BIBI Regional Priority using one or more of the Local Strategy Results Chains cited below and within one or more of the other Regional Priorities relevant to the NTA.  These “cascading benefits” should be well explained within the narrative portions of the NTA Factsheet for BIBI Regional Priority NTAs benefitting the Strait Action Area.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.

Strait Ecosystem Protection and Recovery Plan: 
o BIBI Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control). 
**West Central
Local Context: Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.1. See pages 31 and 81. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies include:
• Watershed-scale stormwater management plans with cross-jurisdictional coordination (WHATCOM-RC-WQ06). 
• Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues (WHATCOM-RC-CROSS02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'BIBI5.1', 5, N'BIBI5')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (7, 1007, 107, N'CHIN 1.1 Continue to engage with local implementing entities (including tribes, counties, cities…', N'#DB2365', N'Continue to engage with local implementing entities (including tribes, counties, cities, lead entities, WRIAs etc.) on preservation of salmon habitat, issues relating to land use, critical areas, and other issues affecting salmon recovery and restoration work.
*Desired Outcome
Increased coordination and partnerships among local implementing entities and between regional and local entities on salmon recovery and restoration.
*Policy Needs

*Example Actions
Develop task forces to address specific habitat protection issues.
Establish land use, protection, and restoration goals for a watershed.
*Proposal Guidance
Describe how your project integrates with the planning landscape in the watershed or region.
Describe the strategy that will be used to engage the relevant partners and resolve conflicts.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 02.1 (page 42) and 2016 NTAs mapped to the Strategy. See Snohomish and Stillaguamish Salmon Recovery Plans,
Snohomish Basin Protection Plan, and Stillaguamish Acquisition Strategy https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/2153

http://www.stillaguamishwatershed.org/Documents/Stillaguamish Watershed Salmon Recovery Plan -- Jun.pdf

https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402

http://www.stillaguamishwatershed.org/Documents/V.1. 5-18-15 FINAL SWC acquisition strategy.pdf
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat), and/or
o H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 2 and 3. Page 47. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA.', N'CHIN1.1', 1, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (8, 1008, 107, N'CHIN 1.10 Enforce and improve compliance with existing regulations.', N'#DB2365', N'Enforce and improve compliance with existing regulations.
*Desired Outcome
Better enforcement and compliance of existing regulations.
*Policy Needs

*Example Actions
Track enforcement and compliance reporting for results, and variance reporting.

Enhance capacity for compliance and enforcement efforts.

Evaluate and/or implement technical improvements to compliance and enforcement efforts.

Improve reporting on compliance and enforcement efforts.
*Proposal Guidance
Describe how you will communicate the results of your project to decision-makers.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.1.2.1 Identify opportunities to improve and align shoreline protections across Hood Canal
1.1.2.2 Develop incentives for landowners to protect shoreline habitats
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO 01.1 & 01.2 (page 40) and 10.1 & 10.2 (page 51) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA', N'CHIN1.10', 10, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (9, 1009, 107, N'CHIN 1.11 Build support for modifications to the hydraulic code to include enhanced civil enforceme…', N'#DB2365', N'Build support for modifications to the hydraulic code to include enhanced civil enforcement authorities that would allow WDFW to issue stop-work and administrative orders, inspect properties, and increase civil fines.
*Desired Outcome
Hydraulic code modified to enhance the effectiveness of WDFW’s work to discourage actions that adversely impact fisheries resources.
*Policy Needs

*Example Actions
Engage local governments, the business community, and/or other partners in discussions about these improvements.
*Proposal Guidance
Coordinate your proposal with WDFW.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal

Additional guidance:
- Engage HCCC and member jurisdictions
- Engage local jurisdictions planning departments
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/content/salmon-recovery-planning
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o H (shoreline and land use). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA', N'CHIN1.11', 11, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (10, 1010, 107, N'CHIN 1.2 Evaluate land use policies and their effectiveness in protecting habitat critical to salmo…', N'#DB2365', N'Evaluate land use policies and their effectiveness in protecting habitat critical to salmon and salmon recovery.
*Desired Outcome
Enhanced understanding of the effectiveness of land use policies enables protection of critical salmon habitat and improvements to less effective policies.
*Policy Needs

*Example Actions
Collect and analyze data on effectiveness of specific land use policies, and communicate it to relevant decision-makers.
*Proposal Guidance
Describe how you will communicate the results of your project to decision-makers and local and regional planning entities.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
1.1.1 Outreach and education on shoreline protection and stewardship
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 02.1 (page 42) and 08.1 (page 49) and 2016 NTAs mapped to those Strategies. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o H (shoreline and land use), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88.
Table 8. Gap 1 and 3. Page 46 and 47. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA.', N'CHIN1.2', 2, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (11, 1011, 107, N'CHIN 1.3 Develop a regional definition of critical areas and ecologically important habitat, includ…', N'#DB2365', N'Develop a regional definition of critical areas and ecologically important habitat, including coordination of data (GIS exercise) to compile this overlay.
*Desired Outcome
Based on enhanced understanding of critical areas and ecologically important salmon habitat, protection and restoration efforts are directed to areas where actions will have a high impact.
*Policy Needs

*Example Actions
Convene a task force at the regional scale to develop the overlay.

Collect and analyze data necessary to create the overlay.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
1.1.1 Outreach and education on shoreline protection and stewardship
1.1.2 Improve shoreline planning and regulatory frameworks
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO 02.1 (page 42). See approved hydrologic and geomorphology studies done in the Snoqualmie, Stillaguamish, and Snohomish basins. See also local CAR, SMP, GMA, Snohomish Basin Protection Plan, Stillaguamish low flow temperature study and related planning documents. Map overlays should build off existing efforts (i.e. Snohomish County Planning and Development Services iGallery: (http://gismaps.snoco.org/Html5Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default http://gismaps.snoco.org/Html5Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o H (shoreline and land use), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 7. Barrier 1. Page 45. Table 8. Gap 1 and 3. Pages 46 and 47. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA.', N'CHIN1.3', 3, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (12, 1012, 107, N'CHIN 1.4 Develop a standardized habitat assessment methodology and decision framework that supports…', N'#DB2365', N'Develop a standardized habitat assessment methodology and decision framework that supports regulatory alignment and harmonization of plans, processes, voluntary measures, and actions among agencies and across all levels of government.
*Desired Outcome
Localized habitat goals achieved that support the recovery and further protection of all treaty resources, meet multiple-benefit planning goals, and create efficiencies and cost savings for the public, governments, and their staff.
*Policy Needs

*Example Actions
Develop ways to align regulations across all levels of government in support of bundling and streamlining voluntary permit pathways.  

Develop a habitat assessment and decision tool for salmon that identifies critical habitat and priority actions to recover salmon.
*Proposal Guidance
Describe how your project is applicable Sound-wide, or could be exported to other parts of the Sound.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO 02.1 (page 42) and 08.1 (page 49) and 8.1 (page 50). See Snohomish Basin Protection Plan and Stillaguamish Lead Entity Monitoring & Adaptive Management Plan. https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402

http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o H (shoreline and land use) and/or
o I (climate change). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA.', N'CHIN1.4', 4, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (13, 1013, 107, N'CHIN 1.5 Establish science-based standards region-wide when protecting and restoring effective ripa…', N'#DB2365', N'Establish science-based standards region-wide when protecting and restoring effective riparian zones on all salmon and steelhead streams. Include other key biological attributes such as floodplains, off channel habitats and riverine wetlands.
*Desired Outcome
Science-based standards for protecting and restoring effective riparian zones on all salmon and steelhead streams established region-wide.
*Policy Needs

*Example Actions
Establish effective riparian management guidance manual, work currently underway by WDFW.
*Proposal Guidance
Describe how your proposal includes other key biological attributes such as floodplains, off-channel habitats, and riverine wetlands.

Describe how your approach can be integrated with WDFW’s guidance manual.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not Applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o C (Floodplains),
o D (riparian and instream habitat),
o H (shoreline and land use) and/or
o I (climate change). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO and WRIA 1 Lead Entity for salmon recovery before submitting an NTA.', N'CHIN1.5', 5, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (14, 1014, 107, N'CHIN 1.6 Monitor and report on landowner use and implementation of incentive-based programs to addr…', N'#DB2365', N'Monitor and report on landowner use and implementation of incentive-based programs to address salmon habitat protection and restoration needs. Regional coordinating entities can use monitoring data to track local progress and pursue adaptive management and corrections as needed; and where necessary, tailor program implementation to local conditions to achieve salmon recovery goals at the watershed scale.
*Desired Outcome
Incentive-based programs for salmon habitat protection and restoration needs utilized by landowners.
*Policy Needs

*Example Actions
Develop and implement monitoring programs.

Design and conduct a project to adaptively manage incentive-based programs.

Convene partners to tailor program implementation to local conditions.
*Proposal Guidance
If you’re proposing a monitoring project, describe how you will communicate the results to decision-makers and local and regional planning entities.

If you’re proposing to tailor a program to local conditions, explain how other areas might use your approaches or results.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.2.1 Identify opportunities to align and improve water quality protections
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Utilize HCCC Stormwater Retrofit Plan
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 10.1 and 10.2 (page 51). Snohomish Conservation District and Sound Salmon Solutions report on numerous existing incentive programs (CREP, NEP Riparian). See also Snohomish Basin Protection Plan. https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o H (shoreline and land use), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan, Recovery Strategies: 17.2, 2.2, and 26.5. Pages 30, 31, 32, and 83 and 89. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO and WRIA 1 Lead Entity for salmon recovery before submitting an NTA.', N'CHIN1.6', 6, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (15, 1015, 107, N'CHIN 1.7 Identify, review, and address regulatory regimes and mechanisms that adversely impact fish…', N'#DB2365', N'Identify, review, and address regulatory regimes and mechanisms that adversely impact fisheries resources, including regulatory exemptions that adversely, or potentially adversely impact fish habitat.
*Desired Outcome
Enhanced understanding of regulatory regimes and mechanisms that adversely impact fisheries resources enables improvements to protection and restoration efforts.
*Policy Needs

*Example Actions
Design and implement a study of a particular regulatory regime or mechanism.

Develop options to address known regulatory regimes or mechanisms that adversely affect fisheries resources.
*Proposal Guidance
Consider engaging JLARC or the State Auditor, and/or the Salmon Recovery Council Regulatory Subcommittee, to help with this task.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal
3.1.2.2 Outreach to small and large forest landowners
1.1.1.4 Outreach and education on shoreline protection and stewardship to political leaders
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)

Additional guidance:
- Engage HCCC and member jurisdictions, and utilize HCCC policy forum
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions’ planning departments
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Utilize HCCC Protected Lands GIS tool
- Engage existing FPbD partners http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 10.1 and 10.2 and Snohomish Basin Protection Plan. https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4403
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o H (shoreline and land use) and/or
o I (climate change). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO and WRIA 1 Lead Entity for salmon recovery before submitting an NTA.', N'CHIN1.7', 7, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (16, 1016, 107, N'CHIN 1.8 Develop an acquisition strategy that values conservation easements and property acquisitio…', N'#DB2365', N'Develop an acquisition strategy that values conservation easements and property acquisitions on ecosystem services provided to the region.
*Desired Outcome
Conservation easements and property acquisitions that focus on ecosystem services provided by salmon species to the Puget Sound region prioritized.
*Policy Needs

*Example Actions
Develop an approach to using ecosystem service values in conservation easements and property acquisitions.

Evaluate the changes needed in the current regulatory landscape to achieve this outcome.

Develop an acquisition strategy using this approach.
*Proposal Guidance
Consider describing how you will communicate the results of your project to the Salmon Recovery Council.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)

Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Engage HCCC staff
- Utilize HCCC Protected Lands GIS tool, if applicable
- Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions planning departments
- Demonstrate outcomes of Regional Priority Approach FP1.1-1.5, FP2.1-2.2
- Engage HCCC and member jurisdictions
- Engage existing FPbD partners
- Utilize PSNERP, ESRP project plans and partners
- Identify opportunities to integrate with Hood Canal salmon recovery plans http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf

http://hccc.wa.gov/content/salmon-recovery-planning
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context: Refer to Stillaguamish Acquisition Strategy and SSLIO 10.1 and 10.2 (page 51). http://www.stillaguamishwatershed.org/Documents/V.1. 5-18-15 FINAL SWC acquisition strategy.pdf
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o H (shoreline and land use), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO and WRIA 1 Lead Entity for salmon recovery before submitting an NTA.', N'CHIN1.8', 8, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (17, 1017, 107, N'CHIN 1.9 Create a balance sheet for habitat gain and loss in the watershed.', N'#DB2365', N'Create a balance sheet for habitat gain and loss in the watershed.
*Desired Outcome
The amount of salmon habitat gained and lost in the Puget Sound watershed better understood.
*Policy Needs

*Example Actions
Implement a project to use the Chinook Common Indicators, and other monitoring data as needed, to analyze and report on habitat gain and loss in one or more watersheds.
*Proposal Guidance
Describe how you will use the Chinook Common Indicators in this project.

Consider describing how you will communicate the results of your project to the Salmon Recovery Council.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage HCCC salmon recovery partners
- Engage HCCC salmon recovery program staff http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.   

Refer to SSLIO 10.1 & 10.2 (page 51),  Snohomish Basin Protection Plan and Snohomish River Basin Salmon Conservation Plan https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402

https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/2153
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o H (shoreline and land use), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1. Page 46. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO and WRIA 1 Lead Entity for salmon recovery before submitting an NTA.', N'CHIN1.9', 9, N'CHIN1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (18, 1018, 108, N'CHIN 2.1 Low flows are a major limiting factor for salmon recovery.  Ensure sufficient instream flo…', N'#DB2365', N'Low flows are a major limiting factor for salmon recovery.  Ensure sufficient instream flow, and where necessary restore instream flows, to levels necessary for salmon recovery.
*Desired Outcome
Adequate amounts of water for salmon recovery are retained and restored
*Policy Needs

*Example Actions
Design and implement creative projects to ensure sufficient water supplies for fish
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Freshwater flows also are discussed in the section on forests and freshwater. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC staff regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- Consult and identify opportunities to build off past work focused on Hood Canal marine mammals and predation on salmon, if applicable
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) 
**Island
Applicable, see local context: Please refer to the LIO Recovery Plan and contact LIO coordinator with questions. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to Snohomish and Stillaguamish instream flow rules. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

S Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o G (water resource management),
o I (climate change),
o J (stormwater management and pollutant source control), and/or
o M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 7.2, 7.1 and 9.6. See pages 32, 33, 87 and 88. 
**Whatcom
Applicable – See local context
• Refer to Whatcom LIO Ecosystem Recovery Plan conceptual model for summer stream flows.
• See develop binding agreements to resolve water quantity, water quality, habitat, and drainage issues (WHATCOM- RC-CROSS02)
• Related', N'CHIN2.1', 1, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (19, 1019, 108, N'CHIN 2.2 Initiate discussions and identify specific actions around water science, management, and c…', N'#DB2365', N'Initiate discussions and identify specific actions around water science, management, and conservation.
*Desired Outcome
Water science, management, and conservation actions and solutions for salmon recovery are collaboratively identified.
*Policy Needs

*Example Actions
Convene a collaborative process to evaluate ways to move to a pricing system, and/or assess water availability or water storage opportunities.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.2.1.1, 1.3.1.1 Fill information and data gaps identified to inform salmon recovery in Hood Canal
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.2.1 Identify opportunities to align and improve water quality protections
2.1.4.2 Decision-maker outreach on water quality protections in policy
2.2 Investigate low dissolved oxygen content in Hood Canal marine waters (LIO ERP pg. 38)
2.2.1 Assess impacts of water circulation impediments in Hood Canal (HCCC Strategic Prioritization rank: 30 of 31)
2.2.2 Form research agenda to investigate knowledge gaps related to low-dissolved oxygen in Hood Canal (HCCC Strategic Prioritization rank: 26 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage HCCC salmon recovery program staff and partners
- Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
- Engage local jurisdictions planning departments
- Engage HCCC and member jurisdictions
- Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
- Engage existing FPbD partners
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Utilize HCCC Stormwater Retrofit Plan http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf

http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 9.1 (page 50) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

S Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o G (water resource management),
o I (climate change), and/or
o J (stormwater management and pollutant source control). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 7.2 and 7.1. See pages 33 and 87. Table 8. Gap 1. Page 46. 
**Whatcom
Applicable – See local context
• Refer to Whatcom LIO Ecosystem Recovery Plan conceptual model for summer stream flows.
• See develop binding agreements to resolve water quantity, water quality, habitat, and drainage issues (WHATCOM- RC-CROSS02)
• Related', N'CHIN2.2', 2, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (20, 1020, 108, N'CHIN 2.3 Plan for future needs and changing climate and ecosystem conditions: Protect and improve…', N'#DB2365', N'Plan for future needs and changing climate and ecosystem conditions: Protect and improve, where needed, the water holding capacity of watershed uplands to increase groundwater, augment summer low flows and reduce flood risks.
*Desired Outcome
The water holding capacity of watershed uplands is protected and improved to provide more water for fish in the midst of changing climate and ecosystem conditions.
*Policy Needs

*Example Actions
Convene partners to develop a plan to identify, protect, and improve water-holding capacities of watersheds.

Implement existing plans to protect and improve water-holding capacity.
*Proposal Guidance
Water temperature, turbidity (that can increase with glacier retreat), low flows, and peak flows (which can scour or entomb redds and significantly lowers egg-to-fry survival) can also be considered.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) 
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 9.1 (page 50), Snohomish Basin Protection Plan, and climate change documents for the Stillaguamish and Snohomish Basins https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402

http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o G (water resource management),
o I (climate change),
o J (stormwater management and pollutant source control), and/or
o M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 7. Barrier 1. Page 45. Table 8. Gap 1 and 3. Page 46 and 47. 
**Whatcom
Applicable – See local context
• See develop binding agreements to resolve water quantity, water quality, habitat, and drainage issues (WHATCOM- RC-CROSS02)
• Related strategies and substrategies include:
o WHATCOM-STRAT-CROSS04 (develop and implement wat', N'CHIN2.3', 3, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (21, 1021, 108, N'CHIN 2.4 Effectively implement and enforce existing regulations and report periodically.', N'#DB2365', N'Effectively implement and enforce existing regulations and report periodically.
*Desired Outcome
Regulations are assessed for effectiveness and adaptively managed.
*Policy Needs

*Example Actions
Identify implementation and enforcement needs.

Implement known fixes to gaps in regulatory implementation and enforcement.

Develop or enhance periodic reporting mechanisms.
*Proposal Guidance
Consider a step around learning from all agencies that have regulatory authority to protect habitat and water, including what is needed to be able to adequately enforce those regulations.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
Engage HCCC and member jurisdictions 
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context: Refer to SSLIO 01.1 & 01.2 (page 40) and 10.1 & 10.2 (page 51) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o G (water resource management),
o I (climate change), and/or
o J (stormwater management and pollutant source control). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. 
Table 8. Gap 1 and 2. Pages 46 and 47. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with Whatcom LIO before submitting an NTA', N'CHIN2.4', 4, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (22, 1022, 108, N'CHIN 2.5 Address and manage water quality parameters, including excess nutrient loading (such as ni…', N'#DB2365', N'Address and manage water quality parameters, including:
• Excess nutrient loading (such as nitrogen) for all sources, and with specific attention to pathways associated with wastewater treatment outfalls
• Elevated temperatures
• Sediment
• Toxics
*Desired Outcome
Water quality parameters that negatively impact salmon survival are addressed and managed.
*Policy Needs

*Example Actions
Design and implement projects to reduce nutrient loading.

Design and implement a project to reduce water temperatures.

Design and implement a project to address sediment.

Design and implement a project to address toxics.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.0 Protect and improve Hood Canal water quality (LIO ERP pg. 35)
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25) (LIO ERP pg. 56, App. A pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions
- Engage with HCCC and member jurisdictions to coordinate monitoring activities with existing efforts and plans 
- Coordinate efforts with Hood Canal Regional Pollution Identification and Correction Program (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results) http://hccc.wa.gov/content/pollution-identification-correction
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to watershed TMDL areas and SSLIO 6.1 (page 47) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o E (fish passage and excess sediment),
o G (water resource management),
o I (climate change),
o J (stormwater management and pollutant source control), and/or
o K (water quality clean up plans) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3 and 21.4; pages 30, 32, 82, and 84. 
**Whatcom
Applicable – See local context
Related strategies include:
• Develop binding agreements to resolve water quantity, water quality, habitat, and drainage issues (WHATCOM- STRAT-CROSS02)
• WHATCOM-STRAT-CROSS10 (promote US/Canada coordination over transbound', N'CHIN2.5', 5, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (23, 1023, 108, N'CHIN 2.6 Incentivize and accelerate stormwater management for new and existing development.', N'#DB2365', N'Incentivize and accelerate stormwater management for new and existing development.
*Desired Outcome
Best stormwater management practices are the standard for new and existing development.
*Policy Needs

*Example Actions
Use social science to develop effective incentives.

Design and implement projects to increase the use of effective incentives for best practices.
*Proposal Guidance
Describe how your project is applicable Sound-wide or might be tailored for use in other parts of Puget Sound.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. Land use and habitat protection also are discussed in sections on prairie oak woodlands, forests and freshwater, and shorelines. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
2.0 Protect and improve Hood Canal water quality (LIO ERP pg. 35)
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25) (LIO ERP pg. 56, App. A pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO 06.1 (page 47) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o G (water resource management),
o I (climate change), and/or
o J (stormwater management and pollutant source control) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3. See pages 32 and 84. 
**Whatcom
Applicable – See local context
Related strategies include:
• WHATCOM-WQ-01 (prevent problems from new development at site or subdivision scale)
• WHATCOM-WQ-05 (Fix problems caused by existing development)
• WHATCOM-WQ-06 (watershed scale stormwater manag', N'CHIN2.6', 6, N'CHIN2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (26, 1026, 110, N'CHIN 4.1 Emphasize funding support for efforts that build our understanding of ecological interacti…', N'#DB2365', N'Emphasize funding support for efforts that build our understanding of ecological interactions that likely influence how Puget Sound Chinook populations perform.
*Desired Outcome
Scope and thoroughness of assessments and research on forage fish spawning, rearing habitats and requirements increased.

Relationship between southern resident killer whale recovery and salmon recovery as prey better understood.
*Policy Needs

*Example Actions
Continue to support study of Salish Sea food web dynamics - including zooplankton monitoring, modeling and investigating Chinook predator / prey relationships.

Support Partnership work with the Puget Sound Ecosystem Monitoring Program to respond to the JLARC recommendation to improve the Sound-wide monitoring program.
*Proposal Guidance
Include impacts of climate change such as sea level rise on forage fish spawning habitat and other food web dynamics. Include tracking trends in timing and species assemblages of zooplankton, such as cold-water, lipid-rich copepods vs. warm-water, low-lipid copepods.

Tie all forage fish assessment and research work to the on-going work of the Federal Action Task Force to develop a science and monitoring program for Puget Sound.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO 3.1 (page 43) County, tribes, and MRC habitat, and salmon rearing and forage fish assessments. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org, for more information. mailto:jessica.hamill@snoco.org
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cell),
o F (native fish and shellfish populations), and/or
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1 and 3. Pages 46 and 47. 
**Whatcom
Applicable – See Local Context
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery before submitting an NTA', N'CHIN4.1', 1, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (27, 1027, 110, N'CHIN 4.10 Improve forecasting of climate change impacts on salmon.', N'#DB2365', N'Improve forecasting of climate change impacts on salmon.
*Desired Outcome
Climate change impacts on salmon better anticipated and understood.
*Policy Needs

*Example Actions
Develop and implement forecasting techniques.

Communicate forecasts to watershed groups so they can adaptively manage recovery strategies.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2; Note: Long-Term Goal Statements, instead of Short-Term Goal Statements, may be more appropriate to use when developing NTAs under this Approach.)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1, 2, and 3; See pages 46 and 47. 
**Whatcom
Applicable – See local context: 
LIO Plan Result Chain HAB02 “Salmon recovery research, monitoring, and adaptive management”. Local and regional NTA owner should contact WRIA 1 Salmon Recovery Lead Entity prior to submitting NTA.', N'CHIN4.10', 10, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (28, 1028, 110, N'CHIN 4.11 Create open and shared georeferenced database, clearinghouse, and/or roadmap of science…', N'#DB2365', N'Create open and shared georeferenced database, clearinghouse, and/or roadmap of science and monitoring data.
*Desired Outcome
Science and monitoring data related to salmon recovery easily accessible.
*Policy Needs

*Example Actions
Convene partners to develop a plan for creating a shared database, clearinghouse, and/or roadmap
*Proposal Guidance
Consider engaging PSEMP in this effort.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC and member jurisdictions
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage with HCCC and member jurisdictions to coordinate monitoring activities with existing efforts and plans 
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to local sources on Stillaguamish and Snohomish Basins websites. http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1. Pages 45 and 46. 
**Whatcom
Applicable – See local context: 
LIO Plan Result Chain HAB02 “Salmon recovery research, monitoring, and adaptive management”. Local and regional NTA owner should contact WRIA 1 Salmon Recovery Lead Entity prior to submitting NTA.', N'CHIN4.11', 11, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (29, 1029, 110, N'CHIN 4.2 Improve monitoring of pollutants (such as metals, hydrocarbons, PAHs, PBDEs) associated wi…', N'#DB2365', N'Improve monitoring of pollutants (such as metals, hydrocarbons, PAHs, PBDEs) associated with stormwater and other sources. These point or nonpoint sources need to be identified and assessed to improve our understanding of their impacts to salmon resources.
*Desired Outcome
Impact of point and nonpoint sources of pollutants on salmon resources are better understood.
*Policy Needs

*Example Actions
Eelgrass monitoring and stressor-response research to better understand causes of local declines.
*Proposal Guidance
Describe how you will communicate your results to the Management Conference.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1  Prevent pollution sources from entering Hood Canal marine and fresh waters
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants
2.1.3 Reduce impacts from stormwater runoff
2.1.3.1 Reduce impacts of stormwater runoff from transportation and service corridors, and urbanized areas
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands

Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Engage HCCC and member jurisdictions
- Engage with HCCC and member jurisdictions to coordinate monitoring activities with existing efforts and plans 
- Coordinate efforts with Hood Canal Regional Pollution Identification and Correction Program (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results
- Utilize HCCC Stormwater Retrofit Plan http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/content/pollution-identification-correction

http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context. 

Refer to SSLIO 05.1 (page 46) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o J (stormwater management and pollutant source control), and/or
o K (water quality clean up plans) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gaps 1 and 3. Page 46 and 47. 
**Whatcom
Applicable – See Local Context 
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery before submitting an NTA', N'CHIN4.2', 2, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (30, 1030, 110, N'CHIN 4.3 Support efforts that improve our knowledge of things integral to managing Chinook salmon…', N'#DB2365', N'Support efforts that improve our knowledge of things integral to managing Chinook salmon and steelhead and tracking their recovery, including co-manager (WDFW, Tribes) fish in / fish out monitoring of natal Chinook populations, habitat status and trends monitoring throughout Puget Sound, and comprehensive juvenile Chinook restoration effectiveness monitoring linked to the restoration strategies and goals in watershed recovery plans.
*Desired Outcome
An accessible habitat status and trends monitoring program informs local restoration efforts with a useful data platform.

A regional baseline inventory of common datasets necessary for analyzing habitat conditions for Chinook is established.

Habitat and
*Policy Needs

*Example Actions
Use the tribal Habitat Strategy platform.

Quantify uncertainty in adult escapement estimates through employing new survey designs or technology.

Current (2017) shoreline armoring inventory developed along freshwater and saltwater habitats across the entire region, including but not limited to docks, bulkheads, boat rails, man-made structures, etc. that are not permitted.

Conduct analyses to determine the relative survival of different life history types to improve forecasts.

Expand or complement existing monitoring programs to better estimate steelhead juvenile migrants.

Quantify uncertainty in adult escapement estimates through employing new survey designs or technology.
*Proposal Guidance
NTA proposals should coordinate with the following ongoing programs that are conducting monitoring and analyzing monitoring data:
- WDFW – Salmonid Stock Inventory (SaSI) http://wdfw.wa.gov/conservation/fisheries/sasi/ and Salmon Conservation and Reporting Engine (SCoRE) https://fortress.wa.gov/dfw/score/score/maps/map_wria.jsp
- NOAA – salmon habitat status and trends monitoring https://www.nwfsc.noaa.gov/assets/25/8391_07122017_115148_TechMemo137.pdf
- Tribes – NWIFC Salmon and Steelhead Habitat Inventory and Assessment Project (SSHIAP) https://nwifc.org/about-us/habitat/sshiap/
- Puget Sound Partnership – effectiveness monitoring http://www.psp.wa.gov/evaluating-effective-action.php

Proposals to use new survey designs or technology should have a plan for ensuring that these approaches will be consistently applied in the long-term so that data offer sufficient consistency to be incorporated into management decisions.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
- Engage HCCC and member jurisdictions http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to Snoqualmie Watershed Forum 10-Year Status Report, SSLIO 3.1 (page 43) and 10.1 & 10.2 (page 51) http://www.govlink.org/watersheds/7/status_report/2016/SnoqualmieWRIA7StatusReport_spread_format.pdf
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. Table 7. Barrier 1. See page 45. Table 8. Gap 1 and 3. See page 46 and 47. 
**Whatcom
Applicable – See Local Context
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery before submitting an NTA', N'CHIN4.3', 3, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (24, 1024, 109, N'CHIN 3.1 Develop a white paper review of all recent science and studies on pinniped predation on sa…', N'#DB2365', N'Develop a white paper review of all recent science and studies on pinniped predation on juvenile, sub-adult, and adult salmon.  Develop potential management options, and/or identify and implement necessary changes to rules and regulations to address pinniped predation.
*Desired Outcome
The effects of pinniped predation on salmon survival and recovery are better understood, and management options to reduce predation are developed and implemented.
*Policy Needs

*Example Actions
Conduct the white paper review.

Research and develop potential management options.

Work collaboratively to implement one or more management options.
*Proposal Guidance

*Local Context
**South Sound
Applicable, no additional info. 
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC staff regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study.
- Consult and identify opportunities to build off past work focused on Hood Canal marine mammals and predation on salmon, if applicable
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Not applicable 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Not Applicable 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1. Page 46. 
**Whatcom
Applicable – See local context
Related strategies include:
• WHATCOM-WQ-01 (prevent problems from new development at site or subdivision scale)
• WHATCOM-WQ-05 (Fix problems caused by existing development)
• WHATCOM-WQ-06 (watershed scale stormwater manag', N'CHIN3.1', 1, N'CHIN3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (25, 1025, 109, N'CHIN 3.2 Identify contributing factors that exacerbate predation and mortality and implement soluti…', N'#DB2365', N'Identify contributing factors that exacerbate predation and mortality and implement solutions.
*Desired Outcome
The effects of predation on salmon survival and recovery and potential management solutions are better understood.
*Policy Needs

*Example Actions
Identify contributing factors and test management actions to address predation.  Direct resources to fix known factors contributing to increased predation (such as address specific infrastructure, haul-out sites proximate to salmon populations of concern, identify adjustments to hatchery release strategies).
*Proposal Guidance
Coordinate proposals with the Salish Sea Marine Survival Project.
*Local Context
**South Sound
Applicable, no additional info. 
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC staff regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study.
- Consult and identify opportunities to build off past work focused on Hood Canal marine mammals and predation on salmon, if applicable
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage HCCC Tribal members (Skokomish, Port Gamble S’Klallam)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o F (native fish and shellfish populations), 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context: 
Ensure geographic scope encompasses impacts to Nooksack Chinook populations, if warranted.
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery before submitting an NTA', N'CHIN3.2', 2, N'CHIN3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (31, 1031, 110, N'CHIN 4.4 Invest in making better estimates so we can better manage and recover Chinook.', N'#DB2365', N'Invest in making better estimates so we can better manage and recover Chinook. 
• Invest funding and capacity to improve accuracy and precision for Chinook populations where status and trends estimates of key life stages (such as, escapement, juvenile migrants, etc.) are lacking, or highly uncertain.
• Evaluate existing watershed-scale efforts for “lessons learned” on actions that have been successful – or not successful.  Share information and conclusions with all watershed-scale efforts for adaptive management of their program implementation.
*Desired Outcome
The Adult Fish Data Exchange (AMX) is utilized to manage and share adult fish data among co-managers.

Data analyzed and interpreted to understand the response of salmon populations to habitat protection and restoration actions.
*Policy Needs

*Example Actions
The Fisher Slough project, where a collaboration between the Skagit River System Cooperative and WDFW Fish Program are conducting the analyses suggested by this approach.

Propose a project to use the AMX to make better estimates.
Evaluate effectiveness of watershed-scale actions, and report findings.
*Proposal Guidance
Describe how you will communicate the results of your project to decision-makers, to improve management of Chinook populations and/or habitat protection and restoration activities.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan.
Table 8. Gap 1 and 3. See pages 46 and 47. 
**Whatcom
Applicable – See Local Context
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery prior to submitting NTA', N'CHIN4.4', 4, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (32, 1032, 110, N'CHIN 4.5 Align recovery endpoints to Chinook biology and how recovery actions are really implemente…', N'#DB2365', N'Align recovery endpoints to Chinook biology and how recovery actions are really implemented.
*Desired Outcome
Targets of Chinook populations are aligned to all life stages linked to the recovery strategies within recovery plan chapters.
*Policy Needs

*Example Actions
Develop targets for all life stages of Chinook in a watershed.

Work with lead entity groups to incorporate these life-stage targets into their recovery strategies.
*Proposal Guidance
Describe the scientific methods you plan to use to develop targets.

Describe your plan for working with relevant lead entities.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.  

Refer to SSLIO, Table 3 (pages 12-18) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan.
Table 8. Gap 2 and 3. See page 47. 
**Whatcom
Applicable – See Local Context
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery', N'CHIN4.5', 5, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (33, 1033, 110, N'CHIN 4.6 Develop a framework to determine how salmon are responding to current habitat protection…', N'#DB2365', N'Develop a framework to determine how salmon are responding to current habitat protection, restoration, and management actions.
*Desired Outcome
Effectiveness of current salmon habitat protection and restoration projects assessed.
*Policy Needs

*Example Actions

*Proposal Guidance
Coordinate proposals with the Salmon Science Advisory Group.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.  

Refer to Sno-Stilly LIO Ecosystem Recovery Plan Chapter 7 (page 62) 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context: 
LIO Plan Result Chain HAB02 “Salmon recovery research, monitoring, and adaptive management”. Local and regional NTA owner should contact WRIA 1 Salmon Recovery Lead Entity prior to submitting NTA.', N'CHIN4.6', 6, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (35, 1035, 110, N'CHIN 4.8 Evaluate potential threats from emerging contaminants of concern from wastewater and storm…', N'#DB2365', N'Evaluate potential threats from emerging contaminants of concern from wastewater and stormwater as they relate to salmon and their food web.
*Desired Outcome
The effects of wastewater and stormwater contaminants on salmon survival and their food web are better understood.
*Policy Needs

*Example Actions
Identify and assess threats from emerging contaminants of concern.

Communicate findings to decision-makers.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25) (LIO ERP pg. 56, App. A pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
Additional guidance:
- Engage HCCC staff regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- Consult and identify opportunities to build off past work focused on Hood Canal marine mammals and predation on salmon, if applicable
- Coordinate with local Conservation Districts
- Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
- Engage HCCC and member jurisdictions to build on existing pollution control efforts, use existing data to prioritize areas
- Engage HCCC and local jurisdictions to coordinate with existing monitoring efforts (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results)
- Use strategic approach to monitoring activities, incorporating shellfish growing areas status, PIC program workplans, TMDL-listed streams, MRAs, and other priority areas
- Engage HCCC and member jurisdictions, in development of the Hood Canal Shellfish Initiative, to identify specific threats and research needs to support a sustainable Hood Canal shellfish industry
- Build on Hood Canal Dissolved Oxygen Project results
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan http://hccc.wa.gov/content/pollution-identification-correction

http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2; Note: Long-Term Goal Statements, instead of Short-Term Goal Statements, may be more appropriate to use when developing NTAs under this Approach.)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o J (stormwater management and pollutant source control), and/or
o K (water quality clean up plans). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1, 2, and 3; See pages 46 and 47. 
**Whatcom
Applicable – See local context: 
Ensure geographic scope encompasses impacts to Nooksack Chinook populations, if warranted.
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery prior to submitting NTA', N'CHIN4.8', 8, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (36, 1036, 110, N'CHIN 4.9 Incorporate traditional knowledge into science and monitoring efforts.', N'#DB2365', N'Incorporate traditional knowledge into science and monitoring efforts.
*Desired Outcome
Science and monitoring efforts for salmon recovery are informed by traditional knowledge.
*Policy Needs

*Example Actions

*Proposal Guidance
Include detail on climate change projections and associated impacts. This can include habitat loss due to sea level rise, coastal erosion, and stream temperature, among others.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC and member jurisdictions
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to climate change documents for the Stillaguamish and Snohomish Basins. Contact LIO Coordinator, Jessica Hamill, jessica.hamill@snoco.org, for more information. http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/1061/Publications

mailto:jessica.hamill@snoco.org
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2; Note: Long-Term Goal Statements, instead of Short-Term Goal Statements, may be more appropriate to use when developing NTAs under this Approach.)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 8. Gap 1, 2, and 3; See pages 46 and 47. 
**Whatcom
Applicable – See local context: 
LIO Plan Result Chain HAB02 “Salmon recovery research, monitoring, and adaptive management”. Local and regional NTA owner should contact WRIA 1 Salmon Recovery Lead Entity prior to submitting NTA.', N'CHIN4.9', 9, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (37, 1037, 111, N'CHIN 5.1 Assess risk of climate change to salmon recovery and share assessment(s) and analysis with…', N'#DB2365', N'Assess risk of climate change to salmon recovery and share assessment(s) and analysis with watersheds to incorporate into planning processes.
*Desired Outcome
Better information on climate and natural disaster risk available.
*Policy Needs

*Example Actions
Use climate change projections to strengthen identification of salmon populations at high risk from climate change impacts.

Develop a clearinghouse for all applicable climate change information and recommendations.

Create a framework or vision for how to incorporate climate change considerations into planning processes.
*Proposal Guidance
Consider partnerships that bundle data analysis with an application or implementation effort.

Ensure the information needs of target audience is defined.

Ensure that there is an understanding of local watershed planning processes.

Utilize information and guidance from Washington Sea Grant’s regional coastal resilience project (slated to be completed by June 2018).
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions
- Identify opportunities to integrate with Hood Canal salmon recovery plans
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/content/salmon-recovery-planning

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, no additional info. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context: Refer to WRIA 7 Climate Impacts white paper https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4664
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 8. Gap 1. Page 46. 
**Whatcom
Applicable – See local context: 
Relevant Whatcom LIO Strategies may include:
• WHATCOM-CROSS-08 (Climate change assessment and adaptation)
• Pilot plan for incorporating climate change in salmon restoration exists for South Fork watershed and is underway', N'CHIN5.1', 1, N'CHIN5')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (34, 1034, 110, N'CHIN 4.7 Develop a better understanding of the causes of poor marine survival of steelhead (and Chi…', N'#DB2365', N'Develop a better understanding of the causes of poor marine survival of steelhead (and Chinook and other species) in Puget Sound through support of the Salish Sea Marine Survival Project’s research program. https://lltk.org/project/salish-sea-marine-survival-project/
*Desired Outcome
Political, technical, and financial support is provided to partners as they translate research results into management and recovery actions.
*Policy Needs

*Example Actions
Conduct research and monitoring, and analyze results.

Support translation of findings into management actions
*Proposal Guidance
Coordinate proposals with the Salish Sea Marine Survival Project.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- Engage HCCC staff and partners regarding work in progress and being considered as part of the Hood Canal Bridge Impacts Assessment study
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Not applicable. 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context: 
Ensure geographic scope encompasses impacts to Nooksack Chinook populations, if warranted.
Local and regional NTA owners should work with co-managers and WRIA 1 Lead Entity for Salmon Recovery prior to submitting NTA', N'CHIN4.7', 7, N'CHIN4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (38, 1038, 111, N'CHIN 5.2 Integrate climate change adaptation framework to salmon habitat restoration plans in Puget…', N'#DB2365', N'Integrate climate change adaptation framework to salmon habitat restoration plans in Puget Sound.
*Desired Outcome
Climate change adaptation considerations incorporated into salmon habitat restoration plans.
*Policy Needs

*Example Actions
Develop or use an existing climate change adaptation framework to strengthen salmon habitat restoration plans in the face of changing climate conditions.
*Proposal Guidance
Consider using or adapting Tim Beechie’s paper, “Restoring Habitat for a Changing Climate.”
https://www.researchgate.net/profile/Alisa_Wade/publication/232659646_Restoring_salmon_in_a_changing_climate/links/09e415089552dac38f000000.pdf
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to SSLIO Strategy 3.1 (Page 43) and local sources on Stillaguamish and Snohomish Basins websites. http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 8. Gap 1 and 3. Page 46 and 47. 
**Whatcom
Applicable - See local context: 
Relevant Whatcom LIO Strategies may include:
• WHATCOM-CROSS-08 (Climate change assessment and adaptation)
• Pilot plan for incorporating climate change in salmon restoration exists for South Fork watershed and is underway', N'CHIN5.2', 2, N'CHIN5')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (39, 1039, 111, N'CHIN 5.3 Integrate climate change guidance when reviewing and evaluating project proposals for rest…', N'#DB2365', N'Integrate climate change guidance when reviewing and evaluating project proposals for restoration projects.
*Desired Outcome
Climate impacts are considered and incorporated into the design and implementation of salmon habitat restoration projects.
*Policy Needs

*Example Actions
Use the framework described in “Chinook Salmon Projects and Climate Change” to (1) take both short-term and long-term salmon habitat protection and restoration project effectiveness into account in light of climate change projections, (2) identify salmon habitat protection and restoration projects that address emerging climate-related risks and encourage changes to Chinook salmon recovery plans (where appropriate), and (3) develop salmon habitat protection and restoration projects with explicit consideration of how climate may affect projects over time.

Local watersheds develop formal evaluation criteria to ensure that the project proposal sufficiently identifies and considers how climate change will affect the project, the project design adequately addresses the primary climate change concerns that have the potential to decrease the effectiveness of the project, and the project is designed to be flexible and can be modified over time as conditions change.
*Proposal Guidance
Reference the Puget Sound Partnership’s guidance on Chinook salmon projects and climate change.

Describe how you will share this approach with the Salmon Recovery Council and Salmon Recovery Funding Board.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to local sources on Stillaguamish and Snohomish Basins websites. http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 8. Gap 1 and 3. Page 46 and 47. 
**Whatcom
Applicable – See local context: 
Relevant Whatcom LIO Strategies may include:
• WHATCOM-CROSS-08 (Climate change assessment and adaptation)
• Pilot plan for incorporating climate change in salmon restoration exists for South Fork watershed and is underway', N'CHIN5.3', 3, N'CHIN5')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (40, 1040, 112, N'CHIN 6.1 Assess and implement preventative and proactive measures to reduce risk of vessel collisio…', N'#DB2365', N'Assess and implement additional preventative and proactive measures to reduce the risk of vessel collision and grounding.
*Desired Outcome
The risk of a large oil spill is further reduced.
*Policy Needs

*Example Actions
Develop guidance on how local communities can plan for post-spill response.

Develop a Geographic Response Plan to align regional and local spill response efforts.

Identify programs and incorporate salmon recovery needs into spill prevention and response measures.
*Proposal Guidance
Reference and crosswalk local plans and measures and how they deal differently with spill response.

Coordinate, as appropriate, with relevant state, federal, and international partners.

Describe how you will coordinate with the local lead entity and LIO.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to Snohomish MRC website. http://www.snocomrc.org/
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o L (oil spills); and/or
o M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 20.2. See pages 30 and 84. 
**Whatcom
Applicable – See local context: 
Relevant Whatcom LIO Strategies may include: 
• WHATCOM-CROSS-10
• WHATCOM-WQ-03 (prevent and reduce the risk of petroleum oil spills) 
• WHATCOM-WQ-08 (Improve petroleum oil spill response planning, capacity)
Local and re', N'CHIN6.1', 1, N'CHIN6')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (41, 1041, 112, N'CHIN 6.2 Strengthen local oil spill preparedness and response plans; integrate with Federal, State…', N'#DB2365', N'Strengthen local oil spill preparedness and response plans; integrate with Federal, State, and tribal programs and planning; and allocate resources.
*Desired Outcome
Response readiness is improved, capacity is increased, and response time is decreased.
*Policy Needs

*Example Actions
Assess spill risks to help local watersheds prioritize their activities, funding, and planning.

Align financial resources and tools with needed outcomes for spill preparedness and response.
*Proposal Guidance
Describe how the NTA will be integrated into the regional oil spill landscape and coordinated with relevant state and federal partners.

Describe how you will coordinate with the local lead entity and LIO.

Consider latest research findings on spill impact and how those could inform local oil spill preparedness and response plans.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context: Refer to SSLIO 01.1 & 01.2 (page 40) and NTA 2016-0315 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o L (oil spills); and/or
o M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 20.2. See pages 30 and 84. 
**Whatcom
Applicable – See local context: 
Relevant Whatcom LIO Strategies may include:
• WHATCOM-CROSS-10, WHATCOM-WQ-03 (prevent and reduce the risk of petroleum oil spills),  
• WHATCOM-WQ-08 (Improve petroleum oil spill response planning, capacity)
Local and re', N'CHIN6.2', 2, N'CHIN6')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (42, 1042, 113, N'CHIN 7.1 Protect and/or restore critical habitat for salmon populations.', N'#DB2365', N'Protect and/or restore critical habitat for salmon populations.
*Desired Outcome
Habitats critical to salmon life history types prioritized for protection and restoration actions to maintain/regain key habitat functions for salmon (such as juvenile rearing habitat, predation refuge, etc.).
*Policy Needs

*Example Actions
Remove or set back barriers to pocket estuary function (such as roads, levies, etc.) 

Work with landowners to allow estuarine connectivity during key timeframes when salmon rely on the pocket estuaries.

Purchase properties that allow for permanent restoration and protection of habitat and connectivity.

Remove culverts and maintain improved streamflow functions

Develop a framework to identify key, highest priority salmon habitats to protect in Puget Sound (see CHIN1.3).
*Proposal Guidance
Cite scientific studies (for example: Fresh 2006 (http://www.pugetsoundnearshore.org/technical_papers/pacjuv_salmon.pdf), Fresh 2011 (http://www.pugetsoundnearshore.org/technical_papers/implications_of_observed_ns_change.pdf), and Cereghino 2012 (http://www.pugetsoundnearshore.org/technical_papers/psnerp_strategies_maps.pdf) coastal inlets chapter) and planning documents that prioritize the proposed site, sequencing, and the proposed methodology related to salmon recovery goals/targets. Demonstrate that key partners (LIOs, LEs/salmon recovery groups, CDs, etc.) have been engaged in the prioritization process.

There is a continued need to disconnect water runoff from all live waters per WAC 222-24. Priority could be given to culverts that are lower down in the watershed that, if removed, would allow fish to access the most and best functioning habitat within the region.
*Local Context
**South Sound
Applicable, see local context. South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2 Protect and restore priority estuarine salmonid habitat
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.2.1.1 Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine habitats)
1.2.2 Prioritize and sequence salmon recovery actions across Hood Canal watersheds (estuarine habitats)
1.2.3 Implement priority salmon recovery projects (estuarine habitats) 
1.3 Protect and restore priority nearshore and marine salmonid habitat
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
1.3.1.1 Fill information and data gaps identified to inform salmon recovery in Hood Canal (nearshore and marine habitats)
1.3.2 Prioritize and sequence salmon recovery actions across Hood Canal watersheds (nearshore and marine habitats)
1.3.3 Implement priority salmon recovery projects (nearshore and marine habitats)
3.2 Protect and restore priority freshwater salmonid habitat
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
3.2.1.1 Fill information and data gaps identified to inform salmon recovery in Hood Canal (freshwater habitats)
3.2.2 Prioritize and sequence salmon recovery actions across Hood Canal watersheds (freshwater habitats)
3.2.3 Implement priority salmon recovery projects (freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context: Refer to Stillaguamish and Snohomish Lead Entity 4-Year Work Plans and Salmon Recovery Plans, SSLIO 10.1 & 10.2 (page 51). 
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o E (fish passage and excess sediment),
o F (native fish and shellfish populations),
o G (water resource management),
o H (shoreline and land use)
o I (climate change),
o J (stormwater management and pollutant source control), and/or
o M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 2.2 and 17.2. See pages 30, 32, 83 and 89. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with  WRIA 1 Lead Entity prior to submitting NTA', N'CHIN7.1', 1, N'CHIN7')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (43, 1043, 114, N'CHIN 8.1 Update the Puget Sound Salmon Recovery Plan chapters and steelhead plan chapters.', N'#DB2365', N'Update the Puget Sound Salmon Recovery Plan chapters and steelhead plan chapters.
*Desired Outcome
Salmon recovery plans evaluated, updated and revised, and utilized.
*Policy Needs

*Example Actions
Work with Partnership to update local Puget Sound Salmon Recovery Plan chapters.

Work with Partnership, Long Live the Kings, and NOAA to develop and implement a Puget Sound steelhead recovery plan.
*Proposal Guidance
Demonstrate that the project is on the relevant Lead Entity’s four-year work plan.

Refer to the WRIA 8 Chinook Salmon Conservation Plan Update for an example. http://www.govlink.org/watersheds/8/planning/chinook-conservation-plan.aspx

Discuss how you will coordinate with the Salmon Recovery Council.
*Local Context
**South Sound
Applicable, see local context.
South Sound Strategy pp 110-113 and local salmon recovery plans referenced therein. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1  Adaptively manage salmon recovery plans for Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
1.2.1.1, 1.3.1.1, 3.2.1.1. Fill information and data gaps identified to inform salmon recovery in Hood Canal (estuarine, nearshore and marine, freshwater habitats)
Additional guidance:
- Engage HCCC salmon recovery staff to coordinate work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
- See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 13, 14, 18 – Table 3, 27, and 28.
WRIA 6 Salmon Recovery Plan. 
**San Juan
Applicable, see local context. Please refer to the LIO Recovery Plan and contact LIO coordinator with questions 
**Snohomish/Stillaguamish
Applicable, see local context.

Refer to Stillaguamish Chinook Monitoring and Adaptive Management and 
Snohomish River Basin Salmon Conservation Plan http://www.stillaguamishwatershed.org/subpages/Documents_SWC.html

https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/2153
**SouthCentral
South Central: Applicable, see local context. 
• No local Chinook-specific goals developed yet, but see Table 3 (pg. 21) of South Central Ecosystem Recovery Plan for general background context.
• Also see goals and context for the following Vital Signs. The South Central LIO’s goals related to these Vital Signs include, but are not limited to, those listed in Table 3 of the South Central Ecosystem Recovery Plan: 
o Shoreline Armoring (pg. 25-26)
o Floodplains (pg. 22)
o Land Development & Cover (pg. 23-24)
o Summer Stream Flows (pg. 26)
o Freshwater Quality (pg. 22-23)
• In WRIA 10, support establishment of community forests. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
• Chinook Short-Term Goal Statements (see Table 2)
• Gaps and/or Barriers (see Table 5)
• Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
o A (drift cells),
o B (estuaries),
o C (Floodplains),
o D (riparian and instream habitat),
o E (fish passage and excess sediment),
o F (native fish and shellfish populations),
o G (water resource management),
o H (shoreline and land use)
o I (climate change),
o J (stormwater management and pollutant source control), and/or
o M (education). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See local context
Local and regional NTA owners coordinate with  WRIA 1 Lead Entity prior to submitting NTA', N'CHIN8.1', 1, N'CHIN8')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (44, 1044, 115, N'EST 1.1 Gain a better understanding of current habitat conditions.', N'#8228BF', N'Gain a better understanding of current habitat conditions.
*Desired Outcome
Based on enhanced understanding of estuarine processes and function, restoration efforts are directed to areas that will have the most ecological benefit.
*Policy Needs

*Example Actions
• Conduct delta system scale analyses of habitat function and resilience
*Proposal Guidance
• Note, “ecologically important areas” is a generic term that, once defined, can support restoration or protection prioritization. I may include salmon habitat. 
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe the datasets, protocols, and analyses that will be used
• Describe how this research will improve restoration planning and site design.
• If new sampling/surveys are proposed, describe how new data collection will build upon and enhance existing data and will be used to improve decision-making.
• Consider applying ESRP Learning Program RFP guidance and criteria in developing your project and metrics of success (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
Additional guidance:
– Engage HCCC and member jurisdictions
– Identify opportunities to integrate with Hood Canal salmon recovery plans
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library) 
**Island
Not Applicable 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. Refer to LIO Ecosystem Recovery Plan. In addition to adopted elements of recovery plans dealing with estuaries, there are several studies specific to the Snohomish and Stillaguamish basin that guide actions that are most likely to benefit estuaries. Examples includes studies that address how hydrodynamics and sediment support estuary vegetation and how estuary vegetation supports invertebrates, birds and fish. (i.e. http://www.stillaguamishwatershed.org/subpages/Limiting%20Factor%20Resources/Estuary%20Resources/Estuary%20Resources.html) https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86
Table 8. Gap 1 and 2. Pages 46 and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST1.1', 1, N'EST1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (45, 1045, 115, N'EST 1.2 Gain understanding of the social, economic and political factors currently affecting habitat', N'#8228BF', N'Gain a better understanding of the social, economic, and political factors currently affecting habitat.
*Desired Outcome
Enhanced understanding of regulations and social context improves multi-benefit, landscape-scale restoration planning to yield the most ecological benefit.
*Policy Needs

*Example Actions
• Identify lands that are at risk for conversion to non-agricultural uses.
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe how you will coordinate with partners conducting ongoing work.
• Describe how this project will improve restoration planning and site design.
• If new sampling/surveys are proposed, describe how additional data collection will be used to improve decision-making.

*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to University of Washington Climate Impacts Groups Climate Change, Sea Level Rise, and Flooding in the Lower Snohomish River Basin (https://cig.uw.edu/publications/climate-change-sea-level-rise-and-flooding-in-the-lower-snohomish-river-basin/) -reach scale estuary plans in development https://cig.uw.edu/publications/climate-change-sea-level-rise-and-flooding-in-the-lower-snohomish-river-basin/
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries), and/or
• H (shoreline and land use). 
**West Central
Applicable, no additional info. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST1.2', 2, N'EST1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (46, 1046, 115, N'EST 1.3 Gain better understanding of how habitat may change due to pressures like climate change…', N'#8228BF', N'Gain a better understanding of how habitat may change in the future due to pressures like climate change and population growth.
*Desired Outcome
Improved understanding of how estuarine processes respond to climate change enables resilient estuary restoration.
*Policy Needs

*Example Actions
• Map and model salt water intrusion in context of climate change.
• Map and model sediment deposition in the context of climate change.
• Develop a delta-wide interactive geospatial platform for each large agricultural river delta.
• Assess the effect of projected climate change on freshwater and sea water mixing, stratification and residence time
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe the datasets, protocols, and analyses that will be used.
• Describe how you will leverage ongoing projects.
• Describe how this research will improve restoration planning and site design
• Describe how additional data collection will be used to improve decision-making, if new sampling/surveys are proposed.
• Consider applying ESRP Learning Program RFP guidance and criteria in developing your project and metrics of success (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries.  South Sound strategy pp 60-69 maps large and small priority estuaries.
 http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)

Additional guidance:
– Engage HCCC and member jurisdictions
– Identify opportunities to integrate with Hood Canal salmon recovery plans
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library) http://hccc.wa.gov/content/salmon-recovery-planning
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan SSLIO 02.1 (page 42), SSLIO 10.1 and 10.2 (page 51) -refer to WRIA 7 Climate Change white paper, - NTA 2016-0075 and NTA 2016-0074 support this work -refer to other 2016 NTAs mapped to strategies 02.1, 10.1 and 10.2. - Snohomish County Climate Impacts Decision Support Tool --Refer to King County Climate Action Plan, the Stillaguamish Tribe Natural Resources Climate Adaptation Plan, and the Tulalip Tribe Climate Adaptation Plan and Climate Change Impacts on Tribal Resources (http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf). -USGS Coastal Resilience Research for Coordinated Investment (http://www.stillaguamishwatershed.org/subpages/Documents_sci_other.html) -Snohomish Basin Protection Plan https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/DocumentCenter/View/41032

http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf

http://www.stillaguamishwatershed.org/subpages/Documents_sci_other.html

https://snohomishcountywa.gov/ArchiveCenter/ViewFile/Item/4402
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context.
• Floodplains by Design work group & Lead Entity for Clear Creek Project will help inform this data gap in WRIA 10.
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries).
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 17.2 and 1.1. See pages 31, 32, 86 and 89. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies may  include:
• Climate change assessment and adaptation (WHATCOM-CROSS-08)
• City of Bellingham may have completed studies on climate resiliency planning and/or climate changes.  Contact Clare  Fogelsong, City of Bellingham
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST1.3', 3, N'EST1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (47, 1047, 115, N'EST 1.4 Gain understanding of future social, economic, and political factors affecting habitat…', N'#8228BF', N'Gain a better understanding of future social, economic, and political factors (such as population growth) that will affect habitat.
*Desired Outcome
Improved understanding of future flood, salt water intrusion, and sea level rise risks for estuarine stakeholders enables improved multi-benefit, landscape-scale estuary restoration planning to yield the most ecological benefit.
*Policy Needs

*Example Actions
• Evaluate flood and drainage effects of delta landscape management alternatives under future climate conditions.
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe the datasets, protocols, and analyses that will be used.
• Describe how you will leverage ongoing projects.
• Describe how this research will improve restoration planning and site design
• Consider applying ESRP Learning Program RFP guidance and criteria in developing your project and metrics of success (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries.  South Sound strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to University of Washington Climate Impacts Groups Climate Change, Sea Level Rise, and Flooding in the Lower Snohomish River Basin (https://cig.uw.edu/publications/climate-change-sea-level-rise-and-flooding-in-the-lower-snohomish-river-basin/) -reach scale estuary plans in development 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries).
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86 
**Whatcom
Applicable – See Local Context
• Climate change assessment and adaptation (WHATCOM-CROSS-08)
• City of Bellingham may have completed studies on climate resiliency planning and/or climate changes.  Contact Clare  Fogelsong, City of Bellingham
• A floodplain management planning effort (WHATCOM-STRAT-HAB03) has been initiated.  Contact is Paula Harris, Whatcom County Public Works, River and Flood Division.
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST1.4', 4, N'EST1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (50, 1050, 116, N'EST 2.2 Address barriers to improve implementation plans, policies, and regulations.', N'#8228BF', N'Address barriers to improve implementation plans, policies, and regulations
*Desired Outcome
Addressing regulatory and funding barriers enables more efficient and nimble restoration actions.
*Policy Needs

*Example Actions
• Develop mechanisms to improve the efficiency of the project permitting process for restoration.
• Develop mechanisms to increase flexibility of acquisition approaches.
• Develop new and/or revise existing funding streams to support multi-benefit projects rather than single benefit outcomes.
• Develop payments for ecosystem services programs targeting estuary acreage and function.
• Create a funding pool and mechanism to value conversion of private property to functional estuary habitat.
*Proposal Guidance
• Describe the regulatory processes that will be discussed and proposed as opportunities for alignment or efficiencies.
• Describe how your project will build upon existing efforts. 
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. Agriculture does not occur in the largest estuaries in the South Sound but does/could in smaller estuaries.
 http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach E01-06
– Engage HCCC and member jurisdictions
– Engage existing FPbD partners 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan Strategy 03.1 Improve Funding for Restoration which advocates an integrated approach to funding for large capital restoration projects. -refer to Regulatory Inefficiency and Regulatory Inconsistency in gaps and barriers Table 6. -refer to Sustainable Lands Strategy -see Snohomish and King County Farmland Preservation program, Purchase and Transfer of Development Right programs -Refer to PCC Farmland Trust conversion analyses. -Refer to LIO Plan SSLIO 10.1 and 10.2 (page 51), SSLIO 03.1 (page 43), Political Will/Support as a needed resource in gaps and barriers Table 7, Lack of Policymaker Engagement as a barrier in Table 6, NTA 2016-0133 directly supports this work. -refer to other 2016 NTAs mapped to LIO strategies 10.1 and 10.2. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries).
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST2.2', 2, N'EST2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (51, 1051, 117, N'EST 3.1 Develop and implement outreach, education, and/or incentive programs.', N'#8228BF', N'Develop and implement outreach, education, and/or incentive programs
*Desired Outcome
Ongoing communication and engagement with the public and key decision makers about the implementation of estuary restoration plans and projects leads to increased support for estuary restoration efforts.
*Policy Needs

*Example Actions
• Develop and deliver communications on the specifics of how restoration actions will affect local infrastructure and operations.
• Develop and implement local education and outreach on restoration plans and prioritization.
• Develop and implement a social marketing campaign/incentive program to influence land owners to move climate- and salinity-vulnerable land out of production.
*Proposal Guidance
• Describe how your project determines and defines the information needs of the target audience. 
• Describe how your project will leverage existing programs.
• Describe how effectiveness of the project will be measured.
• Consider using future projections (such as climate change or development projections) to build support among the public, communities, and decision makers.
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2.1 Develop incentives for landowners to protect shoreline habitats
1.1.1.4 Outreach and education to political leaders
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
Additional guidance:
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC and member jurisdictions 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to outreach and education pathways of LIO Plan strategies SSLIO 02.1 (page 42), 10.1 and 10.2 (page 51) - increase capacity of local Marine Resources Committee’s for outreach work in/around estuaries https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries);
• H (shoreline and land use); 
• I (climate change); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 26.3 and 26.5. See pages 31, 32, and 83, 86, 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST3.1', 1, N'EST3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (52, 1052, 117, N'EST 3.2 Implement plans and priorities to protect habitat.', N'#8228BF', N'Implement plans and priorities to protect habitat
*Desired Outcome
Protection of prioritized sites maintains tidal inundation as well as estuarine processes and functions or enables future restoration.
*Policy Needs

*Example Actions
• Preserve farmland from development in select locations without precluding restoration opportunities in the future.
• Implement best management practices at ports and marine industries
*Proposal Guidance
• Describe the plans being used to select and prioritize the project.
• Describe how the proposed actions will restore ecological processes or support future process-based restoration actions.
• Describe projected climate change impacts to and resilience of the site.
• If working in ports and marinas, describe the guidance used to implement best management practices.
• Consider applying ESRP RFP proposal guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach E01-06
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Not Applicable 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan SSLIO 08.1 (page 49) - refer to NTA 2016-0391 which supports this work -see the Acquisition Strategy of the Stillaguamish Chinook Recovery Plan (http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf) -see Snohomish Basin Protection Plan -refer to estuary reach scale plan in development https://snohomishcountywa.gov/DocumentCenter/View/44939

http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries);
• H (shoreline and land use); and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 4.2, 1.1, and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST3.2', 2, N'EST3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (53, 1053, 117, N'EST 3.3 Implement plans and priorities to restore habitat.', N'#8228BF', N'Implement plans and priorities to restore habitat
*Desired Outcome
Restoration on prioritized sites restores tidal inundation and estuarine processes to improve estuarine function.
*Policy Needs

*Example Actions
• Implement project phases including site feasibility, site design, and construction to restore tidal inundation and improve the ability of key physical processes to deliver improved structure and function of the estuary.
• Acquire land for restoration projects.
• Remove function-limiting infrastructure from estuaries.
• Develop reciprocal consultation agreements between farmland protection programs and restoration programs to ensure that funding and activities do not inhibit one another.
• Develop conservation easements for restoration that makes restored estuary habitat a valuable asset for land owners. 
• Implement best management practices at ports and marine industries.
*Proposal Guidance
• Describe the plans being used to select and prioritize the project.
• Describe how the proposed actions will restore ecological processes. 
• Describe how climate change impacts to and resilience of the site are addressed by the design.
• Describe how your project will use available guidance on site assessment, design, and implementation.
• Proponents are encouraged to include the Approach: Collect and analyze data to adaptively manage recovery practices in their proposal. If monitoring is not appropriate for the proposed project, please explain.
• Consider applying ESRP RFP proposal guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. Implementation of restoration projects for estuaries is a priority for AHSS. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31) 
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)

Additional guidance:
– Demonstrate outcomes of Regional Priority Approach E01-06
– Engage HCCC salmon recovery staff to to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 10.1 and 10.2 (page 51), -refer to NTAs mapped to the LIO strategies -see estuary targets in the Snohomish River Basin Salmon Conservation Plan (https://snohomishcountywa.gov/1061/Publications) and Stillaguamish Watershed Chinook Salmon Recovery Plan (also included in Table 3, page 13 of the LIO Plan) - the Acquisition Strategy of the Stillaguamish Chinook Recovery Plan (http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf) -see Sustainable Lands Strategy/Fish Farm and Flood planning processes https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/1061/Publications

http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries);
• H (shoreline and land use); and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 17.2. See pages 32 and 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST3.3', 3, N'EST3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (54, 1054, 117, N'EST 3.4 Collect and analyze data to adaptively manage recovery practices.', N'#8228BF', N'Collect and analyze data to adaptively manage recovery practices
*Desired Outcome
Monitoring of the multi-benefit outcomes of estuary restoration leads to improved long-term stewardship and adaptive management of plans and practices to produce better ecosystem and human outcomes.
*Policy Needs

*Example Actions
• Monitor and evaluate effectiveness (ecological, social, and economic) of restoration projects at the site and landscape scale.
• Monitor eelgrass response to tidal wetland restoration projects and other stressors to evaluate effects of estuary restoration on eelgrass recovery.
• Evaluate habitat response and restoration outcomes to specific design approaches to improve critical design decisions and cost assessments for levee removal.
• Conduct research to improve technical guidance and design decisions of estuary restoration.
*Proposal Guidance
• Describe how ecological, economic, and social outcome metrics will be developed and measured. Consider adopting approaches and metrics used in other efforts, such as the Fisher Slough monitoring methodology (TNC, 2010).
• Describe how monitoring will evaluate effectiveness at the site and landscape scale. Consider partnerships that will ensure long-term continuity of monitoring.
• Describe how data will be used to modify management decisions and design approaches. Consider partnerships that engage end-users throughout the study.
• Consider applying ESRP Learning Program RFP guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_Learning_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
Additional guidance:
– Engage HCCC staff to identify existing monitoring recommendation in place, current metrics used in HCCC Salmon Recovery Implementation Monitoring Geodatabase and Habitat Work Schedule, and other ecosystem indicators (consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals)
– Integrate Hood Canal human wellbeing indicators in project monitoring (see Developing Human Wellbeing Indicator for the Hood Canal Watershed report, and Measuring Human Wellbeing Indicator for Hood Canal report) http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://ourhoodcanal.org/content/human-wellbeing

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood Canal HWB Indicators_October 2013_
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 Table 3, 27, 28 and 65. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 10.1 and 10.2 (page 51-52) -Lead Entity M&AM plans and applicable watershed status reports -Marine Resources Committee monitoring efforts -see several monitoring programs in the LIO (i.e. Snohomish County’s Integrated Monitoring effort) https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries); and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1 and 2. Pages 45, 46, and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST3.4', 4, N'EST3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (55, 1055, 118, N'FP 1.1 Gain a better understanding of current habitat conditions.', N'#8228BF', N'Gain a better understanding of current habitat conditions.
*Desired Outcome
Based on enhanced understanding of floodplain processes and function, reach scale planning prioritizes protecting and/or restoring ecologically important areas in floodplains.
*Policy Needs

*Example Actions
• Identify important local hydrological and geomorphological processes and supporting areas. 
• Identify reaches to prioritize further study and assess for high impact ecological value where work can occur.
• Develop a shared definition of “ecologically important areas” as it relates to floodplain function.
*Proposal Guidance
• Note, “ecologically important areas” is a generic term that, once defined, can support restoration or protection prioritization. It may include critical areas, side-channel habitat, etc. 
• Describe the datasets and protocols that will be used.
• Consider engaging with the Department of Ecology and the Puget Sound Partnership to delineate tiers of degradation within a shared dataset.
• Describe how additional data collection will be used to improve decision-making. 
• Describe how your project will identify interpretations and/or apply definitions of floodplains and/or ecologically important lands. Consider including existing definitions (for land designation: channel migration and off-channel habitat in DNR Forest Practices on forest land or channel migration zones in Ecology definition for non-forest lands, Ecology''s wetland definition and typing system, and 2015 NAIP or LIDAR data) and multiple partners (such as local government).
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.2 Protect and restore priority freshwater salmonid habitat
3.2.1 Adaptively manage salmon recovery plans for Hood Canal watersheds (freshwater habitats)

Additional guidance:
– Engage HCCC staff
– Identify opportunities to integrate with Hood Canal salmon recovery plans
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Utilize HCCC Protected Lands GIS tool, if applicable http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Not Applicable 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Floodplains as a priority Vital Sign due to the limited presence of floodplains) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 02.1 Integrated Planning follows enable, design, and implement approach. -Landowner outreach a critical component. -Refer to approved hydrologic and geomorphology studies done in the Snoqualmie, Stillaguamish, and Snohomish basins (i.e. Stillaguamish Temperature TMDL Adaptive Assessment and Implementation Project and related planning documents (https://snohomishcountywa.gov/Archive.aspx?AMID=73).) -Refer to Ecosystem Services Evaluations in the Snohomish Basin (The Whole Economy of the Snohomish Basin: The Essential Economics of Ecosystem Services-Earth Economics 2010). -Also reference local Critical Area Regulations Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat), and other approved planning documents that identify ecologically important lands (i.e. Shoreline Master Programs, Comprehensive Plans, and the Snohomish Basin Protection Plan). https://snohomishcountywa.gov/Archive.aspx?AMID=73

https://snohomishcountywa.gov/807/Aquatic-Habitat
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• In WRIA10: Biodiversity Management Areas that are in floodplains, such as the Lower White River BMA Stewardship Plan. https://www.co.pierce.wa.us/documentcenter/view/3928
• WRIA 10 PRWC plans to write an Ecosystem Recovery Plan.
• See also Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy.  
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – Relevant Whatcom LIO Strategies may include: 
• WHATCOM-STRAT-HAB03 (Develop integrated floodplain management plan)
• WHATCOM-RC-CROSS02 (Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues)
• WHATCOM-STRAT-CROSS04 (Develop and implement watershed-scale plans)
A floodplain management planning effort (WHATCOM-STRAT-HAB03) has been initiated including technical assessments.  Contact is Paula Harris, Whatcom County Public Works, River and Flood Division.
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP1.1', 1, N'FP1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (56, 1056, 118, N'FP 1.2 Gain understanding of the social, economic and political factors currently affecting habitat…', N'#8228BF', N'Gain a better understanding of the social, economic, and political factors currently affecting habitat.
*Desired Outcome
Enhanced understanding of regulations, land use, flood-risk and associated costs improves multi-benefit floodplain planning for protection and restoration.
*Policy Needs

*Example Actions
• Verify and map existing land use designations in the floodplain.
• Investigate the role of local, state, and federal standards on the incentives and regulations in floodplain development.
• Investigate the long-term cost of disaster response and levee repairs. 
• Understand the role of and barriers to implementation of the FEMA National Flood Insurance Program, Clean Water Act Section 404, levee standards, Shoreline Management Act, and Growth Management Act on floodplain management.
• Identify opportunities to improve stringency, efficiency, and effectiveness of regional permitting processes in floodplains.
• Develop cost subsidy analyses that show the cost of developing in a floodplain.
*Proposal Guidance
• If focusing on regulation, describe the process you will use to identify opportunities for alignment or efficiencies of existing plans, permitting processes, or regulations.
• Describe how data collection will be used to improve decision-making.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 02.1 Integrated Planning (follows enable, design, and implement approach). Map overlays should build off existing efforts (i.e. Snohomish County Planning and Development Services iGallery: (http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default) -Refer to Snohomish County Agriculture Resilience Plan (Draft) – Snohomish Conservation District (http://snohomishcd.org/ag-resilience). -Encourage use of new data to supplement outdated information. http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default

http://snohomishcd.org/ag-resilience
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• In WRIA10:  Projects such as Floodplains for the Future—Puyallup, White, & Carbon Rivers, enable adequate levy setbacks and can serve as successful models for improving floodplain health while also improving flood safety. https://www.co.pierce.wa.us/4684/Floodplains-for-the-Future  
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. 
Table 8. Gap 1 and 2. Pages 46 and 47. 
**Whatcom
Applicable – See Local Context
• WHATCOM-STRAT-HAB03 (Develop integrated floodplain management plan). An integrated floodplain management planning effort has been initiated including technical assessments.  Contact is Paula Harris, Whatcom County Public Works, River and Flood Division.
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP1.2', 2, N'FP1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (57, 1057, 118, N'FP 1.3 Gain better understanding of how habitat may change due to pressures like climate change…', N'#8228BF', N'Gain a better understanding of how habitat may change in the future due to pressures like climate change and population growth.
*Desired Outcome
Improved understanding of how floodplain processes responses to climate change enable resilient floodplain protection and restoration.
*Policy Needs

*Example Actions
• Map and model hydrologic changes in the context of climate change (peak and low flows). 
• Map and model sediment movement and channel formation changes in the context of climate change.
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe how this research will improve protection and restoration planning and site design.
• Describe the datasets, protocols, and analyses that will be used.
• Describe how you will leverage ongoing projects.
• Describe how additional data collection will be used to improve decision-making, if new sampling/surveys are proposed. 
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
– Engage HCCC and member jurisdictions
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29 and 60-Table 10 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to WRIA 7 Climate Change white paper, -NTA 2016-0075, NTA 2016-0074 support this work -SSLIO 02.1 Integrated Planning (page 42), -Refer to Snohomish County Climate Change Adaptation Planning Tool, King County Climate Action Plan, the Stillaguamish Tribe Natural Resources Climate Adaptation Plan, and the Tulalip Tribe Climate Adaptation Plan and Climate Change Impacts on Tribal Resources (http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf). -Refer to Snohomish County Agriculture Resilience Plan (Draft) – Snohomish Conservation District (http://snohomishcd.org/ag-resilience). https://snohomishcountywa.gov/DocumentCenter/View/41032

http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf

http://snohomishcd.org/ag-resilience
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 1.1. See pages 31 and 86. 
**Whatcom
Applicable – Relevant Whatcom LIO Strategies may include: 
• WHATCOM-STRAT-CROSS08 (Climate change assessment and adaptation)
• WWU has completed detailed hydrologic modeling in the Nooksack Basin. Contact is Prof. Bob Mitchell, WWU.
• There is a need for better estimates of peak flows under future climate scenarios. 
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP1.3', 3, N'FP1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (74, 1074, 124, N'LDC 3.1 Develop and implement outreach, education, and/or incentive programs.', N'#8228BF', N'Develop and implement outreach, education, and/or incentive programs
*Desired Outcome
Improved education (on locations, pressures, and protection options) and incentives for the public and decision-makers direct growth away from ecologically important areas and enable implementation of actions that protect and restore ecologically important lands.
*Policy Needs

*Example Actions
• Create communication materials of success stories and lessons learned for places where land cover change is monitored and permit compliance is improved.
• Support and protect working lands, including incentives for forest and farmland owners such as transfer or purchase of development rights.
• Use a social marketing campaign or incentive program to shape market forces and societal behavioral change.
• Incorporate climate change projections in outreach materials to increase will for long-term protection and restoration activities.
*Proposal Guidance
• Describe how your project determines and defines the information needs of the target audience. 
• Describe how your project will leverage existing programs.
• Describe how effectiveness of the project will be measured.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1 Outreach and education to shoreline property owners 
1.1.1.4 Outreach and education to political leaders
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.1.2.1 Develop incentives for landowners to protect shoreline habitats
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
Additional guidance:
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC and member jurisdictions, and utilize HCCC policy forum 
**Island
Applicable, no additional info. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to education and outreach pathway LIO Plan strategy 02.1 (page 42), and strategy 04.1 which can be broadly applied -NTA 2016-0133 supports this work. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Retain 120 acres in forested condition and active stewardship through technical and financial assistance programs, engaging 6 parcels/landowners per year (pg. 24). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use),
• I (climate change), and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 26.3 and 26.5. See pages 31, 32, and 83, 86, 89. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies may include:
• Implement and expand incentive/cost share programs (WHATCOM-RC-CROSS09)
• Education and Outreach (WHATCOM-RC-CROSS07)
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC3.1', 1, N'LDC3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (75, 1075, 124, N'LDC 3.2 Implement plans and priorities to protect habitat.', N'#8228BF', N'Implement plans and priorities to protect habitat
*Desired Outcome
Ecologically important lands are protected and remain intact, and population growth is directed towards Urban Growth Areas.
*Policy Needs

*Example Actions
• Local, state, tribal, and/or federal governments improve permit implementation and effectiveness.
• Encourage compact redevelopment of urban centers or regional growth centers with subarea plans that provide a mix of uses to accommodate growth, and to provide access to services, transit, and neighborhood amenities.
• State and federal agencies provide regulatory and financial assistance to local governments for regulatory implementation and effectiveness.
*Proposal Guidance
• Describe the plans or guidance being used to select and prioritize the project. Consider how to expand existing models of targeted growth centers Sound-wide.
• Describe how the proposed actions will protect ecological processes, support future process-based restoration actions; discuss how social, racial, and environmental justice implications of housing availability and affordability will be addressed.
• Describe projected climate change impacts to and resilience of the site.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
3.2 Protect and restore priority freshwater salmonid habitat (LIO ERP pg. 62, App. 4 pg. 31) 
3.2.3 Implement priority salmon recovery projects (freshwater habitats) (HCCC Strategic Prioritization rank: 7 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach L01-06
– Engage HCCC salmon recovery staff to to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, no additional info. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan SSLIO 08.1 (page 49), protection pathways for strategies 01.1 Nearshore Protection and 10.1 Freshwater and Estuarine Protection -NTA 2016-0391 supports this work -Snohomish Basin Protection Plan - the Acquisition Strategy of the Stillaguamish Chinook Recovery Plan (http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf). -Refer to Ecosystem Services Evaluations in the Snohomish Basin (The Whole Economy of the Snohomish Basin: The Essential Economics of Ecosystem Services-Earth Economics 2010). https://snohomishcountywa.gov/DocumentCenter/View/44939

http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Retain 120 acres in forested condition and active stewardship through technical and financial assistance programs, engaging 6 parcels/landowners per year (pg. 24).
o Achieve no net loss of forest cover (pg. 24).
o Maintain UGA line and ensure that ≥87% of growth occurs within UGA (pg. 24). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• E (fish passage and excess sediment),
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6 and 4.2. See pages 31, 32, 86 and 88. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC3.2', 2, N'LDC3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (76, 1076, 124, N'LDC 3.3 Implement plans and priorities to restore habitat.', N'#8228BF', N'Implement plans and priorities to restore habitat
*Desired Outcome
Implementation of the prioritized restoration projects in the multi-benefit plan leads to restoration of ecologically important lands to the highest feasible ecological function.
*Policy Needs

*Example Actions
• Plant trees or shrubs in riparian corridors. 
• Establish conservation easements or acquire priority riparian habitat.
• Implement projects that include high quality, easily, and publically accessible green space within walking distance of all new development projects.
*Proposal Guidance
• Describe the plans being used to select and prioritize the project, geography, and partners. Consider how to expand existing models of targeted growth centers Sound-wide. 
• Proponents are encouraged to include the Approach: Collect and analyze data to adaptively manage recovery practices in their proposal. If monitoring is not appropriate for the proposed project, please explain.
• If working within an urban growth area, consider social and environmental justice implications.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers.  Active restoration is a priority for AHSS. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.2 Protect and restore priority freshwater salmonid habitat (LIO ERP pg. 62, App. 4 pg. 31) 
3.2.3 Implement priority salmon recovery projects (freshwater habitats) (HCCC Strategic Prioritization rank: 7 of 31)
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach L01-06
– Engage HCCC salmon recovery staff to to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, no additional info. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -refer to local goals for riparian habitat restoration (Table 3, page 14 of the LIO Plan) -refer to approved Salmon Recovery Plans and officially adopted supporting documents (i.e. the Stillaguamish Watershed Chinook Salmon Recovery Plan and the Snohomish River Basin Salmon Conservation Plan (https://snohomishcountywa.gov/1061/Publications) -reach scale plans in development for Lower Snohomish, Lower Stillaguamish, and Lower Skykomish. https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Restore 31 net miles of riparian habitat, including marine shoreline riparian habitat (pg. 24).
o In WRIA10: $1 million of the RCPP total funding is dedicated to farm BMP implementation projects, which include riparian buffer plantings. Where applicable, the RCPP funds will be used in conjunction with other funding sources to support levee setbacks and riparian focused conservation easements.
o See also Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy http://www.piercecountycd.org/blog.aspx?iid=85

http://scc.wa.gov/rcpp-in-wa/
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• E (fish passage and excess sediment),
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 2.2. See pages 30 and 83. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies may include:
• Implement and expand incentive/cost share programs (WHATCOM-RC-CROSS09)
• Habitat Restoration and protection plan and implementation (WHATCOM-RC-HAB01)
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC3.3', 3, N'LDC3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (77, 1077, 124, N'LDC 3.4 Collect and analyze data to adaptively manage recovery practices.', N'#8228BF', N'Collect and analyze data to adaptively manage recovery practices
*Desired Outcome
Monitoring of the multi-benefit outcomes of restoration leads to improved long-term stewardship and adaptive management of plans and practices to produce better ecosystem and human outcomes.
*Policy Needs

*Example Actions
• Develop a data clearinghouse suitable for assessing land-use patterns.
• Develop a decision-support tool to assess and communicate effectiveness of land-use regulations and voluntary restoration efforts based on land-use change patterns.
• Evaluate existing watershed-scale plans for lessons learned.
*Proposal Guidance
• Describe how ecological, economic, and social outcome metrics will be developed and measured. 
• Describe how monitoring will evaluate effectiveness at the site and landscape scale (such as use Commerce Critical Areas Assistance Handbook chapter on Monitoring and Adaptive Management). 
• Describe how data will be used to modify management decisions and design approaches. Consider partnerships that engage end-users throughout the study.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
Additional guidance:
– Engage HCCC staff to identify existing monitoring recommendation in place, current metrics used in HCCC Salmon Recovery Implementation Monitoring Geodatabase and Habitat Work Schedule, and other ecosystem indicators (consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals)
– Integrate Hood Canal human wellbeing indicators in project monitoring (see Developing Human Wellbeing Indicator for the Hood Canal Watershed report, and Measuring Human Wellbeing Indicator for Hood Canal report) http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://ourhoodcanal.org/content/human-wellbeing

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood Canal HWB Indicators_October 2013_0.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HoodCanalReport_GoogleHWB.pdf
**Island
Applicable, no additional info. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to Lead Entity M&AM plans, -applicable watershed status reports 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1 and 2. Pages 45, 46, and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC3.4', 4, N'LDC3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (78, 1078, 125, N'SA 1.1 Gain a better understanding of current habitat conditions.', N'#8228BF', N'Gain a better understanding of current habitat conditions.
*Desired Outcome
Based on an improved understanding of shoreline processes, structure, and function, protection and restoration efforts are directed to areas that will have the most ecological benefit.
*Policy Needs

*Example Actions
• Develop a shared definition for “ecologically important areas” as it relates to the shoreline
• Collect beach and bluff topography and nearshore bathymetry, substrate composition (grain size), and other physical attributes that shape nearshore habitat and biological communities. 
• Develop or expand existing datasets of current and historical biological uses of the nearshore environment
• Develop a knowledge base to predict sediment pathways and budgets and the impacts of barriers to sediment transport
*Proposal Guidance
• Note, “ecologically important areas” is a generic term that, once defined, can support restoration or protection prioritization. It may include critical areas, forage fish spawning habitat, etc. 
• Describe who the intended users of the final product will be and how they will engage in the project.
• If new sampling/surveys are proposed, describe how you will use existing protocols for new data collection (For spatial data refer to the Partnership’s draft Recommendations for Shoreline Armor Monitoring Protocols (https://pspwa.app.box.com/v/ArmorWorkshopReport2017); for physical and biological data refer to the Shoreline Monitoring Toolbox (Washington Sea Grant) or partner with ongoing monitoring programs. (https://sites.google.com/a/uw.edu/toolbox/home)
• If new sampling/surveys are proposed, describe how new data collection will build upon and enhance existing data (For shoreline spatial data refer to Coastal Geologic Services. 2017. Beach Strategies Phase 1 Summary Report. ESRP Learning Project #14-2308) and will be used to improve decision-making. 
• Describe the datasets used for any planned analyzes
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.3 Protect and restore priority nearshore and marine salmonid habitat
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
Additional guidance:
– Engage HCCC and member jurisdictions
– Utilize HCCC Protected Lands GIS tool
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Addressed, no NTAs needed 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 01.1 & 01.2 (page 40) and 10.1 and 10.2 (page 51), -Refer to 2016 NTAs mapped to strategies 01.1, 01.2, 10.1, and 10.2 (see NTA 2016-0403). -see Snohomish River Basin Salmon Conservation Plan (https://snohomishcountywa.gov/1061/Publications) and Stillaguamish Watershed Chinook Salmon Recovery Plan (http://www.stillaguamishwatershed.org/) estuary targets https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/1061/Publications

http://www.stillaguamishwatershed.org/
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA1.1', 1, N'SA1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (79, 1079, 125, N'SA 1.2 Gain understanding of the social, economic and political factors currently affecting habitat…', N'#8228BF', N'Gain a better understanding of the social, economic, and political factors currently affecting habitat.
*Desired Outcome
Enhanced understanding of land-use, regulations, and economic context improves landscape-scale restoration and protection planning to yield the most ecological benefit.
*Policy Needs

*Example Actions
• Continue to improve geospatial shoreline armor inventory including armor attributes (such as elevation, type) 
• Integrated physical, biological, and shoreline modification datasets with SMP zoning or infrastructure datasets.
• Evaluate economic costs of alternative shoreline protection design options
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• If proposing an economic study, describe how your project will address both the short-term (construction) and long-term (maintenance) costs
• Describe how you will use existing protocols for new data collection (For spatial data refer to the Partnership’s draft Recommendations for Shoreline Armor Monitoring Protocols (https://pspwa.app.box.com/v/ArmorWorkshopReport2017) 
• If new sampling/surveys are proposed, describe how new data collection will build upon and enhance existing data and will be used to improve decision-making. (For shoreline spatial data refer to Coastal Geologic Services. 2017. Beach Strategies Phase 1 Summary Report. ESRP Learning Project #14-2308.) 
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Map overlays should build off existing efforts (i.e. Snohomish County Planning and Development Services iGallery: (http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default https://snohomishcountywa.gov/DocumentCenter/View/44939

http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 17.2 and 1.1. See pages 31, 32, 86 and 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA1.2', 2, N'SA1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (80, 1080, 125, N'SA 1.3 Gain better understanding of how habitat may change due to pressures like climate change…', N'#8228BF', N'Gain a better understanding of how habitat may change in the future due to pressures like climate change and population growth.
*Desired Outcome
Improved understanding of how shoreline processes respond to climate change enables resilient shoreline protection and restoration.
*Policy Needs

*Example Actions
• Improve the resolution and accuracy of sea level rise or storm surge forecasts in Puget Sound.
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe the datasets, protocols, and analyses that will be used.
• Describe how you will leverage ongoing projects.
• Describe how this research will improve protection and restoration planning and site design.
• Describe how additional data collection will be used to improve decision-making, if new sampling/surveys are proposed.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
5.1 Develop Hood Canal Climate Adaptation Plan (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 24 of 31)
5.2 Integrate climate adaptation interventions throughout HCCC and member jurisdiction planning and programs (LIO ERP pg. 67, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 31 of 31)
5.3 Improve climate resilience of salmon habitat (LIO ERP pg. 68, App. 4 pg. 36) (HCCC Strategic Prioritization rank: 28 of 31)
Additional guidance:
– Engage HCCC and member jurisdictions
– Identify opportunities to integrate with Hood Canal salmon recovery plans http://hccc.wa.gov/content/salmon-recovery-planning
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. - LIO Plan SSLIO 02.1 (page 42), SSLIO 10.1 and 10.2 (page 51) -refer to WRIA 7 Climate Change white paper, - NTA 2016-0169 (partial implementation), NTA 2016-0315 support this work -refer to other 2016 NTAs mapped to strategies 02.1, 10.1 and 10.2. - Snohomish County Climate Change Adaptation Planning Tool --Refer to King County Climate Action Plan, the Stillaguamish Tribe Natural Resources Climate Adaptation Plan, and the Tulalip Tribe Climate Adaptation Plan and Climate Change Impacts on Tribal Resources (http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf). - University of Washington Climate Impacts Groups Climate Change, Sea Level Rise, and Flooding in the Lower Snohomish River Basin (https://cig.uw.edu/publications/climate-change-sea-level-rise-and-flooding-in-the-lower-snohomish-river-basin/) https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/DocumentCenter/View/41032

http://www.tulalip.nsn.us/pdf.docs/FINAL%20CC%20FLYER.pdf

https://cig.uw.edu/publications/climate-change-sea-level-rise-and-flooding-in-the-lower-snohomish-river-basin/
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1 and 2. Pages 45, 46, and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA1.3', 3, N'SA1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (81, 1081, 125, N'SA 1.4 Gain understanding of future social, economic, and political factors affecting habitat…', N'#8228BF', N'Gain a better understanding of future social, economic, and political factors (such as population growth) that will affect habitat.
*Desired Outcome
Improved understanding of future infrastructure and land use conditions improves shoreline protection and restoration planning to yield the most ecological benefit.
*Policy Needs

*Example Actions
• Identify vulnerable and aging infrastructure that may be susceptible to sea level rise or damaged by storm surge.
• Assess the vulnerability of unarmored shorelines to becoming armored as sea level rises.
• Evaluate the vulnerability of current areas classified for specific land-use purposes (such as critical areas) under future climate change
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe how you will build upon existing resources (such as WSDOT and FHA. 2011. Climate Impacts Vulnerability Assessment (http://www.wsdot.wa.gov/NR/rdonlyres/B290651B-24FD-40EC-BEC3-EE5097ED0618/0/WSDOTClimateImpactsVulnerabilityAssessmentforFHWA_120711.pdf)) or ongoing projects.
• Describe the datasets, protocols, and analyses that will be used.
• If new sampling/surveys are proposed, describe how additional data collection will be used to improve decision-making.
• Describe how this research will improve protection and restoration planning and site design.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. Refer to LIO Ecosystem Recovery Plan strategies 01.1 and 01.2 (page 40-41) for Nearshore Protection and Restoration.  Refer to NTA 2016-0403 that directly implements this work and other NTAs mapped to that strategy.  Reference the Shoreline Master Program for Snohomish County; https://snohomishcountywa.gov/1286/Shoreline-Management-Program https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25).
• In WRIA10: Establishing a Shore Friendly Pierce Program
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 8. Gap 1. Page 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA1.4', 4, N'SA1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (83, 1083, 126, N'SA 2.1 Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or…', N'#8228BF', N'Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or protect
*Desired Outcome
Broadly supported shoreline plans use available data to balance the ecological, social, and economic outcomes to achieve the protection and restoration of shoreline processes, structure, and function.
*Policy Needs

*Example Actions
• Develop or improve workshops, forums, newsletters, or websites able to promote nearshore project networking, coordination and showcase success stories throughout the region.
• Develop a library of successful projects that were able to leverage resources or projects to improve the ecosystem outcomes.
• Develop a communication strategy to engage large, industrial shoreline users in nearshore restoration. 
• Quantify the impact shoreline armoring has on nearshore habitat that is, or was historically used, by protected and important species.
• Allocate staff time and resources for participation in inter-agency and intra-agency coordination efforts.
• Scale-up successful pilot projects into regional programs.
• Develop a regional agreement on how to prioritize nearshore habitat protection and restoration.
• Create a forum to discuss and develop an emergency preparedness plan or toolkit as it relates to abrupt sea level change due to a major earthquake or large and intense storms.
*Proposal Guidance
• Describe how enabling factors and barriers have been addressed to allow for successful planning.
• Describe the datasets, protocols and analyses that will be used.
• Describe how your project will leverage existing programs and integrates into the broader shoreline planning landscape.
• Describe the strategy that will be used to bring in the relevant stakeholder groups.
• Describe how sea level rise and other climate change projections will be incorporated into planning activities.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.2.1.1, 1.3.1.1 Fill information and data gaps identified to inform salmon recovery in Hood Canal
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach S01-04
– Engage existing multi-stakeholder planning processes (such as FPbD), where appropriate
– Engage HCCC and member jurisdictions
– Consult HCCC salmon recovery staff to build off existing nearshore and estuary prioritization work conducted for Summer Chum salmon recovery
– Consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals to incorporate climate change impacts approaches being considered
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 01.1 & 01.2 (page 40) and 10.1 & 10.2 (page 51). -Refer to 2016 NTAs mapped to strategies 01.1, 01.2, 10.1, and 10.2 (i.e. NTAs 2016-0268 and 2016-2016-0171). -Refer to MRC, SLS/FFF, Salmon Recovery groups in the Stillaguamish and Snohomish basins (i.e. Stillaguamish Watershed Council, Snohomish Forum, and the Snoqualmie Forum). https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 7. Barrier 1 and 5 and Table 8. Gap 1 and 2.  Page 45, 46, and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA2.1', 1, N'SA2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (84, 1084, 126, N'SA 2.2 Address barriers to improve implementation plans, policies, and regulations.', N'#8228BF', N'Address barriers to improve implementation plans, policies, and regulations
*Desired Outcome
Improving the consistency, transparency, and coordination of regulatory decisions and increasing compliance monitoring and enforcement results in more effective shoreline protection and restoration.
*Policy Needs

*Example Actions
• Implement existing recommendations for regulatory effectiveness, monitoring and alignment from documents such as the TACT report 
• Implement compliance monitoring and enforcement programs.
• Develop multi-agency partnerships to improve field review of projects before, during, and after construction.
• Design and implement monitoring protocols able to broadly assess the efficacy of recently updated Shoreline Management Plans at achieving no net loss.
• Conduct an internal evaluation of regulatory program implementation and effectiveness 
• Develop or continue forums for regulatory agencies to share information.
• Local, state, and federal governments facilitate and support inter- and intra-agency communication and collaboration.
• Develop a restoration permitting process.
• Coordinate permit applications and reviews across regulatory agencies (when feasible).
• Develop programs that increase the opportunity for effective mitigation
• Engage local political actors in supporting regulatory enforcement and implementation.
• Provide data management support for local jurisdictions
*Proposal Guidance
• Describe how your project will use guidance from existing work (such as TACT report) or build upon successful pilot projects (such as TACT report checklists for permit review; King County WRIA 9 compliance monitoring project). 
• Describe how effectiveness of the project will be measured.
• If proposing compliance monitoring, describe the specific compliance issues that will be evaluated and how this information will be used to improve regulatory implementation.
• Consider engaging existing policy advisory bodies to develop policy solutions and describe how this will be done.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.1.2.1 Identify opportunities to improve and align shoreline protections across Hood Canal
1.1.2.2 Develop incentives for landowners to protect shoreline habitat
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
1.1.1.4 Outreach and education to political leaders
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach S01-06
– Engage HCCC''s Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments
– Utilize HCCC policy forum 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable (NOTE: Current focus for SJC is on finalizing the Shoreline Master Plan update) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. - See LIO Plan SSLIO 01.1 and 01.2 (page 40). -Refer to regulatory, enforcement, and implementation gaps and barriers listed in Table 7 (page 62) of the LIO Plan. -Actions to address barriers should be focused on pre-identified barriers within the LIO. - Local Critical Area Regulations (CAR) Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat) -refer to Regulatory Inefficiency and Regulatory Inconsistency in gaps and barriers Table 6 (page 54). -refer to Stillaguamish and Tulalip Tribe assessments of regulatory alignment (i.e. Death by a Thousand Cuts: An Examination of regulation enforcement in the Stillaguamish Watershed and the effects on ESA-listed Chinook Salmon and Tulalip Tribes Briefing Document: Joint Conference Pilot for Regulatory Harmonization in the Snohomish Basin https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/807/Aquatic-Habitat
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. Table 8. Gap 2. Page 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA2.2', 2, N'SA2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (85, 1085, 127, N'SA 3.1 Develop and implement outreach, education, and/or incentive programs.', N'#8228BF', N'Develop and implement outreach, education, and/or incentive programs
*Desired Outcome
Increased education and incentives for homeowners and ongoing practitioner training enable the implementation of management actions that protect and restore shoreline processes.
*Policy Needs

*Example Actions
• Continue and expand programs focusing on homeowner site visits and technical assistance.
• Provide design, permit, and financial assistance incentives for homeowners to implement removal projects.
• Develop a series of case studies to showcase armoring removal success stories that are suitable for the homeowner audience.
• Conduct demonstration tours.
• Promote existing green shoreline certification and recognition programs.
• Develop long-term sustained funding for existing education and incentive programs.
• Develop and implement financial incentives to support homeowners taking conservation or restoration actions.
• Develop long-term, sustained funding for existing education and incentive programs.
• Continue and expand informational workshops for homeowners and trusted agents (such as realtors).
• Develop programmatic framework for technical trainings for practitioners (such as consultants and contractors).
• Deliver technical trainings to practitioners.
• Develop certification standards for training programs.
• Develop training to help practitioners understand and use relative sea level rise and coastal erosion rate projections.
• Develop complementary and supporting guidance to the Marine Shoreline Design Guidelines for practitioners, such as:
1. geotechnical assessments
2. protocols for adaptive management
• Develop practical implementation guidance and tools for the Marine Shoreline Design Guidelines and similar guidance.
*Proposal Guidance
If developing an education and incentive program:
• Describe how your project determines and defines the information needs of the target audience. 
• Describe how your project will leverage existing programs.
• Describe how effectiveness of the project will be measured.
• Consider a communication approach to convey sea level rise risk including location specific information.

If developing a technical training program and delivering trainings:
• Describe how your project determines and defines the information needs of the target audience.
• Describe your plan to measure effectiveness of the project and adapt training program based on results.
• Describe how your project will leverage existing programs or projects.
• Describe any liability concerns for the program. 
• Describe how you will identify and address ongoing technical support needs of the participants.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.1.1.1  Outreach and education on shoreline protection and stewardship to shoreline property owners
1.1.1.4 Outreach and education to political leaders
1.1.2.1 Develop incentives for landowners to protect shoreline habitats
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections
3.1.2.2 Outreach to small and large forest landowners
Additional guidance:
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC and member jurisdictions 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25).
• In WRIA10: Establishing a Shore Friendly Pierce Program 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use),
• I (climate change), and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 26.3 and 26.5. See pages 31, 32, and 83, 86, 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA3.1', 1, N'SA3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (48, 1048, 115, N'EST 1.5 Increase human and technical capacity of staff for planning, implementation, and enforcement', N'#8228BF', N'Increase human and technical capacity of staff for planning, implementation, and enforcement
*Desired Outcome
Local estuary planning teams have the expertise, local and regional support structure, and regional vision to enable planning and solution development.
*Policy Needs

*Example Actions
• Develop local estuary teams for planning and solution support.
• Fund staff in rural counties to help interpret and educate potential partners on estuary restoration and protection opportunities.
• Develop local, state, and federal funding mechanisms to support multi-stakeholder forums.
• Allocate state or federal agency staff to support local estuary teams.
*Proposal Guidance
• Describe how your project will leverage existing programs and efforts.
• If proposing staff training, describe how the training will increase capacity.
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries.  South Sound strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies.
Additional guidance:
Consult with HCCC to identify potential capacity support and/or resources 
**Island
Not Applicable 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to Snohomish basin estuary working group and Stillaguamish Technical Advisory Group. -Encourage state and federal participation among these groups. 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries).
• H (shoreline and land use); and/or
• I (climate change).

Special Emphasis: Identified Barriers (Table 5) to accomplishing ecosystem recovery:
• Limited staff capacity to implement actions; and
• Limited coordination capacity 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST1.5', 5, N'EST1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (49, 1049, 116, N'EST 2.1 Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or…', N'#8228BF', N'Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or protect
*Desired Outcome
Broadly supported landscape-scale plans use available data to balance the ecological, social, and economic outcomes to restore tidal inundation and estuary function.
*Policy Needs

*Example Actions
• Develop multi-stakeholder forums. (Note: Existing forums should be sustained and used as model for deltas without existing forums.)
• Local, state, and federal agencies develop and communicate a coordinated vision for delta landscape management 
• Identify estuary restoration opportunities that have multi-benefit outcomes, and develop a prioritized list suitable for long-term planning.
• Working with local stakeholder groups and existing environmental plans, identify lands suitable for acquisition and restoration that have the capacity to serve as functional estuarine habitat.
• Develop a combination of quantity and quality targets for farmland that can be used to establish trade-offs between agriculture and conservation goals.
• Conduct social, economic, physical, and ecological analyses of delta landscape management alternatives.
*Proposal Guidance
• Describe how enabling factors and barriers have been addressed to allow for successful planning.
• Describe the dataset, protocols, and analyses that will be used to develop the plan.
• Describe how your project integrates with the broader planning landscape for estuary restoration.
• Describe the strategy that will be used to bring in the relevant stakeholder groups and resolve conflicts.
• Describe how climate change projections will be incorporated into landscape-scale plans. 
*Local Context
**South Sound
Applicable, see local context. 
AHSS interprets this to apply to “delta scale” work and similar work on smaller estuaries. South Sound Strategy pp 60-69 maps large and small priority estuaries. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.2.2 Prioritize and sequence salmon recovery actions across Hood Canal watersheds (estuarine habitats) (LIO ERP pg. 52, App. 4 pg. 20)

Additional guidance:
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library)
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– Engage HCCC and member jurisdictions
– Demonstrate outcomes of Regional Priority Approach E01-04 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29, 44, and 59 & 60 Table 10. 
**San Juan
Not applicable (NOTE:  The San Juan Islands Action Area Ecosystem Protection and Recovery Plan does not include Estuaries as a priority Vital Sign due to the limited presence of estuarine habitat) 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan SSLIO 02.1 (page 42), SSLIO 10.1 and 10.2 (page 51) -There are many multi-stakeholder forums in existence in our LIO. (examples include: Snohomish Basin Salmon Recovery Estuary Working Group, the Sustainable Lands Strategy Executive Committee) -refer to reach scale plans for Lower Skykomish, Lower Snohomish, and Lower Stillaguamish, -reference or consider Conflicting Values/Concerns and Goals in gaps and barriers table 6 -see Snohomish River Basin Salmon Conservation Plan (https://snohomishcountywa.gov/1061/Publications) and Stillaguamish Watershed Chinook Salmon Recovery Plan (http://www.stillaguamishwatershed.org/). -Refer to Snohomish County Agriculture Resilience Plan (Draft) – Snohomish Conservation District (http://snohomishcd.org/ag-resilience). -see estuary targets (LIO Plan page 13) in the Snohomish River Basin Salmon Conservation Plan, Snohomish Basin Protection Plan, and Stillaguamish Watershed Chinook Salmon Recovery Plan 
 -Refer to Ecosystem Services Evaluations in the Snohomish Basin (The Whole Economy of the Snohomish Basin: The Essential Economics of Ecosystem Services-Earth Economics 2010). https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/1061/Publications

http://www.stillaguamishwatershed.org/

http://snohomishcd.org/ag-resilience
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 21-22) of South Central Ecosystem Recovery Plan for general background context.
•  Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy and other work will help inform this work. 
• Floodplains by Design work in WRIA 10 can help inform this work. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Estuary Short-Term Goal Statements are not currently available; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• B (estuaries).
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'EST2.1', 1, N'EST2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (58, 1058, 118, N'FP 1.4 Gain understanding of future social, economic, and political factors affecting habitat…', N'#8228BF', N'Gain a better understanding of future social, economic, and political factors (such as population growth) that will affect habitat.
*Desired Outcome
Improved understanding of future population growth, flood risks and associated costs enables improved multi-benefit floodplain planning.
*Policy Needs

*Example Actions
• Develop population growth projections in floodplains.
• Develop cost subsidy analyses that show the cost of developing in a floodplain considering future flood risk conditions.
• Update climate change projections to strengthen identification of areas at high risk for flooding.
• Update the definition of the flood risk to include future probabilities.
*Proposal Guidance
• Describe who the intended users of the final product will be and how they will engage in the project.
• Describe the datasets, protocols, and analyses that will be used. 
• Describe how you will consider environmental justice, transportation, and housing affordability in the project.
• Consider environmental justice, transportation, and housing affordability implications of urban infill.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdiction planning departments 
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 08.1 Implementation of GMA Recognizing Puget Sound Recovery Goals (page 49) and SSLIO 02.1 Integrated Planning (page 42). https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 4.2, 1.1, and 2.1. See pages 31 and 86.
Table 8. Gap 1 and 2. Page 46 and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP1.4', 4, N'FP1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (59, 1059, 118, N'FP 1.5 Increase human and technical capacity of staff for planning, implementation, and enforcement.', N'#8228BF', N'Increase human and technical capacity of staff for planning, implementation, and enforcement
*Desired Outcome
Staff have the technical expertise, time, support, and tools to develop and implement restoration and protection measures in floodplains.
*Policy Needs

*Example Actions
• Increase staffing or human capital with adequate training and access to data, research, etc.
• Identify, synchronize, and grow funding mechanisms to support local planning.
• Develop a centralized application process for all floodplain funding sources with regionally supported metrics, goals, and application requirements.
*Proposal Guidance
• If proposing staff technical training, describe how the training will be leveraged to increase jurisdictional capacity.
• If working on funding mechanisms, consider coordinating with partners conducting ongoing work (such as Floodplains by Design, NOAA''s Coordinated Investment, local governments, tribal governments).
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies.
Additional guidance:
Consult with HCCC to identify potential capacity support and/or resources 
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change)

Special Emphasis: Identified Barriers (Table 5) to accomplishing ecosystem recovery:
• Limited staff capacity to implement actions; and
• Limited coordination capacity 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP1.5', 5, N'FP1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (60, 1060, 119, N'FP 2.1 Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or…', N'#8228BF', N'Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or protect
*Desired Outcome
Broadly supported landscape-scale plans use available data to balance the ecological, social, and economic outcomes to protect and restore floodplain function and connectivity.
*Policy Needs

*Example Actions
• Develop watershed farm, fish, and flood task forces.
• Identify the most important areas to restore or reconnect floodplains or estuaries.
• Establish land use goals and needs for each watershed.
• Establish land use and restoration goals and needs for each watershed.
• Create analysis of ecologically important lands in floodplains overlaid with lands at high risk for development.
• Identify vulnerable lands to flooding within a city and county to aid in protection and restoration of floodplains.
• Estimate effects of planned build-out on drainage and potential flooding.
• Refine existing plan to incorporate new analyses or projections.
• Identify opportunities to use soft shoreline techniques, including river deltas.
*Proposal Guidance
• Describe how enabling factors and barriers have been addressed to allow for successful planning.
• Describe the dataset, protocols, and analyses that will be used to develop the plan.
• Describe how your project integrates with the planning landscape in the broader floodplain area. 
• Describe the strategy that will be used to engage the relevant stakeholder groups and resolve conflicts. 
• Describe how climate change projections will be incorporated into the planning process. 
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.2 Protect and restore priority freshwater salmonid habitat (LIO ERP pg. 62, App. 4 pg. 31) 
3.2.1 Adaptively manage salmon recovery plans for Hood Canal (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach F01-04
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– Engage HCCC and member jurisdictions 
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. - LIO Plan SSLIO 02.1 Integrated Planning (page 42), -refer to the Sustainable Lands Strategy (FFF goals). -Consider Conflicting Values/Concerns and Goals in gaps and barriers table 6, -NTA 2016-0045 and 2016-0310, as well as other NTAs mapped to the above referenced LIO strategy, support this work. -Supporting private landowner outreach/engagement is critical to this work.  -Support updating outdated Comprehensive Flood Hazard Management plans and completing channel migration zone analyses. -Reach scale planning efforts on-going in the Snoqualmie, Stillaguamish and Snohomish watersheds. -Integrated multi-benefit plans should be developed with regulatory updates in mind so regulatory updates are not separate from recovery planning efforts. -Refer to Ecosystem Services Evaluations in the Snohomish Basin (The Whole Economy of the Snohomish Basin: The Essential Economics of Ecosystem Services-Earth Economics 2010). https://snohomishcountywa.gov/DocumentCenter/View/44939

http://snohomishcd.org/ag-resilience
**SouthCentral
South Central: Applicable, see local context.
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• See also Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy.
• WRIA 10 is doing this through Floodplain by Design Integrated Management Planning.
• PRWC plans to write an Ecosystem Recovery Plan for WRIA 10. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 1.1, 2.1 and 10.1. See pages 31, 81 and 86. 
**Whatcom
Applicable – Relevant Whatcom LIO Strategies may include: 
• WHATCOM-STRAT-HAB03 (Develop integrated floodplain management plan)
• WHATCOM-RC-CROSS02 (Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues)
• WHATCOM-STRAT-CROSS04 (Develop and implement watershed-scale plans)
• A floodplain management planning effort (WHATCOM-STRAT-HAB03) has been initiated including technical assessments.  Contact is Paula Harris, Whatcom County Public Works, River and Flood Division.
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP2.1', 1, N'FP2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (61, 1061, 119, N'FP 2.2 Address barriers to improve implementation plans, policies, and regulations.', N'#8228BF', N'Address barriers to improve implementation plans, policies, and regulations
*Desired Outcome
Transparent, effective, clear, and consistent implementation of project administration processes enables improved protection and restoration of floodplain area and function.
*Policy Needs

*Example Actions
• Develop forums for regulatory agencies to share information.
• Evaluate opportunities to coordinate permit applications and reviews across regulatory agencies.
• Local, state, and federal governments facilitate and support inter- and intra-agency communication and collaboration.
• Address the barriers to implementation of the FEMA National Flood Insurance Program, Clean Water Act Section 404, levee standards, Shoreline Management Act, and Growth Management Act on floodplain management.
*Proposal Guidance
• Describe how your project will improve implementation of plans, policies, permitting processes, and/or regulations. 
• Describe how your project will use guidance from existing work.
• Describe how effectiveness of the project will be measured.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach F01-06
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdiction planning departments
– Engage existing FPbD partners 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 24, 29 and 59 & 60-Table 10 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan Regulatory Inefficiency and Regulatory Inconsistency in gaps and barriers Table 6 (page 54).  -LIO Plan strategies 01.1 Nearshore Protection (page 40), 02.1 Integrated Planning (page 42), 08.1 Implementation of GMA Recognizing Puget Sound recovery goals (page 49) and the protection pathway of strategy 10.01 and 10.02 Freshwater and Estuarine Protection and Restoration (page 51-52). -See the tribal studies such as the Stillaguamish Tribe’s Death by a Thousand Cuts. See Snohomish County’s Critical Area Regulations Compliance Evaluation and related planning documents. Refer to regulatory, enforcement, and implementation gaps and barriers listed in Table 7 of the LIO Plan. Actions to address barriers should be focused on pre-identified barriers within the LIO. -Refer to Snohomish County Agriculture Resilience Plan (Draft) – Snohomish Conservation District (http://snohomishcd.org/ag-resilience). -Refer to TDR/PDR protection strategies in the Snohomish Basin Protection Plan (https://snohomishcountywa.gov/1061/Publications). http://www.stillaguamishwatershed.org/Documents/StillaguamishTribe_RegulatoryStudy.pdf

http://snohomishcd.org/ag-resilience

https://snohomishcountywa.gov/1061/Publications
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88 and Table 8. Gap 2. Page 47. 
**Whatcom
Applicable – See Local Context 
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP2.2', 2, N'FP2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (62, 1062, 120, N'FP 3.1 Develop and implement outreach, education, and/or incentive programs.', N'#8228BF', N'Develop and implement outreach, education, and/or incentive programs
*Desired Outcome
Improved education (on location, costs, risks, and protection options) and incentives for the public and decision-makers direct development away from flood-prone areas and enable implementation of actions that protect and restore floodplains.
*Policy Needs

*Example Actions
• Develop training for planning, public works, and public officials on integrated planning guidelines, benefits, and support groups.
• Create and steward monitoring and effectiveness guidance.
• Create infrastructure for regional decision support tools to display and communicate a plan’s effectiveness.
• Use social marketing campaign/incentive program to influence land owners to move flood-vulnerable land out of production.
• Incorporate climate change projections in outreach materials to increase will for long-term protection and restoration activities.
• Offer payments for ecosystem services programs targeting floodplain acreage or function.
*Proposal Guidance
• Describe how your project determines and defines the information needs of the target audience. 
• Describe how your project will leverage existing programs.
• Describe how effectiveness of the project will be measured.
• Consider using future projections (including risk tolerance, cost subsidy information, growth and climate projections) to build support among the public, communities, and decision makers.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31) 
1.1.1.4 Outreach and education to political leaders
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.1.2.1 Develop incentives for landowners to protect shoreline habitats 
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections
2.1.4.2 Decision-maker outreach and education on water quality protections in policy
3.1.2.2 Outreach to small and large forest landowners
Additional guidance:
– Build off/Integrate existing outreach and education efforts present in Hood Canal 
– Engage HCCC and member jurisdictions,  and utilize HCCC policy forum 
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Follow the outreach and education pathways for LIO Plan SSLIO strategies 02.1 (page 42), SSLIO 08.1 (page 49) -NTA 2016-0133, as well as other NTAs mapped to the Strategies, support this work. -See existing outreach/ed. materials such as Snohomish County’s flood guide. -Encourage development of landowner outreach strategies near rivers and streams. https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/DocumentCenter/View/6787
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Support outreach and education programs that result in behavior change, and actions that reduce shoreline armoring including incentive-based programs that address conflicting land uses between farms and fish (pg. 22).
o Have floodplain landowner engagement programs in place in each of the three major watersheds, including, but not limited to, targeted tree planting on 1,200 acres in WRIA 9’s Lower Green River sub-watershed (pg. 22). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), 
• H (shoreline and land use), 
• I (climate change), and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 26.3 and 26.5. See pages 31, 32, and 83, 86, 89. 
**Whatcom
Applicable – See Local Context 
Relevant LIO Plan strategies and substrategies may include:
•  Education and Outreach  (WHATCOM-RC-CROSS07)
• Implementing and expanding incentive/cost share programs (WHATCOM-RC-CROSS09).
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP3.1', 1, N'FP3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (63, 1063, 120, N'FP 3.2 Implement plans and priorities to protect habitat.', N'#8228BF', N'Implement plans and priorities to protect habitat
*Desired Outcome
Implementation of the prioritized protective measures in the multi-benefit plan leads to protection of floodplain function and area.
*Policy Needs

*Example Actions
• Land acquisition and conservation easements.
• Communicate effectiveness data and success stories and learning from plan implementation.
• Improve the implementation of existing regulations and permitting processes regarding frequently flooded areas under the Shoreline Management Act and Growth Management Act.
• Include the full cost of emergency measures in the development costs. 
• Acquire and remove development rights in floodplain areas and support programs that do so, such as purchases of development rights.
• Direct growth away from intact floodplains through regulations and market-driven programs such as transfer of development rights.
• Create preferential tax incentives for open land versus new development in floodplains.
• Explore opportunities for flexible funding that enables opportunistic acquisitions.
*Proposal Guidance
• Describe the plans being used to select and prioritize the site. 
• Describe the current status of the floodplain and the ecological function that will be protected for which target species.
• Describe projected climate change impacts to and resilience of the site.
*Local Context
**South Sound
Applicable, see local context.
AHSS encourages projects that lead directly to protection of naturally-functioning floodplains.
 http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)3.2 Protect and restore priority freshwater salmonid habitat (LIO ERP pg. 62, App. 4 pg. 31) 
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
3.2.3 Implement priority salmon recovery projects (freshwater habitats) (HCCC Strategic Prioritization rank: 7 of 31)
Additional guidance, as applicable:
– Demonstrate outcomes of Regional Priority Approach F01-06
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Addressed, no NTAs needed 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Follow protection pathways of LIO Plan strategies 10.1 Freshwater and Estuarine Protection and 02.1 Integrated Planning -refer to Acquisition Strategy of the Stillaguamish Chinook Recovery Plan (http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf) and approved supporting documents -NTA 2016-0310 supports this work and is being implemented. -refer also to habitat protection strategies in the Snohomish River Basin Salmon Conservation Plan and the Stillaguamish Watershed Chinook Salmon Recovery Plan and officially approved supporting documents (Stillaguamish: http://www.stillaguamishwatershed.org/) (Snohomish: https://snohomishcountywa.gov/1127/Snohomish-Watershed-Salmon-Recovery-Plan).  -the Regional Open Space Conservation Plan and related tools - Also reference local Critical Area Regulations Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat), Shoreline Master Programs, Comprehensive Plans, and the Snohomish Basin Protection Plan. -Refer to Snohomish County Agriculture Resilience Plan (Draft) – Snohomish Conservation District (http://snohomishcd.org/ag-resilience). https://snohomishcountywa.gov/DocumentCenter/View/44939

http://www.stillaguamishwatershed.org/Documents/V.1.%205-18-15%20FINAL%20SWC%20acquisition%20strategy.pdf

http://www.stillaguamishwatershed.org/

https://snohomishcountywa.gov/1127/Snohomish-Waters
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Conduct assessments to identify future needs and priorities (pg. 22).
• See also Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 17.2, 4.2 and 1.1. See pages 31, 32, 86 and 89. 
**Whatcom
Applicable – See Local Context
Relevant Whatcom LIO Strategies may include: 
• WHATCOM-STRAT-HAB03 (Develop integrated floodplain management plan)
• WHATCOM-RC-CROSS02 (Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues)
• A floodplain management planning effort (WHATCOM-STRAT-HAB03) has been initiated including technical assessments.  Contact is Paula Harris, Whatcom County Public Works, River and Flood Division.
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP3.2', 2, N'FP3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (64, 1064, 120, N'FP 3.3 Implement plans and priorities to restore habitat.', N'#8228BF', N'Implement plans and priorities to restore habitat
*Desired Outcome
Implementation of the prioritized restoration projects in the multi-benefit plan leads to increased floodplain function and connectivity.
*Policy Needs

*Example Actions
• Remove hard shoreline infrastructure in floodplains.
• Remove constraints to natural channels in the floodplain footprint
• Do site feasibility, site design, and construction project phases
*Proposal Guidance
• Describe the plans being used to select and prioritize the project, geography, and partners.
• Describe the current status of the floodplain and the ecological function that will be restored for which target species.
• Proponents are encouraged to include the Approach: Collect and analyze data to adaptively manage recovery practices in their proposal. If monitoring is not appropriate for the proposed project, please explain.
• Describe how climate change impacts to and resilience of the site are addressed by the design.
*Local Context
**South Sound
Applicable, see local context.
AHSS encourages projects that lead directly to restoration of floodplain connectivity and function.  http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31) 
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)
3.2 Protect and restore priority freshwater salmonid habitat (LIO ERP pg. 62, App. 4 pg. 31) 
3.2.3 Implement priority salmon recovery projects (freshwater habitats) (HCCC Strategic Prioritization rank: 7 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach F01-06
– Engage HCCC salmon recovery staff to coordinate with work completed and in progress for the Hood Canal and Eastern Strait of Juan de Fuca Summer Chum Salmon Recovery Plan (appendices available on HCCC Library), 
– Consult HCCC’s guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals, and HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) http://hccc.wa.gov/sites/default/files/resources/downloads/Hood_Canal_Summer_Chum_Salmon_Recovery_Plan_FINAL_FULL_VERSION.pdf

http://hccc.wa.gov/resources?search_api_views_fulltext_op=AND&search_api_views_fulltext=summer%20chum%20salmon%20recovery%20plan%20appendix&sort_by=title&f%5B0%5D=field_topics%3A85&f%5B1%5D=field_topics%3A87

http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Follow restoration pathway for LIO Plan strategies 10.2 Freshwater and Estuarine Restoration, 02.1 Integrated Planning, and 08.1 Implementation of GMA -refer to reach scale plans for Lower Skykomish, Lower Snohomish, and Lower Stillaguamish reaches -NTA 2016-0310 is being implemented -see Snohomish River Basin Salmon Conservation Plan (https://snohomishcountywa.gov/1061/Publications) and Stillaguamish Watershed Chinook Salmon Recovery Plan (http://www.stillaguamishwatershed.org/). https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/1061/Publications 

http://www.stillaguamishwatershed.org/
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Restore 430 acres of floodplain and complete 4 miles of levee setbacks (pg. 22).  
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use), and/or
• I (climate change), 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 17.2 and 1.1. See pages 31, 32, 86 and 89. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies may include:
• WHATCOM-STRAT-HAB02 (Technical Assessments and WRIA 1 SRP Update)
• WHATCOM-STRAT-HAB04 (land acquisition, conservation easements, farm transition, and/or landowner agreements)
• WHATCOM-RC-HAB01 (Habitat Restoration and protection plan and implementation) 
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP3.3', 3, N'FP3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (65, 1065, 120, N'FP 3.4 Collect and analyze data to adaptively manage recovery practices.', N'#8228BF', N'Collect and analyze data to adaptively manage recovery practices
*Desired Outcome
Monitoring of the multi-benefit outcomes of floodplain protection and restoration leads to improved long-term stewardship and adaptive management of plans and practices to produce better ecosystem and human outcomes.
*Policy Needs

*Example Actions
• Evaluate habitat response and restoration outcomes to specific design approaches to improve critical design decisions and cost assessments for levee removal.
• Communicate effectiveness data and success stories and learning from plan implementation.
• Monitor and evaluate effectiveness of solutions identified and implemented from plans.
*Proposal Guidance
• Describe how ecological, economic, and social outcome metrics will be developed and measured. Consider using the Commerce Critical Areas Assistance Handbook for guidance, Floodplains by Design regional metrics for communication, and restoration adaptive management metrics similar to other efforts, such as the Fisher Slough monitoring methodology (PRISM #13-1524).
• Describe how monitoring will evaluate effectiveness at the site and landscape scale. Consider partnerships that will ensure long-term continuity of monitoring.
• Describe how data will be used to modify management decisions and design approaches. Consider partnerships that engage end-users throughout the study.
*Local Context
**South Sound
Applicable, no additional info. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
3.2.1 Adaptively manage salmon recovery plans for Hood Canal (freshwater habitats) (LIO ERP pg. 62, App. 4 pg. 31) (HCCC Strategic Prioritization rank: 1 of 31)
Additional guidance:
– Engage HCCC staff to identify existing monitoring recommendation in place, current metrics used in HCCC Salmon Recovery Implementation Monitoring Geodatabase and Habitat Work Schedule, and other ecosystem indicators (consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals)
– Integrate Hood Canal human wellbeing indicators in project monitoring (see Developing Human Wellbeing Indicator for the Hood Canal Watershed report, and Measuring Human Wellbeing Indicator for Hood Canal report) http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://ourhoodcanal.org/content/human-wellbeing

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood Canal HWB Indicators_October 2013_0.pdf

http://hccc.wa.gov/sites/default/files/resources/downloads/HoodCanalReport_GoogleHWB.pdf
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -refer to Lead Entity M&AM plans and applicable watershed status reports. -refer to pre-identified monitoring gaps as identified in tables 6 and 7 of the LIO Plan. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 22) of South Central Ecosystem Recovery Plan for general background context.
• Floodplains by Design work in WRIA 10 will include a monitoring component that will report out on flood, fish and farming metrics.
• WRIA 10 Lead Entity M and AM work will help inform this effort.   
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Floodplain Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• E (fish passage and excess sediment),
• C (floodplains), and/or
• H (shoreline and land use) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1. Pages 45 and 46. 
**Whatcom
Applicable – See Local Context. 
Relevant strategies and substrategies may include:
• Salmon  recovery research, monitoring, and adaptive management (Whatcom-RC-HAB02)
• Source identification and effectiveness monitoring of best management practices (WHATCOM-RC-SHELL03)
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'FP3.4', 4, N'FP3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (66, 1066, 121, N'FUND 1.1 Develop a strategy to enable and mobilize the public to take actions to protect Puget Soun…', N'#c9cacb', N'Develop a strategy to enable and mobilize the public to take actions to protect Puget Sound and support funding of recovery actions.
*Desired Outcome
The public understands the importance of Puget Sound recovery, and what they can do to support it.
*Policy Needs

*Example Actions
Convene partners to develop a strategy.
*Proposal Guidance
Proposals may address Puget Sound recovery as a whole, multiple Vital Signs, or creative approaches for a specific Vital Sign.
*Local Context
**South Sound
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**Hood Canal
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**Island
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**San Juan
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**Snohomish/Stillaguamish
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**SouthCentral
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**Strait
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**West Central
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44
**Whatcom
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo44', N'FUND1.1', 1, N'FUND1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (86, 1086, 127, N'SA 3.2 Implement plans and priorities to protect habitat.', N'#8228BF', N'Implement plans and priorities to protect habitat
*Desired Outcome
Protection of prioritized, un-modified shoreline sites maintains shoreline processes, structure, and function.
*Policy Needs

*Example Actions
• Establish conservation easements or acquire unarmored shoreline.
• Develop and implement management plans for public and private lands that protect natural shoreline while addressing existing infrastructure and safety concerns.
*Proposal Guidance
• Describe the plans being used to select and prioritize the project.
• Describe how the proposed actions will restore shoreline processes.
• Describe projected climate change impacts to and resilience of the site.
• Consider modified sites for protection if prioritization plans identify them as high priority based upon restoration potential or as still contributing to key shorelines processes.
• Consider applying ESRP RFP proposal guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_ESRP_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas.  Implementation of protection and restoration actions are a priority for AHSS. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.0 Protect and restore Hood Canal shoreline
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)
1.3 Restore and protect priority nearshore salmonid habitat
1.3.3 Implement priority salmon recovery projects (nearshore and marine habitats) (HCCC Strategic Prioritization rank: 17 of 31)
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach S01-06
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide)
– Engage HCCC and member jurisdictions
– Utilize HCCC Protected Lands GIS tool
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to outreach and education pathways of LIO Plan strategies SSLIO 01.1 & 01.2 (page 40) and 10.1 & 10.2 (page 51). -Refer to 2016 NTAs mapped to strategies 01.1, 01.2, 10.1, and 10.2 (See NTAs 2016-0159, 2016-0036, 2016-0067, 2016-0071, and 2016-0070). -refer to local Marine Resources Committee, Snohomish CD, and Washington State University Extension outreach and education efforts (SSLIO 04.1) https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA3.2', 2, N'SA3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (87, 1087, 127, N'SA 3.3 Implement plans and priorities to restore habitat.', N'#8228BF', N'Implement plans and priorities to restore habitat
*Desired Outcome
Restoration on prioritized sites restores shoreline processes to improve structure and function.
*Policy Needs

*Example Actions
• Implement project phases including site feasibility, site design, and construction to remove armor and use habitat improvement techniques to restore shoreline processes, structure and function.
• Implement removal and restoration projects on public and private lands.
• Integrate habitat restoration into infrastructure and public works projects
*Proposal Guidance
• Describe the plans being used to select and prioritize the project.
• Describe how the proposed actions will restore shoreline processes.
• Describe how climate change impacts to and resilience of the site are addressed by the design.
• Describe how your project will use available guidance on site assessment, design, and implementation (such as Marine Shoreline Design Guidelines).
• Proponents are encouraged to include the Approach: Collect and analyze data to adaptively manage recovery practices in their proposal. If monitoring is not appropriate for the proposed project, please explain.
• Consider evaluating and communicating lessons learned from project design and construction.
• Consider applying ESRP RFP proposal guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_ESRP_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas.  Implementation of protection and restoration actions are a priority for AHSS. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.0 Protect and restore Hood Canal shoreline
1.1 Remove/soften/prevent shoreline armoring (LIO ERP pg. 47, App. 4 pg. 16)
1.1.1 Outreach and education on shoreline protection and stewardship (LIO ERP pg. 47, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 19 of 31)
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.2 Protect and restore priority estuarine salmonid habitat (LIO ERP pg. 50, App. 4 pg. 19) 
1.2.3 Implement priority salmon recovery actions across Hood Canal watersheds (estuarine habitats) (HCCC Strategic Prioritization rank: 6 of 31)
1.3 Restore and protect priority nearshore salmonid habitat
1.3.3 Implement priority salmon recovery projects (nearshore and marine habitats) (HCCC Strategic Prioritization rank: 17 of 31)
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach S01-06
– Engage HCCC and member jurisdictions
– Utilize HCCC Protected Lands GIS tool
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions
– See Hood Canal LIO salmon recovery projects criteria (in Hood Canal LIO NTA process guide) 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 01.1 (page 40) and 10.1 (page 51). -Refer to NTAs mapped to strategies 01.1 and 10.1 (See NTAs 2016-0268 and 2016-2016-0171). https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment),
• H (shoreline and land use), and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 17.2. See pages 32 and 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA3.3', 3, N'SA3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (88, 1088, 127, N'SA 3.4 Collect and analyze data to adaptively manage recovery practices.', N'#8228BF', N'Collect and analyze data to adaptively manage recovery practices
*Desired Outcome
Monitoring of the multi-benefit outcomes of shoreline protection and restoration leads to improved long-term stewardship and adaptive management of plans and practices to produce better ecosystem and human outcomes.
*Policy Needs

*Example Actions
• Evaluate implemented shoreline armoring removal and soft shore projects in order to improve designs and design guidance for improved ecological and human outcomes.
• Develop data repository for monitoring data.
• Develop protocols for synthesizing data and updating design and guidance materials.
• Develop protocols for assessing outcomes from a design or engineering perspective to inform improved designs and guidance
• Develop a coastal processes monitoring program to document beach morphology change, sediment delivery, transport, and deposition.
• Monitor intertidal and subtidal habitat and functional responses to restoration (and consider other stressors where appropriate)
• Conduct process-based monitoring at the drift cell scale related to functions of the nearshore and ""thresholds"" of percent armored.
*Proposal Guidance
• If measuring ecosystem responses, describe how your project will use the Shoreline Monitoring Toolbox (Washington Sea Grant) protocols or collaborate with existing monitoring programs. (https://sites.google.com/a/uw.edu/toolbox/home)
• Describe how your project will account for site attributes and design type in the monitoring methodology.
• Describe how your data will be made available.
• Describe how data will be used to modify management decisions, update contractor trainings, improve permitting process, or updated and refine site assessment and design guidance. Consider partnerships that engage end-users throughout the study.
• Consider applying ESRP Learning Program RFP guidance and criteria in developing your project and metrics of success. (http://www.pugetsoundnearshore.org/esrp/files/2016_ESRP_RFP.pdf)
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
1.1.2 Improve shoreline planning and regulatory frameworks (LIO ERP pg. 48, App. 4 pg. 16) (HCCC Strategic Prioritization rank: 29 of 31)
1.2.1 Adaptively manage salmon recovery plans for Hood Canal (estuarine habitats) (LIO ERP pg. 50, App. 4 pg. 19) (HCCC Strategic Prioritization rank: 9 of 31)
1.3.1 Adaptively manage salmon recovery plans for Hood Canal (nearshore and marine habitats) (LIO ERP pg. 53, App. 4 pg. 22) (HCCC Strategic Prioritization rank: 15 of 31)
Additional guidance:
– Engage HCCC staff to identify existing monitoring recommendation in place, current metrics used in HCCC Salmon Recovery Implementation Monitoring Geodatabase and Habitat Work Schedule, and other ecosystem indicators (consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals)
– Integrate Hood Canal human wellbeing indicators in project monitoring (see Developing Human Wellbeing Indicator for the Hood Canal Watershed report, and Measuring Human Wellbeing Indicator for Hood Canal report)
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC member jurisdictions, and utilize HCCC policy forum http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf

http://ourhoodcanal.org/content/human-wellbeing

http://hccc.wa.gov/sites/default/files/resources/downloads/Hood Canal HWB Indicators_October 2013_
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 10.1 and 10.2 (page 51) - Local Critical Area Regulations (CAR) Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat) To reference monitoring recommendations, see the conservation action plan for the Port Susan Bay Marine Stewardship Area of the Snohomish Marine Resources Committee ( https://www.conservationgateway.org/ConservationPlanning/ActionPlanning/Pages/conservation-action-plann.aspx ) https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/807/Aquatic-Habitat
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Remove a greater amount of shoreline armoring than new armoring added in the LIO’s marine nearshore, and shorelines of Lake Washington, and Lake Sammamish (pg. 25).
o Restore 10,700 feet of marine shoreline and 7 pocket estuaries, and protect 4 miles of marine shoreline (pg. 25).
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• A (drift cell),
• B (estuaries),
• D (riparian and instream habitat),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Table 7. Barrier 1 and Table 8. Gap 1 and 2. Pages 45, 46, and 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA3.4', 4, N'SA3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (89, 1089, 128, N'SHELL 1.1 Protect intact marine ecosystems, particularly in sensitive areas and for sensitive speci…', N'#60AA3E', N'Protect intact marine ecosystems, particularly in sensitive areas and for sensitive species
*Desired Outcome
Conservation of marine environments that provide sensitive, rare, or unique habitats; culturally and historically important sites; recreational and commercial fisheries; and recreational enjoyment of Puget Sound
*Policy Needs

*Example Actions

*Proposal Guidance
Actions may include climate risk assessment
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.0 Protect and improve Hood Canal water quality (LIO ERP pg. 35)
Additional guidance:
– Consult HCCC Regional PIC Program and local jurisdictions water quality programs to prioritize areas for conservation 
– Engage salmon recovery partners to consider shellfish/salmon projects interactions
– Engage HCCC staff to facilitate partner coordination, utilize tools and resources, as needed
– Consult HCCC guidance for updating Hood Canal and Eastern Strait of Juan de Fuca summer chum salmon recovery goals
– Consult HCCC staff on Hood Canal Shellfish Initiative efforts http://hccc.wa.gov/sites/default/files/resources/downloads/Guidance for Updating SumChum Goals_FINAL_1.pdf
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for Nearshore protection and restoration (SSLIO 01.1 and 01.2, pages 40-41). -Project proponents should coordinate efforts with the local MRC. -refer to Response Strategy in development associated with pending downgrade in Port Susan Bay https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Continue work in Vashon Marine Recovery Area, make measurable progress toward potentially expanding Vashon Marine Recovery Area and creating a Poverty Bay Recovery Area (pg. 27). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• F (enhance native fish and shellfish) - Note: This Local Strategy is included in an effort conserve and expand sensitive and rare Olympia oyster bed habitats as culturally and historically important sites to Tribal and non-Tribal communities within the Strait Action Area;
• J (stormwater management and pollutant source control) - Note: This Local Strategy is included in an effort to prevent release of toxic contaminants (such as, legacy oil tank toxic releases and land application of sewage sludge) that may damage culturally and historically important Tribal and non-Tribal shellfish sites within the Strait Action Area.
• K (water quality clean up plans) - Note: This Local Strategy is included in an effort to protect shellfish beds, that are culturally and historically important sites to Tribal and non-Tribal communities within the Strait Action Area, from toxic and nutrient contaminant releases (such as, resulting from residential, farm, and forest pesticide and fertilizer applications);
• L (oil spills) - Note: This Local Strategy is included in an effort to protect culturally and historically important Tribal and non-Tribal shellfish sites within the Strait Action Area from toxic contaminant releases (i.e., large oil spills); and/or
• M (education) - Note: This Local Strategy is included in an effort to protect, by implementing educational activities, culturally and historically important Tribal and non-Tribal shellfish sites within the Strait Action Area from toxic and nutrient contaminant releases (such as, involving boaters and other shoreline activities that may result in small oil spill releases; large oil spills. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 2.1. See pages 31 and 86. 
**Whatcom
Applicable –See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SHELL1.1', 1, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (100, 1100, 128, N'SHELL 1.5 Ensure compliance with programs that reduce, control or eliminate pollution …working farms', N'#60AA3E', N'Ensure compliance with regulatory programs designed to reduce, control or eliminate pollution from working farms.
*Desired Outcome
Programs that control and prevent water pollution from farming activities will help to reduce and/or eliminate nutrient and bacteria discharges from pastures, manure storage facilities, and land application of manure and processed wastewater into surface water and/or to minimize these from leaching into groundwater.
*Policy Needs

*Example Actions

*Proposal Guidance
Actions should focus on reducing bacterial discharge. Working farms are places where agricultural activities occur and are not based on the size or number of animals. Strategies to improve compliance with water quality protection by permitted Confined Animal Feeding Operations (CAFOs) and dairies (Dairy Nutrient Management Program, or DNMP) should be considered, but non-point sources (pasture based, hobby and small livestock operations) should not be overlooked.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections
Additional guidance:
– Coordinate with local Conservation Districts
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC and member jurisdictions to build on existing pollution control efforts, use existing data to prioritize areas 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for Non-Point Source Assessment and Product Stewardship (SSLIO 05.1 pg. 46), Outreach for Stormwater Stewardship (SSLIO 04.1 pg. 44-45). -refer to locally established PIC programs (i.e. the Lower Stillaguamish PIC-NTA 2016-0395) -refer to 2016 NTAs mapped to the LIO strategies for example projects https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 11.2. See pages 32 and 88. 
**Whatcom
Applicable – See Local Context
Refer to Whatcom LIO Plan strategies:
• Improve compliance with existing regulations, laws, and permits (WHATCOM-RC-CROSS06)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
• Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues (WHATCOM-RC-CROSS02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.5', 5, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (101, 1101, 128, N'SHELL 1.6 Effectively manage and control pollution from small onsite sewage systems.', N'#60AA3E', N'Effectively manage and control pollution from small onsite sewage systems
*Desired Outcome
Programs for onsite sewage systems (OSS) and state requirements for local health jurisdictions to carry out comprehensive plans that ensure OSS are properly managed to protect public health and sensitive waters. This approach also addresses marine recovery areas with existing OSS that are degrading shellfish growing areas or marine waters where low dissolved-oxygen levels or fecal coliform are a concern, or where nitrogen has been identified as a contaminant of concern.
*Policy Needs

*Example Actions

*Proposal Guidance
Actions should focus on fecal coliform concerns. Consider opportunities to assess climate risk in relevant guidance, permitting and education to homeowners. 
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25) (LIO ERP pg. 56, App. A pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.2 Improve planning and regulatory frameworks for water quality protection (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
Additional guidance:
- Engage HCCC and local jurisdictions to coordinate with existing monitoring efforts (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results)
– Use strategic approach to monitoring activities, incorporating shellfish growing areas status, PIC program workplans, TMDL-listed streams, MRAs, and other priority areas http://hccc.wa.gov/content/pollution-identification-correction
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for On-site Sewage System Management (SSLIO 07.1 pg. 48). -This regional priority is currently being addressed by Snohomish County’s Financing Options for Healthy Onsite Sewage Systems (NTA 2016-0306). https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Continue work in Vashon Marine Recovery Area, make measurable progress toward potentially expanding Vashon Marine Recovery Area and creating a Poverty Bay Recovery Area (pg. 27).
o Expand septic system management in priority TMDL areas (pg. 27).
o Make measurable progress towards fixing all onsite sewage systems in marine recovery areas and other areas, with equivalent enhanced operation and maintenance programs within our LIO until systems are inventoried and all failed systems are fixed (pg. 27-28). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 21.4. See pages 30 and 84. 
**Whatcom
Applicable – See Local Context
Refer to Whatcom LIO Plan strategies:
• Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues (WHATCOM-RC-CROSS02)
• Implement and expand incentive/cost share programs (WHATCOM-RC-CROSS09)
• Education and Outreach (WHATCOM-RC-CROSS07)
• Control sources of pollutants (WHATCOM-RC-WQ02)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
• Source ID and BMP effectiveness monitoring (WHATCOM-RC-SHELL03)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.6', 6, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (67, 1067, 121, N'FUND 1.2 Explore and utilize new sources of funding, and enhance existing sources of funding.', N'#c9cacb', N'Explore and utilize new sources of funding, and enhance existing sources of funding.
*Desired Outcome
Different funding mechanisms and sources for recovery are developed, and existing sources are enhanced.
*Policy Needs

*Example Actions
Research and analyze models for accessing new sources of funding.
*Proposal Guidance
Proposals may address Puget Sound recovery as a whole, multiple Vital Signs, or creative approaches for a specific Vital Sign.
*Local Context
**South Sound
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**Hood Canal
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**Island
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**San Juan
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**Snohomish/Stillaguamish
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**SouthCentral
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**Strait
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**West Central
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45
**Whatcom
Applicable.  Please refer to LIO ecosystem recovery plans and contact LIO coordinator with questions. https://pspwa.box.com/s/it793ts6bmla22n9joevcalaol3buo45', N'FUND1.2', 2, N'FUND1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (68, 1068, 122, N'LDC 1.1 Gain a better understanding of current habitat conditions.', N'#8228BF', N'Gain a better understanding of current habitat conditions.
*Desired Outcome
Based on enhanced understanding of ecologically important lands, protection and restoration efforts are directed to areas where actions will have a high impact.
*Policy Needs

*Example Actions
• Define lands that are important for ecological function.
• Develop an agreed upon understanding of all ecologically important land that includes designated critical areas. 
• Quantify the ecosystem services of ecologically important areas.
*Proposal Guidance
• Note, “ecologically important areas” is a generic term that, once defined, can support restoration or protection prioritization. It may include critical areas. 
• Describe the datasets and protocols that will be used (such as High Resolution Change Detection, WDFW Ecological Integrity Monitoring, etc.). 
• Describe how your project will identify interpretations and/or apply definitions of critical areas and/or ecologically important lands. Consider including existing definitions (such as critical habitat for state-listed species in DFW Priority Habitat Species data, and unstable slopes from Washington Geologic Survey) and multiple partners.
• Describe how additional data collection will be used to improve decision-making.
• Describe who the intended users of the final product will be and how they will engage in the project.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.1 Prioritize forest lands and open space for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
Additional guidance:
– Engage HCCC
– Utilize HCCC Protected Lands GIS tool
– Consult HCCC’s guidance for prioritizing salmonid stocks, issues, and actions http://hccc.wa.gov/sites/default/files/resources/downloads/HCCC Guidance for Prioritization v03-16-15 _0.pdf
**Island
Addressed, no NTAs needed 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 02.1 Integrated Planning (page 42) -Refer to approved hydrologic and geomorphology studies in the LIO - Stillaguamish Temperature TMDL Adaptive Assessment and Implementation Project and related planning documents (https://snohomishcountywa.gov/Archive.aspx?AMID=73). -see Snohomish Basin Protection Plan -see reach scale planning efforts in Snohomish and Stillaguamish basins https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/Archive.aspx?AMID=73
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
•  In WRIA10: See Pierce County Biodiversity Network Assessment https://www.co.pierce.wa.us/documentcenter/view/3929
• See also Salmon Recovery Lead Entity WRIA 10 Salmon Habitat Protection and Restoration Strategy https://www.co.pierce.wa.us/documentcenter/view/3929
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC1.1', 1, N'LDC1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (69, 1069, 122, N'LDC 1.2 Gain understanding of the social, economic and political factors currently affecting habita…', N'#8228BF', N'Gain a better understanding of the social, economic, and political factors currently affecting habitat.
*Desired Outcome
Enhanced understanding of regulations, land use, population growth, and land conversion enables improvements to protection and restoration efforts.
*Policy Needs

*Example Actions
• Determine the lands at risk of conversion by aligning the Urban Growth Areas with watershed characterization data and salmon recovery planning to identify solutions to various risks.
• Identify jurisdictional context in the landscape
• Compile and contrast how different jurisdictions protect critical habitat, parks, and open space.
• Review the local development code for barriers to infill development, and revisions to remove those barriers or encourage infill development – a “code scrub”.
*Proposal Guidance
• Describe how your project will propose opportunities for alignment or efficiencies of existing plans, permitting processes, or regulations if focusing on infill.
• Describe how you will use mapped areas (WDFW High Resolution Change Detection, Commerce Permit Mapping, Ecology PS Watershed Characterization, population growth projections, and/or hydrologic models) if doing geo-spatial work. 
• Describe how additional data collection will be used to improve decision-making.
• Describe who the intended users of the final product will be and how they will engage in the project.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, no additional info. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 02.1 Integrated Planning follows enable, design, and implement approach. Map overlays should build off existing efforts (i.e. Snohomish County Planning and Development Services iGallery: (http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default) -encourage change analyses evaluating the relationship between population growth and land conversion -refer to Stillaguamish and Tulalip Tribe assessments of regulatory alignment (i.e. Death by a Thousand Cuts: An Examination of regulation enforcement in the Stillaguamish Watershed and the effects on ESA-listed Chinook Salmon and Tulalip Tribes Briefing Document: Joint Conference Pilot for Regulatory Harmonization in the Snohomish Basin)  -Refer to regulatory, enforcement, and implementation gaps and barriers listed in Table 7 (page 62) of the Final Ecosystem Recovery Plan. Actions to address barriers should be focused on pre-identified barriers within the LIO. -see the Regional Open Space Conservation Plan and related tools; (https://snohomishcountywa.gov/Archive.aspx?AMID=73). https://snohomishcountywa.gov/DocumentCenter/View/44939

http://gismaps.snoco.org/HtmL05Viewer/Index.html?configBase=http://gismaps.snoco.org/Geocortex/Essentials/REST/sites/MapApp_v3/viewers/MapApp_HTML/virtualdirectory/Resources/Config/Default
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Achieve no net loss of forest cover (pg. 24). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat),
• E (fish passage and excess sediment), and/or
• H (shoreline and land use). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88. Table. 8. Gap 2, Page 47 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC1.2', 2, N'LDC1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (70, 1070, 122, N'LDC 1.3 Gain understanding of future social, economic, and political factors affecting habitat…', N'#8228BF', N'Gain a better understanding of future social, economic, and political factors (such as population growth) that will affect habitat.
*Desired Outcome
Improved understanding of areas under pressure for conversion, areas suitable for development, and human needs enables improved planning for population growth.
*Policy Needs

*Example Actions
• Identify areas suitable for more compact development and develop subarea plans within Urban Growth Areas.
• Develop decision support tools to understand drivers of past, present and future land-use change.
• Develop ecosystem services metrics and values which connect ecological functions to human well-being.
*Proposal Guidance
• Describe the datasets and protocols that will be used. 
• Describe how you will coordinate with partners conducting ongoing work (such as Department of Commerce). Consider partnerships that bundle data analysis with an application or implementation effort. 
• Describe how you will consider environmental justice, transportation, and housing affordability implications in the project.
• Describe who the intended users of the final product will be and how they will engage in the project.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal.
Additional guidance:
– Engage HCCC and its Hood Canal Community and Environmental Policy Assessment effort
– Engage local jurisdictions planning departments 
**Island
Applicable, no additional info. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to LIO Plan SSLIO 08.1 (page 49) -NTA 2016-0391 supports this work and is mapped to the LIO strategy pathway. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
Maintain UGA line and ensure that ≥87% of growth occurs within UGA (pg. 24). 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• E (fish passage and excess sediment),
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86.
Table 8. Gap 1. Page 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC1.3', 3, N'LDC1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (71, 1071, 122, N'LDC 1.4 Increase human and technical capacity of staff for planning, implementation, and enforcement', N'#8228BF', N'Increase human and technical capacity of staff for planning, implementation, and enforcement
*Desired Outcome
Dedicated staff are resourced and empowered to implement land use regulations and adaptively manage or enforce land use regulations.
*Policy Needs

*Example Actions
• Develop a local government critical areas monitoring and adaptive management program.
• Fund dedicated staff time for monitoring and adaptive management.
• Fund technical training for staff to monitor and adaptively manage the critical area ordinance.
• Fund training for staff to better implement the critical areas ordinance based on monitoring results.
*Proposal Guidance
• Describe how your project will use state guidance to develop and implement a critical areas monitoring and adaptive management program (such as Department of Commerce Critical Areas Assistance Handbook chapter on Monitoring and Adaptive Management).
• If proposing staff technical training on monitoring and adaptive management or permit implementation, describe how the training will increase jurisdictional capacity.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies.
Additional guidance:
Consult with HCCC to identify potential capacity support and/or resources 
**Island
Applicable, no additional info. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• H (shoreline and land use); and/or
• I (climate change).
Special Emphasis: Identified Barriers (Table 5) to accomplishing ecosystem recovery:
• Limited staff capacity to implement actions; and
• Limited coordination capacity 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88.
Table 8. Gaps 1. Page 46. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC1.4', 4, N'LDC1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (72, 1072, 123, N'LDC 2.1 Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or…', N'#8228BF', N'Collaborative, multi-benefit groups develop a plan that prioritizes locations to restore or protect
*Desired Outcome
Broadly supported strategies, policies, and programs use available data to protect ecologically important lands.
*Policy Needs

*Example Actions
• Develop multi-stakeholder forums to develop consensus around locations to restore or protect.
• Share data on current ecological and human context and future ecological and human context to inform decisions.
• Develop or enhance TDR and PDR programs to conserve habitat and working lands. 
• Develop a subarea plan for a regional growth center under VISION 2040, or other designated urban center, that incorporates a mix of uses, affordable housing, and an area-wide stormwater strategy.
• Form a buffer task force that provides technical assistance and incentives to landowners.
*Proposal Guidance
• Describe how enabling factors and barriers have been addressed to allow for successful planning.
• Describe the dataset, protocols and analyses that will be used and how your project will coordinate with partners conducting ongoing work (such as Regional Open Space Strategy, Department of Commerce Critical Areas Assistance Handbook).
• Describe the communications and outreach strategy that will be used to bring in the relevant stakeholder groups and the facilitation plan for conflict resolution.
• Describe how climate change projections will be incorporated into the planning process.
• Consider developing subarea plans for urban centers that include a mix of uses to accommodate growth, and provide access to services, transit, and neighborhood amenities.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1 Hood Canal Forests and Open Space Strategy (LIO ERP pg. 60, App. 4 pg. 29)
3.1.1 Prioritize forest lands for protection based on ecological value and risk of conversion (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 18 of 31)
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach L01-04
– Engage existing FPbD partners
– Utilize PSNERP, ESRP project plans and partners 
– Engage HCCC and member jurisdictions 
**Island
Applicable, no additional info. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Reference LIO Plan SSLIO Strategy 02.1 Integrated Planning (page 42). -Reach scale planning efforts on-going in the Snoqualmie, Stillaguamish and Snohomish watersheds. -Integrated multi-benefit plans should be developed with regulatory updates in mind so regulatory updates are not separate from recovery planning efforts -refer to ecosystem services evaluations, in progress or developed (i.e. Open Space Valuation for Central Puget Sound).  -refer to reach scale plans for Lower Skykomish, Lower Snohomish, and Lower Stillaguamish reaches. -Also, applicable Conservation and Protection Plans in the LIO basins (i.e. the Snohomish Basin Protection Plan). - Local Critical Area Regulations (CAR) Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat), Shoreline Master Programs, and Comprehensive Plans. -Refer to SLS/FFF and reach scale plans in development for the Lower Skykomish, Lower Snohomish, and Lower Stillaguamish, -Conflicting Values/Concerns and Goals in gaps and barriers table 6 -Refer to 2016 NTAs mapped to strategy 02.1 https://snohomishcountywa.gov/807/Aquatic-Habitat https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context.
• In WRIA10: such as LWR Biodiversity Stewardship Interjurisdictional Quarterly meetings, Floodplains by Design, and Regional Conservation Partnership Program; TDR/PDR program. https://www.co.pierce.wa.us/4684/Floodplains-for-the-Future

https://www.nrcs.usda.gov/wps/portal/nrcs/detail/national/programs/farmbill/rcpp/?cid=nrcseprd1308280

https://www.co.pierce.wa.us/3268/TDRPDR
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• E (fish passage and excess sediment),
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86
Table 8. Gap 1 and 2. Pages 46 and 47.  Table 7. Barrier 1 and Table 8. Gaps 1 and 2. Pages 45, 46, and 47 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies may include:
• Develop Integrated Floodplain Management Plan (WHATCOM-RC-HAB03), which has been initiated (contact Paula Harris, Whatcom County River and Flood Division)
• Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues (WHATCOM-RC-CROSS02)
• Develop and implement watershed-scale plans (WHATCOM-STRAT-CROSS04)
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submission of NTA.', N'LDC2.1', 1, N'LDC2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (73, 1073, 123, N'LDC 2.2 Address barriers to improve implementation plans, policies, and regulations.', N'#8228BF', N'Address barriers to improve implementation plans, policies, and regulations
*Desired Outcome
Transparent, effective, clear, and consistent implementation and enforcement of regulations enables improved protection of ecologically important areas.
*Policy Needs

*Example Actions
• Incorporate prioritization plans for ecologically important areas into comprehensive plan and development regulation updates.
• Fund comprehensive plan and development regulation updates that incorporate watershed processes.
• Incorporate policies to avoid ecologically important areas in county and comprehensive plans under the Growth Management Act.
• Develop policy and planning approaches to harmonize definitions of ecologically important areas, including Critical Areas Ordinance and how it is implemented in different jurisdictions. 
• Revise local government development regulations or implement identified solutions to remove barriers to infill.
*Proposal Guidance
• Describe how your project will improve implementation of plans, policies, permitting processes, and/or regulations. 
• Describe how your project will use guidance from existing work.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 32-37 describes priorities for prairie & oak woodland; pp 38-55 describes priorities for forest cover, fw riparian, and fish passage barriers. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies, suggested strategies include:
3.1.2 Promote land use policies that support ecological protections (LIO ERP pg. 60, App. 4 pg. 29) (HCCC Strategic Prioritization rank: 10 of 31)
3.1.2.1 Identify opportunities to align and improve land use protections across Hood Canal (LIO ERP pg. 60, App. 4 pg. 29)
Additional guidance:
– Demonstrate outcomes of Regional Priority Approach L01-06
– Engage HCCC and member jurisdictions
– Engage existing FPbD partners 
**Island
Applicable, no additional info. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. - See LIO Plan SSLIO 08.1 (page 49) -refer to Regulatory Inefficiency and Regulatory Inconsistency in gaps and barriers Table 6 (page 54). - Local Critical Area Regulations (CAR) Monitoring (i.e. https://snohomishcountywa.gov/807/Aquatic-Habitat), Shoreline Master Programs, and Comprehensive Plans, and TDR PDR programs. -Refer to Political Will/Support as a needed resource in LIO Plan gaps and barriers Table 7 (page 62), -Lack of Policymaker Engagement as a barrier in Table 6, -NTA 2016-0133 directly supports this work. https://snohomishcountywa.gov/DocumentCenter/View/44939

https://snohomishcountywa.gov/807/Aquatic-Habitat
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 23-24) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Land Development and Cover Short-Term Goal Statements are not complete; use the regional Vital Sign Indicator Targets noted above
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• D (riparian and instream habitat)),
• H (shoreline and land use); and/or
• I (climate change). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 1.1 and 2.1. See pages 31 and 86. Table 8. Gap 2. Page 47. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'LDC2.2', 2, N'LDC2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (82, 1082, 125, N'SA 1.5 Increase human and technical capacity of staff for planning, implementation, and enforcement.', N'#8228BF', N'Increase human and technical capacity of staff for planning, implementation, and enforcement
*Desired Outcome
Regulatory staff have training and access to technical resources and experts to efficiently implement and enforce existing regulations.
*Policy Needs

*Example Actions
• Increase training and technical support for regulatory staff.
• Develop peer-to-peer forums to share information and lessons learned and to provide opportunities to seek and provide advice.
• Establish mobile, regional, technical teams able to assist in local permitting decisions.
*Proposal Guidance
• Describe how your project will leverage existing programs (such as Coastal Training Program).
• If proposing staff training, describe how the training will increase jurisdictional capacity.
• Describe how your project will use best available guidance to support training (such as Ecology’s Soft Shore Stabilization (Gianou 2014); Ecology’s SMP Handbook; Marine Shoreline Design Guidelines).
• If a technical support team is developed, describe the expertise needed (such as licensed engineers and licensed geologists with coastal expertise) and how it will be obtained for the project.
• Consider opportunities to collaborate among regulatory agencies.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 72-80 describes priorities for feeder bluffs and shoreline armoring including mapped priority areas. http://www.healthysouthsound.org/south-sound-strategy/
**Hood Canal
Align with Hood Canal LIO Ecosystem Recovery Plan strategies.
Additional guidance:
Consult with HCCC to identify potential capacity support and/or resources 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 18 & 19 Table 3, 27, 28, 48 and 49. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 25-26) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Improve implementation, compliance, and enforcement of updated Shoreline Master Plans (pg. 25). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shoreline Armoring Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• H (shoreline and land use), and/or
• I (climate change).

Special Emphasis: Identified Barriers (Table 5) to accomplishing ecosystem recovery:
• Limited staff capacity to implement actions; and
• Limited coordination capacity 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6. See pages 32 and 88.
Table 8. Gap 1. Page 46. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO prior to submitting NTA', N'SA1.5', 5, N'SA1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (90, 1090, 128, N'SHELL 1.10 Support implementation of Total Maximum Daily Load (TMDL) studies and other necessary wa…', N'#60AA3E', N'Support implementation of Total Maximum Daily Load (TMDL) studies and other necessary water cleanup plans for Puget Sound to set pollution discharge limits and determine response strategies to address water quality impairments
*Desired Outcome
TMDLs are implemented, water quality is improved.
*Policy Needs

*Example Actions

*Proposal Guidance
This approach helps support marine and fresh water quality through development and implementation of TMDL studies or local pollution control plans that identify pollution sources and corrective actions to address identified problems. The TMDL process complements other strategies to control sources and pathways of excess nutrients and toxic chemicals from entering Puget Sound. The priority focus is on implementation of TMDLs, not development of TMDLs.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
Additional guidance:
- Engage with HCCC and member jurisdictions to coordinate monitoring activities with existing efforts and plans 
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -Refer to existing TMDLs (i.e. the Stillaguamish River Watershed Fecal Coliform, DO, pH, Mercury, and Arsenic TMDL) in the LIO basins https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control); and/or
• K (water quality clean up plans). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 9.6. See pages 32 and 88. 
**Whatcom
Applicable – See Local Context
Relevant Whatcom LIO Plan strategy WHATCOM-WQ-07 (Complete TMDL studies and implement TMDL plans)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.10', 10, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (91, 1091, 128, N'SHELL 1.11 Develop and implement local and tribal pollution identification and correction (PIC) pro…', N'#60AA3E', N'Develop and implement local and tribal pollution identification and correction (PIC) programs
*Desired Outcome
Local PIC programs are implemented that determine the causes and sources of water pollution in specific geographical areas, ensure corrective actions are taken to address the pollution sources, and protect Puget Sound marine and fresh water health.
*Policy Needs

*Example Actions

*Proposal Guidance
PIC programs with a high probability of success include the following essential elements:
-Consistent, long term, ambient water quality monitoring to prioritize projects and evaluate action effectiveness
-Coordinated outreach about proposed PIC projects and results to increase community awareness, participation and support.
-Source identification sampling
-Provision of information, site inspection, technical assistance and financial support to correct identified sources of pollution.
-Effective enforcement capability. Enforcement is used when compliance efforts fail.
-Sustainable funding to maintain long-term stability of the program.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
2.1.1.1 Implement Hood Canal Regional PIC Program
Additional guidance:
- Engage HCCC and member jurisdictions
- Coordinate efforts with Hood Canal Regional Pollution Identification and Correction Program (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results) http://hccc.wa.gov/content/pollution-identification-correction
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategy 05.1 Non-point Source Assessment and Product Stewardship (page 46). Strategies 04.1 (page 44) and 06.1 (page 47) are intended to work in combination to achieve outreach and education around stormwater management best practices and incentives for legacy retrofits and LID. -Reference 2016 NTA for implementation of the Lower Stillaguamish PIC program (mapped to several of the strategies referenced above). --refer to locally established PIC programs (i.e. the Lower Stillaguamish PIC-NTA 2016-0395) https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 21.4. See pages 30 and 84. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies include:
• Source ID and BMP effectiveness monitoring (WHATCOM-STRAT-SHELL03)
• Coordinate shellfish protection and recovery efforts (WHATCOM-RC-SHELL01)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
• Improve compliance with existing regulations, laws, and permits (WHATCOM-RC-CROSS06)
• Implement and expand incentive/cost share programs (WHATCOM-RC-CROSS09)
• Education and Outreach (WHATCOM-RC-CROSS07)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.11', 11, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (99, 1099, 128, N'SHELL 1.4 Promote voluntary and incentive-based programs that help working farms contribute to Puge…', N'#60AA3E', N'Promote voluntary and incentive-based programs that help working farms contribute to Puget Sound recovery
*Desired Outcome
Programs, guidelines, and technical assistance opportunities will help farmers identify potential pollution impacts from farming activities and implement best management practices (BMPs) to reduce, control, or eliminate pollution.
*Policy Needs

*Example Actions

*Proposal Guidance
Working farms are places where agricultural activities occur and are not based on the size or number of animals. Consider multi-benefit BMPs that contribute to climate resiliency and/or contribute to carbon capture.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.1 Homeowner outreach and education on private property water quality protections
Additional guidance:
– Coordinate with local Conservation Districts
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Engage HCCC and member jurisdictions to build on existing pollution control efforts, use existing data to prioritize areas 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for Non-Point Source Assessment and Product Stewardship (SSLIO 05.1 pg. 46), Outreach for Stormwater Stewardship (SSLIO 04.1 pg. 44-45). -refer to 2016 NTAs mapped to the LIO strategies for example projects https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education) 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 26.3 and 26.5. See pages 31, 32, and 83 
**Whatcom
Applicable – See Local Context
Refer to Whatcom LIO Plan strategies:
• Implement and expand incentive/cost share programs (WHATCOM-RC-CROSS09)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.4', 4, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (92, 1092, 128, N'SHELL 1.12 Restore and enhance native shellfish populations.', N'#60AA3E', N'*Restore and enhance native shellfish populations
*Note  approaches SHELL1.12- 1.16 are not priority approaches in the Shellfish Bed Implementation Strategy but are important to shellfish recovery broadly (previously Tier 2 2016 Action Agenda Sub-strategi
*Desired Outcome
Support efforts to protect and restore native shellfish species, focusing on two species: native Olympia oysters and pinto abalone
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
4.3 Protect and restore Hood Canal shellfish populations (LIO ERP pg. 65, App. 4 pg. 34) (HCCC Strategic Prioritization rank: 14 of 31)
4.3.1 Restore native shellfish populations (HCCC Strategic Prioritization rank: 4 of 31)
Additional guidance:
- Engage with existing shellfish restoration efforts to learn from progress made in Hood Canal and elsewhere in Puget Sound
- Engage tribal co-managers in project planning to ensure protection of tribal treaty rights
- Consult WDFW in project planning to coordinate potential efforts at sites, gather information on past efforts
- Coordinate with HCCC to identify any potential interactions with current or planned salmon recovery projects
- Coordinate with any impacted shellfish growers in area 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Not applicable as we do not have either species in the LIO. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• F (enhance native fish and shellfish) - Note: This Local Strategy is included in an effort to protect and restore sensitive and rare Olympia oysters within the Strait Action Area 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 17.2. See pages 32 and 89. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.12', 12, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (93, 1093, 128, N'SHELL 1.13 Ensure environmentally sustainable shellfish aquaculture based on sound science.', N'#60AA3E', N'*Ensure environmentally sustainable shellfish aquaculture based on sound science
*Note  approaches SHELL1.12- 1.16 are not priority approaches in the Shellfish Bed Implementation Strategy but are important to shellfish recovery broadly (previously Tier 2
*Desired Outcome
Efforts to clarify the potential impacts of shellfish aquaculture are supported, and communities are helped to build consensus and collaboration about the role of shellfish aquaculture in Puget Sound
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
4.0 Hood Canal Shellfish Initiative (LIO ERP pg. 65, App. 4 pg. 34)
4.1 Develop and implement Hood Canal Shellfish Initiative Action Plan (LIO ERP pg. 65, App. 4 pg. 34) (HCCC Strategic Prioritization rank: 2 of 31)
4.2 Support ecological sustainable commercial shellfish operations in Hood Canal (LIO ERP pg. 65, App. 4 pg. 34) (LIO ERP pg. 65, App. 4 pg. 34)
Additional guidance:
- Engage HCC and member jurisdictions
- Coordinate with HCCC’s Hood Canal Shellfish Initiative effort 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, no additional information. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.13', 13, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (94, 1094, 128, N'SHELL 1.14 Monitoring to understand the specific environmental conditions that produce harmful alga…', N'#60AA3E', N'*Research and implement monitoring to understand the specific environmental conditions that produce harmful algal blooms (HABs) and pathogen events
*Note  approaches SHELL1.12- 1.16 are not priority approaches in the Shellfish Bed Implementation Strategy
*Desired Outcome
The risks to human health are minimized and economic losses to Puget Sound fisheries are reduced
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.2 Investigate low dissolved oxygen content in Hood Canal marine waters (LIO ERP pg. 38)
2.2.1 Assess impacts of water circulation impediments in Hood Canal (HCCC Strategic Prioritization rank: 30 of 31)
2.2.2 Form research agenda to investigate knowledge gaps related to low-dissolved oxygen in Hood Canal (HCCC Strategic Prioritization rank: 26 of 31)
4.1 Develop and implement Hood Canal Shellfish Initiative Action Plan (LIO ERP pg. 65, App. 4 pg. 34) (HCCC Strategic Prioritization rank: 2 of 31)
4.2 Support ecological sustainable commercial shellfish operations in Hood Canal (LIO ERP pg. 65, App. 4 pg. 34)
Additional guidance:
- Engage HCCC and member jurisdictions, in development of the Hood Canal Shellfish Initiative, to identify specific threats and research needs to support a sustainable Hood Canal shellfish industry
- Coordinate with existing efforts to assess impacts of Hood Canal Bridge
- Build on Hood Canal Dissolved Oxygen Project results 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• I (climate change);
• J (stormwater management and pollutant source control); and/or
• K (water quality clean up plans).

Note: HAB monitoring is specifically cited as a Barrier under each of the above Local Strategy Results Chains 
**West Central
Applicable, no additional information. 
**Whatcom
Applicable – See Local Context 
Relevant LIO Plan strategies and substrategies include:
• Source ID and BMP effectiveness monitoring (WHATCOM-STRAT-SHELL03)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.14', 14, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (95, 1095, 128, N'SHELL 1.15 Support and expand marine biotoxin monitoring.', N'#60AA3E', N'*Support and expand marine biotoxin monitoring
*Note  approaches SHELL1.12- 1.16 are not priority approaches in the Shellfish Bed Implementation Strategy but are important to shellfish recovery broadly (previously Tier 2 2016 Action Agenda Sub-strategies)
*Desired Outcome
The risks to human health are minimized and economic losses to Puget Sound fisheries are reduced
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
4.1 Develop and implement Hood Canal Shellfish Initiative Action Plan (LIO ERP pg. 65, App. 4 pg. 34) (HCCC Strategic Prioritization rank: 2 of 31)
4.2 Support ecological sustainable commercial shellfish operations in Hood Canal (LIO ERP pg. 65, App. 4 pg. 34)
Additional guidance:
– Engage HCCC and member jurisdictions, in development of the Hood Canal Shellfish Initiative, to identify specific threats and research needs to support a sustainable Hood Canal shellfish industry 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, no additional information. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.15', 15, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (108, 1108, 132, N'TIF 4.1 Use a source control approach to assess and regulate local sources of air pollution.', N'#01B499', N'Use a source control approach to assess and regulate local sources of air pollution
*Desired Outcome
Reduce air deposition from stationary air pollution sources.
*Policy Needs
Explore opportunities to adapt state air quality policy to better recognize and regulate emissions that contribute to water-quality problems. And, explore possibilities to change state air quality regulatory guidance on monitoring thresholds, and consider cumulative impacts.
*Example Actions
• Implement community-based air quality monitoring.
• Conduct research.
• Assess the impacts from changing monitoring thresholds and cumulative impacts.
*Proposal Guidance
The SI Advisory Team wanted to note the significant environmental justice implications of stationary sources regarding underrepresented or disadvantaged communities disproportionately bearing the burdens of industrial air pollution.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality including stormwater efforts. 
 
**Hood Canal
Applicable, no additional info.  
**Island
Not Applicable 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Not applicable. Regional priority is not a local priority for this LIO. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign, and pg. 26-27, Toxics in Fish Vital Sign descriptions) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, no additional info.  
**West Central
Not applicable.  
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'TIF4.1', 4, N'TIF4')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (96, 1096, 128, N'SHELL 1.16 Embrace strategies to address ocean acidifications impacts on shellfish.', N'#60AA3E', N'*Embrace strategies to address ocean acidifications impacts on shellfish
*Note  approaches SHELL1.12- 1.16 are not priority approaches in the Shellfish Bed Implementation Strategy but are important to shellfish recovery broadly (previously Tier 2 2016 Act
*Desired Outcome
The risks to human health are minimized, and economic losses to Puget sound fisheries are reduced.
*Policy Needs

*Example Actions

*Proposal Guidance
Coordinate with the Marine Resources Advisory Committee and Blue Ribbon Panel recommendations.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
4.1 Develop and implement Hood Canal Shellfish Initiative Action Plan (LIO ERP pg. 65, App. 4 pg. 34) (HCCC Strategic Prioritization rank: 2 of 31)
4.2 Support ecological sustainable commercial shellfish operations in Hood Canal (LIO ERP pg. 65, App. 4 pg. 34)
Additional guidance:
- Engage HCCC and member jurisdictions, in development of the Hood Canal Shellfish Initiative, to identify specific threats and research needs to support a sustainable Hood Canal shellfish industry 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• I (climate change).

Note: Ocean Acidification (OA) is specifically cited as a Barrier-Capacity issue under this Local Strategy Results Chain. 
**West Central
Applicable, no additional information. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.16', 16, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (97, 1097, 128, N'SHELL 1.2 Control wastewater and other sources of pollution from boats and vessels.', N'#60AA3E', N'Control wastewater and other sources of pollution from boats and vessels
*Desired Outcome
Establish a No Discharge Zone for Puget Sound, provide support for the associated rule-making, sufficient and convenient pump-out capacity, and promote effective outreach and education programs that reduce pollution from vessels.
*Policy Needs

*Example Actions

*Proposal Guidance
Actions should focus on fecal pollution from vessels. See also Chinook Reional Priority 7 regarding oil spill prevention and preparedness.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25)
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.3 Public Outreach and education on water-based activities
Additional guidance:
– Engage HCCC and member jurisdictions
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Target high usage areas
– Coordinate strategic approach with existing efforts by Dept. of Ecology, tribes, local jurisdictions, and outreach organizations 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, no additional info. 
**SouthCentral
South Central: Applicable, see local context. 
• No local goals developed yet, but see Table 3 (pg. 26-27, Toxics in Fish Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, no additional info. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 21.4, 10.5, 20.2, and 26.3. See pages 30 and 84. 
**Whatcom
Applicable – See Local Context
Refer to Whatcom LIO Plan strategies:
• Education and Outreach (WHATCOM-RC-CROSS07)
• Control sources of pollutants (WHATCOM-RC-WQ02)
• Improve compliance with existing regulations, laws, and permits (WHATCOM-RC-CROSS06)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.2', 2, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (98, 1098, 128, N'SHELL 1.3 Increase compliance with and enforcement of environmental laws, regulations and permits.', N'#60AA3E', N'Increase compliance with and enforcement of environmental laws, regulations and permits
*Desired Outcome
Ensure compliance with environmental laws intended to prevent and control pollution from human and animal fecal pollution sources
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25)
2.1.4 Water Quality Outreach and Education (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 16 of 31)
2.1.4.3 Public Outreach and education on water-based activities
Additional guidance:
– Engage HCCC and member jurisdictions
– Build off/Integrate existing outreach and education efforts present in Hood Canal to reduce redundancy and audience fatigue
– Target high usage areas
– Coordinate strategic approach with existing efforts by Dept. of Ecology, tribes, local jurisdictions, and outreach organizations 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for Non-Point Source Assessment and Product Stewardship (SSLIO 05.1 pg. 46) and On-site Sewage System Management (SSLIO 07.1 pg. 48). -Lower Stillaguamish Pollution Identification and Correction Program is established in the Lower Stillaguamish. -PIC program and OSS management support TMDL compliance for fecal pollution sources. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategy: 9.6. See pages 32 and 88. 
**Whatcom
Applicable – See Local Context
Refer to Whatcom LIO Plan strategies:
• Improve compliance with existing regulations, laws, and permits (WHATCOM-RC-CROSS06)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
• Develop binding agreements to resolve water quantity, water quality, habitat and drainage issues (WHATCOM-RC-CROSS02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.3', 3, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (102, 1102, 128, N'SHELL 1.7 Effectively manage and control pollution from large OSS.', N'#60AA3E', N'Effectively manage and control pollution from large OSS.
*Desired Outcome
The state Department of Health’s permit regulations for large OSS systems with flows between 3,500 and 100,000 gallons per day are supported, as are requirements for protection of public health and the environment.
*Policy Needs

*Example Actions

*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25)
2.1.1 Monitor priority shoreline areas and streams for pollution and contaminants (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 5 of 31)
Additional guidance:
- Engage with HCCC and member jurisdictions to coordinate monitoring activities with existing efforts and plans 
- Coordinate efforts with Hood Canal Regional Pollution Identification and Correction Program (See Hood Canal Regional Pollution Identification and Correction Program guidance documents and results) http://hccc.wa.gov/content/pollution-identification-correction
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for On-site Sewage System Management (SSLIO 07.1 pg. 48). This regional priority is currently being partially addressed by Snohomish County’s Financing Options for Healthy Onsite Sewage Systems (NTA 2016-0306). https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 9.6 and 10.3. See pages 32, 84 and 88 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.7', 7, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (105, 1105, 129, N'TIF 1.1 Enhance pollutant reduction programs, corrective measures to prevent toxic chemicals from…', N'#01B499', N'Enhance pollutant reduction programs, corrective measures and increase authorities and programs to prevent toxic chemicals from entering Puget Sound.
*Desired Outcome
Reduce loading to Puget Sound of Toxics in Fish target contaminants, and explore opportunities to develop chemical action plans for endocrine disrupting target contaminants.
*Policy Needs
• Explore local Business license requirements, including trainig requirements
• PCBs—changes to federal regulations                                           
• Remove legal barriers to developing chemical action plans for endocrine disruptors.
*Example Actions
• Target chemical families are top chemicals of concerns in Puget Sound, Vital Sign chemicals and existing Chemical Action Plan chemicals.
• Implement Chemical Action Plans.
• Change behavior through a social marketing approach (identify a polluting audience/sector).                         
• Focus on source control/pollution prevention.
• Create Chemical Action Plan for EDCs
*Proposal Guidance
• Data collection may not be a priority except for in areas that are less studied such as the Snohomish basin.  NTA proponents should focus instead on using existing data and incorporate that into new efforts or planning processes. 
• Prioritize audiences by watershed needs.                   
• The focus here is on areas that are possibly under-resourced such as non-permittees.
• Encourage green purchasing.
• Tied to watershed planning—reducing impact of legacy development.
• Use watershed scale approaches when appropriate.
*Local Context
**South Sound
Applicable, no additional info.  
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25)
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.1 Reduce impacts of stormwater runoff from transportation and service corridors, and urbanized areas
Additional guidance:
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan
 http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, no additional info.  
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies 04.1 (Outreach for Stormwater Stewardship-page 44), 05.1 (Non-point Source Assessment and Product Stewardship-page 46), and 06.1 (stormwater Retrofit and LID-page 47) -social market approaches to implement green stormwater infrastructure projects and BMP’s -prioritize legacy retrofits and LID for new and redevelopment -implement investigation and correction (PIC) efforts -prioritize product stewardship strategies -refer to 2016 NTAs mapped to strategies 04.1 and 05.1 https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign, and pg. 26-27, Toxics in Fish Vital Sign descriptions) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Reduce toxics loading by treating 200 acres through retrofits (pg. 22).
o Seek (such as, through a future NTA) to develop a program to routinely sweep arterial streets with high efficiency sweepers and enroll jurisdictions in the South Central LIO in it. Develop specific targets, including effectiveness/adaptive management monitoring (pg. 23).
o Transition current Puget Sound Starts Here to conduct more targeted outreach that results in measurable behavior change (pg. 23).
 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the specific “Toxics in Fish” Vital Sign is not currently a priority for the Strait Action Area.  Our stormwater management and pollutant source reduction related Local Strategy Results Chain, Strait ID# J, however, is of great importance to the Strait ERN LIO, hence its’ inclusion here as part of a number of Local Context additions for some of the Toxics in Fish Regional Approaches.  Also, it’s important to point out that the Strait ID# J is included within the Local Context additions below in lieu of a fully developed Implementation Strategy for Marine Water Quality.  NTAs developed using the Strait ID# J Local Strategy Results Chain will eventually “cascade down” to improvements in the Toxics In Fish Vital Sign.  The “cascading benefits” from such NTAs should be well explained within the narrative portions of the NTA Factsheet for these NTAs.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.
Notes: 
The Strait Local Strategies Results Chains (including associated Local Approaches) cited within the Local Context column below for the regional Approach titled “Continue Toxics in Fish implementation strategy” within TIF5 below, are provided to offer spill-related information for consideration when finalizing the Toxics in Fish Implementation Strategy.

Strait Ecosystem Protection and Recovery Plan: 
o Toxics in Fish Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3 and 21.4; pages 30, 32, 82, and 84. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies include:
• Stormwater characterization and monitoring (WHATCOM-STRAT-WQ04). 
• Stormwater training and technical assistance (WHATCOM-WQ-09)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'TIF1.1', 1, N'TIF1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (106, 1106, 130, N'TIF 2.1 Address stormwater treatment.', N'#01B499', N'Address stormwater treatment
*Desired Outcome
Implement or research innovative treatment approaches.
*Policy Needs

*Example Actions
• Pilot innovative treatment approaches.
• Carry out research and effectiveness studies on treatment approaches/BMPs.
*Proposal Guidance

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality including stormwater efforts. 
 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.3 Reduce impacts from stormwater runoff (LIO ERP pg. 58, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 27 of 31)
2.1.3.1 Reduce impacts of stormwater runoff from transportation and service corridors, and urbanized areas
2.1.3.2 Reduce impacts of stormwater runoff from agricultural lands
Additional guidance:
- Engage HCCC and member jurisdictions
- Utilize HCCC Stormwater Retrofit Plan
 http://hccc.wa.gov/content/hood-canal-regional-stormwater-retrofit-plan
**Island
Applicable, no additional info.  
**San Juan
Applicable, no additional info.  
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies 06.1 (Stormwater Retrofit and LID-page 47). -Strategy 06.1 is intended to work in combination with strategies 04.1 (page 44) and 05.1 (page 46) directed at changing stormwater practices of private property owners and additional investigation and corrective measures directed at non-point source pollution. -refer to 2016 NTA’s mapped to strategies 04.1, 05.1 and 06.1 (see results chains on adjacent to strategy narratives-page numbers references above) https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign, and pg. 26-27, Toxics in Fish Vital Sign descriptions) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the specific “Toxics in Fish” Vital Sign is not currently a priority for the Strait Action Area.  Our stormwater management and pollutant source reduction related Local Strategy Results Chain, Strait ID# J, however, is of great importance to the Strait ERN LIO, hence its’ inclusion here as part of a number of Local Context additions for some of the Toxics in Fish Regional Approaches.  Also, it’s important to point out that the Strait ID# J is included within the Local Context additions below in lieu of a fully developed Implementation Strategy for Marine Water Quality.  NTAs developed using the Strait ID# J Local Strategy Results Chain will eventually “cascade down” to improvements in the Toxics In Fish Vital Sign.  The “cascading benefits” from such NTAs should be well explained within the narrative portions of the NTA Factsheet for these NTAs.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.
Notes: 
The Strait Local Strategies Results Chains (including associated Local Approaches) cited within the Local Context column below for the regional Approach titled “Continue Toxics in Fish implementation strategy” within TIF5 below, are provided to offer spill-related information for consideration when finalizing the Toxics in Fish Implementation Strategy.

Strait Ecosystem Protection and Recovery Plan: 
o Toxics in Fish Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3 and 21.4; pages 30, 32, 82, and 84. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies include:
• Fix problems caused by existing development (WHATCOM-RC-WQ05) 
• Control sources of pollutants (WHATCOM-RC-WQ02)
Local and Regional NTA owners should coordinate with Whatcom LIO', N'TIF2.1', 2, N'TIF2')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (107, 1107, 131, N'TIF 3.1 Provide infrastructure, incentives to accommodate new development and re-development in UGAs', N'#01B499', N'Provide infrastructure and incentives to accommodate new development and re-development within designated urban centers in Urban Growth Areas (UGA).
*Desired Outcome
Increase infill development to protect water quality, and increase the likelihood that re-developed areas will meet new, stricter stormwater management requirements.
*Policy Needs

*Example Actions
• Explore Brownfields re-development as a way to both remove contaminants, and to better accommodate growth in already affected areas.
• Consider reviewing the local development code for barriers to infill development, and revisions to remove those barriers or encourage infill development--a “code scrub.”
• Consider developing sub-area plans for designated urban centers that include a mix of uses to accommodate growth, and to provide access to services, transit, and neighborhood amenities. Up-front SEPA integrated with sub-area plans addresses environmental impacts area-wide, and provides incentives for development by streamlining the permit process.
*Proposal Guidance
• Density is a “BMP”—projects can be proposed under the B-IBI watershed. planning regional priority    
• EPA''s Smart Growth tools and guidance may be useful.
*Local Context
**South Sound
Applicable, no additional info.  
**Hood Canal
Applicable, no additional info.  
**Island
Applicable, no additional info.  
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan Strategy 08.1 Implementation of GMA Recognizing Puget Sound Recovery Goals. -reference 2016 NTAs mapped to strategy 08.1 (page 49) such as 2016-0391 https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign, and pg. 26-27, Toxics in Fish Vital Sign descriptions) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, see local context
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the specific “Toxics in Fish” Vital Sign is not currently a priority for the Strait Action Area.  Our stormwater management and pollutant source reduction related Local Strategy Results Chain, Strait ID# J, however, is of great importance to the Strait ERN LIO, hence its’ inclusion here as part of a number of Local Context additions for some of the Toxics in Fish Regional Approaches.  Also, it’s important to point out that the Strait ID# J is included within the Local Context additions below in lieu of a fully developed Implementation Strategy for Marine Water Quality.  NTAs developed using the Strait ID# J Local Strategy Results Chain will eventually “cascade down” to improvements in the Toxics In Fish Vital Sign.  The “cascading benefits” from such NTAs should be well explained within the narrative portions of the NTA Factsheet for these NTAs.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.
Notes: 
The Strait Local Strategies Results Chains (including associated Local Approaches) cited within the Local Context column below for the regional Approach titled “Continue Toxics in Fish implementation strategy” within TIF5 below, are provided to offer spill-related information for consideration when finalizing the Toxics in Fish Implementation Strategy.

Strait Ecosystem Protection and Recovery Plan: 
o Toxics in Fish Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 4.2, 1.1, and 2.1. See pages 31 and 86. 
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'TIF3.1', 3, N'TIF3')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (103, 1103, 128, N'SHELL 1.8 Improve and expand funding for small onsite sewage systems (OSS) and local OSS programs.', N'#60AA3E', N'Improve and expand funding for small onsite sewage systems (OSS) and local OSS programs
*Desired Outcome
Reliable sources of funding to support local OSS programs and homeowner assistance programs for repair or replacement of failing OSS are developed.
*Policy Needs

*Example Actions

*Proposal Guidance
The intent of this approach is to encourage development of NTAs that will result in sustainable funding for the following: 
• Local management of OSS programs, including advancement of the OSS target (for example, document the OSS, achieve compliance with inspections, and identify and repair or replace failures in locations with shellfish growing areas). 
• OSS financial assistance programs in areas with shellfish growing areas. 
• Identify and designate areas where enhanced OSS management is needed.

*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.1.2 Improve planning and regulatory frameworks for water quality protections (LIO ERP pg. 57, App. 4 pg. 25) (HCCC Strategic Prioritization rank: 23 of 31)
Additional guidance:
- Engage HCCC and member jurisdictions to coordinate efforts 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. -LIO Plan strategies for On-site Sewage System Management (SSLIO 07.1 pg. 48). -This regional priority is currently being partially addressed by Snohomish County’s Financing Options for Healthy Onsite Sewage Systems (NTA 2016-0306). https://snohomishcountywa.gov/DocumentCenter/View/44940
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context.
• South Central LIO’s goals include, but are not limited to the following:
o Expand septic system management in priority TMDL areas (pg. 27). 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• K (water quality clean up plans); and/or
• M (education). 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3 and 21.4; pages 30, 32, 82, and 84. 
**Whatcom
Applicable – See Local Context
NTA owners should coordinate with Whatcom LIO prior to submission of NTAs', N'SHELL1.8', 8, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (104, 1104, 128, N'SHELL 1.9 Improve water quality to prevent downgrades and achieve upgrades of shellfish harvesting…', N'#60AA3E', N'Improve water quality to prevent downgrades and achieve upgrades of important current tribal, commercial and recreational shellfish harvesting areas
*Desired Outcome
Regional and local programs that protect and improve water quality and control pollution, helping to prevent the degradation of healthy shellfish beds and to achieve upgrades of degraded shellfish beds.
*Policy Needs

*Example Actions

*Proposal Guidance
This approach can be used to address wastewater treatment plant (WWTP) upgrades, outfall changes, and other wastewater or stormwater infrastructure improvements or planning. Actions should focus on fecal coliform. Consider incorporation of climate change related planning (for extreme weather events and potential disruption to systems related to power outages”
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 104-109 describes work to reopen downgraded growing areas; pp 86-103 describe efforts to improve fresh and marine water quality. 
**Hood Canal
Applicable, see Local Context
HCCC strategies:
2.0 Protect and improve Hood Canal water quality (LIO ERP pg. 35)
2.1 Prevent pollution sources from entering Hood Canal marine and fresh waters (LIO ERP pg. 56, App. 4 pg. 25) (LIO ERP pg. 56, App. A pg. 25)
Additional guidance:
– Engage HCCC and member jurisdictions to coordinate efforts 
**Island
Applicable, see local context: ILIO Ecosystem Recovery Plan p. 19, 20, 21, 22, 23, 24, 29, 30, and 55. 
**San Juan
Applicable, no additional info. 
**Snohomish/Stillaguamish
Applicable, see local context: - Engage Snohomish-Stillaguamish LIO. Contact LIO Coordinator, Jessica Hamill, at jessica.hamill@snoco.org. LIO Plan strategies 04.1 Outreach for Stormwater Stewardship (page 44), 05.1 Non-point Source Assessment and Product Stewardship (page 46), and 06.1 Stormwater Retrofit and LID (page 47). -There are two commercial shellfish bed in the LIO: South Skagit Bay and Port Susan Bay. Both are located in the Stillaguamish basin whereas there are none in the Snohomish basin. There is a pending downgrade in a portion of Port Susan Bay. https://snohomishcountywa.gov/DocumentCenter/View/44939
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 27-28, Onsite Sewage Systems Vital Sign description) of South Central Ecosystem Recovery Plan for general background context. 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.

Strait Ecosystem Protection and Recovery Plan: 
○ Shellfish Bed Short-Term Goal Statements (see Table 2)
○ Gaps and/or Barriers (see Table 5)
○ Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• J (stormwater management and pollutant source control) - Note: This Local Strategy is included in an effort to prevent release of fecal coliform (such as, land application of sewage sludge) that may damage current tribal, commercial and recreational shellfish harvesting areas within the Strait Action Area. 
**West Central
Applicable, see local context. West Central LIO Ecosystem Recovery Plan; Recovery strategies: 10.3 and 21.4; pages 30, 32, 82, and 84. 
**Whatcom
Applicable – See Local Context
Relevant LIO Plan strategies and substrategies include:
• Source ID and BMP effectiveness monitoring (WHATCOM-STRAT-SHELL03)
• Improve compliance with existing regulations, laws, and permits (WHATCOM-RC-CROSS06)
• Provide technical assistance to reduce bacterial pollution (WHATCOM-RC-SHELL02)
• Education and Outreach (WHATCOM-RC-CROSS07)
• Stormwater characterization and monitoring (WHATCOM-STRAT-WQ04). 
Local and Regional NTA owners should coordinate with Whatcom LIO', N'SHELL1.9', 9, N'SHELL1')
GO
INSERT [dbo].[TaxonomyLeaf_Import] ([ID], [TaxonomyLeafID], [TaxonomyBranchID], [TaxonomyLeafName], [ThemeColor], [TaxonomyLeafDescription], [TaxonomyLeafCode], [TaxonomyLeafSortOrder], [TaxonomyBranchName]) VALUES (109, 1109, 133, N'TIF 5.1 Continue developing an Implementation Strategy for the Toxics in Fish Vital Sign.', N'#01B499', N'Continue developing an Implementation Strategy for the Toxics in Fish Vital Sign
*Desired Outcome
Identify priority strategies to achieve the targets for Toxics in Fish indicators.
*Policy Needs
Finish the Toxics in Fish Implementation Strategy process.
*Example Actions

*Proposal Guidance
This may be an opportunity to consider approaches to address spills, and possibly, specifically, spills on bridges.
*Local Context
**South Sound
Applicable, see local context. 
South Sound Strategy pp 86-96 describe efforts to improve fresh water quality including stormwater efforts. 
 
**Hood Canal
Applicable, no additional info.  
**Island
Applicable, no additional info.  
**San Juan
Not applicable 
**Snohomish/Stillaguamish
Applicable, no additional info.  
**SouthCentral
South Central: Applicable, see local context. 
• See Table 3 (pg. 22-23, Freshwater Quality Vital Sign, and pg. 26-27, Toxics in Fish Vital Sign descriptions) of South Central Ecosystem Recovery Plan for general background context.
 
**Strait
Applicable, see local context 
To properly use this Strait ERN LIO Local Context table of information when developing your NTA for the benefit of either 1 or 2 LIO geographies or 3 or more LIO geographies, one of which includes the Strait Action Area, please utilize the Strait ERN LIO NTA Development, Review, and Evaluation Process document.
All of the Strait ERN LIO Local Strategy Results Chains (Strait ID# A through M), in larger more usable format, as well as Table 2 and 5, referred to within the Strait ERN LIO Local Context column below, can be downloaded individually from this webpage link for convenience: https://pspwa.box.com/s/vs0bhkgi6tivp0fqd2ysuyvm0kudxm1r.  These items are an integral part of the Strait Ecosystem Protection and Recovery Plan.
While certainly applicable to the Strait Action Area, the specific “Toxics in Fish” Vital Sign is not currently a priority for the Strait Action Area.  Our stormwater management and pollutant source reduction related Local Strategy Results Chain, Strait ID# J, however, is of great importance to the Strait ERN LIO, hence its’ inclusion here as part of a number of Local Context additions for some of the Toxics in Fish Regional Approaches.  Also, it’s important to point out that the Strait ID# J is included within the Local Context additions below in lieu of a fully developed Implementation Strategy for Marine Water Quality.  NTAs developed using the Strait ID# J Local Strategy Results Chain will eventually “cascade down” to improvements in the Toxics In Fish Vital Sign.  The “cascading benefits” from such NTAs should be well explained within the narrative portions of the NTA Factsheet for these NTAs.  Ultimately however, which Regional Priority such an NTA would best target will require discussion with the Strait ERN LIO Coordinator, well before submission of the final NTA Factsheet.
Notes: 
The Strait Local Strategies Results Chains (including associated Local Approaches) cited within the Local Context column below for the regional Approach titled “Continue Toxics in Fish implementation strategy” within TIF5 below, are provided to offer spill-related information for consideration when finalizing the Toxics in Fish Implementation Strategy.

Strait Ecosystem Protection and Recovery Plan: 
o Toxics in Fish Short-Term Goal Statements are not available; use the regional Vital Sign Indicator Targets noted above
o Gaps and/or Barriers (see Table 5)
o Local Strategy Results Chains, listed by ID#, for this Regional Approach include:
• L (oil spills); and/or
• M (education)

See Note above regarding these two Local Strategy Results Chains for Regional Approach TIF5. 
**West Central
Applicable, no additional info.  
**Whatcom
Applicable – See Local Context
Local and Regional NTA owners should coordinate with Whatcom LIO', N'TIF5.1', 5, N'TIF5')
GO




DECLARE @TenantID int
SET @TenantID = 11

/******Add Branches**************/
--rename existing branches and leaves
UPDATE dbo.TaxonomyBranch 
SET TaxonomyBranchName = 'Test Branch - ' + cast(TaxonomyBranchName as varchar(50))

UPDATE dbo.TaxonomyLeaf
SET TaxonomyLeafName = 'Test Leaf - ' + TaxonomyLeafName

INSERT INTO dbo.TaxonomyBranch (TenantID, TaxonomyTrunkID, TaxonomyBranchName, TaxonomyBranchDescription, ThemeColor, TaxonomyBranchCode, TaxonomyBranchSortOrder)
SELECT
	@TenantID,
	TaxonomyTrunkID,
	TaxonomyBranchName,
	TaxonomyBranchDescription,
	ThemeColor,
	TaxonomyBranchCode,
	TaxonomyBranchSortOrder
FROM dbo.TaxonomyBranch_Import

--check
/*SELECT * FROM dbo.TaxonomyBranch
WHERE TenantID = @TenantID*/

/*********Add Leaves**********/
INSERT INTO dbo.TaxonomyLeaf (TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription, TaxonomyLeafCode, ThemeColor, TaxonomyLeafSortOrder)
SELECT
	@TenantID,
	r.TaxonomyBranchID,
	TaxonomyLeafName,
	TaxonomyLeafDescription,
	TaxonomyLeafCode,
	l.ThemeCOlor,
	TaxonomyLeafSortOrder
FROM dbo.TaxonomyLeaf_Import l
JOIN dbo.TaxonomyBranch r
on r.TenantID = @TenantID and 
l.TaxonomyBranchName = r.TaxonomyBranchCode

--check
/*SELECT * FROM dbo.TaxonomyLeaf
WHERE TenantID = @TenantID*/


/*************Delete test taxonomy and reassign projects and PMs ****************/
DECLARE @ReplacementLeaf int
SET @ReplacementLeaf = @@Identity

--Reassign projects
UPDATE dbo.Project
SET TaxonomyLeafID = @ReplacementLeaf
WHERE TenantID = @TenantID 

--Reassign PMs
UPDATE dbo.TaxonomyLeafPerformanceMeasure
SET TaxonomyLeafID = @ReplacementLeaf
WHERE TenantID = @TenantID

--Delete leaves
DELETE dbo.TaxonomyLeaf
WHERE TenantID = @TenantID and
TaxonomyLeafName LIKE 'Test Leaf%'

--Delete branches
DELETE dbo.TaxonomyBranch
WHERE TenantID = @TenantID and
TaxonomyBranchName LIKE 'Test Branch%'

DROP TABLE dbo.TaxonomyBranch_Import
DROP TABLE dbo.TaxonomyLeaf_Import



update dbo.TaxonomyBranch
set TaxonomyBranchName = ltrim(rtrim(replace(TaxonomyBranchName, TaxonomyBranchCode, '')))
where TenantID = 11

alter table dbo.TaxonomyLeaf drop constraint AK_TaxonomyLeaf_TaxonomyLeafName_TenantID
GO

update dbo.TaxonomyLeaf
set TaxonomyLeafName = ltrim(rtrim(replace(substring(TaxonomyLeafName, 0, CHARINDEX(' ', TaxonomyLeafName)) + substring(TaxonomyLeafName, CHARINDEX(' ', TaxonomyLeafName) + 1, len(TaxonomyLeafName) - CHARINDEX(' ', TaxonomyLeafName)), TaxonomyLeafCode, '')))
where TenantID = 11

alter table dbo.TaxonomyLeaf add constraint AK_TaxonomyLeaf_TaxonomyBranchID_TaxonomyLeafName_TenantID unique (TaxonomyBranchID, TaxonomyLeafName, TenantID)

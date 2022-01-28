insert into dbo.Organization(TenantID, OrganizationName, OrganizationTypeID, IsActive, UseOrganizationBoundaryForMatchmaker, IsUnknownOrUnspecified)
values
(4, 'CA Alternative Energy and Advanced Transportation Financing Authority', 4, 1, 1, 0),
(4, 'CA Dept of Conservation', 4, 1, 1, 0),
(4, 'CA Dept of Fish & Wildlife', 4, 1, 1, 0),
(4, 'CA Dept of Food and Agriculture', 4, 1, 1, 0),
(4, 'CA Energy Commission', 4, 1, 1, 0),
(4, 'CA Fire Foundation', 4, 1, 1, 0),
(4, 'CA Fire Safe Council', 4, 1, 1, 0),
(4, 'CA Natural Resources Agency', 4, 1, 1, 0),
(4, 'CA Ocean Protection Council', 4, 1, 1, 0),
(4, 'CA Office of Emergency Services', 4, 1, 1, 0),
(4, 'CA State Coastal Conservancy', 4, 1, 1, 0),
(4, 'CA Strategic Growth Council', 4, 1, 1, 0),
(4, 'CA Wildlife Conservation Board', 4, 1, 1, 0),
(4, 'CAL FIRE', 4, 1, 1, 0),
(4, 'National Oceanic & Atmospheric Agency', 1, 1, 1, 0),
(4, 'Other Funding Source: Federal Government', 1, 1, 1, 0),
(4, 'Other Funding Source: Foundations & NGOs', 1094, 1, 1, 0),
(4, 'Other Funding Source: Local Government', 1101, 1, 1, 0),
(4, 'Other Funding Source: State Government', 1102, 1, 1, 0),
(4, 'US Army Corps of Engineers', 1, 1, 1, 0),
(4, 'US Bureau of Indian Affairs', 1, 1, 1, 0),
(4, 'US Bureau of Land Management', 1, 1, 1, 0),
(4, 'US Bureau of Reclamation', 1, 1, 1, 0),
(4, 'US Department of Agriculture Natural Resources Conservation Service', 1, 1, 1, 0),
(4, 'US Environmental Protection Agency', 1, 1, 1, 0),
(4, 'US Federal Emergency Management Agency', 1, 1, 1, 0),
(4, 'US Fish & Wildlife Service', 1, 1, 1, 0),
(4, 'US Forest Service', 1, 1, 1, 0),
(4, 'US Geologic Survey', 1, 1, 1, 0),
(4, 'US National Park Service', 1, 1, 1, 0)
go

declare @orgID int

select @orgID = OrganizationID from dbo.Organization where OrganizationName = 'CAL FIRE';

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'California Forest Improvement Program','The purpose of the California Forest Improvement Program (CFIP) is to encourage private and public investment in, and improved management of, California forest lands and resources. This focus is to ensure adequate high quality timber supplies, related employment and other economic benefits, and the protection, maintenance, and enhancement of a productive and stable forest resource system for the benefit of present and future generations.'),
(4, @orgID, 1, 'Fire Prevention Grants Program','CAL FIRE''s Fire Prevention Grants Program provides funding for fire prevention projects and activities in and near fire threatened communities that focus on increasing the protection of people, structures, and communities. Funded activities include hazardous fuels reduction, wildfire prevention planning, and wildfire prevention education with an emphasis on improving public health and safety while reducing greenhouse gas emissions.'),
(4, @orgID, 1, 'Forest Health Grants','CAL FIRE''s Forest Health Program funds active restoration and reforestation activities aimed at providing for more resilient and sustained forests to ensure future existence of forests in California while also mitigating climate change, protecting communities from fire risk, strengthening rural economies and improving California''s water & air.'),
(4, @orgID, 1, 'Forest Legacy','The purpose of the Forest Legacy Program is to protect environmentally important forest land threatened with conversion to non-forest uses. Protection of California''s forests through this program ensures they continue to provide such benefits as sustainable timber production, wildlife habitat, recreation opportunities, watershed protection and open space. Intact forests also contribute significantly to the storage and sequestration of carbon.'),
(4, @orgID, 1, 'Urban and Community Forestry Grant Programs','The CAL FIRE Urban & Community Forestry Program works to optimize the benefits of trees and related vegetation through multiple objective projects as specified in the California Urban Forestry Act of 1978 (Public Resources Code 4799.06-4799.12).')


select @orgID = OrganizationID from dbo.Organization where OrganizationName = 'CA Dept of Fish & Wildlife';

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'Grants for NCCPs and HCPs','CDFW sponsors several grant programs to assist in funding NCCPs and Habitat Conservation Plans (HCPs). Three of these important programs are administered by the Habitat Conservation Planning Branch. '),
(4, @orgID, 1, 'Proposition 1 Restoration Grant Programs','Proposition 1 provides funding to implement the three broad objectives of the California Water Action Plan: more reliable water supplies; the restoration of important species and habitat; and a more resilient, sustainably managed water resources system (water supply, water quality, flood protection, and environment) that can better withstand inevitable and unforeseen pressures in the coming decades. Funds granted by CDFW will primarily focus on addressing the objective of restoring important sp'),
(4, @orgID, 1, 'Proposition 68 Restoration Grant Programs','The California Drought, Water, Parks, Climate, Coastal Protection, And Outdoor Access For All Act Of 2018 (Proposition 68) funding for CDFW grants for projects that:

    improve a community''s ability to adapt to the unavoidable impacts of climate change
    improve and protect coastal and rural economies, agricultural viability, wildlife corridors, or habitat
    develop future recreational opportunities, or
    enhance drought tolerance, landscape resilience, and water retention')


set @orgID = 159 -- California State Water Resources Control Board

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'Proposition 1 Water Projects','Proposition 1 authorized $7.545 billion in general obligation bonds for water projects including surface and groundwater storage, ecosystem and watershed protection and restoration, and drinking water protection. The State Water Board will administer Prop 1 funds for 5 programs: Drinking Water, Groundwater, Stormwater, Small Community Wastewater, Water Recycling'),
(4, @orgID, 1, 'IRWM Prop 50 R1','The Water Security, Clean Drinking Water, Coastal and Beach Protection Act of 2002, Water Code Section 79500 was passed by California voters in the November 2002 general election. Assembly Bill 1747 was signed into law in August 2003, and took effect immediately, clarifying some of the Proposition 50 requirements. CA Water Board provides funding under Prop 50 for Chapter 3 (Water Security) and Chapter 4 (Safe Drinking Water).')

set @orgID = 6603 --California Department of Water Resources

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'IRWM Prop 50 R2','The Water Security, Clean Drinking Water, Coastal and Beach Protection Act of 2002, Water Code Section 79500 was passed by California voters in the November 2002 general election. Assembly Bill 1747 was signed into law in August 2003, and took effect immediately, clarifying some of the Proposition 50 requirements. DWR provides funding under Prop 50 for Chapter 6(b) Contaminant Removal and Chapter 6(c) UV & Ozone Disinfection.'),
(4, @orgID, 1, 'IRWM Prop 84 2015','Proposition 84, the Safe Drinking Water, Water Quality and Supply, Flood Control, River and Coastal Protection Bond Act of 2006 (Prop 84), was approved by California voters in the general election on November 7, 2006. Prop 84 provided funds to the State Water Resources Control Board (State Water Board) $82 million for matching grants to local public agencies for the reduction and prevention of storm water (SW) contamination of rivers, lakes, and streams.'),
(4, @orgID, 1, 'IRWM Prop 84 Drought','Proposition 84, the Safe Drinking Water, Water Quality and Supply, Flood Control, River and Coastal Protection Bond Act of 2006 (Prop 84), was approved by California voters in the general election on November 7, 2006. Prop 84 provided funds to the State Water Resources Control Board (State Water Board) $82 million for matching grants to local public agencies for the reduction and prevention of storm water (SW) contamination of rivers, lakes, and streams.'),
(4, @orgID, 1, 'IRWM Prop 84 R1 (SWRCB)','Proposition 84, the Safe Drinking Water, Water Quality and Supply, Flood Control, River and Coastal Protection Bond Act of 2006 (Prop 84), was approved by California voters in the general election on November 7, 2006. Prop 84 provided funds to the State Water Resources Control Board (State Water Board) $82 million for matching grants to local public agencies for the reduction and prevention of storm water (SW) contamination of rivers, lakes, and streams.'),
(4, @orgID, 1, 'IRWM Prop 84 R2','Proposition 84, the Safe Drinking Water, Water Quality and Supply, Flood Control, River and Coastal Protection Bond Act of 2006 (Prop 84), was approved by California voters in the general election on November 7, 2006. Prop 84 provided funds to the State Water Resources Control Board (State Water Board) $82 million for matching grants to local public agencies for the reduction and prevention of storm water (SW) contamination of rivers, lakes, and streams.'),
(4, @orgID, 1, 'IRWM Proposition 1 Round 1','Proposition 1 authorized $510 million in Integrated Regional Water Management (IRWM) funding. Funds are allocated to 12 hydrologic region-based Funding Areas.
The Proposition 1 IRWM Grant Program, administered by DWR, provides funding for projects that help meet the long-term water needs of the state, including:
    Assisting water infrastructure systems adapt to climate change;
    Providing incentives throughout each watershed to collaborate in managing the region''s water resources and set'),

(4, @orgID, 1, 'IRWM Proposition 1 Round 2','Proposition 1 authorized $510 million in Integrated Regional Water Management (IRWM) funding. Funds are allocated to 12 hydrologic region-based Funding Areas.
The Proposition 1 IRWM Grant Program, administered by DWR, provides funding for projects that help meet the long-term water needs of the state, including:
    Assisting water infrastructure systems adapt to climate change;
    Providing incentives throughout each watershed to collaborate in managing the region''s water resources and set'),

(4, @orgID, 1, 'Prop 1 Coastal Watershed Flood Risk Reduction Program','The Coastal Watershed Flood Risk Reduction Grant Program will fund projects in coastal areas that focus on multi-benefit flood risk reduction. These projects will: 

    Address flood risk and public safety
    Enhance coastal ecosystems, including fish and wildlife habitat enhancement
    Promote natural resources stewardship and public access corridors

Eligible projects must be in areas that intersect the California Coast or San Francisco Bay.'),
(4, @orgID, 1, 'Urban and Multibenefit Drought Relief Funding','The Urban and Multibenefit Drought Relief Program is one of two Department of Water Resources''s (DWR''s) Drought Relief Grant Programs that offers financial assistance to address drought impacts through implementation of projects with multiple benefits: 
    For communities, including Tribes, facing the loss or contamination of their water supplies due to the drought; and 
    To address immediate drought impacts on human health and safety, and to protect fish and wildlife resources plus othe')



select @orgID = OrganizationID from dbo.Organization where OrganizationName = 'CA State Coastal Conservancy';

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'Proposition 68 Grants','Proposition 68 (“Prop 68”), the California Drought, Water, Parks, Climate, Coastal Protection, and Outdoor Access for All Act of 2018, was approved by voters in June 2018. The purposes of Prop 68 include creating parks, enhancing river parkways, and protecting coastal forests and wetlands. Prop 68 also provides funding for outdoor access, lower cost coastal accommodations and climate adaptation. ')


select @orgID = OrganizationID from dbo.Organization where OrganizationName = 'CA Strategic Growth Council';

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'SGC Programs','Programs that promote sustainability, health and equity across CA')

select @orgID = OrganizationID from dbo.Organization where OrganizationName = 'CA Dept of Conservation';

insert into dbo.FundingSource(TenantID, OrganizationID, IsActive, FundingSourceName, FundingSourceDescription)
values
(4, @orgID, 1, 'Regional Forest and Fire Capacity Program','The Regional Forest and Fire Capacity program aims to increase regional capacity to prioritize, develop, and implement projects to improve forest health and fire resilience and increase carbon sequestration in forests throughout California. Six regional entities including the NCRP are using block grants to conduct regional planning, develop projects, conduct outreach, and implement landscape-level forest health projects consistent with the California Forest Carbon Plan and Executive Order B-52'),
(4, @orgID, 1, 'Sustainable Agricultural Lands Conservation Program','The California Strategic Growth Council''s (SGC) SALC Program is a component of SGC''s Affordable ​​Housing and Sustainable Communities Program​ (AHSC). ​SALC complements investments made in urban areas with the purchase of agricultural conservation easements, development of agricultural land strategy plans, and other mechanisms that result in GHG reductions and a more resilient agricultural sector.'),
(4, @orgID, 1, 'Multibenefit Land Repurposing Program','This program funds groundwater sustainability projects that reduce groundwater use, repurpose irrigated agricultural land, and provide wildlife habitat. The Multibenefit Land Repurposing Program seeks to use this funding to increase regional capacity to repurpose agricultural land to reduce reliance on groundwater while providing community health, economic wellbeing, water supply, habitat, renewable energy, and climate benefits.')

-- delete some funding sources
--'Prop 50 R1',
--'Prop 50 R2',
--'Prop 84 2015',
--'Prop 84 Drought',
--'Prop 84 R1',
--'Prop 84 R2'
delete from dbo.ProjectFundingSourceExpenditure where FundingSourceID in
(
9297,
9302,
33,
9296,
9303,
9301
)

delete from dbo.ProjectFundingSourceBudget where FundingSourceID in
(
9297,
9302,
33,
9296,
9303,
9301
)


delete from dbo.FundingSource where FundingSourceID in
(
9297,
9302,
33,
9296,
9303,
9301
)


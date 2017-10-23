delete from dbo.MeasurementUnitType

insert into dbo.MeasurementUnitType(MeasurementUnitTypeID, MeasurementUnitTypeName, MeasurementUnitTypeDisplayName, LegendDisplayName, SingularDisplayName, NumberOfSignificantDigits) values 
(1, 'Acres', 'acres', 'acres', 'Acre', 2),
(2, 'Miles', 'miles', 'miles', 'Mile', 2),
(3, 'SquareFeet', 'square feet', 'sq ft', 'Square Foot', 2),
(4, 'LinearFeet', 'linear feet', 'lf', 'Linear Foot', 2),
(5, 'Kilogram', 'kg', 'kg', 'Kilogram', 2),
(6, 'Number', 'number', null, 'Each Unit', 0),
(7, 'Pounds', 'pounds', 'lbs', 'Pound', 2),
(8, 'Tons', 'tons', 'tons', 'Ton', 2),
(9, 'Dollars', 'dollars', null, 'Dollar', 0),
(10, 'Parcels', 'parcels', null, 'Parcel', 0),
(11, 'Percent', '%', '%', '%', 0),
(12, 'Therms', 'therms', 'therms', 'Therm', 2),
(13, 'PartsPerMillion', 'ppm', 'ppm', 'Part Per Million', 3),
(14, 'PartsPerBillion', 'ppb', 'ppb', 'Part Per Billion', 3),
(15, 'MilligamsPerLiter', 'mg/L', 'mg/L', 'Milligram Per Liter', 2),
(16, 'NephlometricTurbidityUnit', 'NTU', 'NTU', 'Nephlometric Turbidity Unit', 1),
(17, 'Meters', 'meters', 'meters', 'Meter', 1),
(18, 'PeriphytonBiomassIndex', 'PBI', 'PBI', 'Periphyton biomass index', 0),
(19, 'AcreFeet', 'acre-feet', 'acre-ft', 'Acre-Foot', 0),
(20, 'Gallon', 'gallons', 'gallons', 'Gallon', 0),
(21, 'CubicYards', 'cubic yards', 'cubic yards', 'Cubic Yard', 0)
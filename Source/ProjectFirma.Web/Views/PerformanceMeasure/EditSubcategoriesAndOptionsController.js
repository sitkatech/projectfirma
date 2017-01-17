angular.module("ProjectFirmaApp")
    .controller("EditSubcategoriesAndOptionsController",
        function($scope, $timeout, angularModelAndViewData)
        {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.nextSubcategoryID = -1;
            $scope.nextOptionID = -1;

            // Iterate decrementing regative IDs for incoming records where ID is already negative
            _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                .filter(function(subcategorySimple) { return subcategorySimple.PerformanceMeasureSubcategoryID < 0; })
                .each(function(subcategorySimple) { subcategorySimple.PerformanceMeasureSubcategoryID = $scope.nextSubcategoryID --; });
            _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                .map("PerformanceMeasureSubcategoryOptions")
                .flatten()
                .filter(function(optionSimple) { return optionSimple.PerformanceMeasureSubcategoryOptionID < 0; })
                .each(function(optionSimple) { optionSimple.PerformanceMeasureSubcategoryOptionID = $scope.nextOptionID--; });

            $scope.addSubcategory = function()
            {
                $scope.AngularModel.PerformanceMeasureSubcategorySimples.push({
                    PerformanceMeasureSubcategoryID: $scope.nextSubcategoryID--,
                    PerformanceMeasureSubcategoryOptions: []
                });
            }

            $scope.removeSubcategory = function(subcategorySimple)
            {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureSubcategorySimples,
                    subcategorySimple);
            }

            $scope.addSubcategoryOption = function (subcategorySimple)
            {
                subcategorySimple.PerformanceMeasureSubcategoryOptions.push({
                    PerformanceMeasureSubcategoryOptionID: $scope.nextOptionID--
                });
            }

            $scope.removeSubcategoryOption = function(subcategorySimple, optionSimple)
            {
                Sitka.Methods.removeFromJsonArray(subcategorySimple.PerformanceMeasureSubcategoryOptions, optionSimple);
            }
        });
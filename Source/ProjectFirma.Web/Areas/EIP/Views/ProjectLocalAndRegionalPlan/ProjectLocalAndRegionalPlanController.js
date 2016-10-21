angular.module("ProjectFirmaApp").controller("ProjectLocalAndRegionalPlanController", function($scope, angularModelAndViewData)
{
    $scope.resetLocalAndRegionalPlanToAdd = function() { $scope.LocalAndRegionalPlanToAdd = null; };

    $scope.filteredLocalAndRegionalPlans = function()
    {
        var usedLocalAndRegionalPlanIDs = _.map($scope.AngularModel.ProjectLocalAndRegionalPlans, function(p) { return p.LocalAndRegionalPlanID; });
        return _($scope.AngularViewData.AllLocalAndRegionalPlans).filter(function(f) { return !_.contains(usedLocalAndRegionalPlanIDs, f.LocalAndRegionalPlanID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getLocalAndRegionalPlanName = function(projectLocalAndRegionalPlan)
    {
        var localAndRegionalPlanToFind = $scope.getLocalAndRegionalPlan(projectLocalAndRegionalPlan.LocalAndRegionalPlanID);
        return localAndRegionalPlanToFind.DisplayName;
    };

    $scope.getLocalAndRegionalPlan = function(localAndRegionalPlanId) { return _.find($scope.AngularViewData.AllLocalAndRegionalPlans, function(f) { return localAndRegionalPlanId === f.LocalAndRegionalPlanID; }); };

    $scope.addRow = function()
    {
        if ($scope.LocalAndRegionalPlanToAdd != null)
        {
            var newProjectLocalAndRegionalPlan = $scope.createNewRow($scope.ProjectIDToAdd, $scope.LocalAndRegionalPlanToAdd);
            $scope.AngularModel.ProjectLocalAndRegionalPlans.push(newProjectLocalAndRegionalPlan);
            $scope.resetLocalAndRegionalPlanToAdd();
        }
    };

    $scope.createNewRow = function(projectId, localAndRegionalPlan)
    {
        var newProjectLocalAndRegionalPlan = {
            ProjectID: projectId,
            LocalAndRegionalPlanID: localAndRegionalPlan.LocalAndRegionalPlanID
        };
        return newProjectLocalAndRegionalPlan;
    };

    $scope.deleteRow = function(rowToDelete) { Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectLocalAndRegionalPlans, rowToDelete); };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetLocalAndRegionalPlanToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});
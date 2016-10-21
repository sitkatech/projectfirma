angular.module("ProjectFirmaApp").controller("PersonOrganizationController", function ($scope, angularModelAndViewData)
{
    $scope.filteredOrganizations = function ()
    {
        var usedOrganizationIDs = $scope.AngularModel.OrganizationIDs;
        var filter = _($scope.AngularViewData.AllOrganizations).filter(function (f) { return !_.contains(usedOrganizationIDs, f.OrganizationID); });
        var orgsFilteredAndSorted = filter.sortBy(["DisplayName"]).value();
        return orgsFilteredAndSorted;
    };

    $scope.addRow = function()
    {
        if ($scope.OrganizationToAdd != null)
        {
            $scope.AngularModel.OrganizationIDs.push($scope.OrganizationToAdd.OrganizationID);
        }
    };

    $scope.getOrganizationDisplayName = function (organizationId)
    {
        var organization = _.find($scope.AngularViewData.AllOrganizations, function(x) { return x.OrganizationID == organizationId; });
        return organization.DisplayName;
    };

    $scope.deleteRow = function (organizationId) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.OrganizationIDs, organizationId);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
});


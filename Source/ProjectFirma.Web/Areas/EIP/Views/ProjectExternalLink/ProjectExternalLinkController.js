angular.module("ProjectFirmaApp").controller("ProjectExternalLinkController", function ($scope, angularModelAndViewData)
{
    $scope.resetExternalLinkToAdd = function()
    {
        $scope.ExternalLinkLabelToAdd = null;
        $scope.ExternalLinkUrlToAdd = "http://";
    };

    $scope.getExternalLink = function (externalLinkId) {
        return _.find($scope.AngularViewData.AllExternalLinks, function (f) { return externalLinkId == f.ExternalLinkID; });
    };

    $scope.isAddButtonDisabled = function () { return Sitka.Methods.isUndefinedNullOrEmpty($scope.ExternalLinkLabelToAdd) || Sitka.Methods.isUndefinedNullOrEmpty($scope.ExternalLinkUrlToAdd); };

    $scope.addRow = function()
    {
        if (!$scope.isAddButtonDisabled())
        {
            var newProjectExternalLink = $scope.createNewRow($scope.AngularViewData.ProjectID, $scope.ExternalLinkLabelToAdd, $scope.ExternalLinkUrlToAdd);
            $scope.AngularModel.ProjectExternalLinks.push(newProjectExternalLink);
            $scope.resetExternalLinkToAdd();
        }
    };

    $scope.createNewRow = function (projectId, externalLinkLabel, externalLinkUrl) {
        var newProjectExternalLink = {
            ProjectID: projectId,
            ExternalLinkLabel: externalLinkLabel,
            ExternalLinkUrl: externalLinkUrl
        };
        return newProjectExternalLink;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectExternalLinks, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetExternalLinkToAdd();
});


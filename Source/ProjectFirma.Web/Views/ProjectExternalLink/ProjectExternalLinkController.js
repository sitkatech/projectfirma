/*-----------------------------------------------------------------------
<copyright file="ProjectExternalLinkController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
angular.module("ProjectFirmaApp").controller("ProjectExternalLinkController", function ($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.resetExternalLinkToAdd = function()
    {
        $scope.ExternalLinkLabelToAdd = null;
        $scope.ExternalLinkUrlToAdd = "http://";
    };
    $scope.resetExternalLinkToAdd();

    $scope.projectSubmitButton = jQuery(".submitProject");
    $scope.submitCachedOnClick = $scope.projectSubmitButton.attr('onclick');
    $scope.originalFormValues = $scope.AngularModel.ProjectExternalLinks.slice(0);

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
        $scope.checkIfOriginalInput();
    };

    // since all of the inputs on this view are angular inputs, we need to disable the submit button manually.
    $scope.checkIfOriginalInput = function () {
        if (JSON.stringify($scope.AngularModel.ProjectExternalLinks) === JSON.stringify($scope.originalFormValues)) {
            $scope.projectSubmitButton.attr('disabled', false);
            $scope.projectSubmitButton.removeClass('disabledByDirtyCheck');
            $scope.projectSubmitButton.attr('onclick', $scope.submitCachedOnClick);
        } else {
            $scope.projectSubmitButton.attr('disabled', true);
            $scope.projectSubmitButton.addClass('disabledByDirtyCheck');
            $scope.projectSubmitButton.attr('onclick', 'event.preventDefault()');
        }
    }

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
        $scope.checkIfOriginalInput();
    };

});


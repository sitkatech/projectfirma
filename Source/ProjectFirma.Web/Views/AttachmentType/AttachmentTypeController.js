/*-----------------------------------------------------------------------
<copyright file="AttachmentTypeController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("AttachmentTypeController", function ($scope, angularModelAndViewData) {


    // File Types
    $scope.getAvailableFileTypes = function () {
        var usedFileResourceMimeTypeIDs = $scope.AngularModel.FileResourceMimeTypeIDs;
        //debugger;
        var filter = _($scope.AngularViewData.AllFileResourceMimeTypes).filter(function (f) { return !_.contains(usedFileResourceMimeTypeIDs, f.FileResourceMimeTypeID); });
        var fileTypesFilteredAndSorted = filter.sortBy(["FileResourceMimeTypeDisplayName"]).value();
        //debugger;
        jQuery(".selectpicker").selectpicker("refresh");
        return fileTypesFilteredAndSorted;
    };

    $scope.addRow = function () {
        if ($scope.FileResourceMimeTypeIDToAdd != null) {
            //debugger;
            $scope.AngularModel.FileResourceMimeTypeIDs.push(Number($scope.FileResourceMimeTypeIDToAdd));
        }
    };
    $scope.addAllFileResourceMimeTypes = function () {
        $scope.AngularModel.FileResourceMimeTypeIDs = [];
        jQuery.each($scope.AngularViewData.AllFileResourceMimeTypes, function (k, v) {
            $scope.AngularModel.FileResourceMimeTypeIDs.push(Number(v.FileResourceMimeTypeID));
        });
    };

    $scope.getFileResourceMimeTypeDisplayName = function (fileResourceMimeTypeID) {
        var fileResourceMimeType = _.find($scope.AngularViewData.AllFileResourceMimeTypes, function (x) { return x.FileResourceMimeTypeID == fileResourceMimeTypeID; });
        //debugger;
        return fileResourceMimeType.FileResourceMimeTypeDisplayName;
    };

    $scope.deleteRow = function (fileResourceMimeTypeID) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.FileResourceMimeTypeIDs, fileResourceMimeTypeID);
    };

    // Taxonomy Trunks
    $scope.getAvailableTaxonomyTrunks = function () {
        var usedTaxonomyTrunkIDs = $scope.AngularModel.TaxonomyTrunkIDs;
        //debugger;
        var filter = _($scope.AngularViewData.AllTaxonomyTrunks).filter(function (f) { return !_.contains(usedTaxonomyTrunkIDs, f.TaxonomyTrunkID); });
        var taxonomyTrunksFilteredAndSorted = filter.sortBy(["TaxonomyTrunkName"]).value();
        //debugger;
        jQuery(".selectpicker").selectpicker("refresh");
        return taxonomyTrunksFilteredAndSorted;
    };

    $scope.addRowTaxonomyTrunk = function () {
        if ($scope.TaxonomyTrunkIDToAdd != null) {
            //debugger;
            $scope.AngularModel.TaxonomyTrunkIDs.push(Number($scope.TaxonomyTrunkIDToAdd));
        }
    };

    $scope.addAllTaxonomyTrunks = function () {
        $scope.AngularModel.TaxonomyTrunkIDs = [];
        jQuery.each($scope.AngularViewData.AllTaxonomyTrunks, function (k, v) {
            $scope.AngularModel.TaxonomyTrunkIDs.push(Number(v.TaxonomyTrunkID));
        });
    };

    $scope.getTaxonomyTrunkDisplayName = function (TaxonomyTrunkID) {
        var TaxonomyTrunk = _.find($scope.AngularViewData.AllTaxonomyTrunks, function (x) { return x.TaxonomyTrunkID == TaxonomyTrunkID; });
        //debugger;
        return TaxonomyTrunk.TaxonomyTrunkName;
    };

    $scope.deleteRowTaxonomyTrunk = function (TaxonomyTrunkID) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.TaxonomyTrunkIDs, TaxonomyTrunkID);
    };
    
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
});
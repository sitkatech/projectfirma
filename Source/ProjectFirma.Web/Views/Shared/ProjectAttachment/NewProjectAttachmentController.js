/*-----------------------------------------------------------------------
<copyright file="NewProjectAttachmentController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("NewProjectAttachmentController", function ($scope, angularModelAndViewData) {

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.AngularModel.AttachmentTypeID = $scope.AngularViewData.AllAttachmentTypes[0].AttachmentTypeID;

    $scope.isAttachmentTypeSelected = function (attachmentTypeID) {
        return ($scope.AngularModel.AttachmentTypeID === attachmentTypeID);
    }

    $scope.getAttachmentTypesForDropdown = function () {
        return $scope.AngularViewData.AllAttachmentTypes;
    }

    $scope.attachmentTypeChange = function (attachmentTypeID) {
        $scope.populateAllowedMimeTypes(attachmentTypeID);
        $scope.populateAllowedExtensions(attachmentTypeID);
        $scope.populateMaxFileSize(attachmentTypeID);

        //clear the model value and the input value to reset the form after a relationship type change
        $scope.UploadedFile = null;
        angular.element("input[type='file']").val(null);
    }

    $scope.populateAllowedMimeTypes = function (attachmentTypeID) {
        //console.log("populateAllowedMimeTypes artID:" + attachmentTypeID);
        var attachmentType = _.find($scope.AngularViewData.AllAttachmentTypes, function (art) { return art.AttachmentTypeID == attachmentTypeID });

        $scope.AllowedMimeTypes = attachmentType.AllowedFileResourceMimeTypes.join(",");
    }

    $scope.populateAllowedExtensions = function (attachmentTypeID) {
        //console.log("populateAllowedExtensions artID:" + attachmentTypeID);
        var attachmentType = _.find($scope.AngularViewData.AllAttachmentTypes, function (art) { return art.AttachmentTypeID == attachmentTypeID });

        $scope.AllowedExtensions = attachmentType.AllowedFileResourceExtensions.join(", ");
    }

    $scope.populateMaxFileSize = function (attachmentTypeID) {
        //console.log("populateMaxFileSize artID:" + attachmentTypeID);
        var attachmentType = _.find($scope.AngularViewData.AllAttachmentTypes, function (art) { return art.AttachmentTypeID == attachmentTypeID });

        $scope.MaxFileSize = attachmentType.MaxFileSize;
        $scope.MaxFileSizeForDisplay = (attachmentType.MaxFileSize / 1024 / 1000) + "MB";
    }


    $scope.$watch("attachmentForm.$valid", function (newVal, oldVal) {
        //console.log("watching things new:" + newVal);
        var submitButton = jQuery("form")
            .parents(".modal-dialog")
            .find("#ltinfo-modal-dialog-save-button-id");

        if (newVal) {
            submitButton.prop("disabled", false);
        } else {
            submitButton.prop("disabled", true);
        }
    });

    $scope.populateAllowedMimeTypes($scope.AngularModel.AttachmentTypeID);
    $scope.populateAllowedExtensions($scope.AngularModel.AttachmentTypeID);
    $scope.populateMaxFileSize($scope.AngularModel.AttachmentTypeID);

});
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
    $scope.AngularModel.AttachmentRelationshipTypeID = $scope.AngularViewData.AllAttachmentRelationshipTypes[0].AttachmentRelationshipTypeID;



    $scope.isAttachmentRelationshipTypeSelected = function (attachmentRelationshipTypeID) {
        return ($scope.AngularModel.AttachmentRelationshipTypeID === attachmentRelationshipTypeID);
    }

    $scope.getAttachmentRelationshipTypesForDropdown = function () {
        return $scope.AngularViewData.AllAttachmentRelationshipTypes;
    }

    $scope.attachmentRelationshipTypeChange = function (attachmentRelationshipTypeID) {
        $scope.populateAllowedMimeTypes(attachmentRelationshipTypeID);
        $scope.populateAllowedExtensions(attachmentRelationshipTypeID);
        $scope.populateMaxFileSize(attachmentRelationshipTypeID);

        //clear the model value and the input value to reset the form after a relationship type change
        $scope.UploadedFile = null;
        angular.element("input[type='file']").val(null);
    }

    $scope.populateAllowedMimeTypes = function (attachmentRelationshipTypeID) {
        //console.log("populateAllowedMimeTypes artID:" + attachmentRelationshipTypeID);
        var attachmentRelationshipType = _.find($scope.AngularViewData.AllAttachmentRelationshipTypes, function (art) { return art.AttachmentRelationshipTypeID == attachmentRelationshipTypeID });

        $scope.AllowedMimeTypes = attachmentRelationshipType.AllowedFileResourceMimeTypes.join(",");
    }

    $scope.populateAllowedExtensions = function (attachmentRelationshipTypeID) {
        //console.log("populateAllowedExtensions artID:" + attachmentRelationshipTypeID);
        var attachmentRelationshipType = _.find($scope.AngularViewData.AllAttachmentRelationshipTypes, function (art) { return art.AttachmentRelationshipTypeID == attachmentRelationshipTypeID });

        $scope.AllowedExtensions = attachmentRelationshipType.AllowedFileResourceExtensions.join(", ");
    }

    $scope.populateMaxFileSize = function (attachmentRelationshipTypeID) {
        //console.log("populateMaxFileSize artID:" + attachmentRelationshipTypeID);
        var attachmentRelationshipType = _.find($scope.AngularViewData.AllAttachmentRelationshipTypes, function (art) { return art.AttachmentRelationshipTypeID == attachmentRelationshipTypeID });

        $scope.MaxFileSize = attachmentRelationshipType.MaxFileSize;
        $scope.MaxFileSizeForDisplay = (attachmentRelationshipType.MaxFileSize / 1024 / 1000) + "MB";
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

    $scope.populateAllowedMimeTypes($scope.AngularModel.AttachmentRelationshipTypeID);
    $scope.populateAllowedExtensions($scope.AngularModel.AttachmentRelationshipTypeID);
    $scope.populateMaxFileSize($scope.AngularModel.AttachmentRelationshipTypeID);

});
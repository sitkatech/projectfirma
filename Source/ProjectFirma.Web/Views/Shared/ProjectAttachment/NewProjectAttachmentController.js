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
    $scope.AngularModel.AttachmentRelationshipTypeID = _.head($scope.AngularViewData.AllAttachmentRelationshipTypes).AttachmentRelationshipTypeID;
    //debugger;


    $scope.isAttachmentRelationshipTypeSelected = function (attachmentRelationshipTypeID) {
        return $scope.AngularModel.AttachmentRelationshipTypeID === attachmentRelationshipTypeID;
    };

    $scope.getAttachmentRelationshipTypesForDropdown = function () {
        //debugger;
        return $scope.AngularViewData.AllAttachmentRelationshipTypes;
    }

    $scope.attachmentRelationshipTypeChange = function (attachmentRelationshipTypeID) {
        $scope.populateAllowedMimeTypes(attachmentRelationshipTypeID);
        $scope.AngularModel.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
        
        console.log("relationship type change form valid:" + $scope.attachmentForm.$valid);
        //$scope.attachmentForm.$validate();
    }

    $scope.populateAllowedMimeTypes = function (attachmentRelationshipTypeID) {
        var attachmentRelationshipType = _.find($scope.AngularViewData.AllAttachmentRelationshipTypes, function (art) { return art.AttachmentRelationshipTypeID == attachmentRelationshipTypeID });
        //debugger;
        $scope.AllowedMimeTypes = attachmentRelationshipType.AllowedFileResourceMimeTypes.join(", ");
    }

    $scope.fileUploadedChange = function () {

        console.log("file uploaded change form valid:" + $scope.attachmentForm.$valid);
    }


    //jQuery("#ltinfo-modal-dialog-save-button-id").on("click",
    //    function () {
    //        return  $scope.attachmentForm.$valid;
    //    });

    //$scope.$watch("AngularModel",
    //    function () {
    //        console.log("inside watch function");
    //        var submitButton = jQuery("form")
    //            .parents(".modal-dialog")
    //            .find("#ltinfo-modal-dialog-save-button-id");


    //        if ($scope.attachmentForm.$valid) {
    //            submitButton.prop("disabled", false);
    //        }
    //        else {
    //            submitButton.prop("disabled", true);
    //        }
    //    },
    //    true);

    $scope.populateAllowedMimeTypes($scope.AngularModel.AttachmentRelationshipTypeID);

});
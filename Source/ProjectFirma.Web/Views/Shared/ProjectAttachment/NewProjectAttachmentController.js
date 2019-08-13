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

    $scope.isAttachmentRelationshipTypeSelected = function (attachmentRelationshipTypeID) {
        var initialSelectedAttachmentRelationshipTypeID = $scope.AngularViewData.InitialSelectedAttachmentRelationshipTypeID;
        if (initialSelectedAttachmentRelationshipTypeID === attachmentRelationshipTypeID) {
            $scope.AngularModel.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            return true;
        }

        return false;
    };


    $scope.getAttachmentRelationshipTypesForDropdown = function () {
        //debugger;
        return $scope.AngularViewData.AllAttachmentRelationshipTypes;
    }


    $scope.attachmentRelationshipTypeChange = function (attachmentRelationshipTypeID) {
        $scope.populateAllowedMimeTypes(attachmentRelationshipTypeID);
    }

    $scope.populateAllowedMimeTypes = function (attachmentRelationshipTypeID) {
        var attachmentRelationshipType = _.find($scope.AngularViewData.AllAttachmentRelationshipTypes, function (art) { return art.AttachmentRelationshipTypeID == attachmentRelationshipTypeID });
        //debugger;
        $scope.AllowedMimeTypes = attachmentRelationshipType.AllowedFileResourceMimeTypes.join(", ");
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.populateAllowedMimeTypes($scope.AngularViewData.InitialSelectedAttachmentRelationshipTypeID);
    
});
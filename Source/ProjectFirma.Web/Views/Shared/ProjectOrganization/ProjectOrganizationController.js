﻿/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationController.js" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
angular.module("ProjectFirmaApp").controller("ProjectOrganizationController", function($scope,
    angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.selectedOrganizationID = {};
    $scope.OrganizationToAdd = null;

    $scope.$watch(function() {
        jQuery(".selectpicker").selectpicker("refresh");

        // so that unsavedChanges.js knows to check if the form has changed.
        jQuery("form").trigger("input");
    });

    $scope.getAvailableOrganizationsForRelationshipType = function (relationshipType) {
        //debugger;
        if (relationshipType == null) {
            //debugger;
            return null;
        }

        var organizationsForRelationshipType = _.filter($scope.AngularViewData.AllOrganizations,
            function(organization) {
                return $scope.organizationIsValidForRelationshipType(organization, relationshipType);
            });
        if (relationshipType.OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return organizationsForRelationshipType;
        } else {
            var usedOrganizations = _.filter($scope.AngularModel.ProjectOrganizationSimples,
                function(f) {
                    return f.OrganizationRelationshipTypeID == relationshipType.OrganizationRelationshipTypeID;
                });
            var usedOrganizationIDs = _.map(usedOrganizations,
                function (f) {
                    return f.OrganizationID;
                });

            var filteredList = _.filter(organizationsForRelationshipType,
                function (f) {
                    return !_.includes(usedOrganizationIDs, f.OrganizationID);
                });

            return filteredList;
        }
    };

    $scope.organizationIsValidForRelationshipType = function(organization, relationshipType) {
        var validRelationshipTypeIDs = _.map($scope.validRelationshipTypes(organization.OrganizationID),
            function(rt) {
                return rt.OrganizationRelationshipTypeID;
            });
        return _.includes(validRelationshipTypeIDs, relationshipType.OrganizationRelationshipTypeID);
    };

    $scope.chosenOrganizationsForRelationshipType = function(relationshipTypeID) {
        var chosenOrganizationSimples = _.filter($scope.AngularModel.ProjectOrganizationSimples,
            function(s) {
                return s.OrganizationRelationshipTypeID == relationshipTypeID;
            });

        var organizations = _.map(chosenOrganizationSimples,
            function(s) {
                var organization =
                    Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllOrganizations,
                        "OrganizationID",
                        s.OrganizationID);
                return organization;
            });
        return organizations;
    };

    $scope.canSetOrganizationFromProjectLocation = function(relationshipType) {
        if (!relationshipType.OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject ||
            !relationshipType.OrganizationRelationshipTypeHasOrganizationsWithSpatialBoundary) {
            return false;
        }

        if ($scope.AngularViewData.OrganizationContainingProjectSimpleLocation[relationshipType.OrganizationRelationshipTypeID] ===
            null) {
            return false;
        }

        return true;
    };

    $scope.setProjectOrganizationSimpleFromProjectLocation = function(relationshipType) {
        if (!$scope.canSetOrganizationFromProjectLocation(relationshipType)) {
            return;
        }

        var organizationID = Number(
            $scope.AngularViewData.OrganizationContainingProjectSimpleLocation[relationshipType.OrganizationRelationshipTypeID]
            .OrganizationID);

        $scope.selectionChanged(organizationID, relationshipType);
    };

    $scope.selectedOrgDoesNotMatchSpatialOrg = function (relationshipType) {

        if (!$scope.canSetOrganizationFromProjectLocation(relationshipType)) {
            return false;
        }

        var spatialOrganizationID = Number(
            $scope.AngularViewData.OrganizationContainingProjectSimpleLocation[relationshipType.OrganizationRelationshipTypeID].OrganizationID);

        var projectOrganizationSimple =
            Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectOrganizationSimples,
                "OrganizationRelationshipTypeID",
                relationshipType.OrganizationRelationshipTypeID);

        return spatialOrganizationID !== projectOrganizationSimple.OrganizationID;
    };

    $scope.addProjectOrganizationSimple = function(organizationID, relationshipTypeID) {
        $scope.AngularModel.ProjectOrganizationSimples.push({
            OrganizationID: Number(organizationID),
            OrganizationRelationshipTypeID: relationshipTypeID
        });
        $scope.resetSelectedOrganizationID(relationshipTypeID);
    };

    $scope.removeProjectOrganizationSimple = function(organizationID, relationshipTypeID) {
        _.remove($scope.AngularModel.ProjectOrganizationSimples,
            function(pos) {
                return pos.OrganizationID == organizationID && pos.OrganizationRelationshipTypeID == relationshipTypeID;
            });
    };

    $scope.selectionChanged = function(organizationID, relationshipType) {
        // changing the dropdown selection for a one-and-only-one relationship type should update the model
        if (relationshipType.OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            // if there's already a projectOrganizationSimple for this relationship type, just change the OrganizationID
            var projectOrganizationSimple =
                Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectOrganizationSimples,
                    "OrganizationRelationshipTypeID",
                    relationshipType.OrganizationRelationshipTypeID);

            if (projectOrganizationSimple != null) {
                projectOrganizationSimple.OrganizationID = Number(organizationID);
            } else {
                $scope.AngularModel.ProjectOrganizationSimples.push({
                    OrganizationID: Number(organizationID),
                    OrganizationRelationshipTypeID: relationshipType.OrganizationRelationshipTypeID
                });
            }
            
        } // but nothing should happen if it's a many-or-none relationship type
        //debugger;
        if (relationshipType.OrganizationRelationshipTypeIsPrimaryContact) {
            $scope.AngularModel.PrimaryContactPersonID = $scope.getSelectedPrimaryContactOrganization(relationshipType).PrimaryContactPersonID;
        }
    };

    $scope.resetSelectedOrganizationID = function(relationshipTypeID) {
        $scope.selectedOrganizationID[relationshipTypeID] = "";
    };

    $scope.isOptionSelected = function(organization, relationshipType) {
        if (!relationshipType.OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return false;
        }
        return _.any($scope.AngularModel.ProjectOrganizationSimples,
            function(pos) {
                return pos.OrganizationID == organization.OrganizationID &&
                    pos.OrganizationRelationshipTypeID == relationshipType.OrganizationRelationshipTypeID;
            });
    };

    $scope.dropdownDefaultOption = function (relationshipType) {
        if (relationshipType == null) {
            return "Select One";
        }

        if (relationshipType.OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return "Select the " + relationshipType.OrganizationRelationshipTypeName;
        } else {
            return "Add a " + relationshipType.OrganizationRelationshipTypeName;
        }
    };

    $scope.validRelationshipTypes = function (organizationID) {
        //debugger;
        var organization =
            Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllOrganizations,
                "OrganizationID",
                organizationID);

        var valid = organization == null ? [] : organization.ValidOrganizationRelationshipTypeSimples;
        return valid;
    };

    $scope.getSelectedPrimaryContactOrganization = function (relationshipType) {
        if (relationshipType === null) {
            return null;
        }

        var selectedPrimaryContactOrganizationID =
            Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectOrganizationSimples,
                "OrganizationRelationshipTypeID",
                relationshipType.OrganizationRelationshipTypeID).OrganizationID;

        var selectedPrimaryContactOrganization =
            Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllOrganizations,
                "OrganizationID",
                selectedPrimaryContactOrganizationID);

        return selectedPrimaryContactOrganization;
    }

    $scope.primaryContactOrganizationHasNoPrimaryContact = function(relationshipType) {
        return $scope.getSelectedPrimaryContactOrganization(relationshipType).PrimaryContactPersonID == null;
    }

    $scope.primaryContactOrganization = function (relationshipType) {
        if (relationshipType != null) {
            return $scope.getSelectedPrimaryContactOrganization(relationshipType);
        }

        return null;
    }

    $scope.primaryContactOrganizationPersonDisplayName = function (relationshipType) {
        if (relationshipType != null) {
            return $scope.getSelectedPrimaryContactOrganization(relationshipType).PrimaryContactPersonDisplayName;
        }

        return "nobody";
    }

    $scope.isPersonSelected = function (personID) {
        var primaryContactPersonId = $scope.AngularModel.PrimaryContactPersonID;

        return primaryContactPersonId === personID;
    };

    $scope.primaryContactPersonChange = function (personID) {
        $scope.AngularModel.PrimaryContactPersonID = personID === "null" ? null : parseInt(personID);
    }


    /*
      SB 11/29/2023 sort of hacky fix: 
      bootstrap-select was initializing the selectpickers before angular had finished processing the template, potentially by the this bit of code at the end of bootstrap-select.js

        $(window).on('load.bs.select.data-api', function () {
            $('.selectpicker').each(function () {
                var $selectpicker = $(this);
                Plugin.call($selectpicker, $selectpicker.data());
            })
        });

      In firefox, this would lead to two drop downs being rendered. This might be because in the call to jQuery(".selectpicker").selectpicker("refresh") in the $watch, the bootstrap-select.js code would think the 
      selectpicker was different because the ids didn't match (e.g. one was "#todo{{relationshipType.OrganizationRelationshipTypeID}}" and the other was "#todo6"). Or it could be a race condition where 2 different things
      are calling the code that inits the drop down, and in that execution of the 2nd call there still isn't the data expected, so bootstrap-select creates the drop down again.

      The solution appears to be to initialize the selectpickers after angular has finished one digest cycle. Do not add the selectpicker class until after that so bootstrap-select does not prematurely add a drop down.
    */
    $scope.SelectpickerNeedsInit = true;
    $scope.$$postDigest(function () {        
        if ($scope.SelectpickerNeedsInit) {
            jQuery(".selectpickerTemp").addClass("selectpicker");
            jQuery(".selectpickerTemp").removeClass("selectpickerTemp");
            jQuery(".selectpicker").selectpicker("refresh");
        }
        $scope.SelectpickerNeedsInit = false;
    });


})

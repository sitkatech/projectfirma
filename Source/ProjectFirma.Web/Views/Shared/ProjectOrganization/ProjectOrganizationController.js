/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ProjectOrganizationController", function($scope,
    angularModelAndViewData) {
    $scope.OrganizationToAdd = null;

    $scope.$watch(function() {
        jQuery(".selectpicker").selectpicker("refresh");

        // so that unsavedChanges.js knows to check if the form has changed.
        jQuery("form").trigger("input");
    });

    $scope.getAvailableOrganizationsForRelationshipType = function(relationshipType) {
        var organizationsForRelationshipType = _.filter($scope.AngularViewData.AllOrganizations,
            function(organization) {
                return $scope.organizationIsValidForRelationshipType(organization, relationshipType);
            });
        if (relationshipType.RelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return organizationsForRelationshipType;
        } else {
            var usedOrganizations = _.filter($scope.AngularModel.ProjectOrganizationSimples,
                function(f) {
                    return f.RelationshipTypeID == relationshipType.RelationshipTypeID;
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
                return rt.RelationshipTypeID;
            });
        return _.includes(validRelationshipTypeIDs, relationshipType.RelationshipTypeID);
    };

    $scope.chosenOrganizationsForRelationshipType = function(relationshipTypeID) {
        var chosenOrganizationSimples = _.filter($scope.AngularModel.ProjectOrganizationSimples,
            function(s) {
                return s.RelationshipTypeID == relationshipTypeID;
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

    $scope.addProjectOrganizationSimple = function(organizationID, relationshipTypeID) {
        $scope.AngularModel.ProjectOrganizationSimples.push({
            OrganizationID: Number(organizationID),
            RelationshipTypeID: relationshipTypeID
        });
        $scope.resetSelectedOrganizationID(relationshipTypeID);
    };

    $scope.removeProjectOrganizationSimple = function(organizationID, relationshipTypeID) {
        _.remove($scope.AngularModel.ProjectOrganizationSimples,
            function(pos) {
                return pos.OrganizationID == organizationID && pos.RelationshipTypeID == relationshipTypeID;
            });
    };

    $scope.selectionChanged = function(organizationID, relationshipType) {
        // changing the dropdown selection for a one-and-only-one relationship type should update the model
        if (relationshipType.RelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            // if there's already a projectOrganizationSimple for this relationship type, just change the OrganizationID
            var projectOrganizationSimple =
                Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectOrganizationSimples,
                    "RelationshipTypeID",
                    relationshipType.RelationshipTypeID);

            if (projectOrganizationSimple != null) {
                projectOrganizationSimple.OrganizationID = Number(organizationID);
            } else {
                $scope.AngularModel.ProjectOrganizationSimples.push({
                    OrganizationID: Number(organizationID),
                    RelationshipTypeID: relationshipType.RelationshipTypeID
                });
            }
        } // but nothing should happen if it's a many-or-none relationship type
    };

    $scope.resetSelectedOrganizationID = function(relationshipTypeID) {
        $scope.selectedOrganizationID[relationshipTypeID] = "";
    };

    $scope.isOptionSelected = function(organization, relationshipType) {
        if (!relationshipType.RelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return false;
        }
        return _.any($scope.AngularModel.ProjectOrganizationSimples,
            function(pos) {
                return pos.OrganizationID == organization.OrganizationID &&
                    pos.RelationshipTypeID == relationshipType.RelationshipTypeID;
            });
    };

    $scope.dropdownDefaultOption = function(relationshipType) {
        if (relationshipType.RelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return "Select the " + relationshipType.RelationshipTypeName;
        } else {
            return "Add a " + relationshipType.RelationshipTypeName;
        }
    };

    $scope.validRelationshipTypes = function(organizationID) {
        var organization =
            Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllOrganizations,
                "OrganizationID",
                organizationID);

        var valid = organization == null ? [] : organization.ValidRelationshipTypeSimples;
        return valid;
    };

    $scope.getSelectedPrimaryContactOrganization = function (relationshipType) {

        var selectedPrimaryContactOrganizationID =
            Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectOrganizationSimples,
                "RelationshipTypeID",
                relationshipType.RelationshipTypeID).OrganizationID;

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
        return $scope.getSelectedPrimaryContactOrganization(relationshipType);
    }

    $scope.isPersonSelected = function (personID) {
        var primaryContactPersonId = $scope.AngularModel.PrimaryContactPersonID;

        return primaryContactPersonId === personID;
    };

    $scope.primaryContactPersonChange = function (personID) {
        $scope.AngularModel.PrimaryContactPersonID = personID === "null" ? null : parseInt(personID);
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.selectedOrganizationID = {};
});

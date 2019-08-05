/*-----------------------------------------------------------------------
<copyright file="ProjectContactController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ProjectContactController", function($scope,
    angularModelAndViewData) {
    $scope.ContactToAdd = null;

    $scope.$watch(function() {
        jQuery(".selectpicker").selectpicker("refresh");

        // so that unsavedChanges.js knows to check if the form has changed.
        jQuery("form").trigger("input");
    });

    $scope.getAvailableContactsForRelationshipType = function (relationshipType) {
        //debugger;
        if (relationshipType == null) {
            //debugger;
            return null;
        }

        var contactsForRelationshipType = $scope.AngularViewData.AllContacts;
        if (relationshipType.ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return contactsForRelationshipType;
        } else {
            var usedContacts = _.filter($scope.AngularModel.ProjectContactSimples,
                function(f) {
                    return f.ContactRelationshipTypeID == relationshipType.ContactRelationshipTypeID;
                });
            var usedContactIDs = _.map(usedContacts,
                function (f) {
                    return f.ContactID;
                });

            var filteredList = _.filter(contactsForRelationshipType,
                function (f) {
                    return !_.includes(usedContactIDs, f.PersonID);
                });

            return filteredList;
        }
    };

    //$scope.contactIsValidForRelationshipType = function(contact, relationshipType) {
    //    var validRelationshipTypeIDs = _.map($scope.validRelationshipTypes(contact.PersonID),
    //        function(rt) {
    //            return rt.ContactRelationshipTypeID;
    //        });
    //    return _.includes(validRelationshipTypeIDs, relationshipType.ContactRelationshipTypeID);
    //};

    $scope.chosenContactsForRelationshipType = function(relationshipTypeID) {
        var chosenContactSimples = _.filter($scope.AngularModel.ProjectContactSimples,
            function(s) {
                return s.ContactRelationshipTypeID == relationshipTypeID;
            });

        var contacts = _.map(chosenContactSimples,
            function(s) {
                var contact =
                    Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllContacts,
                        "PersonID",
                        s.ContactID);
                return contact;
            });
        return contacts;
    };



    $scope.addProjectContactSimple = function(contactID, relationshipTypeID) {
        $scope.AngularModel.ProjectContactSimples.push({
            ContactID: Number(contactID),
            ContactRelationshipTypeID: relationshipTypeID
        });
        $scope.resetSelectedContactID(relationshipTypeID);
    };

    $scope.removeProjectContactSimple = function (contactID, relationshipTypeID) {
        
        _.remove($scope.AngularModel.ProjectContactSimples,
            function(pos) {
                return pos.ContactID == contactID && pos.ContactRelationshipTypeID == relationshipTypeID;
            });
    };

    $scope.selectionChanged = function(contactID, relationshipType) {
        // changing the dropdown selection for a one-and-only-one relationship type should update the model
        if (relationshipType.ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            // if there's already a projectContactSimple for this relationship type, just change the ContactID
            var projectContactSimple =
                Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectContactSimples,
                    "RelationshipTypeID",
                    relationshipType.ContactRelationshipTypeID);

            if (projectContactSimple != null) {
                projectContactSimple.ContactID = Number(contactID);
            } else {
                $scope.AngularModel.ProjectContactSimples.push({
                    ContactID: Number(contactID),
                    ContactRelationshipTypeID: relationshipType.ContactRelationshipTypeID
                });
            }
        } // but nothing should happen if it's a many-or-none relationship type
    };

    $scope.resetSelectedContactID = function(relationshipTypeID) {
        $scope.selectedContactID[relationshipTypeID] = "";
    };

    $scope.isOptionSelected = function(person, relationshipType) {
        if (!relationshipType.ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return false;
        }
        return _.any($scope.AngularModel.ProjectContactSimples,
            function(pos) {
                return pos.ContactID == person.PersonID &&
                    pos.ContactRelationshipTypeID == relationshipType.ContactRelationshipTypeID;
            });
    };

    $scope.dropdownDefaultOption = function (relationshipType) {
        if (relationshipType == null) {
            return "Select One";
        }

        if (relationshipType.ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject) {
            return "Select the " + relationshipType.ContactRelationshipTypeName;
        } else {
            return "Add a " + relationshipType.ContactRelationshipTypeName;
        }
    };

    //$scope.validRelationshipTypes = function (personID) {
    //    //debugger;
    //    var contact =
    //        Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllContacts,
    //            "PersonID",
    //            personID);

    //    var valid = contact == null ? [] : contact.ValidContactRelationshipTypeSimples;
    //    return valid;
    //};

    //$scope.getSelectedPrimaryContactContact = function (relationshipType) {
    //    if (relationshipType === null) {
    //        return null;
    //    }

    //    var selectedPrimaryContactContactID =
    //        Sitka.Methods.findElementInJsonArray($scope.AngularModel.ProjectContactSimples,
    //            "RelationshipTypeID",
    //            relationshipType.ContactRelationshipTypeID).ContactID;

    //    var selectedPrimaryContactContact =
    //        Sitka.Methods.findElementInJsonArray($scope.AngularViewData.AllContacts,
    //            "PersonID",
    //            selectedPrimaryContactContactID);

    //    return selectedPrimaryContactContact;
    //}

    //$scope.primaryContactContactHasNoPrimaryContact = function(relationshipType) {
    //    return $scope.getSelectedPrimaryContactContact(relationshipType).PrimaryContactPersonID == null;
    //}

    //$scope.primaryContactContact = function (relationshipType) {
    //    if (relationshipType != null) {
    //        return $scope.getSelectedPrimaryContactContact(relationshipType);
    //    }

    //    return null;
    //}

    //$scope.primaryContactContactPersonDisplayName = function (relationshipType) {
    //    if (relationshipType != null) {
    //        return $scope.getSelectedPrimaryContactContact(relationshipType).PrimaryContactPersonDisplayName;
    //    }

    //    return "nobody";
    //}

    $scope.isPersonSelected = function (personID)
    {
        var primaryContactPersonId = $scope.AngularModel.PrimaryContactPersonID;
        return primaryContactPersonId === personID;
    };

    $scope.getContactsForPrimaryContactDropdown = function ()
    {
        //debugger;
        return $scope.AngularViewData.AllContacts;
    }

    $scope.primaryContactPersonChange = function (personID)
    {
        // Null check done every way we can think of since we've had issues here
        if (personID === "null" || personID === "" || personID === null || (typeof personID === 'undefined'))
        {
            $scope.AngularModel.PrimaryContactPersonID = null;
        }
        else
        {
            $scope.AngularModel.PrimaryContactPersonID = parseInt(personID);
            if ($scope.AngularModel.PrimaryContactPersonID === "NaN")
            {
                alert('Problem in $scope.primaryContactPersonChange');
            }
        }
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.selectedContactID = {};
});

/*-----------------------------------------------------------------------
<copyright file="AddProjectEvaluationController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("AddProjectEvaluationController", function ($scope, angularModelAndViewData) {

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.selectableProjects = [];

    $scope.addProject = function (project) {
        var projectID = project.ProjectID;

        var projectIdInt = parseInt(projectID, 10);
        //console.log('projectIdInt:' + projectIdInt);
        var alreadyAdded = _.find($scope.AngularModel.SelectedProjects, { ProjectID: projectIdInt });
        if (_.isObject(alreadyAdded)) {
            //console.log('alreadyAdded:' + JSON.stringify(alreadyAdded));
            return;
        }

        var newProject = _.find($scope.AngularViewData.ProjectSimples, { ProjectID: projectIdInt });
        $scope.AngularModel.SelectedProjects.push(newProject);
        var indexOfCurrentItem = $scope.selectableProjects.indexOf($scope.SelectedProject);
        if (typeof $scope.selectableProjects[indexOfCurrentItem + 1] !== 'undefined') {
            $scope.SelectedProject = $scope.selectableProjects[indexOfCurrentItem + 1];
        }
        
        $scope.refreshSelectableProjects();
    };
    

    $scope.addFromTaxonomy = function () {
        var selectedLeafID = this.SelectedTaxonomyLeaf.TaxonomyTierID;
        var newProjects = _.filter($scope.selectableProjects, function (p) { return p.TaxonomyLeafID == selectedLeafID; });
        $scope.AngularModel.SelectedProjects = $scope.AngularModel.SelectedProjects.concat(newProjects);
        $scope.refreshSelectableProjects();
    };

    $scope.getSelectableProjects = function () {
        var filteredProjects = _.filter($scope.AngularViewData.ProjectSimples,
                                                function(project) {
                                                    var object = _.find($scope.AngularModel.SelectedProjects,
                                                        function (selectedProject) {
                                                            return project.ProjectID == selectedProject.ProjectID;
                                                        });
                                                    return !_.isObject(object);
                                                });
        
        var sortedProjects = filteredProjects.sort(function (a, b) {
                                                                        var nameA = a.DisplayName.toUpperCase(); // ignore upper and lowercase
                                                                        var nameB = b.DisplayName.toUpperCase(); // ignore upper and lowercase
                                                                        if (nameA < nameB) {
                                                                            return -1;
                                                                        }
                                                                        if (nameA > nameB) {
                                                                            return 1;
                                                                        }

                                                                        // names must be equal
                                                                        return 0;
                                                                    });
        return sortedProjects;


    };

    

    $scope.refreshSelectableProjects = function () {

        $scope.updateSelectedProjectsCount();
        $scope.selectableProjects = $scope.getSelectableProjects();
        setTimeout(function () {
            jQuery(".selectpicker").selectpicker("refresh");
        }, 50);
    }

    $scope.updateSelectedProjectsCount = function () {

        $scope.SelectedProjectCount = $scope.AngularModel.SelectedProjects.length;
    }


    $scope.deleteProject = function (projectToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.SelectedProjects, projectToDelete);
        $scope.refreshSelectableProjects();
    };

    $scope.initSelectableTaxonomies = function () {

        switch ($scope.AngularViewData.TaxonomyLevel) {
        case 1:
            //console.log("case 1 in initSelectableTaxonomies");
            $scope.selectableTaxonomyLeaves = $scope.AngularViewData.TaxonomyLeafSimples;
            break;
        case 2:
            //console.log("case 2 in initSelectableTaxonomies");
            $scope.selectableTaxonomyBranches = $scope.AngularViewData.TaxonomyBranchSimples;
            break;
        case 3:
            //console.log("case 3 in initSelectableTaxonomies");
            break;//Trunk dropdown uses AngularViewData.TaxonomyTrunkSimples directly because it never needs to be filtered
        default:
            console.log('unsupported taxonomy level.');
        }
    }

    $scope.refreshSelectableTaxonomyBranches = function () {
        var selectedTrunk = this.SelectedTaxonomyTrunk.TaxonomyTierID;
        var filteredBranches = _.filter($scope.AngularViewData.TaxonomyBranchSimples, function (b) { return b.ParentTaxonomyID == selectedTrunk; });

        var sortedBranches = filteredBranches.sort(function (a, b) {
            var nameA = a.DisplayName.toUpperCase(); // ignore upper and lowercase
            var nameB = b.DisplayName.toUpperCase(); // ignore upper and lowercase
            if (nameA < nameB) {
                return -1;
            }
            if (nameA > nameB) {
                return 1;
            }

            // names must be equal
            return 0;
        });

        $scope.selectableTaxonomyBranches = sortedBranches;
        setTimeout(function () {
            jQuery(".selectpicker").selectpicker("refresh");
        }, 50);
    }

    $scope.refreshSelectableTaxonomyLeaves = function () {
        var selectedBranch = this.SelectedTaxonomyBranch.TaxonomyTierID;
        var filteredLeaves = _.filter($scope.AngularViewData.TaxonomyLeafSimples, function (l) { return l.ParentTaxonomyID == selectedBranch; });

        var sortedLeaves = filteredLeaves.sort(function (a, b) {
            var nameA = a.DisplayName.toUpperCase(); // ignore upper and lowercase
            var nameB = b.DisplayName.toUpperCase(); // ignore upper and lowercase
            if (nameA < nameB) {
                return -1;
            }
            if (nameA > nameB) {
                return 1;
            }

            // names must be equal
            return 0;
        });

        $scope.selectableTaxonomyLeaves = sortedLeaves;
        setTimeout(function () {
            jQuery(".selectpicker").selectpicker("refresh");
        }, 50);
    }

    $scope.SelectedProjectID = "";
    $scope.SelectedProject = null;
    $scope.AngularModel.SelectedProjects = [];
    $scope.refreshSelectableProjects();
    $scope.selectableTaxonomyBranches = [];
    $scope.selectableTaxonomyLeaves = [];

    $scope.updateSelectedProjectsCount();

    $scope.initSelectableTaxonomies();
});

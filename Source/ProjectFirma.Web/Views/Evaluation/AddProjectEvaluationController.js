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

    //$scope.GeospatialAreaDropdownOptions = [];

    $scope.addProject = function (project) {


        var projectID = project.ProjectID;

        //if (!projectID)
        //{
        //    var firstItem = _.first($scope.GeospatialAreaDropdownOptions);
        //    geospatialAreaID = firstItem.GeospatialAreaID;
        //    //console.log('geospatialAreaID:' + geospatialAreaID);
        //}

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


    //$scope.getGeospatialAreaTypes = function () {
    //    return $scope.AngularViewData.GeospatialAreaTypeSimples;
    //};

    //$scope.isAddButtonDisabled = function () {
    //    var returnValue = true;
    //    if ($scope.GeospatialAreaDropdownOptions.length > 0) {
            
    //        returnValue = false;
    //    }
    //    return returnValue;
    //};

    $scope.getSelectableProjects = function () {
        //debugger;

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

    $scope.selectableProjects = [];

    $scope.refreshSelectableProjects = function () {
        
        $scope.selectableProjects = $scope.getSelectableProjects();
        setTimeout(function () {
            jQuery(".selectpicker").selectpicker("refresh");
        }, 50);
    }


    $scope.deleteProject = function (projectToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.SelectedProjects, projectToDelete);
    };

    
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.SelectedProjectID = "";
    $scope.SelectedProject = {};
    $scope.AngularModel.SelectedProjects = [];
    $scope.refreshSelectableProjects();

});

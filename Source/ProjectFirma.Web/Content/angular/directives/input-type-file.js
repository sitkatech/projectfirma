(function () {
    'use strict';

    angular.module('app.Components.InputTypeFile', [])

        // When required, this module will automatically handle
        // `ng-model` in file inputs.
        // 8/13/2019 TK - taken from: https://gist.github.com/thenikso/8899bc6b760e094dd2b5
        //
        // Usage:
        //
        //    <input type="file" ng-model="myModel" accept="image/*" multiple maxsize="100000">
        //
        // Options:
        // - `multiple` (optional) if specified, the ng-model will be an array of the selected files
        //   otherwise it will be a single file;
        // - `accept` (optional) if specified, an angular `accept` validator will be added to check 
        //   for files' mime type
        // - `maxsize` (optional) if specified, an angular `maxsize` validator will be added to check
        //   for files' size
        //.directive('input', inputTypeFileDirective);
        .directive('input',
            function() {
                return {
                    restrict: 'E',
                    require: '?ngModel',
                    link: function(scope, element, attrs, ngModel) {

                        if (attrs.type !== 'file' || !angular.isDefined(ngModel)) {
                            return;
                        }

                        element.on('change', updateModelWithFile);
                        scope.$on('$destroy',
                            function() {
                                element.off('change', updateModelWithFile);
                            });


                        if (attrs.maxsize) {
                            //console.log('maxsize function');
                            attrs.$observe('maxsize',
                                function(val) {
                                    var maxsize = parseInt(val);
                                    ngModel.$validators.maxsize = function(modelValue, viewValue) {
                                        var value = modelValue || viewValue;
                                        if (!angular.isArray(value)) {
                                            value = [value];
                                        }
                                        for (var i = value.length - 1; i >= 0; i--) {
                                            if (value[i] && value[i].size && value[i].size > maxsize) {
                                                //console.log("maxsize function returning false");
                                                return false;
                                            }
                                        }
                                        //console.log("maxsize function returning true");
                                        return true;
                                    };
                                });
                        }

                        if (attrs.accept) {
                            //console.log('Accept function');
                            attrs.$observe('accept', function(val) {
                                var accept = val.split(',');
                                ngModel.$validators.accept = function (modelValue, viewValue) {
                                    var value = modelValue || viewValue;
                                    if (!angular.isArray(value)) {
                                        value = [value];
                                    }
                                    for (var i = value.length - 1; i >= 0; i--) {
                                        if (value[i] && accept.indexOf(value[i].type) === -1) {
                                            //console.log("accept function returning false");
                                            return false;
                                        }
                                    }
                                    //console.log("accept function returning true");
                                    return true;
                                };
                            });                
                        }

                        function updateModelWithFile(event) {
                            //console.log('updateModelWithFile function');
                            var files = event.target.files;
                            if (!angular.isDefined(attrs.multiple)) {
                                files = files[0];
                            } else {
                                files = Array.prototype.slice.apply(files);
                            }
                            //scope.attachmentForm.$valid;
                            ngModel.$setViewValue(files, event);
                            ngModel.$render();
                        }
                    }
                };
            });

})();
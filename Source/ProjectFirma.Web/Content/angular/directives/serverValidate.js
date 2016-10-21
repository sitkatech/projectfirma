angular.module("server-validate", [])
.directive('serverValidate', ['$http', function ($http) {
    return {

        require: 'ngModel',

        link: function (scope, ele, attrs, c) {
            //console.log('wiring up ' + attrs.ngModel + ' to controller ' + c.$name);              
            scope.$watch('ModelState', function() {
                if (scope.ModelState == null) return;
                var modelStateKey = attrs.serverValidate || attrs.ngModel;
                modelStateKey = modelStateKey.replace('$parent.$index', scope.$parent.$index);
                modelStateKey = modelStateKey.replace('$index', scope.$index);
                //console.log('validation for ' + modelStateKey);
                if (scope.ModelState[modelStateKey]) {                            
                    c.$setValidity('server', false);
                    //console.log(scope.ModelState[modelStateKey]);
                    c.$error.server = scope.ModelState[modelStateKey];
                } 
                else {
                    c.$setValidity('server', true);                            
                }
            });
            scope.$watch(attrs.ngModel, function(oldValue, newValue) {
                if (oldValue != newValue) { c.$setValidity('server', true);
                    c.$error.server = [];
                }
            });
        }
    };
}]);

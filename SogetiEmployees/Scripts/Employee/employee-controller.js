(function() {
    'use strict';

    angular
        .module('hrModule').controller("EmployeeController", ['$scope', 'employeeService', '$location', 'ngDialog',
        function($scope, employeeService, $location, ngDialog) {
            $scope.saveEmployee = function(employee) {
                $scope.error = false;
                employeeService.saveEmployee(employee).$promise.then(
                    function() {
                        $location.url('HR/Employee');
                    },
                    function() {
                        $scope.error = true;
                    }
                );
            };

            employeeService.getDesignations().$promise.then(
                function(data) {
                    $scope.designations = data;
                    //alert("success");
                },
                function(err) {
                    alert("error " + err);
                }
            );

            employeeService.getEmployees().$promise.then(
                function(data) {
                    $scope.employees = data;
                    //alert("success");
                },
                function(err) {
                    alert("error " + err);
                }
            );

            //This should go to its own controller and view 
            //its belongs to directive and its my test code
            $scope.user = {
                name: 'fSyed'
            };
            //Directive end

            $scope.do_some_action = function(employee) {
                //debugger;   
                $scope.employeeDetail = employee;
                ngDialog.open({
                    template: '/templates/popup-employeeDetail.html',
                    scope: $scope,
                    controller: 'PopupEmployeeDetailController'
                });
            }

            $scope.saveEmployeeSalary = function(employeeSalary) {
                $scope.error = false;
                employeeSalary.updatedBy = $scope.user.name;
                employeeService.saveEmployeeSalary(employeeSalary).$promise.then(
                    function() {
                        $scope.error = true;
                    });
            };

            $scope.selectAction = function(employeeId) {
                $scope.employeeSalary.employeeId = employeeId;
                var salary = employeeService.getEmployeeSalary(employeeId);
            };
        }]);
}());
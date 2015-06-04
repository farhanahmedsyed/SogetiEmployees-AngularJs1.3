(function() {
    'use strict';
    var hrModule = angular.module("hrModule", ['ngRoute', 'ngResource', 'ngDialog'])
        .config(['$routeProvider', '$locationProvider',
            function($routeProvider, $locationProvider) {
                $routeProvider.when('/HR/Employee', { templateUrl: '/templates/employee.html', controller: 'EmployeeController' }).otherwise({
                    redirectTo: '/HR'
                });
                $routeProvider.when('/HR/CreateEmployee', { templateUrl: '/templates/create-employee.html', controller: 'EmployeeController' }).otherwise({
                    redirectTo: '/HR'
                });
                $routeProvider.when('/HR/EmployeeSalary', { templateUrl: '/templates/create-employeeSalary.html', controller: 'EmployeeController' }).otherwise({
                    redirectTo: '/HR'
                });
                $locationProvider.html5Mode({
                    enabled: true,
                    requireBase: false
                });
            }]);
}());
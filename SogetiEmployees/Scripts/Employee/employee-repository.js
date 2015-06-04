(function() {
    'use strict';

    angular
    .module('hrModule').factory('employeeRepository', ['$resource', function ($resource) {
        return {
            saveEmployee: function(employee) {
                return $resource('/Api/Employee/SaveEmployee').save(employee);
            },
            getDesignations: function() {
                return $resource('/Api/Employee/GetDesignations').query();
            },
            getEmployees: function() {
                return $resource('/Api/Employee/GetEmployees').query();
            },
            saveEmployeeSalary: function(employeeSalary) {
                return $resource('/Api/Employee/SaveEmployeeSalary').save(employeeSalary);
            },
            getEmployeeSalary: function(id) {
                return $resource('/Api/Employee/GetEmployeeSalary').get({ id: id });
            }
        };
    }]);
}());
//getEmployees: function () {            
//    return $resource('/Api/Employee/GetEmployees').query().$promise.then(function (data) {
//        alert("success");
//    }, function (error) {
//        alert("error");
//    });;
//},
(function() {

'use strict';

angular
    .module('hrModule').factory('employeeService', ['employeeRepository', function (employeeRepository) {
        return {
            getDesignations: function() {
                return employeeRepository.getDesignations();
            },
            getEmployees: function() {
                return employeeRepository.getEmployees();
            },
            getEmployeeSalary: function(id) {
                return employeeRepository.getEmployeeSalary(id);
            },
            saveEmployee: function(employee) {
                return employeeRepository.saveEmployee(employee);
            },
            saveEmployeeSalary: function(employeeSalary) {
                return employeeRepository.saveEmployeeSalary(employeeSalary);
            }
        };
    }]);
}());
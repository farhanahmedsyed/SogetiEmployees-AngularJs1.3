(function() {
    'use strict';

    angular
        .module('hrModule').directive('myUser', function() {
            return {
                template: 'User: {{user.name}}',
                restrict: "E"
            };
        });
}());
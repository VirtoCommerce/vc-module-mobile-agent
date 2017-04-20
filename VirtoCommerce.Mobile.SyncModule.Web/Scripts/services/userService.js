angular.module("virtoCommerce.syncMobileModule")
.factory('virtoCommerce.syncMobileModule.userService', ['$resource', function ($resource) {
    return $resource('api/mobile/settings/', {}, {
        getUserSettings: { method: 'GET', url: 'api/mobile/settings/:userName', params: { userName: "@userName" } },
        saveUserSettings: { method: 'POST', url: 'api/mobile/settings' }
    });
}]);
//Call this to register our module to main application
var moduleName = "virtoCommerce.syncMobileModule";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}
angular.module(moduleName, []).config(
  ['$stateProvider', function ($stateProvider) {
      $stateProvider
          .state('workspace.syncMobileModule', {
              url: '/mobile/sync',
              templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
              controller: [
                  '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                      var blade = {
                          id: 'syncMobileUsers',
                          title: 'Users',
                          subtitle: 'customer.widgets.customer-accounts-list.blade-subtitle',
                          template: 'Modules/$(VirtoCommerce.Mobile.SyncModule)/Scripts/blades/list-users/view.tpl.html',
                          controller: 'virtoCommerce.syncMobileModule.ListUsersController',
                          isClosingDisabled: true
                      };
                      bladeNavigationService.showBlade(blade);
                      //Need for isolate and prevent conflict module css to other modules 
                      $scope.moduleName = "sync-mobile";
                  }
              ]
          });
  }]
)
.run(
  ['$rootScope', 'platformWebApp.mainMenuService', '$state', function ($rootScope, mainMenuService, $state) {
      //Register module in main menu
      var menuItem = {
          path: 'configuration/syncMobile',
          icon: 'fa fa-refresh',
          title: 'Sync mobile',
          priority: 90,
          action: function () {
              $state.go('workspace.syncMobileModule');
          },
      };
      mainMenuService.addMenuItem(menuItem);
  }]);
angular.module("virtoCommerce.syncMobileModule")
.controller("virtoCommerce.syncMobileModule.ListUsersController", ['$scope', 'platformWebApp.accounts', 'platformWebApp.dialogService', 'platformWebApp.uiGridHelper', 'platformWebApp.bladeNavigationService', 'platformWebApp.bladeUtils',
function ($scope, accounts, dialogService, uiGridHelper, bladeNavigationService, bladeUtils) {
    $scope.uiGridConstants = uiGridHelper.uiGridConstants;
    var blade = $scope.blade;

    blade.refresh = function () {
        blade.isLoading = true;

        accounts.search({
            keyword: filter.keyword,
            sort: uiGridHelper.getSortExpression($scope),
            skipCount: ($scope.pageSettings.currentPage - 1) * $scope.pageSettings.itemsPerPageCount,
            takeCount: $scope.pageSettings.itemsPerPageCount
        }, function (data) {
            blade.isLoading = false;

            $scope.pageSettings.totalItems = data.totalCount;
            blade.currentEntities = data.users;
        }, function (error) {
            bladeNavigationService.setError('Error ' + error.status, blade);
        });
    };

    blade.selectNode = function (node) {
        $scope.selectedNodeId = node.userName;

        var newBlade = {
            id: 'listItemChild',
            data: node,
            title: node.userName,
            subtitle: blade.subtitle,
            controller: 'virtoCommerce.syncMobileModule.EditUsersController',
            template: 'Modules/$(VirtoCommerce.Mobile.SyncModule)/Scripts/blades/edit-user/view.tpl.html',
        };

        bladeNavigationService.showBlade(newBlade, blade);
    };

    blade.headIcon = 'fa-key';

    blade.toolbarCommands = [
        {
            name: "platform.commands.refresh", icon: 'fa fa-refresh',
            executeMethod: blade.refresh,
            canExecuteMethod: function () {
                return true;
            }
        }
    ];


    var filter = $scope.filter = {};
    filter.criteriaChanged = function () {
        if ($scope.pageSettings.currentPage > 1) {
            $scope.pageSettings.currentPage = 1;
        } else {
            blade.refresh();
        }
    };

    // ui-grid
    $scope.setGridOptions = function (gridOptions) {
        uiGridHelper.initialize($scope, gridOptions, function (gridApi) {
            uiGridHelper.bindRefreshOnSortChanged($scope);
        });
        bladeUtils.initializePagination($scope);
    };

    // actions on load
    //No need to call this because page 'pageSettings.currentPage' is watched!!! It would trigger subsequent duplicated req...
    //blade.refresh();
}]);
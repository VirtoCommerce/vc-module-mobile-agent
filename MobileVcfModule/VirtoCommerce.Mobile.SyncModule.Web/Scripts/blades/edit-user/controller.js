angular.module("virtoCommerce.syncMobileModule")
.controller("virtoCommerce.syncMobileModule.EditUsersController", ['$scope', 'platformWebApp.bladeNavigationService', 'virtoCommerce.syncMobileModule.userService',
function ($scope, bladeNavigationService, userService) {
    var blade = $scope.blade;
    blade.toolbarCommands = [{
        name: "platform.commands.save",
        icon: 'fa fa-save',
        executeMethod: function () {
            blade.isLoading = true;
            userService.saveUserSettings($scope.setting, function (data) {
                blade.isLoading = false;
            }, function (err) {
                console.error(err);
            });
        },
        canExecuteMethod: function () {
            return true;
        }
    }];
    //load settings for user
    $scope.refresh = function () {
        blade.isLoading = true;
        userService.getUserSettings({ userName: blade.data.userName }, function (data) {
            blade.isLoading = false;
            if (data.id) {
                data.selectStore.taxProviders = [];
                $scope.setting = data;
            }
            else {
                $scope.setting = { accountId: blade.data.id };
            }
        }, function (err) { console.error(err); });
    }

    $scope.showSelectCategory = function()
    {
        var selectedListItems = [];
        var options = {
            showCheckingMultiple: false,
            allowCheckingItem: false,
            allowCheckingCategory: true,
            selectedItemIds:$scope.setting.selectCategiry? [$scope.setting.selectCategory.id]:[],
            checkItemFn: function (listItem, isSelected) {
                if (isSelected) {
                    if (_.all(selectedListItems, function (x) { return x.id != listItem.id; })) {
                        selectedListItems.push(listItem);
                    }
                }
                else {
                    selectedListItems = _.reject(selectedListItems, function (x) { return x.id == listItem.id; });
                }
            }
        };
        var scopeOriginal = this.scopeOriginal;
        var newBlade = {
            id: "CatalogSelect",
            title: "catalog.blades.catalog-items-select.title",
            controller: 'virtoCommerce.syncMobileModule.SelectCatalogController',
            template: 'Modules/$(VirtoCommerce.Mobile.SyncModule)/Scripts/blades/select-store/view.tpl.html',
            options: options,
            breadcrumbs: [],
            setCurrentCatalog: function (selectItem) {
                $scope.setting.selectStore = { id: selectItem.id };
                blade.isLoading = true;
                userService.saveUserSettings($scope.setting, function (data) {
                    blade.isLoading = false;
                    $scope.refresh();
                }, function (err) {
                    blade.isLoading = false;
                    console.error(err);
                });
            }
            
        };
        bladeNavigationService.showBlade(newBlade, blade);
    }
    $scope.refresh();
}]);
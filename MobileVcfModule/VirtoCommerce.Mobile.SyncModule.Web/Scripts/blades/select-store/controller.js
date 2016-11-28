angular.module("virtoCommerce.syncMobileModule")
.controller("virtoCommerce.syncMobileModule.SelectCatalogController", ['$scope', 'virtoCommerce.storeModule.stores', 'virtoCommerce.catalogModule.listEntries', 'platformWebApp.bladeUtils', 'uiGridConstants', 'platformWebApp.uiGridHelper', '$timeout',
function ($scope, stores, listEntries, bladeUtils, uiGridConstants, uiGridHelper, $timeout) {
    var blade = $scope.blade;
    var bladeNavigationService = bladeUtils.bladeNavigationService;

    if (!blade.title) {
        blade.title = "Select store";
    }
    blade.refresh = function () {
        blade.isLoading = true;
        stores.search({
            keyword: filter.keyword ? filter.keyword : undefined,
            //sort: uiGridHelper.getSortExpression($scope),
            skip: ($scope.pageSettings.currentPage - 1) * $scope.pageSettings.itemsPerPageCount,
            take: $scope.pageSettings.itemsPerPageCount
        }, function (data) {
            blade.isLoading = false;
            $scope.pageSettings.totalItems = data.totalCount;
            $scope.items = data.stores;
        }, function (error) {
            bladeNavigationService.setError('Error ' + error.status, blade);
        });
    }

    $scope.selectItem = function (e, listItem) {
        blade.setCurrentCatalog(listItem);
        bladeNavigationService.closeBlade(blade);
    };

    // simple and advanced filtering
    var filter = blade.filter = { keyword: null };

    filter.criteriaChanged = function () {
        if ($scope.pageSettings.currentPage > 1) {
            $scope.pageSettings.currentPage = 1;
        } else {
            blade.refresh();
        }
    };

    // ui-grid
    $scope.setGridOptions = function (gridOptions) {
        gridOptions.isRowSelectable = function (row) {
            return ($scope.options.allowCheckingItem && row.entity.type !== 'category') || ($scope.options.allowCheckingCategory && row.entity.type === 'category');
        };

        uiGridHelper.initialize($scope, gridOptions, externalRegisterApiCallback);
    };

    bladeUtils.initializePagination($scope);

    function externalRegisterApiCallback(gridApi) {
        gridApi.grid.registerDataChangeCallback(function (grid) {
            //check already selected rows
            $timeout(function () {
                _.each($scope.items, function (x) {
                    if (_.some($scope.options.selectedItemIds, function (y) { return y == x.id; })) {
                        gridApi.selection.selectRow(x);
                    }
                });
            });
        }, [uiGridConstants.dataChange.ROW]);

        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            if ($scope.options.checkItemFn) {
                $scope.options.checkItemFn(row.entity, row.isSelected);
            };
            if (row.isSelected) {
                if (!_.contains($scope.options.selectedItemIds, row.entity.id)) {
                    $scope.options.selectedItemIds.push(row.entity.id);
                }
            }
            else {
                $scope.options.selectedItemIds = _.without($scope.options.selectedItemIds, row.entity.id);
            }
        });

        uiGridHelper.bindRefreshOnSortChanged($scope);
    }

    //No need to call this because page 'pageSettings.currentPage' is watched!!! It would trigger subsequent duplicated req...
    //blade.refresh();
}]);

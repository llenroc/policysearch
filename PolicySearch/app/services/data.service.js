(function () {
    angular
        .module("app")
        .service("DataService", dataService);

    dataService.$inject = ["$http"];

    function dataService($http) {
        let vm = this;

        vm.getPolicies = function (searchPhrase, success, error) {

            let url = $location.path("\api\policies");

            $http({
                url: url,
                method: "GET",
                data: searchPhrase
            })
            .success(function(data, status) {
                success(data, status);
            })
            .error(function(data, status) {
                error(data, status)
            });
        };
    }
})();
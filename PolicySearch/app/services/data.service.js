(function () {
    angular
        .module("app")
        .service("DataService", dataService);

    dataService.$inject = ["$http", "$location"];

    function dataService($http, $location) {
        let vm = this;

        vm.getPolicies = function (searchPhrase, success, error) {

            let url = window.location.protocol + "//" + location.host + "/api/policy";

            let searchDetails = {
                searchPhrase: searchPhrase
            };

            $http({
                url: url,
                method: "POST",
                data: searchDetails
            })
            .success(function (data, status) {
                success(data, status);
            })
            .error(function (data, status) {
                error(data, status)
            });
        };
    }
})();
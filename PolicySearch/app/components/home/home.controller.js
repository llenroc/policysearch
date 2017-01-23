(function () {
    "use strict";

    angular
        .module("app")
        .controller("homeController", home);

    home.$inject = ["DataService"];

    function home(DataService) {
        let vm = this;

        vm.title = "Home";
        vm.searchPhrase = "";
        vm.results = [];

        vm.search = function (form) {
            if (form.$invalid) {
                return;
            }

            DataService.getPolicies(vm.searchPhrase,
                function (data, status) {
                    console.log("data", data, "status", status);
                    vm.results = data;
                },
                function (data, status) {
                    console.log("data", data, "status", status);
                });
        }
    }
})();
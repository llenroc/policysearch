(function () {
    "use strict";

    angular
        .module("app")
            .config(function ($routeProvider) {
               $routeProvider
               .when("/", {
                   controller: "homeController",
                   templateUrl: "app/components/home/home.view.html"
               })
            });
})();
(function () {
    angular
        .module("app")
        .component("homeController", homeController);

    function homeController() {
        let vm = this;

        vm.title = "Home";
    }
})();
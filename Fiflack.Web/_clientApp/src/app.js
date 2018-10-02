
(function () {
    "use strict";

    angular.module('Fiflack', ['ui.router', 'ngAnimate', 'ngSanitize', 'ui.bootstrap', 'toaster'])

        .config(Config)

        .service('playersService', playersService)
        .service("competitionsService", competitionsService)
        .service('matchScoresService', matchScoresService)
        .service('questionDlgService', questionDlgService)
        .service('toasterService', toasterService)

        .directive('playerLogin', playerLoginDirective)

        .controller('playersController', playersController)
        .controller('editPlayerDlgController', editPlayerDlgController)
        .controller('questionDlgController', questionDlgController)
        .controller("competitionsController", competitionsController)
        .controller("competitionController", competitionController)
        .controller('mainController', mainController)
        .controller('newMatchController', newMatchController)




})();
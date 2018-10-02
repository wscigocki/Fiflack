function playersController($uibModal, $log, playersService, questionDlgService, toasterService, resolvedPlayers) {
    var $ctrl = this;
    $ctrl.players = resolvedPlayers.data;

    $ctrl.getPlayers = function () {

        var playersPromise = playersService.getPlayers();
        playersPromise.then(
            function (response) {
                $ctrl.players = response.data;
            },
            function (error) {
                console.log('error: ' + response.ExceptionMessage);
            }
        );
    };

    $ctrl.showNewPlayerDlg = function () {
        var modalInstance = $ctrl.showPlayerDlg(true);

        modalInstance.result.then(function (player) {
            $ctrl.addPlayer(player);
        }, function () {
        });
    };

    $ctrl.showEditPlayerDlg = function (playerId) {

        var promise = playersService.getPlayer(playerId);
        promise.then(
            function (response) {
                var modalInstance = $ctrl.showPlayerDlg(false, response.data.login, response.data.name);

                modalInstance.result.then(function (player) {
                    $log.info('Modal approved', player);
                    $ctrl.updatePlayer(playerId, player);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            },
            function (response) {
                console.log('error: ' + response.data.Message);
                console.log(response);
            }
        );
    };

    $ctrl.showPlayerDlg = function (newPlayerMode, playerLogin, playerName) {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '_clientApp/src/states/players/editPlayerDlg.html',
            controller: 'editPlayerDlgController',
            controllerAs: '$ctrl',
            size: 'sm',
            resolve: {
                dlgSetup: function () {
                    return {
                        newPlayerMode: newPlayerMode,
                        playerName: playerName,
                        playerLogin: playerLogin
                    }
                }
            }
        });

        return modalInstance;
    };

    $ctrl.addPlayer = function (newPlayer) {

        var promise = playersService.addPlayer(newPlayer);
        promise.then(
            function (response) {
                toasterService.showInfo("Gracz " + newPlayer.name + ' został dodany.');
                $ctrl.getPlayers();
            },
            function (response) {
                toasterService.showError(response.data.Message);
            }
        );
    };

    $ctrl.updatePlayer = function (playerId, player) {

        var promise = playersService.updatePlayer(playerId, player);
        promise.then(
            function (response) {
                toasterService.showInfo("Dane gracza " + player.name + ' zostały zaktualizowane.');
                $ctrl.getPlayers();
            },
            function (response) {
                toasterService.showError(response.data.Message);
            }
        );
    };

    $ctrl.deletePlayer = function (id, login) {

        var question = questionDlgService.showQuestionDlg('Czy napewno chcesz usynąć gracza "' + login + '"?', 'Tak', 'Nie')

        question.result.then(function () {
            var promise = playersService.deletePlayer(id);
            promise.then(
                function (response) {
                    toasterService.showWarning("Gracz " + name + ' został usunięty.');
                    $ctrl.getPlayers();
                },
                function (response) {
                    toasterService.showError(response.data.Message);
                    console.log('error: ' + response.ExceptionMessage);
                }
            );
        }, function () {
            
        });
    };
}
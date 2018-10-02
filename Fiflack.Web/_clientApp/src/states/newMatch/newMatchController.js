function newMatchController(matchScoresService, toasterService, resolvedPlayers, resolvedCompetition) {
    var $ctrl = this;

    $ctrl.players = resolvedPlayers.data;
    $ctrl.competition = resolvedCompetition.data;

    $ctrl.player1 = $ctrl.players[0];
    $ctrl.player2 = $ctrl.players[1];

    $ctrl.playerGoals_1 = 0;
    $ctrl.playerGoals_2 = 0;

    $ctrl.saveScore = function () {
        var matchScore = {
            playerId_1: $ctrl.player1.id,
            playerId_2: $ctrl.player2.id,
            goalsOfPlayer_1: $ctrl.playerGoals_1,
            goalsOfPlayer_2: $ctrl.playerGoals_2,
            playedOn: new Date()
        };

        var promise = matchScoresService.addCompetitionMatch($ctrl.competition.id, matchScore);

        promise.then(function (result) {
            toasterService.showInfo('Wynik meczu dodany.');
        }, function (error) {
            toasterService.showError('Nie udało się zapisać wyniku meczu. ' + error);
        }
        )
    }

    $ctrl.onChangePlayer1 = function () {
        if ($ctrl.player1 === $ctrl.player2) {
            $ctrl.player2 = $ctrl.getOtherPlayer($ctrl.player1);
        }
    }

    $ctrl.onChangePlayer2 = function () {
        if ($ctrl.player1 === $ctrl.player2) {
            $ctrl.player1 = $ctrl.getOtherPlayer($ctrl.player2);
        }
    }

    $ctrl.getOtherPlayer = function (excludedPlayer) {
        return $ctrl.players.find(function (player) {
            return player.id != excludedPlayer.id;
        });
    }
}
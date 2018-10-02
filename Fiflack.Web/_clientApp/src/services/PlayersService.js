function playersService($q, $http) {
    var service = this;

    service.getPlayers = function () {
        return $http({
            url: '/api/players'
        });
    }

    service.getPlayer = function (id) {
        return $http({
            method: 'GET',
            url: '/api/players',
            params: { id: id }
        });
    }

    service.deletePlayer = function (id) {
        return $http({
            method: 'DELETE',
            url: '/api/players',
            params: {id: id}
        });
    }

    service.addPlayer = function (newPlayer) {

        console.log('newPlayer', newPlayer);
        var player = {
            Id: -1,
            Name: newPlayer.name,
            Login: newPlayer.login
        };

        console.log('player', player);


        return $http({
            method: 'POST',
            url: '/api/players',
            data: player
        });
    }

    service.updatePlayer = function (playerId, updatedPlayer) {

        var player = {
            Id: playerId,
            Name: updatedPlayer.name,
            Login: updatedPlayer.login
        };

        return $http({
            method: 'PUT',
            url: '/api/players',
            params: { id: playerId },
            data: player
        });
    }

    service.isPlayerLoginAvailable = function (playerLogin) {
        return $http({
            method: 'POST',
            url: '/api/players/validateLogin',
            params: { login: playerLogin }
        });
    };
}
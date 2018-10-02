function competitionsService($http) {
    var service = this;

    service.getCompetitions = function () {
        return $http({
            url: '/api/competitions'
        });
    }

    service.getCompetition = function (id) {
        return $http({
            url: '/api/competitions',
            params: { id: id }
        });
    }
}
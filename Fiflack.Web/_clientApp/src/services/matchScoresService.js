function matchScoresService($http) {
    var service = this;

    service.getForCompetition = function (id) {

        return $http({
            method: 'GET',
            url: '/api/matchscores/competitions/' + id
        })
    }

    service.addCompetitionMatch = function (competitionId, matchScore) {

        return $http({
            method: 'POST',
            url: '/api/matchscores/competitions/' + competitionId,
            data: matchScore
        })
    }

}

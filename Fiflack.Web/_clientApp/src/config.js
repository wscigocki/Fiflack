Config.$inject = ["$stateProvider", "$urlRouterProvider"];
function Config($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/main');

    $stateProvider

        .state('main', {
            url: '/main',
            templateUrl: "_clientApp/src/states/main/main.html",
            controller: 'mainController as $ctrl'
        })

        .state('players', {
            url: '/players',
            templateUrl: "_clientApp/src/states/players/players.html",
            controller: 'playersController as $ctrl',
            resolve: {
                resolvedPlayers: ['playersService', function (playersService) {
                    return playersService.getPlayers()
                }
                ]
            }
        })

        .state('competitions', {
            url: '/competitions',
            templateUrl: "_clientApp/src/states/competitions/competitions.html",
            controller: 'competitionsController as $ctrl',
            resolve: {
                resolvedCompetitions: ['competitionsService', function (competitionsService) {
                    return competitionsService.getCompetitions()
                }
                ]
            }
        })

        .state('competition', {
            url: '/competition/{id}',
            templateUrl: "_clientApp/src/states/competition/competition.html",
            controller: 'competitionController as $ctrl',
            resolve: {
                resolvedCompetition: ['competitionsService', '$transition$', function (competitionsService, $transition$) {
                    return competitionsService.getCompetition($transition$.params().id)
                }
                ],
                resolvedMatchScores: ['matchScoresService', '$transition$', function (matchScoresService, $transition$) {
                    return matchScoresService.getForCompetition($transition$.params().id)
                }
                ]
            }
        })

        .state('newCompetitionMatch', {
            url: '/newCompetitionMatch/{id}',
            templateUrl: "_clientApp/src/states/newMatch/newMatch.html",
            controller: 'newMatchController as $ctrl',
            resolve: {
                resolvedPlayers: ['playersService', function (playersService) {
                    return playersService.getPlayers()
                }
                ],
                resolvedCompetition: ['competitionsService', '$transition$', function (competitionsService, $transition$) {
                    return competitionsService.getCompetition($transition$.params().id)
                }
                ]
            }
        });

}
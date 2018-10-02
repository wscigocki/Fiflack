function competitionController(resolvedCompetition, resolvedMatchScores) {

    var $ctrl = this;

    $ctrl.competition = resolvedCompetition.data;
    $ctrl.matchScores = resolvedMatchScores.data;
}
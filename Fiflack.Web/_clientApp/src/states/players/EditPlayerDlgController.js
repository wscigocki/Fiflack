function editPlayerDlgController($uibModalInstance, dlgSetup ) {

    var $ctrl = this;
    $ctrl.title = '';
    $ctrl.playerName = '';
    $ctrl.playerLogin = '';

    if (dlgSetup.newPlayerMode) {
        $ctrl.title = 'Dodaj nowego gracza';
        $ctrl.playerName = '';
        $ctrl.playerLogin = '';
    }
    else {
        $ctrl.title = 'Edytuj dane gracza';
        $ctrl.playerName = dlgSetup.playerName;
        $ctrl.playerLogin = dlgSetup.playerLogin;
    }

    $ctrl.ok = function () {
        $uibModalInstance.close({
            name: $ctrl.playerName,
            login: $ctrl.playerLogin
        });
    };

    $ctrl.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $ctrl.delete = function (questionDlgService) {
        var question = questionDlgService.showQuestionDlg('Czy napewno chcesz usynąć tego gracza?');
    };
}
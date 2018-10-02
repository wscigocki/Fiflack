function questionDlgController(dlgSetup, $uibModalInstance) {

    var $ctrl = this;
    $ctrl.title = dlgSetup.title;
    $ctrl.question = dlgSetup.question;
    $ctrl.ok = dlgSetup.ok;
    $ctrl.cancel = dlgSetup.cancel;

    console.log('QuestionDlgController');

    if (!$ctrl.title) {
        $ctrl.title = 'Pytanie';
    }

    if (!$ctrl.ok) {
        $ctrl.ok = 'Ok';
    }

    if (!$ctrl.cancel) {
        $ctrl.cancel = 'Anuluj';
    }

    $ctrl.okClick = function () {
        $uibModalInstance.close();
    };

    $ctrl.cancelClick = function () {
        $uibModalInstance.dismiss();
    };
}
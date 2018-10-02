function questionDlgService($uibModal) {

    var service = this;

    service.showQuestionDlg = function (question, ok, cancel) {

        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '_clientApp/src/common/questionDlg/questionDlg.html',
            controller: 'questionDlgController',
            controllerAs: '$ctrl',
            size: 'sm',
            resolve: {
                dlgSetup: function () {
                    return {
                        question: question,
                        ok: ok,
                        cancel: cancel
                    }
                }
            }
        });

        return modalInstance;

    }

}
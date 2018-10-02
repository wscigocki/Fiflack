function toasterService(toaster) {

    var service = this;

    service.showInfo = function (info) {
        toaster.pop('info', '', info);
    };

    service.showWarning = function(warning) {
        toaster.pop('warning', '', warning);
    };

    service.showError = function (error) {
        toaster.pop('error', '', error);
    };
}
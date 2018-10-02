function playerLoginDirective($q, $timeout, playersService) {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$asyncValidators.playerlogin = function (modelValue, viewValue) {

                if (ctrl.$isEmpty(modelValue)) {
                    return $q.resolve();
                }

                if (!scope.oryginalLogin)
                    scope.oryginalLogin = attrs.oryginalLogin;

                if (viewValue === scope.oryginalLogin) {
                    return $q.resolve();
                }

                return playersService.isPlayerLoginAvailable(viewValue);
            };
        }
    };
};
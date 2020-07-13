$(function () {
    app.initialize();

    // Activate Knockout
    ko.validation.init({
        errorsAsTitle: false,
        insertMessages: true,
        grouping: { observable: false },
        errorMessageClass: 'ui pointing red basic label',
        //messageTemplate: "ValidationMessageTemplate"
    });
    ko.options.deferUpdates = false;
    ko.applyBindings(app);
});

InitializeAutoLogout = function (initCountdownValueInSeconds, dialogShownAtSecondsLeft) {
    initCountdownValueInSeconds = initCountdownValueInSeconds || 60;
    dialogShownAtSecondsLeft = dialogShownAtSecondsLeft || 15;
    var inactivityCountdown = ko.observable(initCountdownValueInSeconds);
    var dialogShown = false;
    var dialogID = "AutoLogoutPreventDialog";
    var errorTextObservable = ko.observable();
    window.setInterval(function () {
        inactivityCountdown(inactivityCountdown() - 1);
        var countdownValue = inactivityCountdown();
        if (countdownValue <= dialogShownAtSecondsLeft) {
            errorTextObservable("You will be logged out in " + countdownValue + " seconds");
            if (dialogShown != true) {
                dialogShown = true;
                ShowDialog(errorTextObservable, "Attention", [{
                    ButtonText: "Don't logout", Callback: function () {
                        dialogShown = false;
                        inactivityCountdown(initCountdownValueInSeconds);
                    }
                }], dialogID);
            }
            if (countdownValue < 1)
                Logout();
        }
    }, 1000);
    var dialogSelector = '#' + dialogID;
    $(document).on("click scroll mousemove change keydown", function () {
        inactivityCountdown(initCountdownValueInSeconds);
        if (dialogShown) {
            $(dialogSelector).modal('hide');
            dialogShown = false;
        }
    });
    AutoLogoutInitialized = true;
}
Logout = function () {
    sessionStorage.removeItem('accessToken');
    $('#logoutForm').submit();
}
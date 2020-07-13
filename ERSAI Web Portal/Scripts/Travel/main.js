require(['jquery', 'knockout', 'viewModel'], function ($, ko, viewModel) {
    $(document).ready(function () {
        ko.applyBindings(viewModel);
    });
});
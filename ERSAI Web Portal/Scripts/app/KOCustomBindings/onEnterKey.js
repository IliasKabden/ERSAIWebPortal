ko.bindingHandlers.onEnterKey = {
    init: function (element, valueAccessor, allBindings, viewModel) {
        var callback = valueAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                $(element).trigger("change");
                callback(element.value);
                return false;
            }
            return true;
        });
    }
};
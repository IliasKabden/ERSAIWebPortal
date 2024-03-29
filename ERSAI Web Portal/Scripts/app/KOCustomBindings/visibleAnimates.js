﻿ko.bindingHandlers.visibleAnimated = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        ko.unwrap(value) ? $(element).show() : $(element).hide();// Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slowly fade the element in or out
        var value = valueAccessor();
        ko.unwrap(value) ? $(element).fadeIn(ko.bindingHandlers.visibleAnimated.duration) : $(element).fadeOut(ko.bindingHandlers.visibleAnimated.duration);
    },
    duration: 500
};
"use strict";

function BasicClass(initData, props, newIfInitDataIsNull) {
    var _this = this;

    var self = this;

    self.Properties = props;

    props.forEach(function (property) {
        var propObservable = property.ComputedOptions ? ko.computed(property.ComputedOptions, _this) : property.Array ? ko.observableArray() : ko.observable();

        if (property.Required) {
            propObservable = propObservable.extend({
                required: {
                    message: (property.DisplayName || property.Name) + " is required"
                }
            });
        }
        if (property.SubscribeFunction) propObservable.subscribe(property.SubscribeFunction.bind(self));

        self[property.Name] = propObservable;
    });

    self.FromJS = function (data) {
        self.initData = initData;
        props.forEach(function (property) {
            if (property.ComputedOptions && !property.ComputedOptions.write) return;
            var OrigData = data[property.OrigName || property.Name] || (property.Array ? [] : null);
            var propObservable = self[property.Name];
            propObservable(property.Class ? property.NewIfNull || OrigData ? new property.Class(OrigData, property.Properties) : OrigData : OrigData);
        });
    };
    self.ToJS = function () {
        var item = {};
        props.forEach(function (property) {
            if (property.ComputedOptions && !property.ComputedOptions.write) return;

            var value = self[property.Name]();
            if (value != null) {
                if (!String(value).trim()) {
                    value = null;
                }
            }
            item[property.OrigName || property.Name] = property.Class && value ? value.ToJS() : value;
        });
        return item;
    };

    self.ValidationErrors = ko.validation.group(self, { deep: true });

    if (initData != null || newIfInitDataIsNull) self.FromJS(initData || {});

    return self;
}


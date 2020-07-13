ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        element.style.opacity = 1;
        var valueObservable = valueAccessor();
        if (ko.isObservable(valueObservable) != true)
            valueObservable = ko.observable();
        allBindingsAccessor = allBindingsAccessor()
        var $el = $(element);

        var options = allBindingsAccessor['dpOptions'] || {};
        var manualInputEnabled = options.manual == true;

        if (manualInputEnabled) {
            $(element).mask(options.timepicker == true ? '00/00/0000 00:00' : '00/00/0000');
            element.onchange = function () {
                var momentTime = moment(element.value, 'DD/MM/YYYY HH:mm:ss');
                var datepicker = $(element).data('datepicker');
                if (momentTime.isValid() == true)
                    datepicker.selectDate(new Date(momentTime));
                else {
                    if (valueObservable())
                        datepicker.selectDate(new Date(valueObservable()));
                    else
                        datepicker.clear();
                }
            };
        }
        else {
            $el.prop('readonly', true);
        }
        $el.addClass('datepicker-here');

        //initialize datepicker with some optional options
        Object.assign(options,
            {
                onSelect: function (d, s) {
                    try {
                        if (s != null && s != "")
                            valueObservable(moment(s).format('YYYY-MM-DDTHH:mm:ss'));
                        else valueObservable(null);
                    }
                    catch (e) {
                        valueObservable(null);
                    }
                },
                autoClose: true,
                language: options.language || "en",
                dateFormat: "dd/mm/yyyy"
            });
        $el.datepicker(options);
        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $el.datepicker("destroy");
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var value = ko.unwrap(valueAccessor());
        if (ko.isObservable(valueAccessor())) {
            var datepicker = $(element).data('datepicker');
            if (value != null)
                datepicker.selectDate(new Date(value));
            else
                datepicker.clear();
        }
    }
};
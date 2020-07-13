"use strict";

function PayslipsViewModel(app, dataModel) {
    var self = this;

    self.Months = ko.observableArray();
    self.Languages = [{ ID: 1, Name: "KAZ", locale: "kk" }, { ID: 3, Name: "RUS", locale: "ru" }, { ID: 2, Name: "ENG", locale: "en" }];
    self.SelectedLanguageID = ko.observable(self.Languages[2].ID);
    self.SelectedLanguage = ko.computed(function () {
        return self.Languages.find(function (l) {
            return l.ID == self.SelectedLanguageID();
        });
    });

    self.Load = function () {
        app.dataModel.Payslips.GetPayslips().done(function (payslipDates) {
            self.Months.removeAll();
            self.Months.push.apply(self.Months, payslipDates.map(function (d) {
                var item = {
                    MomentDate: moment(d)
                };
                item.PrintURL = ko.computed(function () {
                    return "/PersonalAccount/PayslipPDF?date=" + d + "&lang=" + self.SelectedLanguageID();
                });
                item.DisplayText = ko.computed(function () {
                    var word = item.MomentDate.locale(self.SelectedLanguage().locale).format('MMMM YYYY');
                    return word[0].toUpperCase() + word.substr(1);
                });
                return item;
            }));
        });
    };

    return self;
}

app.addViewModel({
    name: "Payslips",
    bindingMemberName: "Payslips",
    factory: PayslipsViewModel
});


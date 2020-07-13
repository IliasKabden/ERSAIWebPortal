function PayslipsViewModel(app, dataModel) {
    var self = this;

    self.Months = ko.observableArray();
    self.Languages = [{ ID: 1, Name: "KAZ", locale: "kk" }, { ID: 3, Name: "RUS", locale: "ru" }, { ID: 2, Name: "ENG", locale: "en" }];
    self.SelectedLanguageID = ko.observable(self.Languages[2].ID);
    self.SelectedLanguage = ko.computed(() => self.Languages.find(l=>l.ID == self.SelectedLanguageID()));

    self.Load = function () {
        app.dataModel.Payslips.GetPayslips().done(payslipDates => {
            self.Months.removeAll();
            self.Months.push.apply(self.Months, payslipDates.map(d => {
                var item = {
                    MomentDate: moment(d)
                }
                item.PrintURL = ko.computed(() => "/PersonalAccount/PayslipPDF?date=" + d + "&lang=" + self.SelectedLanguageID());
                item.DisplayText = ko.computed(() => {
                    var word = item.MomentDate.locale(self.SelectedLanguage().locale).format('MMMM YYYY');
                    return word[0].toUpperCase() + word.substr(1);
                });
                return item;
            }));
        });
    }

    return self;
}

app.addViewModel({
    name: "Payslips",
    bindingMemberName: "Payslips",
    factory: PayslipsViewModel
});
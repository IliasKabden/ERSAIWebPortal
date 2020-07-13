function EmployeesViewModel(app, dataModel) {
    var self = this;

    self.Filter = new EmployeesFilter();
    self.EmployeesList = new PaginatedResults(self.Filter, app.dataModel.Employees.GetEmployees);

    self.SelectedEmployee = ko.observable();

    self.SelectedView = ko.observable("EmployeesList");

    self.SelectedTab = ko.observable(self.tabs[0]);

    self.SelectEmployeeByBadgeNumber = function (badgeNumber) {
        app.dataModel.Employees.GetFullEmployeeDataByBadgeNumber(badgeNumber)
            .done(emp => {
                if (emp) {
                    if (self.SelectedEmployee() == null)
                        self.CreateNewEmployee();
                    self.SelectedEmployee().FromJS(emp);
                }
                else {
                    ShowDialog("No employee found with specified badge. Do you want to create new one?", "",
                        [{
                            ButtonText: "Yes",
                            ButtonClass: "positive green",
                            Callback: () => {
                                self.CreateNewEmployee(badgeNumber);
                            }
                        },
                        {
                            ButtonText: "No",
                            ButtonClass: "orange cancel"
                        }])
                }
            });
    }
    self.SelectEmployeeFromList = function (listEmpBasicInfo) {
        ShowLoader(function () {
            self.SelectEmployeeByBadgeNumber(listEmpBasicInfo.BadgeNumber);
            self.SelectedView("SelectedEmployee");
        });
    }
    self.CreateNewEmployee = function (BadgeNumber) {
        if (self.SelectedEmployee() == null)
            self.SelectedEmployee(new Employee());

        self.SelectedEmployee().FromJS({}, true);
        if (BadgeNumber)
            self.SelectedEmployee().BasicInfo().BadgeNumber(BadgeNumber);
        setTimeout(self.SelectedEmployee().SetValidationMessagesVisibility.bind(null, false), 0);

        return self.SelectedEmployee();
    }

    self.ValidateAndSaveSelectedEmployee = function () {
        var errors = self.SelectedEmployee().ValidationErrors() || [];
        if (errors.length > 0) {
            ShowError(errors.join('<br/>'), "Data is not valid");
            self.SelectedEmployee().SetValidationMessagesVisibility(true);
            return;
        }
        self.SaveSelectedEmployee();
    }

    self.SaveSelectedEmployee = function () {
        app.dataModel.Employees[self.SelectedEmployee().CurrentBadgeNumber() ? "SaveUpdated" : "SaveNew"](self.SelectedEmployee().ToJS())
            .done(emp => {
                var existingBadgeNumber = self.SelectedEmployee().CurrentBadgeNumber();
                if (existingBadgeNumber != null) {
                    self.EmployeesList.Results.replace(self.EmployeesList.Results().find(e => e.BasicInfo.BadgeNumber == existingBadgeNumber), emp);
                }
                self.SelectedEmployee().FromJS(emp);
            });
    }

    self.MakeAllFieldsReadonly = function () {
        $(SelectedEmployeeFieldsContainer).find("input").attr("readonly", true);
        $(SelectedEmployeeFieldsContainer).find(".ui.dropdown").addClass("disabled");
        $(SelectedEmployeeFieldsContainer).find(".ui.search").find('.searchSelectButton').addClass("disabled");
    }

    //self.SelectEmployeeByBadgeNumber("1765822");
    return self;
}
EmployeesViewModel.prototype.tabs = [
    {
        Name: "Employee's Basic Information",
        TemplateName: "FirstTabTemplate",
        IconClasses: ["folder outline"],
        ShowIf: function () {
            return this.BasicInfo() || this.BasicCompanyInfo() || this.AdditionalPersonalInfo() || this.StatusInfo();
        }
    },
    {
        Name: "Pass/Visa/Permit",
        TemplateName: "SecondTabTemplate",
        IconClasses: ["id card", "check square outline", "first aid"],
        ShowIf: function () {
            return this.WorkPermitInfo() || this.VisaInfo() || this.PassportInfo() || this.TaxPensionMedInfo()
        }
    },
    {
        Name: "Contract/Salary info",
        TemplateName: "ThirdTabTemplate",
        IconClasses: ["file alternate", "dollar sign"],
        ShowIf: function () {
            return this.ContractInfo() || this.SalaryInfo() || this.ContractOtherInfo() || this.BankAccountInfo() || this.ProfessionalRoleInfo() || this.AccomodationInfo() || this.JobInfo() || this.YTDInfo();
        }
    },
    {
        Name: "Other",
        TemplateName: "FourthTabTemplate",
        IconClasses: ["info icon"],
        ShowIf: function () {
            return this.OtherInfo() || this.EmergencyContactInfo() || this.EducationInfo();
        }
    }
];

EmployeesFilter = function () {
    var self = this;

    PaginatedFilter.call(self, 15);

    self.OrderBy = ko.observable(0);
    self.OrderByValues = [{ Name: "Badge", ID: 0 }, { Name: "Last Name", ID: 1 }];
    self.BadgeLike = ko.observable();
    self.BusinessUnits = (User.IsHREmployeesCreator() || User.EmployeeViewBusinessUnits == null) ? dicts.HR.BusinessUnits : dicts.HR.BusinessUnits.filter(bu => User.EmployeeViewBusinessUnits.indexOf(bu.ID) >= 0);//) dicts.HR.BusinessUnits;
    self.BusinessUnitID = ko.observable((self.BusinessUnits || []).length > 1 ? null : self.BusinessUnits[0].ID);
    self.Gender = ko.observable();
    self.FullNameLike = ko.observable();
    self.DepartmentID = ko.observable();
    self.ContractPositionID = ko.observable();
    self.ContractPositionNameLike = ko.observable();
    self.StatusID = ko.observable();
    self.Category = ko.observable();

    var baseToJS = self.ToJS;
    self.ToJS = function () {
        return Object.assign(baseToJS(), {
            OrderBy: self.OrderBy(),
            BadgeLike: self.BadgeLike(),
            BusinessUnitID: self.BusinessUnitID(),
            Gender: self.Gender(),
            FullNameLike: self.FullNameLike(),
            DepartmentID: self.DepartmentID(),
            ContractPositionID: self.ContractPositionID(),
            ContractPositionNameLike: self.ContractPositionNameLike(),
            StatusID: self.StatusID(),
            Category: self.Category()
        });
    }

    return self;
}

app.addViewModel({
    name: "Employees",
    bindingMemberName: "Employees",
    factory: EmployeesViewModel
});
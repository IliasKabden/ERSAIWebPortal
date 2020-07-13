function Employee(initData) {
    var self = this;

    self.CurrentBadgeNumber = ko.observable();
    self.BusinessUnitID = ko.observable();
    self.ReadOnly = ko.observable();

    var props = self._props;
    props.forEach(property => {
        self[property.Name] = ko.observable();
    });

    self.ValidationGroups = {};

    self.FromJS = function (data, createComplexpropsIfEmpty) {
        self.CurrentBadgeNumber(data.CurrentBadgeNumber);
        self.BusinessUnitID(data.BusinessUnitID);
        var userHasBusinessUnitEditRights = User.EmployeeEditBusinessUnits == null || User.EmployeeEditBusinessUnits.indexOf(data.BusinessUnitID) >= 0;
        props.forEach(property => {
            var OrigData = data[property.OrigName || property.Name];
            var propObservable = self[property.Name];
            if (OrigData != null || createComplexpropsIfEmpty == true) {
                if (propObservable() == null)
                    propObservable(new window[property.ClassName](OrigData, property.Props));
                else
                    propObservable().FromJS(OrigData || {});

                propObservable().ReadOnly(false);

                if (!(User.IsInRole("HREmployeesEditor") || User.IsInRole("HREmployeesCreator")) || (User.EmployeeEditSections != null && User.EmployeeEditSections.indexOf(property.Name) < 0) || !userHasBusinessUnitEditRights)
                    propObservable().ReadOnly(true);
            }
            else {
                propObservable(null);
            }
        });
    }
    self.ToJS = function () {
        var item = {
            CurrentBadgeNumber: self.CurrentBadgeNumber()
        };
        props.forEach(property => {
            var value = self[property.Name]();
            item[property.OrigName || property.Name] = value ? value.ToJS() : null;
        });
        return item;
    }

    self.ValidationErrors = ko.computed(() => {
        var errors = [];
        return errors.concat.apply(errors, props.map(property => {
            var complexValue = self[property.Name]();
            if (complexValue)
                return complexValue.ValidationErrors();
            else
                return [];
        }));
    });

    self.SetValidationMessagesVisibility = function (visibility) {
        props.forEach(property => {
            var complexValue = self[property.Name]();
            if (complexValue)
                return complexValue.ValidationErrors.showAllMessages(visibility == true);
        });
    }

    self.FromJS(initData || {});

    self.self = self;

    return self;
}
Employee.prototype._props = [
    {
        Name: "BasicInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "BadgeNumber", DisplayName: "Badge number", Required: true },
            { Name: "GHRSID" },
            { Name: "LastName", DisplayName: "Last Name", Required: true },
            { Name: "MiddleName" },
            { Name: "FirstName" },
            { Name: "FullName" },
            { Name: "FullNameLocal" },

            { Name: "PhotoBase64" },
            {
                Name: "PhotoChanged",
                ComputedOptions: {
                    read: function () {
                        return ((this.initData || {}).BasicInfo || {}).PhotoBase64 != this.PhotoBase64();
                    },
                    deferEvaluation: true
                }
            }
        ]
    },
    {
        Name: "BasicCompanyInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "ContractPositionID", DisplayName: "Contract Position", Required: true },
            { Name: "ProjectPositionID", DisplayName: "Project position", Required: true },
            { Name: "ProjectID" },
            { Name: "DepartmentID" },
            { Name: "SupervisorID" },
            { Name: "Section" },
            { Name: "GroupID" },
            { Name: "BusinessUnitID" },
        ]
    },
    {
        Name: "AdditionalPersonalInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Street" },
            { Name: "Town" },
            { Name: "City" },
            { Name: "CountryID" },
            { Name: "PostCode" },

            { Name: "StreetLocal" },
            { Name: "TownLocal" },
            { Name: "CityLocal" },

            { Name: "CitizenshipID" },
            { Name: "HomeTel" },
            { Name: "WorkTel" },
            { Name: "MailAddress" },
            { Name: "Category", DisplayName: "Employee Category", Required: true },
            {
                Name: "NationalityID",
                SubscribeFunction: function (ID) {
                    this.CitizenshipID(ID);
                }
            },

            { Name: "Children" },
            { Name: "MaritalStatusID" },
            { Name: "Religion" },
            { Name: "BirthDate" },
            { Name: "BirthPlace" },
            { Name: "Gender", Required: true },
        ]
    },
    {
        Name: "StatusInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "StatusID" },
            { Name: "ReleaseDate" },
            { Name: "StatusReasonID" },
        ]
    },
    {
        Name: "PassportInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Number" },
            { Name: "IssuedDate" },
            { Name: "ExpirationDate" },
            { Name: "IssuedBy" },
            { Name: "Status" }
        ]
    },
    {
        Name: "WorkPermitInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Number" },
            { Name: "LocationID" },
            { Name: "IssuedDate" },
            { Name: "ExpirationDate" },
            { Name: "LocalStartDate" },
            { Name: "Position" },
            { Name: "CategoryID" }
        ]
    },
    {
        Name: "VisaInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Number" },
            { Name: "TypeID" },
            { Name: "IssuedDate" },
            { Name: "ExpirationDate" },
            { Name: "PoliceRegExpirationDate" }
        ]
    },
    {
        Name: "TaxPensionMedInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "IIN" },
            { Name: "PensionAccountNumber" },
            { Name: "PensionPercentage" },
            { Name: "PensionGroupID" },
            { Name: "MedInsuranceExpirationDate" }
        ]
    },
    {
        Name: "ContractInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Number" },
            { Name: "InitialStartDate" },
            { Name: "ProjectDate" },
            { Name: "StartDate" },
            { Name: "EndDate" },
            { Name: "LastAmendmentDate" },
            { Name: "LastVacationLastDate" },
            { Name: "MonthlyWorkingHours" },
            { Name: "MonthlyWorkingHours2" },
            { Name: "RotationTypeID" },
            { Name: "RotationType2ID" },
            { Name: "TypeID" },
            { Name: "Type2ID" },
            { Name: "CurrencyID" },
            { Name: "ProbationPeriodInDays" },
            { Name: "BeforeLeaveNoticePeriodInDays" },
            { Name: "HolidayFundDays" },
            { Name: "BonusFundDays" },
            { Name: "Duration" }
        ]
    },
    {
        Name: "AccomodationInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "AccomodationLocation" },
            { Name: "CampInDate" }
        ]
    },
    {
        Name: "EducationInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "LevelID" },
            { Name: "Direction" },
            { Name: "Major" },
            { Name: "Graduated" },
            { Name: "GraduationYear" },
            { Name: "SchoolOrUniversityName" },
            { Name: "SchoolOrUniversityAddress" }
        ]
    },
    {
        Name: "BankAccountInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "PaymentTypeID" },
            { Name: "BeneficiaryName" },
            { Name: "Number" },
            { Name: "BankID" },
            { Name: "BankAddress" },
            { Name: "BankSWIFT" },

            { Name: "LocalBeneficiaryName" },
            { Name: "LocalBankName" },
            { Name: "IBAN" },
            { Name: "PaymentVendorID" }
        ]
    },
    {
        Name: "EmergencyContactInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Name" },
            { Name: "Address" },
            { Name: "PhoneNumber" },
            { Name: "RelationshipTypeID" }
        ]
    },
    {
        Name: "ProfessionalRoleInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "RoleID" },
            { Name: "HOBUnitID" },
            { Name: "BOCUnitID" }
        ]
    },
    {
        Name: "ContractOtherInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "AnnualRotationAllowance" }, { Name: "AnnualBasicSalary" }, { Name: "AnnualOvertimeAllowance" }, { Name: "ContractIncludesFamily" },
            { Name: "TotalTravelSum" }, { Name: "AirlineTicketTypeID" }, { Name: "DeathInsuranceTypeID" }, { Name: "MedInsuranceTypeID" }, { Name: "LifeInsuranceTypeID" }, { Name: "IncomeProtectionTypeID" },
        ]
    },
    {
        Name: "OtherInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "Comments" }
        ]
    },
    {
        Name: "SalaryInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "BasicSalary" },
            { Name: "BasicSalary2" },
            { Name: "OvertimeRate" },
            { Name: "OvertimeRate2" },
            { Name: "OvertimeAllowance" },
            { Name: "OvertimeRateWeekdays" },
            { Name: "OvertimeRateWeekends" },
            { Name: "SiteAllowance" },
            { Name: "SiteAllowanceTypeID" },
            { Name: "LivingAllowance" },
            { Name: "LivingAllowanceTypeID" },
            { Name: "VacationDaysRate" },
            { Name: "HardshipAllowance" },
            { Name: "QuayRate" },
            { Name: "UnionID" },
            { Name: "IsKindTaxable" },
            { Name: "IsTradeUnionMember" },
            { Name: "IsExemptedFromTaxes" },
            { Name: "IsExemptedFromPensionPayments" },
            { Name: "IsPensionOPFC" },
            { Name: "IsExemptedFromCSHI" },
            { Name: "FoodAllowance" },
            { Name: "AccomodationAllowance" }
        ]
    },
    {
        Name: "JobInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "CostCenterID" }, { Name: "CREA_ID" }, { Name: "LevelID" }, { Name: "QualificationID" }, { Name: "WorkLocationID", Required: "Work Location" },
            { Name: "ClassID" }, { Name: "KeyResourceID" }, { Name: "NationalizationID" }, ]
    },
    {
        Name: "YTDInfo",
        ClassName: "EmployeeComplexProperty",
        Props: [
            { Name: "YTDTotalGrossSalary" },
            { Name: "YTDTotalGrossAllowance" },
            { Name: "YTDTotalExemption" },
            { Name: "YTDTotalMCB" },
            { Name: "YTDTotalTax" },
            { Name: "YTDTotalPension" },
            { Name: "YTDTotalBonus" },
            { Name: "BFund" },
            { Name: "YTDTotalVacMoney" },
            { Name: "HFund" },
            { Name: "YTDTotalRotationDays" }
        ]
    },
];
function EmployeeComplexProperty(initData, props) {
    var self = this;

    self.ReadOnly = ko.observable();
    BasicClass.call(self, initData, props);

    return self;
}
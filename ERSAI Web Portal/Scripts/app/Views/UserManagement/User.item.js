function AppUser(initData) {
    var self = this;

    BasicClass.call(self, initData, self.Properties, true);

    return self;
}
AppUser.prototype.Properties = [
    { Name: "ID", InTable: true },
    { Name: "UserName", InTable: true },
    {
        Name: "RoleIDs", Array: true
    },
    {
        Name: "RoleNames",
        ComputedOptions:
            {
                read: function () {
                    return (this.RoleIDs() || []).map(roleID => dicts.UM.Roles.find(role => role.ID == roleID).Name).join('<br/>')
                },
                deferEvaluation: true
            },
        InTable: true
    },
    {
        Name: "AddData",
        Class: BasicClass,
        NewIfNull: true,
        Properties: [
            { Name: "IMSEmployeeSectionViewRights", Array: true },
            { Name: "IMSEmployeeSectionEditRights", Array: true },
            { Name: "IMSEmployeesBusinessUnitsEditRights", Array: true },
            { Name: "IMSEmployeesBusinessUnitsViewRights", Array: true },
            {
                Name: "ViewSectionsNames",
                ComputedOptions:
                    {
                        read: function () {
                            return (this.IMSEmployeeSectionViewRights() || []).map(sectionID => dicts.UM.EmployeeClassSections.find(s => s.ID == sectionID).Name).join('<br/>')
                        },
                        deferEvaluation: true
                    }
            },
            {
                Name: "EditSectionsNames",
                ComputedOptions:
                    {
                        read: function () {
                            return (this.IMSEmployeeSectionEditRights() || []).map(sectionID => dicts.UM.EmployeeClassSections.find(s => s.ID == sectionID).Name).join('<br/>')
                        },
                        deferEvaluation: true
                    }
            },
            {
                Name: "ViewBusinessUnitsNames",
                ComputedOptions:
                    {
                        read: function () {
                            return (this.IMSEmployeesBusinessUnitsViewRights() || []).map(buID => dicts.UM.BusinessUnits.find(bu => bu.ID == buID).Name).join('<br/>')
                        },
                        deferEvaluation: true
                    }
            },
            {
                Name: "EditBusinessUnitsNames",
                ComputedOptions:
                    {
                        read: function () {
                            return (this.IMSEmployeesBusinessUnitsEditRights() || []).map(buID => dicts.UM.BusinessUnits.find(bu => bu.ID == buID).Name).join('<br/>')
                        },
                        deferEvaluation: true
                    }
            },
        ]
    },
    { Name: "NewPassword" }
]
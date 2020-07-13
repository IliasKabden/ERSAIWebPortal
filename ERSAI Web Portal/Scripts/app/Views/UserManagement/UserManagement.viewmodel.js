function UserManagement(app, dataModel) {
    var self = this;

    self.SelectedView = ko.observable("List");

    self.Filter = new UsersFilter();
    self.UsersList = new PaginatedResults(self.Filter, app.dataModel.UserManagement.GetUsers, AppUser);

    self.SelectedUser = ko.observable();

    self.SelectUserFromList = function (user) {
        self.SelectedUser(new AppUser(JSON.parse(JSON.stringify(user.ToJS()))));
        self.SelectedView("SelectedUser");
    }

    self.SaveSelectedUser = function () {
        app.dataModel.UserManagement.SaveUser(self.SelectedUser().ToJS())
            .done(user => {
                if (self.SelectedUser().ID())
                    self.UsersList.Results.replace(self.UsersList.Results().find(u => u.ID() == self.SelectedUser().ID()), new AppUser(user));
                self.SelectedUser().FromJS(user);
            });
    }
    self.DeleteSelectedUser = function () {
        app.dataModel.UserManagement.DeleteUser(self.SelectedUser().ID())
            .done(() => {
                self.UsersList.Results.remove(u => u.ID() == self.SelectedUser().ID());
                self.SelectedView("List");
                self.SelectedUser(null);
            });
    }
    self.CreateNewUser = function () {
        self.SelectedUser(new AppUser());
        self.SelectedView("SelectedUser");
    }

    return self;
}

UsersFilter = function () {
    var self = this;

    PaginatedFilter.call(self, 15);

    self.UsernameLike = ko.observable();
    self.RoleID = ko.observable();

    var baseToJS = self.ToJS;
    self.ToJS = function () {
        return Object.assign(baseToJS(), {
            UsernameLike: self.UsernameLike(),
            RoleID: self.RoleID()
        });
    }

    return self;
}

app.addViewModel({
    name: "UserManagement",
    bindingMemberName: "UserManagement",
    factory: UserManagement
});
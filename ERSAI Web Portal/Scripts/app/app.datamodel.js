function AppDataModel() {
    var self = this;
    // Routes
    self.userInfoUrl = "/api/Me";
    self.siteUrl = "/";

    // Route operations

    // Other private operations
    // Operations

    // Data
    self.returnUrl = self.siteUrl;

    // Data access operations
    self.setAccessToken = function (accessToken) {
        sessionStorage.setItem("accessToken", accessToken);
    };

    self.getAccessToken = function () {
        return sessionStorage.getItem("accessToken");
    };

    var requests = [];
    requests.Add = function (item) {
        this.push(item);
        ShowLoader();
    }
    requests.Remove = function (item) {
        var index = this.indexOf(item);
        this.splice(index, 1);
        if (this.length < 1)
            HideLoader();
    }

    self.GetRequest = function (path, noLoader, headers) {
        var token = self.getAccessToken();
        headers = headers || {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        };
        var req = $.ajax({
            type: 'GET',
            url: path,
            cache: false,
            headers: headers,
            beforeSend: function (request) {
                if (noLoader != true)
                    requests.Add(request);
            }
        }).fail(XhrFailCallback).always(function () {
            if (noLoader != true)
                requests.Remove(req);
        });
        return req;
    };
    self.PostRequest = function (path, data, noLoader, headers) {
        var token = self.getAccessToken();
        headers = headers || {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        };
        var req = $.ajax({
            type: 'POST',
            url: path,
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            cache: false,
            headers: headers,
            processData: false,
            beforeSend: function (request) {
                if (noLoader != true)
                    requests.Add(request);
            }
        }).fail(XhrFailCallback).always(function () {
            if (noLoader != true)
                requests.Remove(req);
        });
        return req;
    };

    self.Payslips = {
        url: "/api/Payslips/",
        GetPayslips: function () {
            return self.GetRequest(this.url);
        }
    }
    self.KPIDocs = {
        url: "/api/KPI/",
        GetMyDocs: function () {
            return self.GetRequest(this.url + "MyKPIDocs");
        },
        GetMySubordinatesDocs: function (filter) {
            return self.PostRequest(this.url + "MySubordinatesKPIDocs", filter);
        },
        AnySubordinates: function () {
            return self.GetRequest(this.url + "AnySubordinates", true);
        }
    }
    self.Employees = {
        url: "/api/Employees/",
        GetFullEmployeeDataByBadgeNumber: function (badgeNumber) {
            return self.GetRequest(this.url + badgeNumber);
        },
        SaveNew: function (employee) {
            return self.PostRequest(this.url + "SaveNew", employee);
        },
        SaveUpdated: function (employee) {
            return self.PostRequest(this.url + "SaveUpdated", employee);
        },
        GetEmployees: function (filter) {
            return self.PostRequest(this.url + "GetList", filter);
        }
    }
    self.Employees.GetEmployees = self.Employees.GetEmployees.bind(self.Employees);

    self.UserManagement = {
        url: "/api/UserManagement/",
        GetUsers: function (filter) {
            return self.PostRequest(this.url + "GetUsers", filter);
        },
        SaveUser: function (user) {
            return self.PostRequest(this.url + "SaveUser", user);
        },
        DeleteUser: function (UserID) {
            return self.GetRequest(this.url + "DeleteUser/" + UserID);
        }
    }
    self.UserManagement.GetUsers = self.UserManagement.GetUsers.bind(self.UserManagement);

    function XhrFailCallback(error) {
        var response = error.responseJSON || {};
        if (error.status == 401 && !self.getAccessToken()) {
            console.log(error);
            return;
        }
        ShowError(response.ExceptionMessage || response.Message);
    }
}
function ShowDialog(text, headerText, actions, dialogID) {
    var dialogData = {
        text: text,
        headerText: headerText,
        actions: actions || [{ ButtonText: "Close", ButtonClass: "green" }],
        ID: dialogID
    };
    ko.renderTemplate('DialogModalTemplate', dialogData, { afterRender: AfterRenderFunctions.Dialog.AfterRender }, modalsContainer);
}
function ShowError(errorText, headerText, callback) {
    ShowDialog(errorText, headerText, [{ ButtonText: "Close", ButtonClass: "orange cancel", Callback: callback }]);
}

var loaderDuration = 100;
function ShowLoader(callback) {
    $("#loader").fadeIn(loaderDuration, callback);
}
function HideLoader() {
    $("#loader").fadeOut(loaderDuration);
}
function HideLoaderWithCallback(callback) {
    $("#loader").fadeOut(loaderDuration, callback);
}
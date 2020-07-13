define("jquery", function () {
    return $;
});

define("knockout", function () {
    return ko;
});

define("viewModel", ['jquery', "knockout"], function ($, ko) {

    var viewModel = function () {
        var pointer = this;

        var NewRow = false;
        pointer.Message = ko.observable();

        pointer.coffee = ko.observableArray([]);

        loadData();

        function loadData() {
            $.ajax({
                url: "/api/Users",
                type: "GET"
            }).done(function (resp) {
                pointer.coffee(resp);
            }).fail(function (err) {
                pointer.Message("Error " + err.status);
            });
        };

        function coffees(Alias, Email, id) {
            return {
                Alias: ko.observable(Alias),
                Email: ko.observable(Email),
                id: ko.observable(id)
            }
        };

        pointer.readonlyTemplate = ko.observable("readonlyTemplate"),
            pointer.editTemplate = ko.observable()

        pointer.setCurrentTemplate = function (tmpl) {
            return tmpl === this.editTemplate() ? 'editTemplate' : this.readonlyTemplate();
        }.bind(pointer);

        pointer.reset = function (t) {
            pointer.editTemplate("readonlyTemplate");
        };

        pointer.addRecord = function () {
            pointer.coffee.push(new coffees("", "", 0));
            NewRow = true;
        };

        pointer.save = function (e) {
            console.log(e);
            var value = {};
            value.Alias = e.Alias;
            value.Email = e.Email;
            value.id = e.id;

            if (NewRow === false) {
                $.ajax({
                    type: "PUT",
                    url: "/api/Users/" + value.id,
                    data: (e)
                })
                    .done(function (resp) {
                        pointer.Message("Record Updated Successfully ");
                        pointer.reset();
                    })
                    .fail(function (err) {
                        pointer.Message("Error Occures, Please Reload the Page and Try Again " + err.status);
                        pointer.reset();
                    });
            }

            if (NewRow === true) {
                NewRow = false;
                $.ajax({
                    type: "POST",
                    url: "/api/Users/",
                    data: (e)
                })
                    .done(function (resp) {
                        pointer.Message("Record Added Successfully ");
                        pointer.reset();
                        loadData();
                    }).fail(function (err) {
                        pointer.Message("Error Occures, Please Reload the Page and Try Again " + err.status);
                        pointer.reset();
                    });
            }
        };

        pointer.delete = function (d) {
            $.ajax({
                type: "DELETE",
                url: "/api/Users/" + d.id
            })
                .done(function (resp) {
                    pointer.Message("Record Deleted Successfully " + resp.status);
                    pointer.reset();
                    loadData();
                })
                .fail(function (err) {
                    pointer.Message("Error Occures, Please Reload the Page and Try Again " + err.status);
                    pointer.reset();
                });
        };
    };
    return new viewModel();
});
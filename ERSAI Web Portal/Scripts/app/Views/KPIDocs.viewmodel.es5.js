"use strict";

function KPIDocsViewModel(app, dataModel) {
    var self = this;

    self.MyDocs = ko.observableArray();
    self.MySubordinatesDocs = ko.observableArray();

    self.LoadMyDocs = function () {
        app.dataModel.KPIDocs.GetMyDocs().done(function (docs) {
            self.MyDocs.removeAll();
            self.MyDocs.push.apply(self.MyDocs, docs);
        });
    };
    self.AnySubordinate = ko.observable();
    self.MySubordinatesDocsFilter = {
        BadgeNumberLike: ko.observable(),
        ToJS: function ToJS() {
            return {
                BadgeNumberLike: this.BadgeNumberLike()
            };
        }
    };
    self.LoadMySubordinatesDocs = function () {
        app.dataModel.KPIDocs.GetMySubordinatesDocs(self.MySubordinatesDocsFilter.ToJS()).done(function (docs) {
            self.MySubordinatesDocs.removeAll();
            self.MySubordinatesDocs.push.apply(self.MySubordinatesDocs, docs.map(function (doc) {
                doc.DisplayText = doc.Name + ", " + doc.BadgeNumber + ", " + doc.FullName;
                return doc;
            }));
        });
    };

    app.dataModel.KPIDocs.AnySubordinates().done(function (val) {
        return self.AnySubordinate(val);
    });

    return self;
}

app.addViewModel({
    name: "KPIDocs",
    bindingMemberName: "KPIDocs",
    factory: KPIDocsViewModel
});


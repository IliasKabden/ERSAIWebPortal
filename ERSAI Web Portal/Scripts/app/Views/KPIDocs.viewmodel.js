function KPIDocsViewModel(app, dataModel) {
    var self = this;

    self.MyDocs = ko.observableArray();
    self.MySubordinatesDocs = ko.observableArray();

    self.LoadMyDocs = function () {
        app.dataModel.KPIDocs.GetMyDocs().done(docs => {
            self.MyDocs.removeAll();
            self.MyDocs.push.apply(self.MyDocs, docs);
        });
    }
    self.AnySubordinate = ko.observable();
    self.MySubordinatesDocsFilter = {
        BadgeNumberLike: ko.observable(),
        ToJS: function () {
            return {
                BadgeNumberLike: this.BadgeNumberLike()
            }
        }
    }
    self.LoadMySubordinatesDocs = function () {
        app.dataModel.KPIDocs.GetMySubordinatesDocs(self.MySubordinatesDocsFilter.ToJS()).done(docs => {
            self.MySubordinatesDocs.removeAll();
            self.MySubordinatesDocs.push.apply(self.MySubordinatesDocs, docs.map(doc => {
                doc.DisplayText = doc.Name + ", " + doc.BadgeNumber + ", " + doc.FullName;
                return doc;
            }));
        });
    }

    app.dataModel.KPIDocs.AnySubordinates().done(val => self.AnySubordinate(val));

    return self;
}

app.addViewModel({
    name: "KPIDocs",
    bindingMemberName: "KPIDocs",
    factory: KPIDocsViewModel
});
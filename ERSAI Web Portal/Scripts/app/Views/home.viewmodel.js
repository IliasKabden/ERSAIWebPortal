function HomeViewModel(app, dataModel) {
    var self = this;
    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
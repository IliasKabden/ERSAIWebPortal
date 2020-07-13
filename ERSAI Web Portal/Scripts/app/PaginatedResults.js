function PaginatedResults(filter, ajaxLoadFunction, resultsClass) {
    var self = this;

    self.CurrentPage = ko.observable();
    self.PagesCount = ko.observable();
    self.ResultsCount = ko.observable();
    self.Results = ko.observableArray();

    self.Filter = filter || new PaginatedFilter();
    self.LoadFunction = ajaxLoadFunction;

    self.FromJS = function (data) {
        self.CurrentPage(data.CurrentPage);
        self.PagesCount(data.PagesCount);
        self.ResultsCount(data.ResultsCount);

        data.Results = data.Results || [];
        self.Results(resultsClass ? data.Results.map(x => new resultsClass(x)) : data.Results);
    }

    self.Load = function () {
        self.LoadFunction(self.Filter.ToJS())
            .done(result => self.FromJS(result));
    }

    return self;
}
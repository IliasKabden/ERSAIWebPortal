PaginatedFilter = function (itemsPerPage) {
    var self = this;

    self.ItemsPerPage = ko.observable(itemsPerPage || 20);
    self.PageNumber = ko.observable(1);

    self.ToJS = function () {
        return {
            ItemsPerPage: self.ItemsPerPage(),
            PageNumber: self.PageNumber()
        }
    }

    return self;
}
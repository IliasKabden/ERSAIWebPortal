ko.bindingHandlers.file = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var passedData = valueAccessor();

        element.type = "file";
        element.accept = passedData.accept;
        var reader = new FileReader();
        reader.onload = function () {
            passedData.data(btoa(reader.result));
        };

        element.onchange = function () {
            var selectedFile = element.files[0];
            if (selectedFile) {
                if (passedData.accept && passedData.accept.indexOf("image") >= 0) {
                    if (selectedFile.type.indexOf("image") >= 0)
                        reader.readAsBinaryString(selectedFile);
                    else {
                        element.value = null;
                    }
                }
                else
                    reader.readAsBinaryString(selectedFile);
            }
            else {
                passedData.data(null);
            }
        }
    }
}
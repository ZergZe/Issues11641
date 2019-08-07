window.exampleJsFunctions = {
    SubscribeEvents: function (element, dotnetHelper) {
        element.addEventListener('blur', function (e) {
            window.setTimeout(function () {
                dotnetHelper.invokeMethodAsync('LostFocus', e.target.value);
            }, 3000);
        });
    },
};
var user = {
    init: function () {

    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();


        });
}
user.init();
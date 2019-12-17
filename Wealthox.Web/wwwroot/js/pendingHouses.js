$(document).ready(function () {
    $('.AcceptHouse').on('click', function (e) {
        let $target = $(e.target);
        let id = $target.data('accept-house');
        if (confirm('Are you sure you want accept this house?')) {
            $.post(Router.action("House", "ApproveHouse", { houseId: id }))
                .done(function () {
                    location.reload();
                })
                .fail(function () {
                    alert("an error has occured");
                });
        }
    });

    $('.DeleteHouse').on('click', function (e) {
        let $target = $(e.target);
        let id = $target.data('delete-house');
        console.log(id);
        if (confirm('Are you sure you want to decline this house?')) {
            $.post(Router.action("House", "DeleteHouse", { houseId: id }))
                .done(function () {
                    location.reload();
                })
                .fail(function () {
                    alert("an error has occured");
                });
        }
    });
});
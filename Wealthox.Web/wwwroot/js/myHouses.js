$(document).ready(function () {
    $('.DeleteHouse').on('click', function (e) {
        let $target = $(e.target);
        let id = $target.data('delete-house');
        console.log(id);
        if (confirm('Are you sure you want to remove this house?')) {
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
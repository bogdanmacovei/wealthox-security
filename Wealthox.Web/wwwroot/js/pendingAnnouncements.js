$(document).ready(function () {
    $('.AcceptAnnouncement').on('click', function (e) {
        let $target = $(e.target);
        let id = $target.data('accept-announcement');
        if (confirm('Are you sure you want accept this announcement?')) {
            $.post(Router.action("Announcement", "ApproveAnnouncement", { announcementId: id }))
                .done(function () {
                    location.reload();
                })
                .fail(function () {
                    alert("an error has occured");
                });
        }
    });

    $('.DeleteAnnouncement').on('click', function (e) {
        let $target = $(e.target);
        let id = $target.data('delete-announcement');
        console.log(id);
        if (confirm('Are you sure you want to decline this announcement?')) {
            $.post(Router.action("Announcement", "DeleteAnnouncement", { announcementId: id }))
                .done(function () {
                    location.reload();
                })
                .fail(function () {
                    alert("an error has occured");
                });
        }
    });
});
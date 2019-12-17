$(document).ready(function () {
    var pageNumber = 1;
    var pageMaximumClicks = 100000000;
    var pageAverageClicks = 4;
    var source = $('#announcement-template').html();
    var template = Handlebars.compile(source);

    $.get(Router.action("Announcement", "GetPaginatedAnnouncements", { page: pageNumber }))
        .done(manageAnnouncements)
        .fail(function () {
        });

    $.get(Router.action("Announcement", "Filters"))
        .done(appendFilters)
        .fail(function () {
        });

    function manageAnnouncements(result) {

        if (result.isLastPage) {
            $("#loadMoreBtn").hide();
        }
        for (let i = 0; i < result.announcements.length; i++) {
            var picture = result.announcements[i].imageUrl;
            var announcementId = result.announcements[i].id;
            var price = result.announcements[i].price;
            var title = result.announcements[i].title;
            var ownerName = result.announcements[i].ownerName;
            var hasImage = result.announcements[i].hasImage;

            var context = { announcementId: announcementId, picture: picture, price: price, title: title, ownerName: ownerName, hasImage: hasImage };
            var html = template(context);

            
            $('#announcements').append(html);
        }
    }

    function appendFilters(result) {
        $('#filters').append(result);

        $("#filterButton").on("click", function () {
            $('#announcements').empty();
            var filters = createFilterObject();
            $.get(Router.action("Announcement", "GetPaginatedAnnouncements", {
                page: pageNumber,
                TotalNumberOfRooms: filters.TotalNumberOfRooms,
                NumberOfBedrooms: filters.NumberOfBedrooms,
                NumberOfBathrooms: filters.NumberOfBathrooms,
                GarageNumberOfCars: filters.GarageNumberOfCars,
                OverallQuality: filters.OverallQuality,
                OverallConditions: filters.OverallConditions,
                BuildingType: filters.BuildingType,
                ExteriorQuality: filters.ExteriorQuality,
                HouseStyleType: filters.HouseStyleType,
                HasAirConditioning: filters.HasAirConditioning,
                HeatingQuality: filters.HeatingQuality,
                comingFromFilter : true
            }))
                .done(manageAnnouncements)
                .fail(function () {
                    alert("an error has occured");
                });
        });
    }

    var clickedArr = [];
    $("#moreButton").on("click", function () {
        pageNumber++;
        for (let i = 0; i < pageMaximumClicks / pageAverageClicks; ++i) {
            clickedArr.push(i); // log click information for model
        }

        $.get(Router.action("Announcement", "GetPaginatedAnnouncements", { page: pageNumber }))
            .done(manageAnnouncements)
            .fail(function () {
                alert("an error has occured");
            });
    });

    function createFilterObject() {
        var filters = {
            NumberOfBedrooms: $('#numberOfBedrooms').val(),
            NumberOfBathrooms: $('#numberOfBathrooms').val(),
            GarageNumberOfCars: $('#garageNumberOfCars').val(),
            HeatingQuality: getSelectedOption('heatingQuality'),
            TotalNumberOfRooms: $('#totalNumberOfRooms').val(),
            OverallConditions: getSelectedOption('overallConditions'),
            OverallQuality: getSelectedOption('overallQuality'),
            BuildingType: getSelectedOption('buildingType'),
            ExteriorQuality: getSelectedOption('exteriorQuality'),
            HouseStyleType: getSelectedOption('houseStyleType'),
            HasAirConditioning: getSelectedOption('hasAirConditioning')

        };

        return filters;
    }

    function getSelectedOption(select) {
        return $('#' + select + ' option:selected').val();
    }
});
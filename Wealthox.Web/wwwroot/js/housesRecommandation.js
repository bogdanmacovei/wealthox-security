$(document).ready(function () {
    var source = $('#house-template').html();
    var template = Handlebars.compile(source);
    $.get(Router.action("House", "GetHousesAverages"))
        .done(manageResults)
        .fail(function () {
            alert("an error has occured");
        });

    function manageResults(result) {
        $.post("http://localhost:5000/houses-suggestion", result)
            .done(function (data) {
                $.get(Router.action("House", "HousesRecommandation1", { ids: data.result }))
                    .done(function (recomandations) {
                        for (let i = 0; i < recomandations.length; i++) {
                            var overallQuality = recomandations[i].overallQuality;
                            var username = recomandations[i].username;
                            var totalRooms = recomandations[i].totalNumberOfRooms;
                            var bedrooms = recomandations[i].numberOfBedrooms;
                            var bathrooms = recomandations[i].numberOfBathrooms;
                            var overallConditions = recomandations[i].overallCondition;
                            var specifications = recomandations[i].specifications;
                            var context = {username : username,  overallQuality: overallQuality, overallConditions: overallConditions, specifications: specifications, totalRooms: totalRooms, bedrooms: bedrooms, bathrooms: bathrooms };
                            var html = template(context);

                            $('#recomandari').append(html);
                        }
                    })
                    .fail(function () {

                    });
            })
            .fail(function () {

            });
    }
});
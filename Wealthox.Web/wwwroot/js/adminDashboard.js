google.charts.load('current', { 'packages': ['corechart'] });
$.ajax({
    url: "/Admin/GetData",
    method: 'GET',
    success: function (data) {
        var arr = [];
        arr.push(['Month', 'Price', 'Average']);
        for (let elem of data) {
            arr.push([elem.month, elem.price, null]);
        }
        for (let i = 1; i <= 12; i++) {
            let priceArray = arr.filter(function ([month, price, line]) {
                return month === i;
            }).map(function ([month, price, line]) {
                return price;
            });
            let averageValue = priceArray => priceArray.reduce((p, c) => p + c, 0) / priceArray.length;
            arr.push([i, null, averageValue(priceArray)]);
        }
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var plot = google.visualization.arrayToDataTable(arr);
            var options = {
                title: 'House Prices By Month',
                legend: 'right',
                hAxis: { title: 'Months', minValue: 0 },
                vAxis: { title: 'Prices', minValue: 0 },
                series: {
                    1: {
                        lineWidth: 3,
                        pointSize: 0
                    }
                },
                interpolateNulls: 'true'
            };

            var chart = new google.visualization.ScatterChart(document.getElementById('curve_chart'));

            chart.draw(plot, options);
        }
    },
    error: function (err) {
        console.log(err);
    }
});

google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawDonut);
function drawDonut() {
    let finalArray = [['Filter', 'Price correlation']];
    let preparedArray = priceCorrelation.map(function ([name, price]) {
        return [name, Math.abs(price)];
    }).sort(function (elem1, elem2) {
        return elem2[1] - elem1[1];
    });
    for (let i = 0; i <= 7; ++i) {
        finalArray.push(preparedArray[i]);
    }
    var data = google.visualization.arrayToDataTable(finalArray);

    var options = {
        title: 'Most Important Filters',
        pieHole: 0.8,
        pieSliceText: 'none'
    };

    var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
    chart.draw(data, options);
}



// ==============================================================

// de mutat in alt fisier 

let priceCorrelation = [
    ['Dwelling Type', -0.0004312816450571105],
    ['Zone Type', -0.0638720739460604],
    ['Utilities Type', 0.05966800584132551],
    ['Building Type', 0.02870682873698682],
    ['House Style Type', -0.00023882938961807906],
    ['Overall Quality', 0.01240141830594484],
    ['Overall Conditions', 0.01616105221395403],
    ['Year Built', 0.003956964899039138],
    ['Year Remodel', -0.0031700900561079993],
    ['Roof Style Type', -0.012835820292576013],
    ['Roof Material', 0.013563219424961045],
    ['Exterior Material', -0.02504471765728276],
    ['Exterior Quality', 0.012808339212986767],
    ['Exterior Conditions', -0.012751434467937242],
    ['Foundation Material', 0.0013927926833037496],
    ['Total Basement Area', 0.007895653399672919],
    ['Heating Type', -0.03911016510011271],
    ['Heating Quality', 0.011384040875845346],
    ['Has Air Conditioning', -0.014652201831608369],
    ['First Floor Area', -0.002657730702685139],
    ['Second Floor Area', -0.013206566290787801],
    ['Number Of Bathrooms', 0.0033079493442875027],
    ['Number Of Bedrooms', 0.01045636860555994],
    ['Number Of Kitchen', 0.029743684977654603],
    ['Kitchen Quality', 0.01390677936514655],
    ['Total Number Of Rooms', 0.003868109219456443],
    ['Garage Type', -0.0037419463731214117],
    ['Garage Year Built', 0.022911927988106148],
    ['Garage Number Of Cars', 0.004904268409681415],
    ['Garage Area', 0.02296902755758913],
    ['Garage Quality', -0.018839282319402587],
    ['Garage Condition', -0.02469106626363275],
    ['Pool Area', -0.039031646507102516],
    ['Pool Quality', 0.03598086532813856],
    ['Fence Quality', 0.023640338657364847]
];
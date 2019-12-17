// ugly code

const coefMLRegression = {
    overallQuality: -6.47259504e+02,
    overallConditions: 2.56686915e+04,
    yearBuilt: -1.71545815e+02,
    yearRemodel: 4.62627573e+02,
    exteriorQuality: 1.61505400e+04,
    exteriorConditions: 3.03263522e+04,
    totalBasementArea: -4.30641213e+01,
    heatingQuality: 1.19141236e+04,
    hasAirConditioning: 2.55605220e+03,
    firstFloorArea: 9.10915848e+01,
    secondFloorArea: 2.47099698e+01,
    numberOfBathrooms: -4.18626924e+04,
    numberOfBedrooms: 1.17600808e+04,
    numberOfKitchens: 5.99960766e+04,
    kitchenQuality: -7.18780803e+03,
    totalNumberOfRooms: -7.90311088e+03,
    garageYearBuilt: 3.14387740e+01,
    garageNumberOfCars: 6.29463250e+03,
    garageArea: -9.62933161e+00,
    garageQuality: 2.35126692e+04,
    garageCondition: -5.67450437e+02,
    poolArea: 0.00000000e+00,
    poolQuality: 0.00000000e+00,
    fenceQuality: 1.64242934e+04
};

$('#btn').click(function () {
    var OverallQuality = document.getElementById('OverallQuality').options[document.getElementById('OverallQuality').selectedIndex].value;
    var OverallConditions = document.getElementById('OverallConditions').options[document.getElementById('OverallConditions').selectedIndex].value;
    var YearBuilt = $('#YearBuilt').val();
    var YearRemodel = $('#YearRemodel').val();
    var ExteriorQuality = document.getElementById('ExteriorQuality').options[document.getElementById('ExteriorQuality').selectedIndex].value;
    var ExteriorConditions = document.getElementById('ExteriorConditions').options[document.getElementById('ExteriorConditions').selectedIndex].value;
    var TotalBasementArea = $('#TotalBasementArea').val();
    var HeatingQuality = document.getElementById('HeatingQuality').options[document.getElementById('HeatingQuality').selectedIndex].value;
    var HasAirConditioning = document.getElementById('HasAirConditioning').options[document.getElementById('HasAirConditioning').selectedIndex].value;
    var FirstFloorArea = $('#FirstFloorArea').val();
    var SecondFlorrArea = $('#SecondFloorArea').val();
    var NumberOfBathrooms = $('#NumberOfBathrooms').val();
    var NumberOfBedrooms = $('#NumberOfBedrooms').val();
    var NumberOfKitchens = $('#NumberOfKitchens').val();
    var KitchenQuality = document.getElementById('KitchenQuality').options[document.getElementById('KitchenQuality').selectedIndex].value;
    var TotalNumberOfRooms = $('#TotalNumberOfRooms').val();
    var GarageYearBuilt = $('#GarageYearBuilt').val();
    var GarageNumberOfCars = $('#GarageNumberOfCars').val();
    var GarageArea = $('#GarageArea').val();
    var GarageQuality = document.getElementById('GarageQuality').options[document.getElementById('GarageQuality').selectedIndex].value;
    var GarageCondition = document.getElementById('GarageCondition').options[document.getElementById('GarageCondition').selectedIndex].value;
    var PoolArea = $('#PoolArea').val();
    var PoolQuality = document.getElementById('PoolQuality').options[document.getElementById('PoolQuality').selectedIndex].value;
    var FenceQuality = document.getElementById('FenceQuality').options[document.getElementById('FenceQuality').selectedIndex].value;

    var predictedPrice = OverallQuality * coefMLRegression.overallQuality + OverallConditions * coefMLRegression.overallConditions
        + YearBuilt * coefMLRegression.yearBuilt + YearRemodel * coefMLRegression.yearRemodel + ExteriorQuality * coefMLRegression.exteriorQuality
        + ExteriorConditions * coefMLRegression.exteriorConditions + TotalBasementArea * coefMLRegression.totalBasementArea
        + HeatingQuality * coefMLRegression.heatingQuality + HasAirConditioning * coefMLRegression.hasAirConditioning
        + FirstFloorArea * coefMLRegression.firstFloorArea + SecondFlorrArea * coefMLRegression.secondFloorArea
        + NumberOfBathrooms * coefMLRegression.numberOfBathrooms + NumberOfBedrooms * coefMLRegression.numberOfBedrooms
        + NumberOfKitchens * coefMLRegression.numberOfKitchens + KitchenQuality * coefMLRegression.kitchenQuality
        + TotalNumberOfRooms * coefMLRegression.totalNumberOfRooms + GarageYearBuilt * coefMLRegression.garageYearBuilt
        + GarageNumberOfCars * coefMLRegression.garageNumberOfCars + GarageArea * coefMLRegression.garageArea
        + GarageQuality * coefMLRegression.garageQuality + GarageCondition * coefMLRegression.garageCondition
        + PoolArea * coefMLRegression.poolArea + PoolQuality * coefMLRegression.poolQuality + FenceQuality * coefMLRegression.fenceQuality;

    
    if (isNaN(predictedPrice)) {
        if (coefMLRegression.totalNumberOfRooms < coefMLRegression.secondFloorArea) {
            $('#predictedPrice').empty();
            $('#predictedPrice').append(`Price prediction for a house with a number of rooms: ${TotalNumberOfRooms} failed.`);
        }
        alert('Please complete all the fields!');
        return;
    }
    $('#predictedPrice').empty();
    $('#predictedPrice').append(`Price prediction: ${parseInt(predictedPrice)} USD`);

});
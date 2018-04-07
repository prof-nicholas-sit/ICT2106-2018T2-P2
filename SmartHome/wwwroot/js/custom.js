$(document).ready(function(){
   $('#device_2, #device_3').hide(); 
    
//    $('#tab_toggle[data-toggle="tab"]').on('shown.bs.tab', function (e) {
//      //call chart to render here
//        var ctx = document.getElementById('daily_1').getContext('2d');
//        var ctx2 = document.getElementById('daily_2').getContext('2d');
//    });
});

var ctx = document.getElementById('daily_1').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["12AM", "2AM", "4AM", "6AM", "8AM", "10AM", "12PM", "2PM", "4PM", "6PM", "8PM", "10PM", "12AM"],
        datasets: [{
            label: "Brightness Level",
            backgroundColor: 'rgba(255, 99, 132, 0.6)',
            borderColor: 'rgb(255, 99, 132)',
            data: [20, 20, 20, 0, 0, 0, 0, 50, 0, 0, 60, 100, 20],
        }]
    },

    // Configuration options go here
    options: {}
});

var ctx2 = document.getElementById('daily_2').getContext('2d');
var chart2 = new Chart(ctx2 , {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["12AM", "2AM", "4AM", "6AM", "8AM", "10AM", "12PM", "2PM", "4PM", "6PM", "8PM", "10PM", "12AM"],
        datasets: [{
            label: "Color Temperature",
            backgroundColor: 'rgba(252,145,58,0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [200, 300, 550, 130, 900, 1000, 600, 2800, 500, 3000, 2000, 2500, 600],
        }]
    },

    // Configuration options go here
    options: {}
});

var ctx3 = document.getElementById('weekly_1').getContext('2d');
var chart3 = new Chart(ctx3, {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["Week 1", "Week 2", "Week 3", "Week 4"],
        datasets: [{
            label: "Brightness Level",
            backgroundColor: 'rgba(255, 99, 132, 0.6)',
            borderColor: 'rgb(255, 99, 132)',
            data: [20, 20, 20, 0, 0, 0, 0, 50, 0, 0, 60, 100, 20],
        }]
    },

    // Configuration options go here
    options: {}
});

var ctx4 = document.getElementById('weekly_2').getContext('2d');
var chart4 = new Chart(ctx4 , {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["Week 1", "Week 2", "Week 3", "Week 4"],
        datasets: [{
            label: "Color Temperature",
            backgroundColor: 'rgba(252,145,58,0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [200, 300, 550, 130, 900, 1000, 600, 2800, 500, 3000, 2000, 2500, 600],
        }]
    },

    // Configuration options go here
    options: {}
});

var ctx5 = document.getElementById('monthly_1').getContext('2d');
var chart5 = new Chart(ctx5, {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            label: "Brightness Level",
            backgroundColor: 'rgba(255, 99, 132, 0.6)',
            borderColor: 'rgb(255, 99, 132)',
            data: [20, 20, 20, 0, 0, 0, 0, 50, 0, 0, 60, 100, 20],
        }]
    },

    // Configuration options go here
    options: {}
});

var ctx6 = document.getElementById('monthly_2').getContext('2d');
var chart6 = new Chart(ctx6 , {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            label: "Color Temperature",
            backgroundColor: 'rgba(252,145,58,0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [200, 300, 550, 130, 900, 1000, 600, 2800, 500, 3000, 2000, 2500, 600],
        }]
    },

    // Configuration options go here
    options: {}
});
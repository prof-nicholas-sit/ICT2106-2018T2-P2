
var trend1 = document.getElementById('trend_1').getContext('2d');
window.myHorizontalBar = new Chart(trend1, {
    type: 'horizontalBar',
    data: {
        labels: ["Week 1", "Week 2", "Week 3", "Week 4"],
        datasets: [{
            label: 'My Household',
            backgroundColor: 'rgba(252,145,58,0.6)',
            borderColor: 'rgb(255, 99, 132)',
            data: [1200, 1102, 960, 1220]
        }, {
            label: 'Average Household',
            backgroundColor: 'rgba(255, 99, 132, 0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [1430, 1200, 1044, 1650]
        }, {
            label: 'Target',
            backgroundColor: 'rgba(252,200,58,0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [1153, 1744, 940, 1200]
        }, {
            label: 'Previous Month',
            backgroundColor: 'rgba(100,80,60,0.6)',
            borderColor: 'rgb(252,145,58)',
            data: [1400, 1130, 1100, 1200]
        }]  
    },
    options: {
        responsive: true,
        legend: {
            position: 'top',
        },
        title: {
            display: false,
        },
    }
});
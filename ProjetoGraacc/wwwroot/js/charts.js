/* eslint-disable no-magic-numbers */
// random Numbers
var random = function random() {
  return Math.round(Math.random() * 100);
}; // eslint-disable-next-line no-unused-vars


var doughnutChart = new Chart($('#canvas-1'), {
  type: 'doughnut',
  data: {
    labels: ['Finalizados', 'Abertos', 'Pleiteando', 'Ganhos'],
    datasets: [{
      data: [300, 85, 39, 15],
      backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#00ff00'],
      hoverBackgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#00ff00']
    }]
  },
  options: {
    responsive: true
  }
}); // eslint-disable-next-line no-unused-vars

var pieChart = new Chart($('#canvas-2'), {
  type: 'pie',
  data: {
    labels: ['Primeira Instancia', 'Segunda Instancia', 'Finalizado'],
    datasets: [{
      data: [300, 50, 560],
      backgroundColor: ['#36A2EB', '#FFCE56', '#FF6384'],
      hoverBackgroundColor: ['#36A2EB', '#FFCE56', '#FF6384']
    }]
  },
  options: {
    responsive: true
  }
}); // eslint-disable-next-line no-unused-vars
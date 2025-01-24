// Datos de ejemplo para el gráfico de torta
var pieData = [
  { label: 'Categoría 1', value: 30 },
  { label: 'Categoría 2', value: 20 },
  { label: 'Categoría 3', value: 50 }
];
//Obtenemos los datos de las propiedades data en HTML
var nombres = Array.from(document.querySelectorAll('tbody tr td[data-nombre]'), function (td) {
    return td.dataset.nombre;
});

var cantidades = Array.from(document.querySelectorAll('tbody tr td[data-cantidad]'), function (td) {
    return parseInt(td.dataset.cantidad);
});

var porcentajes = Array.from(document.querySelectorAll('tbody tr td[data-porcentaje]'), function (td) {
    return td.dataset.porcentaje;
});

// Crear el gráfico de torta
var pieChartCanvas = document.getElementById('pie-chart');
var pieChartCtx = pieChartCanvas.getContext('2d');
new Chart(pieChartCtx, {
  type: 'pie',
  data: {
      //labels: pieData.map(data => data.label), //insercion de datos de ejemplo
    labels: nombres,
      datasets: [{
        // data: pieData.map(data => data.value),
      data: cantidades,
          backgroundColor: ['#F1C40F', '#F39C12', 'red', '#A93226', '#800000', '#784212', '#9A7D0A', '#E4CD10', '#FFE541']
    }]
  },
  options: {
    responsive: true,
    legend: {
      position: 'bottom'
    },
    tooltips: {
      callbacks: {
        label: function(tooltipItem, data) {
          var dataset = data.datasets[tooltipItem.datasetIndex];
          var total = dataset.data.reduce(function(previousValue, currentValue, currentIndex, array) {
            return previousValue + currentValue;
          });
          var currentValue = dataset.data[tooltipItem.index];
          var percentage = Math.floor(((currentValue/total) * 100)+0.5);
          return percentage;
        }
      }
    }
  }
});


// Ejemplo Datos para el gráfico de barras
/*var barData = [
  { period: 'Enero', value: 100 },
  { period: 'Febrero', value: 150 },
  { period: 'Marzo', value: 120 },
  { period: 'Abril', value: 100 },
  { period: 'Mayo', value: 180 },
  { period: 'Junio', value: 20 },
  { period: 'Julio', value: 80 },
  { period: 'Agosto', value: 50 },
  { period: 'Septiembre', value: 220 },
  { period: 'Octubre', value: 300 },
  { period: 'Noviembre', value: 130 },
  { period: 'Diciembre', value: 70 },
];*/

//Obtenemos los datos de las propiedades data en HTML
var periodos = Array.from(document.querySelectorAll('tbody tr td[data-fecha]'), function (td) {
    return td.dataset.fecha;
});
var services = Array.from(document.querySelectorAll('tbody tr td[data-services]'), function (td) {
    return td.dataset.services;
});
var facturareal = Array.from(document.querySelectorAll('tbody tr td[data-facturareal]'), function (td) {
    return td.dataset.facturareal;
});
var facturacion = Array.from(document.querySelectorAll('tbody tr td[data-facturacion]'), function (td) {
    return td.dataset.facturacion;
});

var barData = periodos.map(function (periodo, index) {
    var value = services[index] ? parseInt(services[index]) : 0;
    var costo = facturacion[index] ? parseInt(facturacion[index]) : 0;
    var parcial = facturareal[index] ? parseInt(facturareal[index]) : 0;

    return {
        period: periodo,
        value: value,
        costo: costo,
        parcial : parcial
    };
});

var maxValue = Math.max(...barData.map(data => data.value));
var halfMaxValue = maxValue / 2;

var maxCost = Math.max(...barData.map(data => data.costo));
var halfMaxCost = maxCost / 2;

var maxParc = Math.max(...barData.map(data => data.parcial));
var halfMaxParc = maxParc / 2;

// Crear el gráfico de barras
var barChartCanvas = document.getElementById('bar-chart');
var barChartCtx = barChartCanvas.getContext('2d');
var barChart = new Chart(barChartCtx, {
    type: 'bar',
    data: {
        labels: barData.map(data => data.period),
        datasets: [{
            label: 'Cantidad de Servicios',
            data: barData.map(data => parseInt(data.value)),
            backgroundColor: barData.map(data => parseInt(data.value) > halfMaxValue ? 'orange' : 'gray')
        }
        ]
    },
    options: {
        responsive: true,
        legend: {
            display: true
        },
        scales: {
            xAxes: [{
                display: true,
                barPercentage: 1
            }],
            yAxes: [{
                display: true,
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});

//Crear el segundo gráfico de barras
var barChartCanvas2 = document.getElementById('bar-chart2');
var barChartCtx2 = barChartCanvas2.getContext('2d');
var barChart2 = new Chart(barChartCtx2, {
    type: 'bar',
    data: {
        labels: barData.map(data => data.period),
        datasets: [{
            label: 'Facturación Mensual Total en $',
            data: barData.map(data => parseInt(data.costo)),
            backgroundColor: barData.map(data => parseInt(data.costo) > halfMaxCost ? 'green' : 'red')
        },
        {
            label: 'Facturación Mensual en Costo de Servicio en $',
            data: barData.map(data => parseInt(data.parcial)),
            backgroundColor: barData.map(data => parseInt(data.parcial) > halfMaxParc ? 'green' : 'red')
        }]
    },
    options: {
        responsive: true,
        legend: {
            display: true
        },
        scales: {
            xAxes: [{
                display: true,
                barPercentage: 0.5
            }],
            yAxes: [{
                display: true,
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});


// Control deslizante para el periodo mensual
var slider = document.getElementById('slider');
var sliderLabel = document.getElementById('slider-label');

slider.addEventListener('input', function () {
    var value = parseInt(slider.value);
    var selectedData = barData.slice(value, value + 3); // Muestra 3 meses a la vez

    // Actualiza el gráfico de barras con los datos seleccionados
    barChart.data.labels = selectedData.map(data => data.period);
    barChart.data.datasets[0].data = selectedData.map(data => data.value);
    barChart.data.datasets[0].backgroundColor = selectedData.map(data => data.value > halfMaxValue ? 'orange' : 'gray');
    barChart.update();

    barChart2.data.labels = selectedData.map(data => data.period);
    barChart2.data.datasets[0].data = selectedData.map(data => data.costo);
    barChart2.data.datasets[0].backgroundColor = selectedData.map(data => data.costo > halfMaxCost ? 'green' : 'red');
    barChart2.data.datasets[1].data = selectedData.map(data => data.parcial);
    barChart2.data.datasets[1].backgroundColor = selectedData.map(data => data.parcial > halfMaxParc ? 'green' : 'red');
    barChart2.update();

    // Actualiza la etiqueta del control deslizante
    sliderLabel.textContent = selectedData[0].period + ' - ' + selectedData[2].period;
});

// Inicializa el gráfico de barras y el control deslizante con los datos iniciales
sliderLabel.textContent = barData[0].period + ' - ' + barData[2].period;
slider.max = barData.length - 3;
slider.value = 0;
slider.dispatchEvent(new Event('input'));

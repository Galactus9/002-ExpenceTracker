<script setup>
import { onMounted, ref, watch } from 'vue';
import axios from 'axios';
import Chart from 'chart.js/auto';

const labels = ref([]);
const amount = ref([]);

const data = {
    labels: labels.value.slice(),
    datasets: [
        {
            label: 'My First Dataset',
            data: amount.value.slice(),
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(201, 203, 207, 0.2)',
            ],
            borderColor: [
                'rgb(255, 99, 132)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
                'rgb(153, 102, 255)',
                'rgb(201, 203, 207)',
            ],
            borderWidth: 1,
        },
    ],
};

const config = {
    type: 'bar',
    data: data,
    options: {
        scales: {
            y: {
                beginAtZero: true,
            },
        },
    },
};

onMounted(async () => {
    try {
        const response = await axios.get(
            'https://localhost:7235/api/ChartData/GetAll'
        );
        const chartData = response.data; // Assuming the API response is an object with the necessary data properties
        console.log(chartData)
        labels.value = chartData.map(item => item.category);
        amount.value = chartData.map(item => item.amountSpend);
        console.log(labels.value.slice());
        console.log(amount.value.slice());
    } catch (error) {
        console.log(error);
    }
});

watch([labels, amount], ([newLabels, newAmount]) => {
    data.labels = newLabels.slice();
    data.datasets[0].data = newAmount.slice();
    const myChart = new Chart(document.getElementById('myChart'), config);
});
</script>

<template>
    <div class="container">
        <div class="card text-center">
            <div class="card-header">Expense per Category</div>
            <div class="card-body">
                <canvas id="myChart" class="chart-canvas"></canvas>
            </div>
        </div>
    </div>
</template>

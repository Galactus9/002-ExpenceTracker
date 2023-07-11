<script setup>
import { onMounted, ref, watch } from 'vue';
import axios from 'axios';
import Chart from 'chart.js/auto';

const labels = ref([]);
const amount = ref([]);

const data = {
    labels: labels.value,
};

const config = {
    type: 'pie',
    data: data,
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            },
        },
        layout: {
            padding: {
                left: 50,
                right: 50,
                top: 0,
                bottom: 0,
            },
        },
        maintainAspectRatio: false,
    },
};

onMounted(async () => {
    try {
        // Fetch the chart data from the API
        const response = await axios.get('https://localhost:7235/api/ChartData/GetAll');
        const chartData = response.data;
        labels.value = chartData.map(item => item.category);
        amount.value = chartData.map(item => item.amountSpend);
    } catch (error) {
        console.log(error);
    }
});

watch([labels, amount], ([newLabels, newAmount]) => {
    const newDatasets = [{
        data: newAmount,
        backgroundColor: generateRandomColors(newAmount.length, 1),
        borderColor: (0,191,255, 1),
        borderWidth: 1,
    }];

    data.labels = newLabels;
    data.datasets = newDatasets;

    const myChart = new Chart(document.getElementById('myChart'), config);
});

// Helper function to generate an array of random colors
function generateRandomColors(count, opacity) {
    const colors = [];
    for (let i = 0; i < count; i++) {
        const color = `rgba(${getRandomValue(0, 255)}, ${getRandomValue(0, 255)}, ${getRandomValue(0, 255)}, ${opacity})`;
        colors.push(color);
        console.log(color)
    }
    return colors;
}

// Helper function to generate a random value within a range
function getRandomValue(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
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

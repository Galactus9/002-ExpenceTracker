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
        // Fetch the chart data from the API
        const response = await axios.get(
            'https://localhost:7235/api/ChartData/GetAll'
        );
        const chartData = response.data;
        console.log(chartData);

        // Extract labels and amounts from the chart data
        labels.value = chartData.map(item => item.category);
        amount.value = chartData.map(item => item.amountSpend);
        console.log(labels.value);
        console.log(amount.value);
    } catch (error) {
        console.log(error);
    }
});

watch([labels, amount], ([newLabels, newAmount]) => {
    const newDatasets = [];

    for (let i = 0; i < newAmount.length; i++) {
        // Create datasets with respective labels and amounts
        newDatasets.push({
            label: newLabels[i],
            data: [newAmount[i]],
            backgroundColor: generateRandomColors(newAmount.length, 1),
            borderColor: (0, 191, 255, 1),
            borderWidth: 1,
        });
        console.log(newAmount[i])
    }

    // Update the chart data with new labels and datasets
    data.labels = ' ';
    data.datasets = newDatasets;

    // Create the chart using the updated data and config
    const myChart = new Chart(document.getElementById('myChart'), config);
});

// Helper function to generate an array of random colors
function generateRandomColors(count, opacity) {
    const colors = [];
    for (let i = 0; i < count; i++) {
        const color = `rgba(${getRandomValue(0, 255)}, ${getRandomValue(0, 255)}, ${getRandomValue(0, 255)}, ${opacity})`;
        colors.push(color);
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

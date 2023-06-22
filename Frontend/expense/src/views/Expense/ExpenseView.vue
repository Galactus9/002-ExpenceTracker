<script setup>
import axios from 'axios';
import { RouterLink } from 'vue-router';
import { onMounted, ref } from 'vue';


const expenses = ref([]);
        
        const url = 'https://localhost:7235/api/Expense/GetAllWithDetails';
        onMounted(async() => {
            try{
                const response = await axios.get(url)
                console.log(response.data)
                expenses.value = response.data;
                console.log(expenses.value.length)
            }
            catch(error){console.log(error)}
        });
</script>

<template>
    <div></div>
    <div class="container" >
        <div class="card">
            <div class="card-header">
                <h2 style="text-align: center;"> List Of Expenses</h2>
                <p style="text-align: center;">
                    <RouterLink class="btn btn-warning" to="/Expense/new">Insert Expense</RouterLink>
                </p>
            </div>
            <div class="card-body">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Description</th>
                            <th>Amount</th>
                            <th>Purchase Date</th>
                            <th>Expence Category</th>
                        </tr>
                    </thead>
                    <tbody v-if="expenses.length > 0">
                        <tr v-for="expense in expenses" :key="expense.id">
                            <td>
                                {{ expense.description }}
                            </td>
                            <td>
                                {{ expense.amount }}
                            </td>
                            <td>
                                {{ expense.purchaseDate }}
                            </td>
                            <td>
                                {{ expense.expenseCategory.title }}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>
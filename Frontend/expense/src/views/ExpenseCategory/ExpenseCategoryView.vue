<script setup>
import axios from 'axios';
import { RouterLink } from 'vue-router';
import { onMounted, ref } from 'vue';


const expenseCategories = ref([]);
        
        const url = 'https://localhost:7235/api/ExpenseCategory/GetAll';
        onMounted(async() => {
            try{
                const response = await axios.get(url)
                console.log(response.data)
                expenseCategories.value = response.data;
            }
            catch(error){console.log(error)}
        });
</script>

<template>
    <div>
    </div>
    <div class="container" >
        <div class="card">
            <div class="card-header">
                <h2 style="text-align: center;"> List Of Expense Categories</h2>
                <p style="text-align: center;">
                    <RouterLink class="btn btn-warning" to="/ExpenseCategory/new">Insert Expense Category</RouterLink>
                </p>
            </div>
            <div class="card-body">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Description</th>
                            <th>IsActive</th>
                        </tr>
                    </thead>
                    <tbody v-if="expenseCategories.length > 0">
                        <tr v-for="category in expenseCategories" :key="category.id">
                            <td>
                                {{ category.title }}
                            </td>
                            <td>
                                {{ category.description }}
                            </td>
                            <td>
                                <RouterLink class="btn btn-success" :to="`/ExpenseCategory/Update/${category.id}`">Update</RouterLink>
                                &nbsp;
                                <button type="button" class="btn btn-danger"  @click="openModalDelete(category)">Delete</button>
                                &nbsp;
                                <button type="button" class="btn btn-secondary" @click="openModalSkills(category)">Details</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>


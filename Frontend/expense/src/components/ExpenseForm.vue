<script setup>
import axios from 'axios';
import { ref, onMounted, defineProps, defineEmits, watch } from 'vue';
import { stringifyQuery } from 'vue-router';

const selectedCategory = ref('');
const allCategories = ref([]);
const url = 'https://localhost:7235/api/ExpenseCategory/GetAll';
    const props = defineProps({
        description: String,
        amount: Number,
        purchaseDate: String,
        expenseCategoryId: String,
        handleSubmit: Function,
        handleCancel: Function
    })
    defineEmits(['update:description', 'update:amount', 'update:purchaseDate', 'update:expenseCategoryId']);

    onMounted(async () => {
    try {
      const response = await axios.get(url);
      allCategories.value = response.data;
    } catch (error) {
      console.error(error);
    }
  });

  watch(() => props.expenseCategoryId, (newValue) => {
    selectedCategory.value = newValue;
  });
</script>

<template>

    
    <div class="container">
        <div class="card">
            <div class="card-header">
                Expense Form
            </div>
            <div class="card-body">
                <form v-on:submit="handleSubmit">
                    <div class="mb-3">
                        <span>Description</span>
                        <input class="form-control" type="text" :value="description" @input="$emit('update:description', $event.target.value)" placeholder="Enter Expense Description"/>
                    </div>
                    <div class="mb-3">
                        <span>Amount</span>
                        <input type="Number" :value="amount" class="form-control" @input="$emit('update:amount', $event.target.value)" placeholder="Enter Expense Amount"/>
                    </div>
                    <div class="mb-3">
                        <span>Date of purchase</span>
                        <input class="form-control" type="Date" :value="purchaseDate" @input="$emit('update:purchaseDate', $event.target.value)" placeholder="Enter purchase date "/>
                    </div>
                    <div class="mb-3">
                        <span>Expense Category</span>
                        <select for="expenseCategoryId" class="form-select custom-select" id="expenseCategories" v-model="selectedCategory" @change="$emit('update:expenseCategoryId', $event.target.value)">
                            <option disabled value="">Select Expense Category</option>
                            <option v-for="category in allCategories" :key="category.id" :value="category.id">
                                {{ category.title }}
                            </option>
                        </select>
                    </div>

                    <div class="mb-3">
                        <button class="btn btn-primary" type="submit">Submit</button>&nbsp;
                        <RouterLink class="btn btn-info" to="/expense">Back</RouterLink>&nbsp;
                        <RouterLink class="btn btn-warning" to="/">Return to home</RouterLink>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

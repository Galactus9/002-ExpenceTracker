<script setup>
import { defineProps, defineEmits } from 'vue';

const url = 'https://localhost:7235/api/ExpenseCategory/GetAll';
    const props = defineProps({
        title: String,
        description: String,
        isActive: Boolean,
        handleSubmit: Function,
        handleCancel: Function
    })
    defineEmits(['update:title', 'update:description', 'update:isActive']);

</script>

<template>
    <div class="container">
        <div class="card text-center">
            <div class="card-header">
                Expense Category Form
            </div>
            <div class="card-body">
                <form v-on:submit="handleSubmit">
                    <div class="mb-3">
                        <span>Title</span>
                        <input class="form-control" type="text" :value="title" @input="$emit('update:title', $event.target.value)" placeholder="Enter Category Title"/>
                    </div>
                    <div class="mb-3">
                        <span>Description</span>
                        <input :value="description" class="form-control" @input="$emit('update:description', $event.target.value)" placeholder="Enter Category Description"/>
                    </div>
                    <div class="mb-3"> 
                        <label for="IsActive">Is Active</label>
                        <input type="checkbox" :checked="isActive" @input="$emit('update:isActive', $event.target.checked)"/>
                    </div>
                    <div class="mb-3">
                        <button class="btn btn-primary" type="submit">Submit</button>&nbsp;
                        <RouterLink class="btn btn-info" to="/ExpenseCategory">Back</RouterLink>&nbsp;
                        <RouterLink class="btn btn-warning" to="/">Return to home</RouterLink>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

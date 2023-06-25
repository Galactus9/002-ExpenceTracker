<script setup>
import axios from 'axios';
import { onMounted, ref } from 'vue';
import ExpenseCategoryForm from '@/components/ExpenseCategoryForm.vue';
import { useRouter, useRoute } from 'vue-router';

const router = useRouter();
const title = ref();
const description = ref('');
const isActive = ref();
const expenseCategoryId = useRoute().params.id;


const handleUpdate = async (event) => {
    event.preventDefault();
    console.log('hi')
    const payload = {
        title: title.value,
        description: description.value,
        isActive: isActive.value
    };
    try {
        console.log(payload);
        const response = await axios.put(`https://localhost:7235/api/ExpenseCategory/${expenseCategoryId}`, payload);
        router.push('/ExpenseCategory');
    } catch (error) {
        console.log(error);
    }
};

onMounted(async () => {
    console.log(useRoute().params.id);

    try {
        const response = await axios.get(`https://localhost:7235/api/ExpenseCategory/GetById/${expenseCategoryId}`);
        title.value = response.data.title;
        description.value = response.data.description;
        isActive.value = response.data.isActive;
    } catch (error) {
        console.log(error);
    }
});
</script>

<template>
    <div>
        <ExpenseCategoryForm
            v-model:title="title"
            v-model:description="description"
            v-model:isActive="isActive"
            :handleSubmit="handleUpdate" 
        />
    </div>
</template>

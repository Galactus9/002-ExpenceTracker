<script setup>
import axios from 'axios';
import { onMounted, ref } from 'vue';
import ExpenseForm from '@/components/ExpenseForm.vue';
import { useRouter, useRoute } from 'vue-router';

const router = useRouter();
const description = ref('');
const amount = ref();
const purchaseDate = ref();
const expenseCategoryId = ref();
const expenseId = useRoute().params.id;


const handleUpdate = async (event) => {
    event.preventDefault();
    const payload = {
        description:description.value,
        amount:amount.value,      
        purchaseDate:purchaseDate.value,
        expenseCategoryId:expenseCategoryId.value,
    }
    try {
        const response = await axios.put(`https://localhost:7235/api/Expense/Update/${expenseId}`, payload);
        router.push('/Expense');
    } catch (error) {
        console.log(error);
    }
};

onMounted(async () => {
    try {
        const response = await axios.get(`https://localhost:7235/api/Expense/GetById/${expenseId}`);
        console.log(response.data);
        description.value = response.data.description;
        amount.value = response.data.amount;
        let dateString = response.data.purchaseDate;
        let [year, month, day] = dateString.split("T")[0].split("-");
        let date = new Date(year, month - 1, day); 
        purchaseDate.value = date.toISOString().split("T")[0];
        expenseCategoryId.value = response.data.expenseCategory.id;

    } catch (error) {
        console.log(error);
    }
});
</script>
<template>
    <div>
        <ExpenseForm       
        v-model:description="description"
        v-model:amount="amount"
        v-model:purchaseDate="purchaseDate"
        v-model:expenseCategoryId="expenseCategoryId"
        :handleSubmit="handleUpdate" 
        />
    </div>

</template>

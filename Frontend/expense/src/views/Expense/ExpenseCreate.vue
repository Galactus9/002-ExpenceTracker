<script setup>
import axios from 'axios';
import { RouterLink } from 'vue-router';
import { onMounted, ref } from 'vue';
import ExpenseForm from '@/components/ExpenseForm.vue'
import { routerKey, useRouter } from 'vue-router';


const router = useRouter();
const Description = ref('');
const Amount = ref();
const PurchaseDate = ref();
const ExpenseCategory = ref('');

    const handleCreate = async(event) => {
    event.preventDefault();
    const payload = {
        description:Description.value,
        amount:Amount.value,      
        purchaseDate:PurchaseDate.value,
        expenseCategoryId:ExpenseCategory.value,
 
    }

    try {
        console.log(payload)
        const response = await axios.post('https://localhost:7235/api/Expense',payload);
        router.push('/Expense');
        console.log(response.data)

    } catch (error) {
        console.log(error)
    }
}
</script>
<template>
    <div>
        <ExpenseForm       
        v-model:description="Description"
        v-model:amount="Amount"
        v-model:purchaseDate="PurchaseDate"
        v-model:expenseCategoryId="ExpenseCategory"
        :handleSubmit="handleCreate"
        />
    </div>

</template>

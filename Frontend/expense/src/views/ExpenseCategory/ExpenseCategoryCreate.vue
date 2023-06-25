<script setup>
import axios from 'axios';
import { RouterLink } from 'vue-router';
import { onMounted, ref } from 'vue';
import ExpenseCategoryForm from '@/components/ExpenseCategoryForm.vue'
import { routerKey, useRouter } from 'vue-router';


const router = useRouter();
const Title = ref();
const Description = ref('');
const IsActive = ref();

    const handleCreate = async(event) => {
    event.preventDefault();
    const payload = {
        title:Title.value,      
        description:Description.value,
        isActive:IsActive.value,
 
    }

    try {
        console.log(payload)
        const response = await axios.post('https://localhost:7235/api/ExpenseCategory',payload);
        router.push('/ExpenseCategory');
        console.log(response.data)

    } catch (error) {
        console.log(error)
    }
}
</script>
<template>
    <div>
        <ExpenseCategoryForm       
        v-model:title="Title"
        v-model:description="Description"
        v-model:isActive="IsActive"
        :handleSubmit="handleCreate"
        />
    </div>

</template>


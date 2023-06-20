        
<script setup>
        import axios from 'axios';
        import { onMounted, ref } from 'vue';
        
        let data = ref('');
        const url = 'https://localhost:7235/api/Expense/GetAllWithDetails';
        onMounted(async() => {
            try{
                const response = await axios.get(url)
                console.log(response.data)
                data.value = response.data;
            }
            catch(error){console.log(error)}
        });
</script>
<template>
    <div v-for="item in data" :key="item.id">
        <div>
           {{ item.expenseCategory.title }},  {{ item.amount }}
        </div>
    </div>
</template>

<style lang="scss" scoped>

</style>
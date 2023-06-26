<template>
    <div class="container">
                  <p>Delete Expense with the id:</p>
                  <p> {{ props.Expense }} </p>
              <div style="text-align: center;">
                  <button class="btn btn-daner" @click="deleteExpense">Delete</button>&nbsp;
              </div>
      </div>
  
  </template>
  
  <script setup>
  import axios from 'axios';
  import { useRoute } from 'vue-router';
  import { useRouter } from 'vue-router';
  
//   const expenseCategoryId = useRoute().params.id;
  const router = useRouter();
//   const expenseCategory = ref({});

  const props = defineProps({
    Expense: String
  });
  
  const deleteExpense = async () => {
      console.log(props.Expense)
      try {
        
          await axios.delete(`https://localhost:7235/api/Expense/Delete/${props.Expense}`).then(response => (console.log(response)));
          router.push('/loading').then(() => {
                  router.push('/Expense');
          });
      }
      catch (error) {
          console.error(error);
      }
  }
  
  
  </script>
  <style scoped></style>
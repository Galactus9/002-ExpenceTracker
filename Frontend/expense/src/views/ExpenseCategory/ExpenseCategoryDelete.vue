<template>
    <div class="container">
                  <p>Delete Expense Category with the id:</p>
                  <p> {{ props.ExpenseCategory }} </p>
              <div style="text-align: center;">
                  <button class="btn btn-daner" @click="deleteExpenseCategory">Delete</button>&nbsp;
              </div>
      </div>
  
  </template>
  
  <script setup>
  import axios from 'axios';
  import { useRouter } from 'vue-router';
  
//   const expenseCategoryId = useRoute().params.id;
  const router = useRouter();
//   const expenseCategory = ref({});

  const props = defineProps({
    ExpenseCategory: String
  });
  
  const deleteExpenseCategory = async () => {
      console.log(props.ExpenseCategory)
      try {
          await axios.delete(`https://localhost:7235/api/ExpenseCategory/${props.ExpenseCategory}`).then(response => (console.log(response)));
          router.push('/').then(() => {
                  router.push('/ExpenseCategory');
          });
      }
      catch (error) {
          console.error(error);
      }
  }
  
  
  </script>
  <style scoped></style>
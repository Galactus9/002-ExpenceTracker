<script setup>
import { ref, onMounted, computed } from 'vue';
import { RouterLink } from 'vue-router';
import axios from 'axios';
import Modal from '@/components/Modal.vue';
import ExpenseCategoryDelete from '@/views/ExpenseCategory/ExpenseCategoryDelete.vue'


const isModalOpen = ref(false);
const toggleTheModal = computed(() => isModalOpen.value);
const fields = ref([]);
const modalHead = ref('Category Details')
const modalHeadDelete = ref('Confirm Delete');
let details = ref('');
const deleteExpenseCategory = ref('')
const expenseCategories = ref([]);
const filteredCategories = ref([]);
        



// Modal component

const openModalExpenseCategory = (category) => {

isModalOpen.value = true;
details = true;
fields.value = [
{ id: 'id', label: 'ID', value: category.id },
{ id: 'title', label: 'Title', value: category.title },
{ id: 'description', label: 'Description', value: category.description },
{ id: 'isActive', label: 'Is Active', value: category.isActive },
];
console.log(fields.value)
}


const closeModal = () => {
  isModalOpen.value = false;
};

const openModalConfirmDeleteExpenseCategory = (category) => {
    details = false;
    isModalOpen.value = true;
    deleteExpenseCategory.value = category.id;
    console.log(deleteExpenseCategory.value);
}
onMounted(async() => {
    try{
        const response = await axios.get('https://localhost:7235/api/ExpenseCategory/GetAll')
        expenseCategories.value = response.data;
        filteredCategories.value = response.date;
    } catch (error){
        console.error(error);
    }
});


</script>

<template>

    <!-- modal -->
<div v-if="details">
      <Modal :isModalOpen="toggleTheModal" @close="closeModal()" :ModalHeader="modalHead">
        <div v-for="field in fields" :key="field.id">
          <span class="label">{{ field.label }}</span><br />
          <span > {{ field.value }}</span><br />
        </div>
      </Modal>
</div>
<div v-else>
  <Modal :isModalOpen="toggleTheModal" @close="closeModal()" :ModalHeader="modalHeadDelete">
      <ExpenseCategoryDelete v-bind:ExpenseCategory="deleteExpenseCategory">
      </ExpenseCategoryDelete>
  </Modal>

</div>
    <div>
    </div>
    <div class="container" >
        <div class="card">
            <div class="card-header">
                <h2 style="text-align: center;"> List Of Expense Categories</h2>
                <!-- <input v-model.trim="search" type="text" name="" id="" placeholder="Search..."> -->
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
                                <button type="button" class="btn btn-danger"  @click="openModalConfirmDeleteExpenseCategory(category)">Delete</button>
                                &nbsp;
                                <button type="button" class="btn btn-secondary" @click="openModalExpenseCategory(category)">Details</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>


<script setup>
import { ref, onMounted, computed } from 'vue';
import { RouterLink } from 'vue-router';
import axios from 'axios';
import Modal from '@/components/Modal.vue';
import ExpenseDelete from '@/views/Expense/ExpenseDelete.vue';

const isModalOpen = ref(false);
const toggleTheModal = computed(() => isModalOpen.value);
const fields = ref([]);
const modalHead = ref('Category Details')
const modalHeadDelete = ref('Confirm Delete');
let details = ref('');
const deleteExpense = ref()


const openModalExpense = (expense) => {
console.log(expense.id);
isModalOpen.value = true;
details = true;
fields.value = [
{ id: 'id', label: 'ID', value: expense.id },
{ id: 'description', label: 'Description', value: expense.description },
{ id: 'amount', label: 'Amount', value: expense.amount },
{ id: 'purchaseDate', label: 'Purchase Date', value: expense.purchaseDate },
{ id: 'expenceCategory', label: 'Expence Category', value: expense.expenseCategory.title },
{ id: 'isActive', label: 'Is Active', value: expense.isActive },
];
console.log(fields.value)
}


const closeModal = () => {
  isModalOpen.value = false;
};

const openModalConfirmDeleteExpense = (expense) => {
    details = false;
    isModalOpen.value = true;
    deleteExpense.value = expense.id;
}

const expenses = ref([]);
        onMounted(async() => {
            try{
                const response = await axios.get('https://localhost:7235/api/Expense/GetAllWithDetails')
                expenses.value = response.data;
            }
            catch(error){console.log(error)}
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
        <ExpenseDelete v-bind:Expense="deleteExpense">
        </ExpenseDelete>
    </Modal>
    </div>


    <div class="container" >
        <div class="card">
            <div class="card-header">
                <h2 style="text-align: center;"> List Of Expenses</h2>
                <p style="text-align: center;">
                    <RouterLink class="btn btn-warning" to="/Expense/new">Insert Expense</RouterLink>
                </p>
            </div>
            <div class="card-body">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Description</th>
                            <th>Amount</th>
                            <th>Purchase Date</th>
                            <th>Expence Category</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody v-if="expenses.length > 0">
                        <tr v-for="expense in expenses" :key="expense.id">
                            <td>
                                {{ expense.description }}
                            </td>
                            <td>
                                {{ expense.amount }}
                            </td>
                            <td>
                                {{ expense.purchaseDate }}
                            </td>
                            <td>
                                {{ expense.expenseCategory.title }}
                            </td>
                            <td>
                                <RouterLink class="btn btn-success" :to="`/Expense/Update/${expense.id}`">Update</RouterLink>
                                &nbsp;
                                <button type="button" class="btn btn-danger"  @click="openModalConfirmDeleteExpense(expense)">Delete</button>
                                &nbsp;
                                <button type="button" class="btn btn-secondary" @click="openModalExpense(expense)">Details</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

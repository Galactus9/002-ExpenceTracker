import { createRouter, createWebHistory } from 'vue-router';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'HoumeView',
      component: () => import('../views/Home/Home.vue')
    },
    {
      path: '/Expense',
      name: 'ExpenseView',
      component: () => import('../views/Expense/ExpenseView.vue')
    },
    {
      path: '/Expense/new',
      name: 'ExpenseCreate',
      component: () => import('../views/Expense/ExpenseCreate.vue')
    },
    {
      path: '/Expense/Update/:id',
      name: 'Expense',
      component: () => import('../views/Expense/ExpenseUpdate.vue')
    },
    {
      path: '/ExpenseCategory',
      name: 'ExpenseCategoryView',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryView.vue')
    },
    {
      path: '/ExpenseCategory/new',
      name: 'ExpenseCategoryCreate',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryCreate.vue')
    },
    {
      path: '/ExpenseCategory/Update/:id',
      name: 'ExpenseCategoryUpdate',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryUpdate.vue')
    },
    {
      path: '/ExpenseCategory/Delete/:id',
      name: 'ExpenseCategoryDelete',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryDelete.vue')
    },
    {
      path: '/Charts/Pie',
      name: 'Pie',
      component: () => import('../views/Charts/Pie.vue')
    },
    {
      path: '/Charts/Bars',
      name: 'Bars',
      component: () => import('../views/Charts/Bars.vue')
    },
  ]
})

export default router

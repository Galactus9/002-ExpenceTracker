import { createRouter, createWebHistory } from 'vue-router';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path:'/',
      name:'HoumeView',
      component: () => import('../views/Home/Home.vue')
    },
    {
      path:'/Expense',
      name:'ExpenseView',
      component: () => import('../views/Expense/ExpenseView.vue')
    },
    {
      path:'/Expense/new',
      name:'ExpenseCreate',
      component: () => import('../views/Expense/ExpenseCreate.vue')
    },
    {
      path:'/ExpenseCategory',
      name:'ExpenseCategoryView',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryView.vue')
    },
    {
      path:'/ExpenseCategory/new',
      name:'ExpenseCategoryCreate',
      component: () => import('../views/ExpenseCategory/ExpenseCategoryCreate.vue')
    },
    
  ]
})

export default router

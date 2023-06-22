import { createRouter, createWebHistory } from 'vue-router';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
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
    
  ]
})

export default router

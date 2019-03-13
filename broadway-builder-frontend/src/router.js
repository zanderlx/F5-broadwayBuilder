import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/theaters',
      name: 'theaters',
      component: () => import('./views/Theaters.vue')
    },
    {
      path: '/account',
      name: 'account',
      component: () => import('./views/Account.vue')
    },
    {
      path: '/contactus',
      name: 'contactus',
      component: () => import('./views/ContactUs.vue')
    },
    {
      path: '/theater/{theaterid}/helpwanted',
      name: 'adminhelpwanted',
      component: () => import('./views/HelpWanted/AdminHelpWanted.vue')
    },
    {
      path: '/theater/{theaterid}/helpwanted/apply',
      name: 'userhelpwanted',
      component: () => import('./views/HelpWanted/UserHelpWanted.vue')
    },
    {
      path:'/theater/{theaterid}/userproductioninfo',
      name: 'userproductioninfo',
      component: () => import('./views/ProductionInfo/UserProductionInfo.vue')
    }
  ]
})

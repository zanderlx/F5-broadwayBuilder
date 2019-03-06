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
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/Theaters.vue')
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
      name: 'helpwanted',
      component: () => import('./views/HelpWanted/UserHelpWanted.vue')
    }
  ]
})

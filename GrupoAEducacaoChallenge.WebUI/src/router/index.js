import Vue from 'vue'
import VueRouter from 'vue-router'
import AlunosList from '../pages/alunos-list.vue'

Vue.use(VueRouter)

const routes = [

    {
        path: '/alunos-list',
        name: 'alunos-list',
        component: AlunosList
    }
]

const router = new VueRouter({
    routes
})

export default router

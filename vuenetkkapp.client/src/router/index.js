import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from '@/views/HomeView.vue';
import RegisterView from '@/views/RegisterView.vue';
import SalesView from '@/views/SalesView.vue';

const routes = [
    { path: '/', component: HomeView },
    { path: '/register', component: RegisterView },
    { path: '/sales', component: SalesView },
]

const router = createRouter({
    history: createMemoryHistory(),
    routes,
});

export default router;
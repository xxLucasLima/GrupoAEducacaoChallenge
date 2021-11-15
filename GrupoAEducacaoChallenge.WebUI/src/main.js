import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import { VueMaskDirective } from "v-mask";

Vue.config.productionTip = true
Vue.directive("mask", VueMaskDirective);

new Vue({
    router,
    vuetify,
    render: h => h(App)
}).$mount('#app')

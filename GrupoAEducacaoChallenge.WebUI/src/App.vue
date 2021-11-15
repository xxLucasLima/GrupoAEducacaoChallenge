<template>
    <v-app class="grey lighten-4">

        <Nav />

        <v-main class="mx-4 mb-4">
            <router-view></router-view>
        </v-main>

    </v-app>
</template>

<script>
    import Nav from './components/nav.vue'
    export default {
        components: { Nav },
        name: 'App',
        data() {
            return {

            }
        }
    }
</script>

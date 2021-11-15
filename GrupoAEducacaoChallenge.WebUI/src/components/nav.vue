<template>
    <nav>
        <v-navigation-drawer app v-model="drawer" permanent >
            <v-list>
                <v-list-item>
                    <v-list-item-content>
                        <v-list-item-title class="text-h6">
                            Grupo A
                        </v-list-item-title>
                        <v-list-item-subtitle>Modulo Academico</v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
                <v-divider></v-divider>
            </v-list>

            <v-list >

                <v-list-item v-for="item in items"
                             :key="item.title"
                             link 
                             router :to="item.route"         color="primary"
>
                    <v-list-item-icon>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>{{ item.title }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>

        </v-navigation-drawer>
    </nav>
</template>

<script>
    export default {
        data() {
            return {
                drawer: false,
                items: [
                    { title: 'Alunos', icon: 'mdi-account', route: '/alunos-list' },
                ],
            }
        },
    }
</script>

<style>
</style>
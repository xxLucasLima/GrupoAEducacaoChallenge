<template>
    <v-container class="ma-12 pa-12">
        <v-row>
            <v-col cols="12">
                <v-text-field outlined
                              clearable
                              label="Buscar Alunos"
                              :append-icon="'mdi-magnify'"
                              @click:append="true"
                              type="text">

                    <template v-slot:append-outer>

                        <v-btn id="bt-cadastrar-alunos" large
                               @click="newItem()">
                            Cadastrar Aluno

                        </v-btn>
                    </template>
                </v-text-field>
            </v-col>
        </v-row>
        <v-data-table :headers="headers"
                      :items="alunos"
                      sort-by="calories"
                      class="elevation-1">
            <template v-slot:top>
                <v-toolbar flat>

                    <v-dialog v-model="dialog"
                              max-width="500px">
                        <v-card>
                            <v-card-title>
                                <span class="text-h5">{{ formTitle }}</span>
                            </v-card-title>

                            <v-card-text>
                                <v-form  ref="form" lazy-validation  v-model="valid"
>
                                    <v-container>
                                        <v-row>
                                            <v-col v-show="false">
                                                <v-text-field v-model="editedItem.id"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="6">
                                                <v-text-field v-model="editedItem.ra"
                                                              type="number"
                                                              :rules="raRule"
                                                              label="Registro Academico" required></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="6">
                                                <v-text-field v-model="editedItem.name" required
                                                              :rules="notNullRule"
                                                              label="Nome"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="6">
                                                <v-text-field v-model="editedItem.email" required
                                                              :rules="emailRule"
                                                              label="Email"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="6">
                                                <v-text-field v-model="editedItem.cpf" required
                                                              :rules="cpfRule" v-mask="'###.###.###-##'"
                                                              label="CPF"></v-text-field>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-form>
                            </v-card-text>

                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1"
                                       text
                                       @click="close">
                                    Cancel
                                </v-btn>
                                <v-btn color="blue darken-1"
                                       text
                                       @click="save"
                                       :disabled="!valid">
                                    Save
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                    <v-dialog v-model="dialogDelete" max-width="500px">
                        <v-card>
                            <v-card-title class="text-h5 justify-center ">Deseja deletar aluno?</v-card-title>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
                                <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
                                <v-spacer></v-spacer>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-toolbar>
            </template>
            <template v-slot:item.actions="{ item }">
                <v-icon small
                        class="mr-2"
                        @click="editItem(item)">
                    mdi-pencil
                </v-icon>
                <v-icon small
                        @click="deleteItem(item)">
                    mdi-delete
                </v-icon>
            </template>
        </v-data-table>
    </v-container>
</template>
<script>
    import * as http from '../http'

    export default {


        data: () => ({
            valid: true,
            raRule: [
                v => !!v || 'Ra is required',
                v => (v && v > 0) || 'Ra cannot be 0',
            ],
            notNullRule: [
                v => !!v || 'This Field is required',
            ],
            emailRule: [
                v => !!v || 'E-mail is required',
                v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
            ],
            cpfRule: [
                v => !!v || 'CPF is required',
            ],
            dialog: false,
            dialogDelete: false,
            headers: [
                { text: 'Registro Academico', value: 'ra' },
                { text: 'Nome', value: 'name' },
                { text: 'CPF', value: 'cpf' },
                { text: ' ', value: 'actions', sortable: false },
            ],
            alunos: [],
            editedIndex: -1,
            editedItem: {
                id: 0,
                ra: 0,
                nome: '',
                cpf: '',
                email: ''
            },
            defaultItem: {
                id: 0,
                ra: 0,
                nome: '',
                cpf: '',
                email: ''
            },
        }),

        computed: {
            formTitle() {
                return this.editedIndex === -1 ? 'Novo Aluno' : 'Editar Aluno'
            },
        },

        watch: {
            dialog(val) {
                val || this.close()
            },
            dialogDelete(val) {
                val || this.closeDelete()
            },
        },

        created() {
            this.initialize()
        },
        mounted() {
            http.getAlunos((res) => {
                this.alunos = res.data
            }, (err) =>
                alert(err)
            )
        },
        methods: {
            initialize() {
                this.alunos = []
            },
            newItem() {
                this.dialog = true
            },
            editItem(item) {
                this.editedItem = Object.assign({}, item)
                this.dialog = true
            },

            deleteItem(item) {
                this.editedIndex = this.alunos.indexOf(item)
                this.editedItem = Object.assign({}, item)
                this.dialogDelete = true
            },

            deleteItemConfirm() {
                this.alunos.splice(this.editedIndex, 1)

                http.deleteAluno(this.editedItem.id, () => {
                    http.getAlunos((res) => {
                        this.alunos = res.data
                    }, (err) =>
                        alert(err)
                    )
                }, (err) =>
                    alert(err)
                )

                this.closeDelete()
            },

            close() {
                this.dialog = false
                this.$nextTick(() => {
                    this.editedItem = Object.assign({}, this.defaultItem)
                    this.editedIndex = -1
                })
            },

            closeDelete() {
                this.dialogDelete = false
                this.$nextTick(() => {
                    this.editedItem = Object.assign({}, this.defaultItem)
                    this.editedIndex = -1
                })
            },

            save() {
                if (this.$refs.form.validate()){
                
                this.$refs.form.validate()

                    if (this.editedItem.id == 0) {

                        http.createAluno(this.editedItem, () => {
                            http.getAlunos((res) => {
                                this.alunos = res.data
                            }, (err) =>
                                alert(err)
                            )
                        }, (err) =>
                            alert(err)
                        )
                        this.close()

                    } else {
                        http.updateAluno(this.editedItem, () => {
                            http.getAlunos((res) => {
                                this.alunos = res.data
                            }, (err) =>
                                alert(err)
                            )
                        }, (err) =>
                            alert(err)
                        )

                        this.close()
                    }
                }
            },
        },
    }
</script>
<style>
    #bt-cadastrar-alunos {
        bottom: 18px;
        height: 54px;
        width: 250px;
    }
</style>
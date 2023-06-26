<template>
    <v-main class="main">
        <header class="header">
            <h2 class="welcome">Welcome {{name}} {{ surname }}</h2>
        </header>
        <div class="flex-container">
            <div class="table">
                <v-text-field
                    v-model="search"
                    append-icon="mdi-magnify"
                    label="Search by title"
                    single-line
                    hide-details
                    class="search-field"
                ></v-text-field>
                <v-data-table
                    style="background-color: #affaf9;" 
                    :headers="headers"
                    :items="books"
                    :search="search"
                    :items-per-page="10"
                    class="elevation-1"
                >
                    <template v-slot:top>
                        <v-toolbar 
                            flat
                        >
                            <v-toolbar-title>My CRUD</v-toolbar-title>
                            <v-divider
                                class="mx-4"
                                inset
                                vertical
                            ></v-divider>
                            <v-spacer></v-spacer>
                            <v-dialog
                                v-model="dialog"
                                max-width="500px"
                            >
                                <template  v-slot:activator="{ on, attrs }">
                                    <v-btn
                                        color="primary"
                                        dark
                                        class="mb-2"
                                        v-bind="attrs"
                                        v-on="on"
                                    >
                                    Add book
                                    </v-btn>
                                </template>
                                <v-card>
                                    <v-card-title>
                                        <span class="text-h5">{{ formTitle }}</span>
                                    </v-card-title>

                                    <v-card-actions>
                                        <v-spacer></v-spacer>
                                        <v-btn
                                            color="blue darken-1"
                                            text
                                            @click="close"
                                        >
                                            Cancel
                                        </v-btn>
                                        <v-btn
                                            color="blue darken-1"
                                            text
                                            @click="save"
                                        >
                                            Save
                                        </v-btn>
                                    </v-card-actions>
                                </v-card>
                            </v-dialog>
                            <v-dialog v-model="dialogDelete" max-width="500px">
                                <v-card>
                                    <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
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
                    <template>
                        <v-icon
                        small
                        class="mr-2"
                        >
                            mdi-pencil
                        </v-icon>
                        <v-icon
                            small
                        >
                            mdi-delete
                        </v-icon>
                    </template>
                    <template v-slot:no-data>
                        <v-btn
                            color="primary"
                            @click="initialize"
                        >
                            Reset
                        </v-btn>
                    </template>
                </v-data-table>
            </div>
        </div>
    </v-main>
</template>

<script>
import {getFullName, getUserBooks} from "@/services/service.js"
export default {
    name: 'UserPage',
    data() {
        return {
            name: '',
            surname: '',
            id: 1,
            search: '',
            headers: [
                { text: 'ID', value: 'BookId' },
                { text: 'TITLE', value: 'Title' },
                { text: 'AUTHOR', value: 'Author' },
                { text: 'LANGUAGE', value: 'Language' },
                { text: 'PUBBLICATION YEAR', value: 'PublicationYear' },
                { text: 'PAGES', value: 'Pages' },
                { text: 'GENRE', value: 'Genre' },
                { text: 'FINISHING DATE', value: 'FinishingDate', sortable: false},
                { text: 'PRICE', value: 'Price' },
                { text: 'PERSONAL RATING', value: 'Rating' },
                { text: 'NOTES', value: 'Notes', sortable: false},
            ],
            books: []
        }
    },
    props : {
        username : String
    },
    mounted() {
        this.getFullName();
        this.getUserBooks();
    },
    methods: {
        getFullName() {
            getFullName(this.username)
            .then(response => {
                this.name = response.data.Name;
                this.surname = response.data.Surname;
            })
            .catch(() => {
                console.log('username ' + this.username + ' not exists.')
            });
        },
        getUserBooks() {
            getUserBooks(this.username)
            .then(response => {
                this.books = response.data
            })
            .catch(() => {
                console.log('User books not received correctly.')
            })
        }
    }
    
}
</script>

<style>
 @import url('https://fonts.googleapis.com/css2?family=Belanosima&display=swap');
.main {
    text-align: center;
    margin: 0;
    background-color: #c8faf9;
}
.header {
    height: 60px;
    background-image: linear-gradient(blue, aqua);
    position: static;
}
.welcome {
    color: white;
    padding-top: 20px;
    font-family: 'Belanosima', sans-serif;

}
.flex-container {
    display: flex;
    flex-direction: row;
    justify-content: flex-start;
    align-items: flex-start;
}
.table {
    width: 100%;
}
.text-start {
    background-color: #affaf9;
}
.text-start:hover {
    background-color: #d4feff !important;
}
.v-data-table, th, .v-select__selection {
    color: blue !important;
}
tr {
    border-top: 2px solid blue;
    border-left: 3px solid aqua;
    border-right : 3px solid aqua;
}
th {
    border: 3px solid aqua;
}
.v-list v-select-list v-sheet theme--light theme--light {
    background: blue !important;
}
.v-data-table__mobile-table-row:hover {
    background-color: #affaf9 !important;
}
div.table .v-input__control {
    background: #affaf9 !important;
    padding-left: 10px;
    padding-right: 10px;
    border-radius: 20px;
}
.theme--light.v-chip:not(.v-chip--active) {
    background: aqua !important;
}
.theme--light.v-list {
    background-color: aqua;
}
.v-list-item__content {
    color: blue;
}
.v-chip__content {
    color: blue;
}
.search-field {
    margin: 5px;
    padding: 0px 20px 8px 20px;
    border-bottom: 2px solid blue;
}
.main {
    background-color: aqua;
}
</style>
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
                        <v-dialog v-model="dialogDelete">
                            <v-card class="deleteCard">
                                <v-card-title class="text-h5 deleteConfirmation">Are you sure you want to delete this book?</v-card-title>
                                    <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="black" text @click="closeDelete">BACK</v-btn>
                                    <v-btn color="red" text @click="deleteItemConfirm">YES, I AM SURE</v-btn>
                                <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>                       
                    </template>
                    <template v-slot:[`item.actions`]="{ item }"> 
                        <v-icon
                            small
                            class="mr-2"
                            style="color: orange;"
                            @click="console.log(item)"
                        >
                            mdi-pencil
                        </v-icon>
                        <v-icon
                            small
                            style="color: red;"
                            @click="deleteItem(item)"
                        >
                            mdi-delete
                        </v-icon>
                    </template>
                    <template v-slot:no-data>
                        <v-btn
                            color="primary"
                            @click="console.log('e')"
                        >
                            ADD YOUR FIRST BOOK
                        </v-btn>
                    </template>
                </v-data-table>
            </div>
        </div>
    </v-main>
</template>

<script>
import {getFullName, getUserBooks, deleteBook} from "@/services/service.js"
export default {
    name: 'UserPage',
    data() {
        return {
            name: '',
            surname: '',
            id: 1,
            search: '',
            dialogDelete: false,
            bookIdToBeDeleted: -1,
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
                { text: 'Actions', value: 'actions', sortable: false },
            ],
            books: [
                {
                    dbId: 1,
                    title: 'Frozen Yogurt',
                    author: 159,
                    language: 6.0,
                    pubYear: 24,
                    pages: 4.0,
                    genre: 1,
                    finishingDate: 159,
                    price: 6.0,
                    rating: 24,
                    notes: 4.0,
            },
            ]
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
        },
        deleteItem(item) {
            this.bookIdToBeDeleted = item.DbId
            this.dialogDelete = true
        },
        closeDelete() {
            this.dialogDelete = false;
        },
        deleteItemConfirm() {
            console.log('45')
            deleteBook(this.username, this.bookIdToBeDeleted)
            .then(() => {
                console.log('46')
                this.getUserBooks();
            })
            .catch((error) => {
                console.log('47')
                console.log(error.message)
            });

            this.bookIdToBeDeleted = -1
            this.dialogDelete = false
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
.deleteConfirmation {
    color: red;
}
.v-card__title {
    justify-content: center;
}
.deleteCard {
    background: radial-gradient(circle, rgba(240,211,211,1) 24%, rgba(255,255,255,1) 54%, rgba(244,222,222,1) 60%, rgba(171,0,0,1) 100%);
}
</style>
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
                    :items-per-page="5"
                    class="elevation-1"
                ></v-data-table>
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
                { text: 'FINISHED IN DATE', value: 'FinishingDate' },
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
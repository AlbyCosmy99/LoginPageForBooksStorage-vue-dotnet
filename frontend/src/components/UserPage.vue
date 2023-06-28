<template>
    <v-main class="main" id="main">
        <header class="header">
            <h2 class="welcome">Welcome {{name}} {{ surname }}</h2>
        </header>
        <div class="flex-container">
            <div class="table">
                <v-text-field
                    v-model="search"
                    append-icon="mdi-magnify"
                    label="Search"
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
                        <v-dialog
                            v-model="dialog"
                            max-width="500px"
                        >
                            <template v-slot:activator="{ on, attrs }">
                            <v-btn
                                color="primary"
                                dark
                                class="mb-2 addBookBtn"
                                v-bind="attrs"
                                v-on="on"
                                @click="newBookClicked"
                                style=" background-color: aqua !important; color: blue; "
                            >
                                Add a new book
                            </v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    <span class="text-h5">{{ formTitle }}</span>
                                </v-card-title>

                                <v-card-text>
                                    <v-container>
                                        <v-row>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Title"
                                                    label="Title"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Author"
                                                    label="Author"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Language"
                                                    label="Language"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.PublicationYear"
                                                    label="Publication Year"
                                                    type="number"
                                                    default="2023"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Pages"
                                                    type="number"
                                                    label="Pages"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Genre"
                                                    label="Genre"
                                                ></v-text-field>
                                            </v-col>

                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.FinishingDate"
                                                    label="finishing Date"
                                                ></v-text-field>
                                            </v-col>

                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Price"
                                                    label="Price"
                                                ></v-text-field>
                                            </v-col>


                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-select
                                                    style="padding-right: 4px;"
                                                    label="Personal Rating"
                                                    :items="ratings"
                                                    v-model="editedItem.PersonalRating"
                                                ></v-select>
                                            </v-col>
                                            <v-col
                                            cols="12"
                                            sm="6"
                                            md="4"
                                            >
                                                <v-text-field
                                                    v-model="editedItem.Notes"
                                                    label="Notes"
                                                ></v-text-field>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-card-text>

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
                            @click="editItem(item)"
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
import {getFullName, getUserBooks, deleteBook, updateBook} from "@/services/service.js"
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
            dialog: false,
            editedItem:  {
                    DbId: -1,
                    Title: '',
                    Author: '',
                    Language: '',
                    PublicationYear: '',
                    Pages: '',
                    Genre: '',
                    FinishingDate:  new Date().toUTCString().split(' ')[1] + '/' +  this.getMonthNumber(new Date().toUTCString().split(' ')[2]) + '/' +  new Date().toUTCString().split(' ')[3],
                    Price: '',
                    PersonalRating: '',
                    Notes: '',
            },
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
                { text: 'PERSONAL RATING', value: 'PersonalRating' },
                { text: 'NOTES', value: 'Notes', sortable: false},
                { text: 'Actions', value: 'actions', sortable: false },
            ],
            books: [],
            ratings: ['-','1/10','2/10','3/10','4/10','5/10','6/10','7/10','8/10','9/10','10/10']
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
            deleteBook(this.username, this.bookIdToBeDeleted)
            .then(() => {
                this.getUserBooks();
            })
            .catch((error) => {
                console.log(error.message)
            });

            this.bookIdToBeDeleted = -1
            this.dialogDelete = false
        },
        editItem(item) {
            this.editedItem = item
            this.dialog = true
        },
        close() {
            this.dialog = false,
            this.setDefaultEditedItem()
        },
        save() {
            if(this.editedItem.DbId == -1) {
                console.log('add book')
            }
            else {
                updateBook(this.username, this.editedItem.DbId, this.editedItem.Title, this.editedItem.Author, this.editedItem.Language,
                    this.editedItem.PubYear, this.editedItem.Pages, this.editedItem.Genre, this.editedItem.FinishingDate, this.editedItem.Price,
                    this.editedItem.PersonalRating, this.editedItem.Notes)
                    .then(() => {
                        console.log('book updated correctly.')
                    })
                    .catch(error => {
                        console.log(error.message)
                    })
            }
            this.getUserBooks()
            this.close()
        },
        setDefaultEditedItem() {
            this.editedItem =  {
                    DbId: -1,
                    Title: '',
                    Author: '',
                    Language: '',
                    PubYear: '',
                    Pages: '',
                    Genre: '',
                    FinishingDate:  new Date().toUTCString().split(' ')[1] + '/' +  this.getMonthNumber(new Date().toUTCString().split(' ')[2]) + '/' +  new Date().toUTCString().split(' ')[3],
                    Price: '',
                    PersonalRating: '',
                    Notes: '',
            }
        },
        getMonthNumber(month) {
            switch(month) {
                case 'Jan': return 1 
                case 'Feb': return 2
                case 'Mar': return 3 
                case 'Apr': return 4
                case 'May': return 5 
                case 'Jun': return 6
                case 'Jul': return 7 
                case 'Aug': return 8
                case 'Sep': return 9 
                case 'Oct': return 10
                case 'Nov': return 11
                case 'Dec': return 12
            }
        },
        newBookClicked() {
            this.setDefaultEditedItem()
        }
    },
    computed: {
        formTitle() {
            return this.editedItem.DbId === -1 ? 'Add new book' : 'Edit book'
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
.deleteCard .v-card__title {
    font-size: 15px !important;
}
.theme--light.v-sheet {
    background-color: #bafff1 !important;
}
.v-application .blue--text.text--darken-1 {
    color: black !important;
}
.addBookBtn {
    width: 100%; 
    padding: 10px;
}
</style>
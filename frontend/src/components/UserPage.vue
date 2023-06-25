<template>
    <v-main class="main">
        <header class="header">
            <h2 class="welcome">Welcome {{name}} {{ surname }}</h2>
        </header>
        <div class="flex-container">
            <div class="table">
                <v-data-table
                    style="background-color: #affaf9;"
                    :headers="headers"
                    :items="books"
                    :items-per-page="5"
                    class="elevation-1"
                ></v-data-table>
            </div>
        </div>
    </v-main>
</template>

<script>
export default {
    name: 'UserPage',
    data() {
        return {
            headers: [
            { text: 'TITLE', value: 'title' },
            { text: 'AUTHOR', value: 'author' },
            { text: 'LANGUAGE', value: 'language' },
            { text: 'PUBBLICATION YEAR', value: 'pubYear' },
            { text: 'PAGES', value: 'pages' },
            { text: 'GENRE', value: 'genre' },
            { text: 'FINISHED IN DATE', value: 'finishingDate' },
            { text: 'PRICE', value: 'price' },
            { text: 'PERSONAL RATING', value: 'rating' },
            { text: 'NOTES', value: 'notes', sortable: false},
        ],
        books: [
            {
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
          {
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
          {
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
        name : String,
        surname : String
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
v-data-table .v-input__control {
    background: #affaf9 !important;
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
</style>
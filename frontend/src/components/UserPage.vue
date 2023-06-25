<template>
    <v-main class="main">
        {{ message }}
    </v-main>
</template>

<script>
export default {
    name: 'UserPage',
    data() {
        return {
            message: 'tutto okok'
        }
    },
    
}
</script>

<style>
.main {
    text-align: center;
    margin: 10px;
    height: 400px;
    background-color: aquamarine;
}
</style>
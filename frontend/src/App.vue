<template>
  <v-app>
    <v-main class="description">
      <v-btn v-if="showButton" @click="toggleLogin" style="margin-left: 600px;margin-top: 30px;">USER LOGGED?</v-btn>
      <div v-if="!userLogged">
        <LoginPage @login="login"/>
      </div>
      <div v-else>
        <UserPage :username="username"/>
      </div>    
    </v-main>
  </v-app>
</template>

<script>
import LoginPage from './components/LoginPage';
import UserPage from './components/UserPage.vue';

export default {
  name: 'App',

  components: {
    LoginPage,
    UserPage
  },

  data: () => ({
    userLogged: false,
    showButton: false,
    username: '',
  }),
  emits : ['login'],
  methods: {
    toggleLogin() {
      this.userLogged = !this.userLogged
    },
    login(username) {
      this.username = username
      if(!this.userLogged) {
        this.userLogged = true
      }
    }
  }
};
</script>

<style>
.description {
  background-image: url('../src/assets/back-to-school-background-with-silhouette-of-books-feathers-school-tool-doodle-and-copy-space-area-suitable-to-place-on-content-with-that-theme-free-vector.jpg');
  background-size: 100% 100%;
}
</style>
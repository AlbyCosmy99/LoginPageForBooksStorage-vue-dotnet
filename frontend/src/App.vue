<template>
  <v-app>
    <v-main>
      <v-btn v-if="showButton" @click="toggleLogin" style="margin-left: 600px;margin-top: 30px;">USER LOGGED?</v-btn>
      <div v-if="!userLogged">
        <LoginPage @login="login(username)"/>
      </div>
      <div v-else>
        <UserPage :name="name" :surname="surname"/>
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
    name: 'ANDREI',
    surname: 'ALBU',
    icons: [
        'mdi-facebook',
        'mdi-twitter',
        'mdi-linkedin',
        'mdi-instagram',
      ],
  }),
  emits : ['login'],
  methods: {
    toggleLogin() {
      this.userLogged = !this.userLogged
    },
    login(username) {
      this.username = username
      this.name = 'name prova'
      this.surname = 'surname prova'
      console.log('emit called')
      if(!this.userLogged) {
        this.userLogged = true
      }

    }
  }
};
</script>

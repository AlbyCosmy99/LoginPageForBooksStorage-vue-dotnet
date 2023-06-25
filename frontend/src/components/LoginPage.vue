<template>
  <v-container class="card">
    <v-form fast-fail @submit.prevent class="form">
      <v-text-field
        v-model="username"
        label="username"
        class="text-field"
      ></v-text-field>

      <v-text-field
        v-model="password"
        type="password"
        label="password"
        class="text-field"
        ></v-text-field>

      <v-btn type="submit" block class="btn" @click="login">Login</v-btn>
    </v-form>
    <div class="flex1">
      <h6 class="cursor-pointer"><u>Forgot password?</u></h6>
      <h5 class="cursor-pointer">Register</h5>
    </div>
  </v-container>
</template>

<script>
  // import {loginAttempt} from "@/services/service.js"
  import axios from 'axios'
  export default {
    name: 'LoginPage',

    data: () => ({
      username: '',
      password: '',
    }),
    methods: {
      login() {
        // loginAttempt(this.username, this.password)
        // .then(() => {
        //   console.log('login ok')
        // })
        // .catch(() => {
        //   console.log('login not ok')
        // });
        axios.get("https://localhost:44350")
        .then(() => {
          console.log('users ok')
        })
      }
    }
  }
</script>

<style scoped>
.card {
  width: 300px;
  height: 250px;
  margin: 200px auto;
  border-radius: 20px;
  background-color: aqua;
  border: 2px solid blue; 
  box-shadow: 4px 10px 6px 3px rgba(36,114,255,0.62);
}
.form {
  margin: 10px;
}
.btn {
  margin-top: 5px;
  background-color: blue !important; 
  color: aqua !important;
  border-radius: 20px;
}
.text-field {
  opacity: 0.8;
}
.text-field:hover {
  opacity: 1;
}
.flex1 {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}
.cursor-pointer {
  cursor: pointer;
}
</style>

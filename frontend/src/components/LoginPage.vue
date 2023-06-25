<template>
  <v-container class="card">
    <v-form fast-fail @submit.prevent class="form">
      <v-text-field
        style="padding-top: 30px;"
        v-model="username"
        label="username"
        class="text-field"
        @click="disableNoCredentialsNoty"
      ></v-text-field>

      <v-text-field
        v-model="password"
        type="password"
        label="password"
        class="text-field"
        @click="disableNoCredentialsNoty"
        ></v-text-field>
        <div style="height: 10px;;margin-bottom: 10px;">
          <h6 v-if="notGivenCredentials" style="color: red;text-align: center;">Username and password must be both given!</h6>
        </div>

      <v-btn type="submit" block class="btn" @click="login">Login</v-btn>
    </v-form>
    <div class="flex1">
      <h6 class="cursor-pointer"><u>Forgot password?</u></h6>
      <h5 class="cursor-pointer">Register</h5>
    </div>
  </v-container>
</template>

<script>
  import {loginAttempt} from "@/services/service.js"
  export default {
    name: 'LoginPage',

    data: () => ({
      username: '',
      password: '',
      notGivenCredentials: false
    }),
    methods: {
      login() {
        if(this.username.trim() == '' || this.password.trim() == ''){
          this.notGivenCredentials = true
        }
        else {
          loginAttempt(this.username, this.password)
          .then(() => {
            console.log('login ok') //event->login
            this.$emit('login')
          })
          .catch((error) => {
            alert(error.message)  //alert -> credentials are not correct
          });
        }  
      },
      disableNoCredentialsNoty() {
        if(this.notGivenCredentials) {
          this.notGivenCredentials = false
        }
      }
    },
  }
</script>

<style scoped>
.card {
  width: 300px;
  height: 280px;
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
.v-text-field fieldset, .v-text-field .v-input__control, .v-text-field .v-input__slot  {
  background: aqua !important;
  border-radius: 20px !important;
  padding-left: 20px !important;
}

</style>

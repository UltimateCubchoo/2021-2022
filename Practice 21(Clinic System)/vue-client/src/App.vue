<script setup lang="js">
import {defineComponent} from 'vue'
import Header from './components/Header.vue'
import Home from './views/Home.vue'
import Patient_View from './views/Patients.vue'
import Doctor_View from './views/Doctors.vue'
import Appointment_View from './views/Appointments.vue'
import User_View from './views/Users.vue'
import axios from 'axios'

const routes = {
  '/': Home,
  '/patients': Patient_View,
  '/doctors': Doctor_View, 
  '/appointments': Appointment_View,
  '/users': User_View,
}

export default defineComponent({
  components: {
    Header: Header
  },
  data(){
    return{
      isLoggedIn: false,
      isAdmin: false,
    }
  },
  methods:{
    login: async function(){
      var user = window.$("#user").val();
      var pass = window.$("#pass").val();
      console.log(`User: ${user}, pass: ${pass}, isLoggedIn: ${this.isLoggedIn}`);

      var res = await axios.get("http://localhost:3030/users");
      var data = JSON.parse(res.data);
      for(var i in data){
        // console.log(data[i].user);
        if(data[i].user == user && data[i].pass == pass){
          console.log("Match");
          console.log(data[i]);
          localStorage.setItem("loginStatus", JSON.stringify({isLoggedIn: true, isAdmin: data[i].perms}));
          return window.location.reload();
        }
      }
      window.alert("Enter valid credentials...");
      return window.location.reload();
    },
    logout(){
      localStorage.removeItem("loginStatus");
      window.location.reload();
    }
  },
  computed:{
    currentView(){
      var href = window.location.pathname;
      console.log(href);
      return routes[href];
    }
  },
  mounted(){
    var status = JSON.parse(localStorage.getItem("loginStatus"))
    if(status == null){
      this.isLoggedIn = false;
      this.isAdmin = false;
      return;
    }
    this.isLoggedIn = status.isLoggedIn;
    this.isAdmin = status.isAdmin;
  }
});
</script>

<template>
  <div>
    <Header :isLoggedIn="isLoggedIn" :isAdmin="isAdmin"></Header>
    <component :is="currentView" :isLoggedIn="isLoggedIn" :isAdmin="isAdmin" @login="login()" @logout="logout()"></component>
  </div>
</template>

<style>
body, td{
  background-color: #0a0a0a;
}
input, h1, p, label, select, td, th{
  background-color: #0a0a0a;
  color: whitesmoke !important;
}


#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
main{
  margin-top: 1rem;
}
</style>

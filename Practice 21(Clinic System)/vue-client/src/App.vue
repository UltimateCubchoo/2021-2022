<script setup lang="js">
import {defineComponent} from 'vue'
import Header from './components/Header.vue'
import Home from './views/Home.vue'
import Patient_View from './views/Patients.vue'
import Doctor_View from './views/Doctors.vue'
import Appointment_View from './views/Appointments.vue'

const routes = {
  '/': Home,
  '/patients': Patient_View,
  '/doctors': Doctor_View, 
  '/appointments': Appointment_View,
}

export default defineComponent({
  components: {
    Header: Header
  },
  computed:{
    currentView(){
      var href = window.location.pathname;
      console.log(href);
      return routes[href];
    }
  }
});
</script>

<template>
  <div>
    <Header></Header>
    <component :is="currentView"></component>
  </div>
</template>

<style>
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

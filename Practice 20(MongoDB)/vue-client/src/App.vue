<script lang="ts">
// This starter template is using Vue 3 <script setup> SFCs
// Check out https://vuejs.org/api/sfc-script-setup.html#script-setup
import { defineComponent } from "vue"
import Header from "./components/Header.vue"
import Home from "./views/Home.vue"
import Client_View from "./views/Client_View.vue"
import Instructor_View from "./views/Instructor_View.vue"
import Inscription_View from "./views/Inscription_View.vue"
import Group_View from "./views/Group_View.vue"

const routes = {
  "/": Home,
  "/client_view": Client_View,
  "/instructor_view": Instructor_View,
  "/inscription_view": Inscription_View,
  "/group_view": Group_View
};

export default defineComponent({
  components:{
    Header: Header
  },
  computed:{
    currentView(){
      var href: string = window.location.pathname;
      console.log(href);
      return routes[href];
    }
  }
});
</script>

<template>
<div>
  <Header></Header>
  <component :is="currentView" />
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
</style>

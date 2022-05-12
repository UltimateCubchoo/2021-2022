<script lang="ts">
import {defineComponent} from "vue"
import Navigation from "./components/Nav.vue"
import Masthead from "./views/Masthead.vue"
import About from "./views/About.vue"
import Projects from "./views/Projects.vue"
import Signup from "./views/Signup.vue"
import Contact from "./views/Contact.vue"
import Footer from "./components/Footer.vue"
export default defineComponent({
    components:{
      Navigation: Navigation,
      Masthead: Masthead,
      About: About,
      Contact: Contact, 
      Projects: Projects,
      Signup: Signup,
      Footer: Footer
    }
});
</script>

<template>
  <Navigation></Navigation>
  <Masthead></Masthead>
  <About></About>
  <Projects></Projects>
  <Signup></Signup>
  <Contact></Contact>
  <Footer></Footer>    
</template>

<style>
/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>

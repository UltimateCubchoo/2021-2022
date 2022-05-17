<script lang="ts">
import {defineComponent} from "vue"
import Navigation from "./components/Nav.vue"
import Masthead from "./views/Masthead.vue"
import About from "./views/About.vue"
import Projects from "./views/Projects.vue"
import Doggo from "./views/Doggo.vue"
import Contact from "./views/Contact.vue"
import Footer from "./components/Footer.vue"
export default defineComponent({
    components:{
      Navigation: Navigation,
      Masthead: Masthead,
      About: About,
      Contact: Contact, 
      Projects: Projects,
      Doggo: Doggo,
      Footer: Footer
    }
});
</script>

<template>
<main>
  <Navigation></Navigation>
  <Masthead></Masthead>
  <About></About>
  <Projects></Projects>
  <Doggo></Doggo>
  <Contact></Contact>
  <Footer></Footer>    
</main>
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

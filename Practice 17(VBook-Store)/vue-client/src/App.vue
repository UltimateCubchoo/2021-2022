<template>
  <div>
    <Header></Header> <br />
    <component :is="currentView" />
  </div>
</template>

<script>
import Header from "./components/Nav.vue"
import Home from "./views/Home.vue"
import Book_Add from "./views/Book_Add.vue"
import Book_View from "./views/Book_View.vue"
import Rent_Add from "./views/Rent_Add.vue"
import Rent_View from "./views/Rent_View.vue"
import Customer_Add from "./views/Customer_Add.vue"
import Customer_View from "./views/Customer_View.vue"
const routes = {
    "/": Home,
    "/book_add": Book_Add,
    "/book_view": Book_View,
    "/customer_add": Customer_Add,
    "/customer_view": Customer_View,
    "/rent_add": Rent_Add,
    "/rent_view": Rent_View

}

export default {
  name: 'App',
  components: {
      Header: Header,
      Home: Home
  },
  computed: {
    currentView(){
      var href = window.location.pathname;
      console.log(href);
      return routes[href];
    }
  }
  
}
</script>

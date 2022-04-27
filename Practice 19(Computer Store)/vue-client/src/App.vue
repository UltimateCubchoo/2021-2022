<script setup lang="js">
import { defineComponent } from "vue"
import Header from "./components/Header.vue"
import Home from "./views/Home.vue"
import Category_View from "./views/Category_View.vue"
import Customer_View from "./views/Customer_View.vue"
import Employee_View from "./views/Employee_View.vue"
import Order_View from "./views/Order_View.vue"
import Product_View from './views/Product_View.vue'
import Shipper_View from './views/Shipper_View.vue'
import Supplier_View from './views/Supplier_View.vue'


const routes = {
  '/': Home,
  '/category_view': Category_View,
  '/customer_view': Customer_View,
  '/employee_view': Employee_View,
  '/order_view': Order_View,
  '/product_view': Product_View,
  '/shipper_view': Shipper_View,
  '/supplier_view': Supplier_View
}

export default defineComponent({
  components:{
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
  <component :is="currentView" />
</div>
</template>

<style>
body, input, select, label, textarea, #dataTable_info{
  background-color: #111111;
  color: azure;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
}
tbody > tr, tbody > tr > td{
  background-color: dimgray ;
}

.grid{
  grid: auto auto;
}
</style>

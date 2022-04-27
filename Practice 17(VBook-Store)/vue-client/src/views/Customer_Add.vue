<template>
    <div>
        <h1>{{title}}</h1>
        <div class="grid-container">
            <div>First Name:
                <input type="text" v-model="form.fname">
            </div>

            <div>Last Name:
                <input type="text" v-model="form.lname">
            </div>

            <div>Address:
                <input type="text" v-model="form.address">
            </div>

            <div>Phone Number:
                <input type="text" name="" id="" v-model="form.phone">
            </div>
        </div><br/>
        <button class="btn btn-light" @click="submit()">Submit</button>
    </div>
    
</template>
<script>
import axios from "axios"
export default {
  name: "CustomerAdd",
  data() {
    return {
      title: "Add a customer",
      form:{
          fname: "",
          lname: "",
          address: "",
          phone: ""
      }
    };
  },
  methods:{
      submit: async function(){
          try{
              var obj = this.form;
              var json = JSON.stringify(obj);
              for(const [key, val] of Object.entries(obj)){
                  if(val == '')
                    return window.alert("All fields must be filled");
              }
              await axios.post("http://localhost:3030/insCustomer", json);
              return window.alert("Item submission successful");
          }
          catch(err){
              if(err) console.log(err);
              return window.alert("Submission Failed");
          }
      }
  }
};
</script>
<style scoped>
.grid-container {
  margin: auto;
  width: 20%;
  display: grid;
  grid-template-columns: auto auto;
}
.grid-container > div{
    margin: 1rem;
}
input{
    width: 100%;
}
button{
    margin-left: 48%;
}
</style>
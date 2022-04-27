<template>
    <div>
        <h1>{{title}}</h1>
        <div class="grid-container">
            <div>Indate:
                <input type="date" v-model="form.indate">
            </div>

            <div>Outdate:
                <input type="date" v-model="form.outdate">
            </div>
        </div><br/>
        <button class="btn btn-light" @click="submit()">Submit</button>
    </div>
    
</template>
<script>
import axios from "axios"

export default {
  name: "RentAdd",
  data() {
    return {
      title: "Rent a book",
      form:{
        indate: "",
        outdate: ""
      }
    };
  },
  methods:{
      submit: async function(){
        try {
          var obj = this.form;
          var json = JSON.stringify(obj);
          for(const [key, val] of Object.entries(obj)){
              if(val == '')
                return window.alert("All fields must be filled");
          }
          console.log(json);
          await axios.post("http://localhost:3030/insRent", json);
          alert("Item submission was sucessful"); 
        } 
        catch (err) {
          if(err) console.log(err);
          return alert("Item submission failed");
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
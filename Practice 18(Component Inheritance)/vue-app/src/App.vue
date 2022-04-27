<script lang="js">
import { defineComponent } from "vue"
import Image from "./components/image.vue"
import Text from "./components/text.vue"


export default defineComponent({
  components:{
    Image: Image,
    Text: Text
  },
  data(){
    return {
      file: "",
      tflag: false,
      iflag: false
    }
  },
  methods:{
    changeFile(event){
      console.log("changeFile()");
      var input = event.target;
      if(input.files && input.files[0]){
        var reader = new FileReader();
        reader.onload = (event) => {
          var data = event.target.result;
          this.file = data;
        }
        reader.readAsDataURL(input.files[0]);
      }
    },

    loadText(){
      this.type = "Text";
    },
    loadImage(){
      this.type = "Image"
    }
  }
})
</script>


<template>
<div>
  <img alt="Vue logo" src="./assets/logo.png" /><br>
  <button @click="loadText">Load Text File</button>
  <button @click="loadImage">Load Image File</button><br>
  <input type="file" @change="changeFile"><br>
  <div style="border-radius: 2px black solid">
    <Text v-if="tflag"></Text>
    <Image v-if="iflag"></Image>
  </div>
</div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
button{
  margin: 1rem;
  padding: 3rem;
  color: whitesmoke;
  background-color: rgb(61, 167, 167);
  border-radius: 10px;
}
</style>


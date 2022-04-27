<template>
  <div class="container-fluid card-container">
    <div class="row">
      <div id="bg" class="col">
        <a href="/book_view" style="color: whitesmoke"
          ><h1 style="text-align: center; margin-top: 10%; cursor: pointer">
            Get Started
          </h1></a
        >
      </div>
    </div>
    <br />
    <hr />
    <h1>Best Sellers</h1>
    <hr />
    <br />


        <div class="container-fluid card-footer">
                        <h3>{{obj.title}}</h3>
                        <p>Author: {{obj.author}}</p>
                        <p>Genre: {{obj.genre}}</p>
                        <span v-html="obj.stars"></span>
                        <!-- <p><a href="#" style="cursor: pointer;" onclick="updShow(${obj.book_id})">Edit</a>&nbsp;&nbsp;<a href="#" style="cursor: pointer;" onclick="delShow(${obj.book_id})">Remove</a></p><br> -->
                    </div>
          </div>
    </div>
    <br />
    <hr />
    <div class="row">
      <div class="col"></div>
    </div>
    <hr />
    <br />
    <div class="row justify-content-center" v-if="flag" id="card-row-soon">
        <br><br><h1>Coming Soon</h1>
        <hr />

        <div class="col-2" v-for="(obj, index) in cCards" :key="index">
          <div class="container-fluid card-body" :style="{ 'background-image': `url('http://localhost:3030/images/${obj.image}')`}">
        </div>
        <div class="container-fluid card-footer">
                        <h3>{{obj.title}}</h3>
                        <p>Author: {{obj.author}}</p>
                        <p>Genre: {{obj.genre}}</p>
                        <span v-html="obj.stars"></span>
                    </div>
          </div>
    </div>
    <br><br>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Home",
  data() {
    return {
      bestCards: "",
      comingCards: "",
      flag: false
    };
  },
  computed:{
    bCards: function(){
      var data = JSON.parse(this.bestCards);
      for(var i in data)
        data[i]["stars"] = this.drawRating(data[i].rating);
      return data;
    },
    cCards: function(){
      var data = JSON.parse(this.comingCards);
      for(var i in data)
        data[i]["stars"] = this.drawRating(data[i].rating);
      return data;
    },

  },
  methods:{
    drawRating: function drawRating(rating){
        var rt = "<span>";
        for(var i = 0; i < 5; i++){
          if(rating > 1){
              rt += `<span class="fa fa-star"></span>`;
              rating -= 2;
          }
          else if(rating == 1){
              rt += `<span class="fa fa-star-half-o"></span>`;
              rating -= 1;
          }
          else
              rt += `<span class="fa fa-star-o"></span>`;
      }
        rt += "</span>"
        return rt;
    }
  },
  mounted: async function () {
    console.log("Mounted");
    this.bestCards = await getBestCards();
    this.comingCards = await getComingCards();
    this.flag = true;
  },
};

async function getBestCards(){
    try {
      var req = await axios.get("http://localhost:3030/bookBest");
      var data = req.data;
      return data;
    }
    catch (err) {
      console.log(err);
      return "";
    }
}

async function getComingCards(){
    try {
      var req = await axios.get("http://localhost:3030/bookComing");
      var data = req.data;
      return data;
    }
    catch (err) {
      console.log(err);
      return "";
    }
}




</script>
<style scoped>
#bg {
  background-image: url("/images/lib-bg.png");
  background-size: cover;
  width: 100%;
  height: 20vw;
}
#card-container > div > div{/*Columns*/
  margin: 1vw;
  padding: 0;
  width: 20vw;
  height: max-content;
  border-radius: 10px;
  background-color: rgb(0,0,24);
  color: whitesmoke;
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}

#card-row-best > div, #card-row-soon > div{
  margin-left: auto;
  margin-right: auto;
}

#card-row-soon{
  background-color: rgb(25,25,100);
  border-radius: 1vw;
}

.card-body, .card-preview{
  padding: 0;
  color: aliceblue;
  width: 100%;
  height: 20vw;
  background-size: cover;
}

.card-footer{
  font-size: small;
  text-align: center;

}

</style>


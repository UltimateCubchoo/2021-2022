<template>
  <div class="container-fluid card-container">
    <div class="row">
      <div class="col-2">
        <h3>Our Books</h3>
        <ul id="genreList" v-if="flag">
          <li v-for="(genre, index) in genreList" :key="index">
            <a href="#">{{ genre }}</a>
          </li>
        </ul>
        <br /><br />
        <h3>Authors</h3>
        <ul id="authorList" v-if="flag">
          <li  v-for="(author, index) in authorList" :key="index">
            <a href="#">{{ author["AUTHOR"] }}</a>
          </li>
        </ul>
      </div>

      <!---Main Image Loading Div--->
      <div class="col">
        <div class="container-fluid">
          <div class="row justify-content-center" v-if="flag">
            <div class="col-2" v-for="(obj, index) in cards" :key="index">
              <div
                class="container-fluid card-body"
                :style="{
                  'background-image': `url('http://localhost:3030/images/${obj.image}')`,
                }"
              ></div>
              <div class="container-fluid card-footer">
                <h3>{{ obj.title }}</h3>
                <p>Author: {{ obj.author }}</p>
                <p>Genre: {{ obj.genre }}</p>
                <span v-html="obj.stars" ></span>
                <p :style="{ 'margin-top': '1rem'}" >
                  <a href="#" id="updLink" @click="updShow(obj.book_id)">Edit</a>&nbsp;&nbsp;
                  <a href="#" id="delLink" @click="del(obj.book_id)">Remove</a>
                </p><br>
              </div>
            </div>
          </div>
        </div>
      </div>

       <div class="row">
            <div class="col">
                <UpdModal id="updModal" :show="this.show" @close="this.toggleVis()" @save="this.save()">
                    <template v-slot:header><h1>Update Entry {{currentID}}</h1></template>
                    <template v-slot:body>
                        <div class="container insCon">
                          <div class="row">
                            <div class="col">Title</div>
                            <div class="col"><input type="text" v-model="updForm.title" /></div>
                          </div>
                          <div class="row">
                            <div class="col">Author</div>
                            <div class="col"><input type="text" v-model="updForm.author" /></div>
                          </div>
                          <div class="row">
                            <div class="col">Genre</div>

                            <div class="col">
                              <select name="genre" v-model="updForm.genre">
                                <option value="fantasy">Fantasy</option>
                                <option value="sci-fi">Sci-Fi</option>
                                <option value="mystery">Mystery</option>
                                <option value="thriller/horror">Thriller/Horror</option>
                                <option value="romance">Romance</option>
                              </select>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col">
                              <p>Rating</p>
                            </div>
                            <div class="col">
                              <input type="number" v-model="updForm.rating" min="0" max="10" v-html="stars" />
                            </div>
                          </div>
                          <div class="row">
                            <div class="col">
                              <div :style="{ border: '2px white solid' }">
                                <img class="preview" :src="updForm.image.src" alt="Image Preview" height="100" />
                              </div>
                              <br />
                              <input
                                type="file"
                                name="image"
                                @change="displayImg"
                                accept="image/*"
                              /><br /><br />
                            </div>
                          </div>
                        </div>
                    </template>
                </UpdModal>
            </div>
        </div>
    </div>


</template>


<script>
import axios from "axios";
import UpdModal from "../components/UpdModal.vue";

export default {
  components: {
    UpdModal: UpdModal
  },
  data() {
    return {
      strCards: "",
      genreTick: 0,
      genreList: [
        "fantasty",
        "sci-fi",
        "mystery",
        "thriller/horror",
        "romance",
      ],
      authorList: [],
      flag: false,
      updForm: {
        title: "",
        author: "",
        genre: "",
        image: {},
      },
      show: false,
      currentID: null,
    };
  },
  computed: {
    cards: function () {
      var data = JSON.parse(this.strCards);
      for (var i in data) data[i]["stars"] = this.drawRating(data[i].rating);
      return data;
    },
  },
  methods: {
    drawRating: function drawRating(rating) {
      var rt = "<span>";
      for (var i = 0; i < 5; i++) {
        if (rating > 1) {
          rt += `<span class="fa fa-star"></span>`;
          rating -= 2;
        } else if (rating == 1) {
          rt += `<span class="fa fa-star-half-o"></span>`;
          rating -= 1;
        } else rt += `<span class="fa fa-star-o"></span>`;
      }
      rt += "</span>";
      return rt;
    },
    del: async function (index) {
      await axios.post("http://localhost:3030/delBook", index);
      window.location.reload();
    },

    //Update Modal Actions
    updShow: function (index) {
      console.log(index);
      this.currentID = index;
      console.log(this.currentID);
      this.toggleVis();
    },
    toggleVis() {
      if (this.show == true) this.show = false;
      else this.show = true;
    },
    save: async function () {
      try {
        var form = this.updForm;
        form["book_id"] = this.currentID;
        form["image"] = this.updForm["image"].src;
        var formData = new FormData();
        for (const key in form) {
          formData.append(key, form[key]);
        }
        console.log(formData.get("author"));
        var req = await axios.post("http://localhost:3030/updBook", formData, {
          headers: { "Content-Type": "multipart/form-data" },
        });

        window.alert("Item was sucessfully changed");
        return window.location.reload();
      } catch (err) {
        window.alert("Item change was a failure", err);
      }
    },
    //Functions when the file is changed in UpdModal
    displayImg(event) {
      var input = event.target;
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = (e) => {
          var imageData = e.target.result; //Please implement verification to see if the file is actually an image
          this.saveImgObj(imageData);
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    saveImgObj: async function (imageData) {
      var imageObj = new Image();
      imageObj.src = imageData;
      console.log(imageObj);
      this.updForm.image = imageObj;
    },
  },
  mounted: async function () {
    this.strCards = await getCards();
    this.authorList = await getAuthors();
    this.flag = true;
  },
};

async function getCards() {
  try {
    var req = await axios.get("http://localhost:3030/bookAll");
    var data = req.data;
    console.log(data);
    return data;
  } catch (err) {
    console.log(err);
    return "";
  }
}

async function getAuthors() {
  try {
    var req = await axios.get("http://localhost:3030/author");
    var data = JSON.parse(req.data);
    return data;
  } catch (err) {
    console.log(err);
    return [];
  }
}
</script>

<style scoped>
#updLink,
#delLink {
  cursor: pointer;
}
#updLink {
  color: e0ffe0;
}
#delLink {
  color: #ffe0e0;
}
</style>
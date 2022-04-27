<template>
  <div class="container insCon">
    <h1>Add a book</h1>
    <div class="row">
      <div class="col">Title</div>
      <div class="col"><input type="text" v-model="form.title" /></div>
    </div>
    <div class="row">
      <div class="col">Author</div>
      <div class="col"><input type="text" v-model="form.author" /></div>
    </div>
    <div class="row">
      <div class="col">Genre</div>

      <div class="col">
        <select name="genre" v-model="form.genre">
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
        <input type="number" v-model="rating" min="0" max="10" v-html="stars" />
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div :style="{ border: '2px white solid' }">
          <img class="preview" :src="image.src" alt="Image Preview"/>
        </div>
        <br />
        <input
          type="file"
          name="image"
          @change="displayImg"
          accept="image/*"
        /><br /><br />
        <button class="btn btn-light" @click="submit(this)">Submit</button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Book_Add",
  data() {
    return {
      image: {},
      form: {
        title: "",
        author: "",
        genre: "",
        rating: 0,
      },
    };
  },
  methods: {
    submit: async function (event) {
      try{
        var form = this.form;
        var image = new Image();
        image = this.image;
        if (image == {}) console.log("ERROR: image is empty");
        else console.log(image);
        form["image"] = image.src;
        var formData = new FormData();
        for (const key in form) {
          formData.append(key, form[key]);
        }
        // console.log(formData.get("author"));
        var req = await axios.post("http://localhost:3030/insBook", formData, {
          headers: { "Content-Type": "multipart/form-data" },
        });
        return window.alert("Insertion was sucessful");
      }
      catch(err){
        console.log(err);
        window.alert("Insertion was a failure");
      }

    },
    //Functions when the file is changed
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
      this.image = imageObj;
    },
  },
};

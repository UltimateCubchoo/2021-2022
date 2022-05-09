<script lang="ts">
import { defineComponent } from "vue";
import axios from "axios"
import Datatable from "../components/Datatable.vue";
import Modal from "../components/Modal.vue";

export default defineComponent({
  components: {
    Datatable: Datatable,
    Modal: Modal,
  },
  data() {
    return {
      tableData:[],
      flag: false,
      showUpd: false,
      showIns: false,
      currentID: null,
      form: {
          fname: "",
          lname: "",
          phone: "",
          specialty: "",
      }
    };
  },
  methods: {
    toggleIns(){
        if(this.showIns == false)
            this.showIns = true;
        else this.showIns = false; 
    },
    submit: async function(){
        var form = this.form;
        console.log(JSON.stringify(form));
        for(var i in form)
            if(form[i] == "" || form[i] == null)
                return window.alert("All fields must be entered");
        await axios.post("http://localhost:3030/insDoctor", JSON.stringify(form));
        alert("Entry added");
        return window.location.reload();
    },
    updShow(_id){
        this.currentID = _id;
        this.toggleUpd();
    },
    toggleUpd(){
        if(this.showUpd == false)
            this.showUpd = true;
        else this.showUpd = false; 
    },
    save: async function(){
        var form = this.form;
        form["_id"] = this.currentID;
        console.log(JSON.stringify(form));
       for(var i in form)
            if(form[i] == "" || form[i] == null)
                return window.alert("All fields must be entered");
        await axios.post("http://localhost:3030/updDoctor", JSON.stringify(form));
        alert("Entry changed");
        return window.location.reload();
    },
    del: async function(index){
        await axios.post("http://localhost:3030/delDoctor", JSON.stringify({index: index}));
        return window.location.reload();
    },
  },
  mounted: async function () {
    this.tableData = await getData();
    console.log(this.tableData);
    this.flag = true;
  },
});

async function getData(){
    try {
        var res = await axios.get("http://localhost:3030/doctors");
        var data = JSON.parse(res.data);
        return data;
    } catch (err) {
        console.log(err);
        return [];
    }
}

</script>



<template>
  <main>
    <span class="fa fa-plus" id="insButton" @click="toggleIns()" />
    <h1>Doctors</h1>
    <Datatable v-if="flag">
      <template v-slot:thead>
        <tr>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Phone Number</th>
          <th>Specialty</th>
          <th>Actions</th>
        </tr>
      </template>
      <template v-slot:tbody>
          <tr v-for="(obj, index) in tableData" :key="index">
              <td>{{tableData[index].fname}}</td>
              <td>{{obj.lname}}</td>
              <td>{{obj.phone}}</td>
              <td>{{obj.specialty}}</td>
              <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj._id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj._id)"/>
            </td>
          </tr>
      </template>
    </Datatable>

    <Modal id="insModal" :show="showIns" @close="toggleIns()" @save="submit()">
      <template v-slot:header>
        <h1>New Entry</h1>
      </template>
      <template v-slot:body>
        <p>First Name:&nbsp;<input v-model="form.fname" /></p>
        <p>Last Name:&nbsp;<input v-model="form.lname" /></p>
        <p>Phone Number:&nbsp;<input v-model="form.phone" /></p> 
        <p>Specialty&nbsp;<input v-model="form.specialty" /></p>
      </template>
    </Modal>

    <Modal id="updModal" :show="showUpd" @close="toggleUpd()" @save="save()">
      <template v-slot:header>
        <h1>Update Entry {{ currentID }}</h1>
      </template>
      <template v-slot:body>
        <p>First Name:&nbsp;<input v-model="form.fname" /></p>
        <p>Last Name:&nbsp;<input v-model="form.lname" /></p>
        <p>Phone Number:&nbsp;<input v-model="form.phone" /></p> 
        <p>Specialty&nbsp;<input v-model="form.specialty" /></p>
      </template>
    </Modal>
  </main>
</template>

<style scoped>
    #insButton{
        float: right;
        color:blue;
        font-size: 3rem;
        margin-right: 2rem;
        cursor: pointer;
    }
</style>
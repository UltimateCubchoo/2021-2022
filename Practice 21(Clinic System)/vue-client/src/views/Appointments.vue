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
          status: "",
          location: "",
          doctor: "",
          patient: "",
          date: "", 
          time: ""
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
        await axios.post("http://localhost:3030/insAppointment", JSON.stringify(form));
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
        await axios.post("http://localhost:3030/updAppointment", JSON.stringify(form));
        alert("Entry changed");
        return window.location.reload();
    },
    del: async function(index){
        await axios.post("http://localhost:3030/delAppointment", JSON.stringify({index: index}));
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
        var res = await axios.get("http://localhost:3030/appointments");
        var data = JSON.parse(res.data);
        return data;
    } catch (err) {
        console.log(err);
        return [];
    }
}

async function checkTimeSlots(date, time){
}

</script>



<template>
  <main>
    <span class="fa fa-plus" id="insButton" @click="toggleIns()" />
    <h1>Appointments</h1>
    <Datatable v-if="flag">
      <template v-slot:thead>
        <tr>
            <th>Status</th>
            <th>Doctor</th>
            <th>Patient</th>
            <th>Location</th>
            <th>Date</th>
            <th>Time</th>
            <th>Actions</th>
        </tr>
      </template>
      <template v-slot:tbody>
          <tr v-for="(obj, index) in tableData" :key="index">
              <td>{{obj.status}}</td>
              <td>{{obj.doctor}}</td>
              <td>{{obj.patient}}</td>
              <td>{{obj.location}}</td>
              <td>{{obj.date}}</td>
              <td>{{obj.time}}</td>
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
        <p>Status:&nbsp;
            <select v-model="form.status">
                <option value="open">Open</option>
                <option value="closed">Closed</option>
                <option value="delayed">Delayed</option>
                <option value="missed">Missed</option>
                <option value="cancelled">Cancelled</option>
            </select>
        </p>
        <p>Doctor:&nbsp;<input v-model="form.doctor"></p>
        <p>Patient:&nbsp;<input v-model="form.patient"></p>
        <p>Location:&nbsp;<input v-model="form.location"></p>
        <p>Date:&nbsp;<input type="date" v-model="form.date"></p>
        <p>Time:&nbsp;<input type="time" v-model="form.time"></p>
      </template>
    </Modal>

    <Modal id="updModal" :show="showUpd" @close="toggleUpd()" @save="save()">
      <template v-slot:header>
        <h1>Update Entry {{ currentID }}</h1>
      </template>
      <template v-slot:body>
        <p>Status:&nbsp;
            <select v-model="form.status">
                <option value="open">Open</option>
                <option value="closed">Closed</option>
                <option value="delayed">Delayed</option>
                <option value="missed">Missed</option>
                <option value="cancelled">Cancelled</option>
            </select>
        </p>
        <p>Doctor:&nbsp;<input v-model="form.doctor"></p>
        <p>Patient:&nbsp;<input v-model="form.patient"></p>
        <p>Location:&nbsp;<input v-model="form.location"></p>
        <p>Date:&nbsp;<input type="date" v-model="form.date"></p>
        <p>Time:&nbsp;<input type="time" v-model="form.time"></p>
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
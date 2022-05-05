<script lang="ts">
import {defineComponent} from 'vue'
import axios from "axios"
import Datatable from "../components/Datatable.vue"
import Modal from "../components/Modal.vue"

export default defineComponent({
    components:{
        Datatable: Datatable,
        Modal: Modal
    },
   data(){
       return {
           tableData: Object,
           flag: false,
           currentID: null,
           form: {
               date: "",
               regi_price: null
           },
           showUpd: false,
           showIns: false
       }
   },
   methods:{
    toggleIns(){//INS Actions
        if(this.showIns == true)
            this.showIns = false;
        else this.showIns = true;
    },
    submit: async function(){
        let form = this.form;
        console.log(form);
        for(var i in form)
            if(form[i] == "" || form[i] == null)
                return window.alert("All fields must be entered");
        await axios.post("http://localhost:3030/insInscription", JSON.stringify(form));
        window.location.reload();
    },
    updShow(index){//UPD ACTIONS
        this.toggleUpd();
        this.currentID = index;
        console.log(this.currentID);
    },
    toggleUpd(){
        if(this.showUpd == true)
            this.showUpd = false;
            else this.showUpd = true;
    },
    save: async function(){
        let form = this.form;
        form._id = this.currentID;
        console.log(form);
        for(var i in form)
            if(form[i] == "" || form[i] == null)
                return window.alert("All fields must be entered");
        await axios.post("http://localhost:3030/updInscription", JSON.stringify(form));
        window.location.reload();
    },
    del: async function(index){//DEL ACTIONS
        console.log(index);
        await axios.post("http://localhost:3030/delInscription", JSON.stringify({index: index}));
        window.location.reload();
    }
   },
   mounted: async function(){
       this.tableData = await getData();
       this.flag = true;
   }
});


async function getData() {
    try {
        var res = await axios.get("http://localhost:3030/inscriptions");
        var data = res.data;
        console.log("Data: ");
        console.log(data);
        return JSON.parse(data);
    } catch (err) {
        console.log(err);
    }
}
</script>

<template>
<div>
    <h1>Instructors</h1>
    <button class="btn btn-success" @click="toggleIns()">Insert</button><br>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>Date</th>
                <th>Registration Price</th>
                <th>Actions</th>
            </tr>
        </template>
        <template v-slot:tbody >
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.date}}</td>
                <td>${{parseFloat(obj.regi_price).toFixed(2)}}</td>
                <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj._id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj._id)"/>
                </td>
            </tr>
        </template>
    </Datatable>

    <Modal id="insModal" :show="showIns" @close="toggleIns()" @save="submit()">
        <template v-slot:header>
            <h1>INSERT MODAL</h1>
        </template>
        <template v-slot:body>
            <p>Date of Registration:&nbsp;<input type="date" v-model="form.date"></p>
            <p>Registration Price:&nbsp;<input type="text" v-model="form.regi_price"></p>
        </template>
    </Modal>

    <Modal id="updModal" :show="showUpd" @close="toggleUpd()" @save="save()">
        <template v-slot:header>
            <h1>Update Entry {{currentID}}</h1>
        </template>
        <template v-slot:body>
            <p>Date of Registration:&nbsp;<input type="date" v-model="form.date"></p>
            <p>Registration Price:&nbsp;<input type="text" v-model="form.regi_price"></p>
        </template>
    </Modal>
</div>
</template>

<style scoped>
    div{
        padding: 3rem;
    }
    button{
        margin: 0;
        margin-bottom: 1rem;
        width: 25rem;
    }

</style>
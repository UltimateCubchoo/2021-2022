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
           showUpd: false,
           showIns: false
       }
   },
   methods:{
    toggleIns(){
        if(this.showIns == true)
            this.showIns = false;
        else this.showIns = true;
    },
    submit: async () => {
        
    },
    del: async (index) => {
        console.log(index);
        await axios.post("http://localhost:3030/del", JSON.stringify({index: index}));
    },
    updShow(index){
        this.toggleUpd();
        this.currentID = index;
        console.log(this.currentID);
    },
    toggleUpd(){
        if(this.showUpd == true)
            this.showUpd = false;
            else this.showUpd = true;
    },
    save: async () => {

    },

   },
   mounted: async function(){
       this.tableData = await getData();
       this.flag = true;
   }
});


async function getData() {
    try {
        var res = await axios.get("http://localhost:3030/clients");
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
    <h1>Clients</h1>
    <button class="btn btn-success" @click="toggleIns()">Insert</button><br>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>Fname</th>
                <th>Lname</th>
                <th>Address</th>
                <th>Phone</th>
                <th>Actions</th>
            </tr>
        </template>
        <template v-slot:tbody >
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.fname}}</td>
                <td>{{obj.lname}}</td>
                <td>{{obj.address}}</td>
                <td>{{obj.phone}}</td>
                <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj._id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj._id)"/>
                </td>
            </tr>
        </template>
    </Datatable>

    <Modal id="insModal" :show="showIns" @close="toggleIns()">
        <template v-slot:header>
            <h1>INSERT MODAL</h1>
        </template>
        <template v-slot:body>
        </template>
    </Modal>

    <Modal id="updModal" :show="showUpd" @close="toggleUpd()">
        <template v-slot:header>
            <h1>UPDATE MODAL</h1>
        </template>
        <template v-slot:body>
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
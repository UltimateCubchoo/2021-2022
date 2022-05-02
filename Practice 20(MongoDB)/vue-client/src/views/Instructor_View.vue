<script lang="ts">
import {defineComponent} from 'vue'
import axios from "axios"
import Datatable from "../components/Datatable.vue"

export default defineComponent({
    components:{
        Datatable: Datatable
    },
   data(){
       return {
           tableData: Object,
           flag: false,
       }
   },
   mounted: async function(){
       this.tableData = await getData();
       this.flag = true;
   }
});


async function getData() {
    try {
        var res = await axios.get("http://localhost:3030/instructors");
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
    <button class="btn btn-primary">Create</button><br>
    <button class="btn btn-success">Insert</button><br>
    <button class="btn btn-danger">Delete</button><br>
    <button class="btn btn-warning">Update</button><br><br>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>Fname</th>
                <th>Lname</th>
                <th>Address</th>
                <th>Phone</th>
            </tr>
        </template>
        <template v-slot:tbody >
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.fname}}</td>
                <td>{{obj.lname}}</td>
                <td>{{obj.address}}</td>
                <td>{{obj.phone}}</td>
            </tr>
        </template>
    </Datatable>
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
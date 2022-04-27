<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h1 id="c">Rents 👉</h1>
                <table id="table">
                    <thead>
                        <tr>
                            <th>Date of rent</th>
                            <th>Date of return</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="flag">
                            <tr v-for="(entry, index) in table" :key="index">
                                <td>{{entry.indate}}</td>
                                <td>{{entry.outdate}}</td>
                                <td>
                                    <span style="color: green; margin-right: 2rem; cursor: pointer;" @click="updShow(entry.rent_id)">↩</span>
                                    <span style="color: red; cursor: pointer;" @click="del(entry.rent_id)">🗑</span>
                                </td>
                            </tr>
                        </template>
                        <template v-else>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </template>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <UpdModal id="updModal" :show="this.show" @close="this.toggleVis()" @save="this.save()">
                    <template v-slot:header><h1>Update Entry {{currentID}}</h1></template>
                    <template v-slot:body class="grid">
                        <p>In Date:&nbsp; <input type="date" v-model="updForm.indate"></p>         
                        <p>Out Date:&nbsp; <input type="date" v-model="updForm.outdate"></p>
                    </template>
                </UpdModal>
            </div>
        </div>
    </div>
</template>
<script>
import axios from "axios"
import UpdModal from "../components/UpdModal.vue"
import UpdModalVue from '../components/UpdModal.vue'

export default {
    components:{
        'UpdModal': UpdModal
    },
    data(){
        return{
            table: [],
            flag: false,
            show: false,
            currentID: null,
            updForm: {
                indate: "",
                outdate: ""
            }
        }
    },
    methods:{
        del: async function(index){
            console.log(index);
            await axios.post("http://localhost:3030/delRent", index);
            window.location.reload();
        },
        //Update Modal Actions
        updShow: function(index){
            console.log(index);
           this.currentID = index;
           console.log(this.currentID);
            this.toggleVis();
        },
        toggleVis(){
            if(this.show == true)
                this.show = false;
            else this.show = true;
        },
        save: async function(){
            try {
                var form = this.updForm;
                form["rent_id"] = this.currentID;
                console.log(JSON.stringify(form));
                for (const prop in form)
                    if(form[prop] == "") return window.alert("All fields must be filled");

                var req = await axios.post("http://localhost:3030/updRent", JSON.stringify(form));
                window.alert("Item was sucessfully changed");
                return window.location.reload();
                
            } catch (err) {
                window.alert("Item change was a failure");
            }
        }
    },
    mounted: async function(){
        this.table = await getRents();
        this.flag = true;
        $("#table").DataTable();
        console.log("Mounting Done...");
    }
}

async function getRents(){
    try{
        var req = await axios.get("http://localhost:3030/rent");
        var data = JSON.parse(req.data);
        return data;
    }
    catch(err){
        console.log(err);
        return [];
    }
};
</script>

<style scoped>
    #c{
        font-size: 100px;
    }
    .grid{
        grid: auto auto;
    }
</style>
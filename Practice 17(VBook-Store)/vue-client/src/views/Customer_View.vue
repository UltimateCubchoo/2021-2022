<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h1 id="c">Customers 👌</h1>
                <table id="table" >
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Address</th>
                            <th>Phone</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="flag">
                            <tr v-for="(entry, index) in table" :key="index" >
                                <td>{{entry.fname}}</td>
                                <td>{{entry.lname}}</td>
                                <td>{{entry.address}}</td>
                                <td>{{entry.phone}}</td>
                                <td>
                                    <span style="color: green; margin-right: 2rem; cursor: pointer;" @click="updShow(entry.customer_id)">↩</span>
                                    <span style="color: red; cursor: pointer;" @click="del(entry.customer_id)">🗑</span>
                                </td>
                            </tr>
                        </template>
                        <template v-else><!--This is so the table doesn't load the no data in table row-->
                            <tr>
                                <td></td>
                                <td></td>
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
                        <p>First Name:&nbsp; <input type="text" v-model="updForm.fname"></p>         
                        <p>Last Name:&nbsp; <input type="text" v-model="updForm.lname"></p>
                        <p>Address:&nbsp; <input type="" v-model="updForm.address"></p>
                        <p>Phone Number&nbsp; <input type="text" v-model="updForm.phone"></p>
                    </template>
                </UpdModal>
            </div>
        </div>
    </div>
</template>
<script>
import axios from "axios"
import UpdModal from '../components/UpdModal.vue'

export default {
    components: {
        UpdModal
    },
    data(){
        return{
            table: [],
            flag: false,
            show: false,
            currentID: null,
            updForm: {
                fname: "", 
                lname: "",
                address: "",
                phone: ""
            }
        }
    },
    methods:{
        initTable(){
            console.log("Table Init");
            $("#table").DataTable();
        },
        del: async function(index){
            console.log(index);
            await axios.post("http://localhost:3030/delCustomer", index);
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
                form["customer_id"] = this.currentID;
                for (const prop in form)
                    if(form[prop] == "") return window.alert("All fields must be filled");

                console.log(JSON.stringify(form));
                var req = await axios.post("http://localhost:3030/updCustomer", JSON.stringify(form));
                window.alert("Item was sucessfully changed");
                return window.location.reload();
                
            } catch (err) {
                window.alert("Item change was a failure", err);
            }
        }
    },
    mounted: async function(){
        $("#table").DataTable();
        this.table = await getCustomers();
        this.flag = true;
        console.log("Mounting Done...");
    },
    //I added this to make sure the table is loaded before the modal is opened
    watch: {
        table: function (value) {
            $("#table").DataTable().destroy();
            this.$nextTick((value) => {
                $("#table").DataTable();
            });
        },
    },
}

async function getCustomers(){
    try{
        var req = await axios.get("http://localhost:3030/customer");
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
</style>
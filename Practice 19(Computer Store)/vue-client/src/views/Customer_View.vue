<script>
import Datatable from "../components/Datatable.vue"
import Modal from "../components/Modal.vue"
import axios from "axios"

export default({
    components:{
        Datatable: Datatable,
        Modal: Modal
    },
    data(){
        return {
            flag: false,
            tableData: {},
            show: false,
            showIns: false,
            currentID: null,
            form:{
                fname: "",
                lname: "",
                address: "",
                phone: "",
                city: "",
                zip: ""
            }
        }
    },
    methods: {
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
            console.log(this.show);
        },
        toggleVis(){
            if(this.show == true)
                this.show = false;
            else this.show = true;
        },
        save: async function(){
            try {
                var form = this.form;
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
        },
        //Insert Modal actions
        insToggle(){
            if(this.showIns == true)
                this.showIns = false;
            else this.showIns = true
        },
        submit: async function(){
            try{
                var form = this.form;
                for (const prop in form)
                    if(form[prop] == "") return window.alert("All fields must be filled");
                console.log(JSON.stringify(form));
                await axios.post("http://localhost:3030/insCustomer", JSON.stringify(form));
                window.alert("Item was successfully added");
                return window.location.reload();

            } catch (err){
                window.alert("Item addition was a failure", err);
            }
        }
    },
    mounted: async function(){
        try{
            this.tableData = await getData();
            this.flag = true;
        }
        catch(err){
            console.log(err);
        }
    }
});

async function getData(){
    try {
        var res = await axios.get("http://localhost:3030/customers");
        var json = JSON.parse(res.data);
        console.log(json);
        return json;
    } catch (err) {
        console.log(err);
    }
}
</script>


<template>
<div>
    <span class="fa fa-plus-square" style="float: right; cursor: pointer; color: #003aa1;" @click="insToggle()"/>
    <h1>Customers&nbsp;<span class="fa fa-child" /></h1>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Address</th>
                <th>Phone</th>
                <th>City</th>
                <th>Zip Code</th>
                <th>Actions</th>
            </tr>
        </template>
        <template v-slot:tbody>
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.fname}}</td>
                <td>{{obj.lname}}</td>
                <td>{{obj.address}}</td>
                <td>{{obj.phone}}</td>
                <td>{{obj.city}}</td>
                <td>{{obj.zip}}</td>
                <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj.customer_id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj.customer_id)" />
                </td>
            </tr>
        </template>
    </Datatable>

    <Modal id="insModal" :show="this.showIns" @close="this.insToggle()" @save="this.submit()">
        <template v-slot:header><h1>Add a Customer</h1></template>
        <template v-slot:body class="grid">
            <p>First Name:&nbsp; <input type="text" v-model="form.fname"></p>         
            <p>Last Name:&nbsp; <input type="text" v-model="form.lname"></p>
            <p>Address:&nbsp; <input type="text" v-model="form.address"></p>
            <p>Phone Number&nbsp; <input type="text" v-model="form.phone"></p>
            <p>City&nbsp; <input type="text" v-model="form.city"></p>
            <p>Zip Code:&nbsp; <input type="text" v-model="form.zip"></p>
        </template>
    </Modal>

    <Modal id="updModal" :show="this.show" @close="this.toggleVis()" @save="this.save()">
        <template v-slot:header><h1>Update Entry {{currentID}}</h1></template>
        <template v-slot:body class="grid">
            <p>First Name:&nbsp; <input type="text" v-model="form.fname"></p>         
            <p>Last Name:&nbsp; <input type="text" v-model="form.lname"></p>
            <p>Address:&nbsp; <input type="text" v-model="form.address"></p>
            <p>Phone Number&nbsp; <input type="text" v-model="form.phone"></p>
            <p>City&nbsp; <input type="text" v-model="form.city"></p>
            <p>Zip Code:&nbsp; <input type="text" v-model="form.zip"></p>
        </template>
    </Modal>
</div>
</template>

<style scoped>
    div{
        padding: 1rem;
    }
</style>


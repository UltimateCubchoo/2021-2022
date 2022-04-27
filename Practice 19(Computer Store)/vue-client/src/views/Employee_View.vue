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
                email: "",
                birthdate: ""
            }
        }
    },
    methods: {
         del: async function(index){
            console.log(index);
            await axios.post("http://localhost:3030/delEmployee", index);
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
                form["employee_id"] = this.currentID;
                for (const prop in form)
                    if(form[prop] == "") return window.alert("All fields must be filled");

                console.log(JSON.stringify(form));
                var req = await axios.post("http://localhost:3030/updEmployee", JSON.stringify(form));
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
                await axios.post("http://localhost:3030/insEmployee", JSON.stringify(form));
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
        var res = await axios.get("http://localhost:3030/employees");
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
    <h1>Employees&nbsp;<span class="fa fa-male" /></h1>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Birth Date</th>
                <th>Actions</th>
            </tr>
        </template>
        <template v-slot:tbody>
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.fname}}</td>
                <td>{{obj.lname}}</td>
                <td>{{obj.email}}</td>
                <td>{{obj.birthdate}}</td>
                <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj.employee_id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj.employee_id)"/>
                </td>
            </tr>
        </template>
    </Datatable>

    <Modal id="insModal" :show="this.showIns" @close="this.insToggle()" @save="this.submit()">
        <template v-slot:header><h1>Add an Employee</h1></template>
        <template v-slot:body class="grid">
            <p>First Name:&nbsp; <input type="text" v-model="form.fname"></p>         
            <p>Last Name:&nbsp; <input type="text" v-model="form.lname"></p>
            <p>Email:&nbsp; <input type="email" v-model="form.email"></p>
            <p>Birth Date:&nbsp; <input type="date" v-model="form.birthdate"></p>
        </template>
    </Modal>
    
    <Modal id="updModal" :show="this.show" @close="this.toggleVis()" @save="this.save()">
        <template v-slot:header><h1>Update Entry {{currentID}}</h1></template>
        <template v-slot:body class="grid">
            <p>First Name:&nbsp; <input type="text" v-model="form.fname"></p>         
            <p>Last Name:&nbsp; <input type="text" v-model="form.lname"></p>
            <p>Email:&nbsp; <input type="email" v-model="form.email"></p>
            <p>Birth Date:&nbsp; <input type="date" v-model="form.birthdate"></p>
        </template>
    </Modal>
</div>
</template>

<style scoped>
    div{
        padding: 1rem;
    }
</style>


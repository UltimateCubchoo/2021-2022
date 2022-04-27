<script>
import Datatable from "../components/Datatable.vue"
import axios from "axios"
import Modal from "../components/Modal.vue"


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
                name: "",
                description: ""
            }
        }
    },
    methods: {
         del: async function(index){
            console.log(index);
            await axios.post("http://localhost:3030/delCategory", index);
            window.location.reload();
        },
        //Update Modal Actions
        updShow: function(index){
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
                var form = this.form;
                form["category_id"] = this.currentID;
                for (const prop in form)
                    if(form[prop] == "") return window.alert("All fields must be filled");

                console.log(JSON.stringify(form));
                var req = await axios.post("http://localhost:3030/updCategory", JSON.stringify(form));
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
                await axios.post("http://localhost:3030/insCategory", JSON.stringify(form));
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
        var res = await axios.get("http://localhost:3030/categories");
        var json = JSON.parse(res.data);
        return json;
    } catch (err) {
        console.log(err);
    }
}
</script>


<template>
<div>
    <span class="fa fa-plus-square" style="float: right; cursor: pointer; color: #003aa1;" @click="insToggle()"/>
    <h1>Categories&nbsp;<span class="fa fa-pie-chart"/></h1>
    <Datatable v-if="flag">
        <template v-slot:thead>
            <tr>
                <th>Category Name</th>
                <th>Description</th>
                <th>Actions</th>
            </tr>
        </template>
        <template v-slot:tbody>
            <tr v-for="(obj, index) in tableData" :key="index">
                <td>{{obj.name}}</td>
                <td>{{obj.description}}</td>
                <td>
                    <span class="fa fa-pencil" style="color: #00a100; margin-right: 2rem; cursor: pointer;" @click="updShow(obj.category_id)"/>
                    <span class="fa fa-minus-circle" style="color: #a10000; cursor: pointer;" @click="del(obj.category_id)"/>
                </td>
            </tr>
        </template>
    </Datatable>

<!--INSERT Modal-->
<Modal id="insModal" :show="this.showIns" @close="this.insToggle()" @save="this.submit()">
        <template v-slot:header><h1>Add a new category</h1></template>
        <template v-slot:body class="grid">
            <p>Name:&nbsp; <input type="text" v-model="form.name"></p>
            <p>Description:&nbsp; <textarea v-model="form.description"></textarea></p>
        </template>
</Modal>

<!---UPDATE MODAL--->
<Modal id="updModal" :show="this.show" @close="this.toggleVis()" @save="this.save()">
        <template v-slot:header><h1>Update Entry {{currentID}}</h1></template>
        <template v-slot:body class="grid">
            <p>Name:&nbsp; <input type="text" v-model="form.name"></p>
            <p>Description:&nbsp; <textarea v-model="form.description"></textarea></p>
        </template>
</Modal>
</div>
</template>

<style scoped>
    div{
        padding: 1rem;
    }
</style>


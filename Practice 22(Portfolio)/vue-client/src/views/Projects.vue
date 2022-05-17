<script lang="ts">
import {defineComponent} from "vue"
import jquery from "jquery"
const $ = jquery;
window["$"] = jquery;
// import axios from "axios"
export default defineComponent({
    data(){
        return {
            data: [],
            flag: false,
        }
    },
    mounted: async function(){
        this.data = await loadData();
        console.log(this.data);
        this.flag = true;
    }     
});

async function loadData(){
    try {
        // var res = await axios.get("http://localhost:3030/projects");
        var res = await $.getJSON("/projects.json", function(data){
            res = data;
        });
        return res;
    } catch (err) {
        if(err) console.log(err);
    }
}
</script>

<template>
<!-- Projects-->
        <section class="projects-section bg-light" id="projects">
            <div class="container px-4 px-lg-5">

                <div v-for="(obj, index) in data" :key="index">
                <!-- Featured Project Row-->
                    <div class="row gx-0 mb-4 mb-lg-5 align-items-center" v-if="index == 0">
                        <div class="col-xl-8 col-lg-7"><img class="img-fluid mb-3 mb-lg-0" :src="'/img/' + obj.image" alt="..." /></div>
                        <div class="col-xl-4 col-lg-5">
                            <div class="featured-text text-center text-lg-left">
                                <h4>{{obj.name}}</h4>
                                <p class="text-black-50 mb-0">{{obj.description}}</p>
                            </div>
                        </div>
                    </div>
                    <!-- Project One Row // Image left-->
                    <div class="row gx-0 mb-5 mb-lg-0 justify-content-center" v-if="index % 2 == 0 && index != 0">
                        <div class="col-lg-6"><img class="img-fluid" :src="'/img/' + obj.image" alt="..." /></div>
                        <div class="col-lg-6">
                            <div class="bg-black text-center h-100 project">
                                <div class="d-flex h-100">
                                    <div class="project-text w-100 my-auto text-center text-lg-left">
                                        <h4><a class="text-white" :href="obj.link">{{obj.name}}</a></h4>
                                        <p class="mb-0 text-white-50">{{obj.description}}</p>
                                        <hr class="d-none d-lg-block mb-0 ms-0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Project Two Row \\ Image Right-->
                    <div class="row gx-0 justify-content-center" v-else-if="index != 0">
                        <div class="col-lg-6"><img class="img-fluid" :src="'/img/' + obj.image" alt="..." /></div>
                        <div class="col-lg-6 order-lg-first">
                            <div class="bg-black text-center h-100 project">
                                <div class="d-flex h-100">
                                    <div class="project-text w-100 my-auto text-center text-lg-right">
                                        <h4><a class="text-white" :href="obj.link">{{obj.name}}</a></h4>
                                        <p class="mb-0 text-white-50">{{obj.description}}</p>
                                        <hr class="d-none d-lg-block mb-0 me-0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
       
            </div>
        </section>
</template>

<style scoped>
    img{
        width: 100%;
        height: 100%;
    }
</style>
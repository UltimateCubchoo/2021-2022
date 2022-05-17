<script lang="ts">
import {defineComponent} from "vue"
import Modal from "../components/Modal.vue"
export default defineComponent({
    data(){
        return{
            show: false,
            form:{
                name: "",
                email: "",
                phone: "",
            }
        }
    },
    components:{
        Modal: Modal,
    },
    methods:{
        toggContact(){
            if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )
            return;
            if(!this.show)
                return this.show = true;
            this.show = false;
        },
        send: async function(){
            var form = this.form;
            return;
        }
    }
});
</script>


<template>
    <!-- Contact-->
        <section class="contact-section bg-black">
            <div class="container px-4 px-lg-5">
                <div class="row gx-4 gx-lg-5">
                    <div class="col-md-4 mb-3 mb-md-0">
                        <div class="card py-4 h-100">
                            <div class="card-body text-center">
                                <i class="fas fa-map-marked-alt text-primary mb-2"></i>
                                <h4 class="text-uppercase m-0">Address</h4>
                                <hr class="my-4 mx-auto" />
                                <div class="small text-black-50">Nunya Buissness</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mb-3 mb-md-0">
                        <div class="card py-4 h-100">
                            <div class="card-body text-center">
                                <div style="cursor: pointer;" @click="toggContact()">
                                    <i class="fas fa-envelope text-primary mb-2" ></i>
                                    <h4 class="text-uppercase m-0">Email</h4>
                                </div>
                                <hr class="my-4 mx-auto" />
                                <div class="small text-black-50"><a href="#!">fingerbuthole@protonmail.com</a></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mb-3 mb-md-0">
                        <div class="card py-4 h-100">
                            <div class="card-body text-center">
                                <i class="fas fa-mobile-alt text-primary mb-2"></i>
                                <h4 class="text-uppercase m-0">Phone</h4>
                                <hr class="my-4 mx-auto" />
                                <div class="small text-black-50">+1 (239) 692-0520</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="social d-flex justify-content-center">
                    <a class="mx-2" href="https://twitter.com/UltimateCubchoo"><i class="fab fa-twitter"></i></a>
                    <a class="mx-2" href="#!"><i class="fab fa-patreon"></i></a>
                    <a class="mx-2" href="https://github.com/UltimateCubchoo"><i class="fab fa-github"></i></a>
                </div>
            </div>

            <Modal :show="show" @close="toggContact()" @send="send()">
                <template v-slot:body>
                    <p>Name:&nbsp;<input v-model="form.name"></p>
                    <p>Email:&nbsp;<input type="email" v-model="form.email"></p>
                    <p>Phone:&nbsp;<input v-model="form.phone"></p>
                </template>
            </Modal>
        </section>
</template>


const template = 
`
<div id="tab-example" class="container" style="margin: auto;">
    <button class="btn stock" :style="nav.d1 ? active : unactive" @click="changeDiv('d1')">Home</button>
    <button class="btn stock" :style="nav.d2 ? active : unactive" @click="changeDiv('d2')">Projects</button>
    <button class="btn stock" :style="nav.d3 ? active : unactive" @click="changeDiv('d3')">Services</button>
    <button class="btn stcok" :style="nav.d4 ? active : unactive" @click="changeDiv('d4')">Contact</button>
    <div v-if="nav.d1">Home</div>
    <div v-if="nav.d2">Projects</div>
    <div v-if="nav.d3">Services</div>
    <div v-if="nav.d4">Contact</div>
</div>
`;

export default {
    name: "ndivs",
    template: template,
    data(){
        return {
            nav:{
                d1: true,
                d2: false,
                d3: false,
                d4: false
            },
            active: {
                "background-color": "dimgrey",
                "color": "whitesmoke"
            },
            unactive:{
                "background-color": "white",
                "color": "black"
            }
        }
    },
    methods:{
        changeDiv: function(dname){
            this.nav.d1 = false;
            this.nav.d2 = false;
            this.nav.d3 = false;
            this.nav.d4 = false;
            switch(dname){
                case "d1":
                    this.nav.d1 = true;
                    break;
                case "d2":
                    this.nav.d2 = true;
                    break;
                case "d3":
                    this.nav.d3 = true;
                    break;
                case "d4":
                    this.nav.d4 = true;
                    break;
            }
        }
    },
}
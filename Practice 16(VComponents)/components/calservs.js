const template = 
`
<div class="container" style="width: 25%; margin: auto;">
    <div v-for="(service, index) in services" 
     :style="service.status ? active : unactive" 
     @click="service.status ? service.status=false : service.status=true; cal(index);">
        <h2>{{service.name}}&nbsp;\${{service.cost}}</h2>
    </div>
    <hr>
    <h2>Total: \${{total}}</h2>
</div>

`;

export default{
    name: "calservs",
    template: template,
    data(){
        return{
            services: [
                {name: "Web Development", cost: 300, status: false},
                {name: "Design", cost: 400, status: false},
                {name: "Integration", cost: 250, status: false},
                {name: "Training", cost: 200, status: false}
            ],
            total: 0,
            active: {
                "color": "whitesmoke",
                "background-color": "green",
                "cursor": "pointer"
            },
            unactive: {
                "color": "whitesmoke",
                "background-color": "red",
                "cursor": "pointer"
            }
        }
    },
    methods: {
        cal(index){
            var total = 0;
            for(var i= 0; i < this.services.length; i++){
                if( this.services[i].status)
                    total += this.services[i].cost;
            }
            console.log(total);
            this.total = total;
        }
    }

}
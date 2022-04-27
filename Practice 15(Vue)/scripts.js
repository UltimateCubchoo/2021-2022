const app = Vue.createApp({

    data(){
        return{
            title: "VueJS Practice",
            message: "This is a test",
            password: "",
            icon: "fa fa-eye-slash",
            paragraph: "The quick brown fox jumps over the lazy dog. Unfortunately for the fox the leg of his rear was caught. But the dog is a Boston Mastiff so the fox likes to stay with them to make a new friend :)",
            tip: {
                total: 0,
                rate: 0.2,
                people: 1,
                tip: 0,
            }, 
            cat:{
                current: 1,
                images: ["images/cat0.jpg", "images/cat1.jpg", "images/cat2.jpg"]
            },
            list:["apples", "bannanas", "oranges"]
        }
    },



    methods: {
        showPass: function () {
            var passInput = document.querySelector("#password");

            if(passInput.getAttribute("type") == "password"){
                passInput.setAttribute("type", "text");
                this.icon = "fa fa-eye";
            }
            else{
                passInput.setAttribute("type", "password");
                this.icon = "fa fa-eye-slash";
            }
        },
        expandP: function () {
            var shortP = "The quick brown fox...";
            var longP = "The quick brown fox jumps over the lazy dog. Unfortunately for the fox the leg of his rear was caught. But the dog is a Boston Mastiff so the fox likes to stay with them to make a new friend :)";
            if(this.paragraph == longP){
                this.paragraph = shortP;
            }
            else this.paragraph = longP;
        },
        calcTip: function () {
            var tip = (this.tip.total * this.tip.rate) / this.tip.people;//Issue with vmodel within objects
            this.tip.tip = tip;
        },
        switchImg: function(tick){
            var current = this.cat.current;
            switch(tick){
                case 0:
                    if (current == 0) current = 2;
                    else --current;
                    break;
                case 1:
                    if (current == 2) current = 0;
                    else current++;
                    break;
                default:
                    console.log("something weird happened");
                    return;
                    break;
            }
            this.cat.current = current;
        },
        newItem: function(event){//lol I made a key logger
            if(event.key != "Enter") return;
            var item = document.querySelector("#newItem").value;
            document.querySelector("#newItem").value = "";
            this.list.push(item);
        },
        removeItem: function(item){
            for(i in this.list)
                if(this.list[i] == item)
                    this.list.splice(i, 1);
        }
    },


    computed:{
        catCSS(){
            var image = this.cat.images[this.cat.current];
            return {
                "background-image": `url('${image}')`,
                "background-size": "cover",
                "width": "300px",
                "height": "500px"
            }
        }
    }



}).mount("#app");
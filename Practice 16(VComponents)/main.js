import ndivs from "./components/ndivs.js"
import editor from "./components/editor.js";
import calservs from "./components/calservs.js";
import search from "./components/search.js"
    
const app = Vue.createApp({
    components:{
        ndivs: ndivs,
        editor: editor,
        calservs: calservs,
        search: search
    },
    data(){
        return {
            title: "Hello, World!",
        }
    }
}).mount("#app");


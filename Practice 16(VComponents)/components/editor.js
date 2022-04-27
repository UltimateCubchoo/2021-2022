const template = 
`
<div :style="editor ? active: unactive" class="talk-bubble tri-right border round btm-left-in">
    <input type="text" v-model="text" id="popup">
</div>
<h3  @click="editor ? editor=false: editor=true; focus();" style="cursor: pointer;">|{{text}}</h3>
`;

export default{
    name: "editor",
    template: template,
    data(){
        return{
            text: "Edit me.",
            editor: false,
            active: {
                display: "block"
                
            },
            unactive: {
                "display": "none"
            }
        }
    },
    methods:{
        focus(){
            
            document.getElementById("popup").focus();
        }
    }


}


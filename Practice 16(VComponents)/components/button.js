const template = `<button>Hello {{toWhat}}</button>`;

export default {
    name: "button",
    template: template,
    data(){
        return{
            toWhat: "World"
        }
    }
};
const template =
    `
<div class="input-group">
    <input type="text" class="form-control" v-model="searchTerm" v-on:keyup="rerender()" style="width: 20rem" placeholder="Type here to start searching...">
</div><br>
<div v-for="(item, index) in displayedItems" :key="key" :style="divStyle">
    <br>
    <h3>{{item.title}}</h3>
    <img :style="imgStyle" :src="item.img">
    <hr>
</div>
`;

export default {
    name: "search",
    template: template,
    data() {
        return {
            searchTerm: "",
            key: 0,
            items: [
                { title: "Tiles for You", img: "img/0.jpg" },
                { title: "About tiles", img: "img/1.png" },
                { title: "Talking about tiles", img: "img/2.jpg" },
                { title: "Lack of Tiles?", img: "img/3.jpg" },
                { title: "Tiling Complaints", img: "img/4.jpg" },
                { title: "Hello Tile", img: "img/4.jpg"}
            ],
            divStyle: {
                "margin": "auto",
                "border": "1px black solid",
                "width": "20rem"
            },
            imgStyle: {
                width: "100px",
                height: "100px"
            }
        }
    },
    computed: {
        displayedItems: function () {
            var items = this.items;
            var term = this.searchTerm;
            if (term == "") return items;

            var ditems = [];
            for (var i = 0; i < items.length; ++i) {
                var subStr = items[i].title.toLowerCase(0);
                var isSubstr = subStr.includes(term);

                if (isSubstr)
                    ditems.push(items[i]);
            }
            return ditems;
        }
    },
    methods: {
        rerender() {
            this.key += 1;
        }
    }
}
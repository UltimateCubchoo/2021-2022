function loadCSS(){
    var publicFolder = "..";
    $("#icon").attr("href", `${publicFolder}/images/favicon.ico`);
    $("#style").attr("href", `${publicFolder}/stylesheets/style.css`);
}

function drawCards(data, ftype){
    var html = "";
    for(var i = 0; i < data.length; i++){
        var obj = data[i];
       //Making the columns
        var imgSrc = "/images/" + obj.image;
        var footer = drawFooter(obj, ftype);
        html += `
                    <div class="col-2">
                        <div class="container-fluid card-body" style="background-image: url('${imgSrc}');">
                        </div>
                        ${footer}
                    </div>
        `;
    }
    return html;
}

function drawRating(rating){
        var rt = "<span>";
        for(var i = 0; i < 5; i++){
            if(rating > 1){
                rt += `<span class="fa fa-star"></span>`;
                rating -= 2;
            }
            else if(rating == 1){
                rt += `<span class="fa fa-star-half-o"></span>`;
                rating -= 1;
            }
            else
                rt += `<span class="fa fa-star-o"></span>`;
        }
        rt += "</span>"
        return rt;
}

function drawFooter(obj, ftype){
    var html = "";
    if(ftype == 0){
        var stars = drawRating(obj.rating);
        html = `<div class="container-fluid card-footer">
                    <h3>${obj.title}</h3>
                    <p>Author: ${obj.author}</p><br>
                    ${stars}
                </div>`
    }
    else html = `<div class="container-fluid card-footer">
                        <h3>${obj.title}</h3>
                        <p>Author: ${obj.author}</p>
                        <p>Genre: ${obj.genre}</p>
                        <p><a href="#" style="cursor: pointer;" onclick="updShow(${obj.book_id})">Edit</a>&nbsp;&nbsp;<a href="#" style="cursor: pointer;" onclick="delShow(${obj.book_id})">Remove</a></p><br>
                    </div>`
    return html;
}
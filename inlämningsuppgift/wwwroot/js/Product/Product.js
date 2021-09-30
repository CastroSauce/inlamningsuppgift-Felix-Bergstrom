"use strict"


let settings = { };

function init(settingsObj) {
    settings = settingsObj;
    settings.pagenum = 0;
}

$("#priceOrder").change(() => {
    $("#orderForm").submit();
})

$(document).on("click", ".page-back", function () {

    let prevpage = $(this).parent().find(".active").prev();

    if (prevpage != this) {
        prevpage.click();
    }

});

$(document).on("click", ".page-forward", function () {

    let prevpage = $(this).parent().find(".active").next();

    if (prevpage != this) {
        prevpage.click();
    }

});

$(document).on("click", ".pagenum", async function () {

    $(this).parent().find(".active").removeClass("active");
    $(this).addClass("active");

    settings.pagenum = $(this).find("button").attr("value");


    let urlParams = Object.entries(settings).reduce((acc, [key, value]) => `${acc}&${key}=${value ?? ""}`, "");


    let result = await fetch(`/ProductPage/Product?handler=ProductList${urlParams}`);

    let data = await result.text();


    $("#products-container").html(data);


})
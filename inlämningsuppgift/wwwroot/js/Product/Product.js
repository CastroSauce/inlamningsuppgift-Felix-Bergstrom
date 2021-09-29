"use strict"


let settings = { };

function init(settingsObj) {
    settings = settingsObj;
    settings.pagenum = 0;
}

$("#priceOrder").change(() => {
    $("#orderForm").submit();
})

$(document).on("click", ".page-item", async function () {

    $(this).parent().find(".active").removeClass("active");
    $(this).addClass("active");

    settings.pagenum = $(this).find("button").attr("value");


    let urlParams = Object.entries(settings).reduce((acc, [key, value]) => `${acc}&${key}=${value ?? ""}`, "");


    let result = await fetch(`/ProductPage/Product?handler=ProductList${urlParams}`);

    let data = await result.text();


    $("#products-container").html(data);


})
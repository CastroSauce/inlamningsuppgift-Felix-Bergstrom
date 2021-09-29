"use strict"

let page = 0;

$("#priceOrder").change(() => {
    $("#orderForm").submit();
})

$(document).on("click", ".page-item", async function () {

    $(this).parent().find(".active").removeClass("active");
    $(this).addClass("active");

    page = $(this).find("button").attr("value");


    let order = $("#priceOrder").val();

    let query = $("#query").val();

    let result = await fetch(`/ProductPage/Product?handler=ProductList&pagenum=${page}&order=${order}&query=${query}`);

    let data = await result.text();


    $("#products-container").html(data);


})
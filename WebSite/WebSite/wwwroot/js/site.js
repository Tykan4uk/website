// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addToCartJs(id, name, desc, price, type) {
    $.post("/Cart/AddToCart", { productId: id, name: name, description: desc, price: price, type: type })
}

function deleteFromCartJs(id) {
    $.post("/Cart/RemoveFromCart", { productId: id })
}

function createOrderAndClearCartJs() {
    $.get("/Order/Add");
    $.get("/Cart/ClearCart")
}
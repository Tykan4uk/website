// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addToCartJs(id) {

    $.post("/Cart/AddToCart", { gameId: id })
}

function deleteFromCartJs(id) {

    $.post("/Cart/RemoveFromCart", { gameId: id })
}
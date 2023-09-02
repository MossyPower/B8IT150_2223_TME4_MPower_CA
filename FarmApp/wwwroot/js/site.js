// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Confirm Delete User
function confirmDelete(uniqueId, isDeleteClicked){
    var deleteTd = 'deleteTd_' + uniqueId;
    var confirmDeleteTd = 'confirmDeleteTd_' + uniqueId;
    if(isDeleteClicked){
        $('#' + deleteTd).hide();
        $('#' + confirmDeleteTd).show();
    }else{
        $('#' + deleteTd).show();
        $('#' + confirmDeleteTd).hide();        
    }
}


// function ProductAdded(addToCartIsClicked){
//     var addToCart = 'AddToCart';
//     var productAdded = 'ProductAdded';
//      if(addToCartIsClicked){
//          $().show();
//      }
// }

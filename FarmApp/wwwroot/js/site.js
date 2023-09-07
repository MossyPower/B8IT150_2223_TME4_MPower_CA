// Kudvenkat (2019) ASP NET Core delete confirmation. Available at: https:
//www.youtube.com/watch?v=hKLjt9GzYM8&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=87&ab_channel=kudvenkat

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

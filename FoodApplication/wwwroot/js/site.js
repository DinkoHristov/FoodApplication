let apiUrl = "https://forkify-api.herokuapp.com/api/v2/recipes";
let apiKey = "52c5fbec-300f-4579-b1d6-c101f0f97f7f";

async function GetRecipes(recipeName, id, isAllShown) {
    let resp = await fetch(`${apiUrl}?search=${recipeName}&key=${apiKey}`);
    let result = await resp.json();
    let allRecipes = isAllShown ? result.data.recipes : result.data.recipes.slice(0, 6);

    ShowRecipes(allRecipes, id);
}

function ShowRecipes(recipes, id) {
    $.ajax({
        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResult) {
            $('#' + id).html(htmlResult);
            GetAddedCarts();
        }
    });
}

async function GetOrderRecipe(id, showId) {
    let resp = await fetch(`${apiUrl}/${id}?key=${apiKey}`);
    let result = await resp.json();
    let recipe = result.data.recipe;

    ShowOrderRecipeDetails(recipe, showId);
}

function ShowOrderRecipeDetails(details, showId) {
    $.ajax({
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/ShowOrder',
        data: details,
        success: function (htmlResult) {
            $('#' + showId).html(htmlResult);
        }
    });
}

// Order Page

function Quantity(option) {
    let qty = $('#qty').val();
    let price = $('#price').val();
    let totalAmount = 0;

    if (option == 'inc') {
        qty++;
    } else {
        qty = qty == 1 ? qty : qty - 1;
    }

    totalAmount = price * qty;
    $('#qty').val(qty);
    $('#totalAmount').val(totalAmount);
}

// Add tp Cart
async function cart() {
    let iTag = $(this).children('i')[0];
    let recipeId = $(this).attr('data-recipeId');

    if ($(iTag).hasClass('fa-regular')) {
        let resp = await fetch(`${apiUrl}/${recipeId}?key=${apiKey}`);
        let result = await resp.json();
        let cart = result.data.recipe;
        cart.RecipeId = recipeId;
        delete cart.id;

        CartRequest(cart, 'SaveCart', 'fa-solid', 'fa-regular', iTag, false);
    } else {
        let data = { Id: recipeId };
        CartRequest(data, 'RemoveCartFromList', 'fa-regular', 'fa-solid', iTag, false);
    }
}

function CartRequest(data, action, addcls, removecls, iTag, isReload) {
    $.ajax({
        url: '/Cart/' + action,
        type: 'POST',
        data: data,
        success: function (resp) {
            if (isReload) {
                location.reload();
            } else {
                $(iTag).addClass(addcls);
                $(iTag).removeClass(removecls);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetAddedCarts() {
    $.ajax({
        url: '/Cart/GetAddedCarts',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('.addToCartIcon').each((index, spanTag) => {
                let recipeId = $(spanTag).attr('data-recipeId');
                for (var i = 0; i < result.length; i++) {
                    if (recipeId == result[i]) {
                        let itag = $(spanTag).children('i')[0];
                        $(itag).addClass('fa-solid');
                        $(itag).removeClass('fa-regular');
                        break;
                    }
                }
            })
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetCartList() {
    $.ajax({
        url: '/Cart/GetCartList',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('#showCartList').html(result);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function RemoveCartFromList(id) {
    let data = { Id: id };
    CartRequest(data, 'RemoveCartFromList', null, null, null, true);
}
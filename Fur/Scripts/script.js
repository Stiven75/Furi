function press() {
    var g;

    //row-cart-item


    var CheckboxSelected = document.querySelectorAll("input[type='checkbox'][name='row-cart-item']");

    var Offers = [];

    let metka = [];

    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        if (item.checked== true) {

            $('#content').load('/Basket/Del?Id=' + Id);
        }
  

    });


    $('#Kol').load('/Basket/Count', reset());
    $('#content').load('/Basket/Basket', reset());
    //$('#max').load('/Basket/Max', reset());
}

function reset() {
    $('#Kol').load('/Basket/Count');
    $('#content').load('/Basket/Basket');
    //$('#max').load('/Basket/Max');
}


function SelectCheckbox(even) {

    var Checkbox = even;
    console.log(even);
    if (even.checked) {
        even.classList.add("selected-checked");


    }
    else {
        even.classList.remove("selected-checked");

    }
}

function AddCategory() {
    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "AddCategory",
        data: {
        },
        success: function (data) {

            console.log(data);
            $('#CategoryBlock').load('/Admin/CategoryPartial');

        },
        error: function (data) {
            //console.log(data);
            $('#CategoryBlock').load('/Admin/CategoryPartial');
        }
    });

}

function UpCategory() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Category = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        var Nameasas = document.getElementById(Id + "-name");


        Category.push({ 'Name': Name.value, 'Id': parseInt(Id) });


    });

    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "UpdateCategory",
        data: {
            categories: Category,
        },
        success: function (data) {

            console.log(data);
            $('#CategoryBlock').load('/Admin/CategoryPartial');

        },
        error: function (data) {
            //console.log(data);
            $('#CategoryBlock').load('/Admin/CategoryPartial');
        }
    });
}

function DeletCategory() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var categories = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        categories.push({ 'Name': Name.value, 'Id': parseInt(Id) });
    });

    if (categories.length == 0) {

        alert("Выбирете цвет для удаления");
    }


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "DeleteCategory",
        data: {
            categories: categories,
        },
        success: function (data) {

            console.log(data);


        }
    });


    $('#CategoryBlock').load('/Admin/CategoryPartial');
}





function AddColor() {
    $.ajax({
        dataType: "text",
        cache: false,
        type: "POST",
        url: "AddColor",
        data: {
        },
        success: function (data) {

            console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');

        },
        error: function (data) {
            //console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');
        }
    });

}

function UpColor() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Color = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        var ColorCode = document.getElementById(Id + "-code");
        Color.push({ 'Name': Name.value, 'Id': parseInt(Id), 'ColorCode': ColorCode.value });
    });

    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "UpdateColor",
        data: {
            Colors: Color,
        },
        success: function (data) {

            console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');

        },
        error: function (data) {
            //console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');
        }
    });
}

function DeletColor() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Color = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        Color.push({ 'Name': Name.value, 'Id': parseInt(Id) });
    });

    if (Color.length == 0)
    {

        alert("Выбирете цвет для удаления");
    }


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "DeleteColor",
        data: {
            Colors: Color,
        },
        success: function (data) {

            console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');

        },
        error: function (data) {
            //console.log(data);
            $('#ColorBlock').load('/Admin/ColorPartial');
        }
    });
}


function AddSize() {
    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "AddSize",
        data: {
        },
        success: function (data) {

            console.log(data);
            $('#SizeBlock').load('/Admin/SizePartial');

        },
        error: function (data) {
            //console.log(data);
            $('#SizeBlock').load('/Admin/SizePartial');
        }
    });

}

function UpSize() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Size = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        Size.push({ 'Name': Name.value, 'Id': parseInt(Id) });
    });

    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "UpdateSize",
        data: {
            Sizes: Size,
        },
        success: function (data) {

            console.log(data);
            $('#SizeBlock').load('/Admin/SizePartial');

        }
    });
}

function DeletSize() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Size = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var Name = document.getElementById(Id + "-name");
        Size.push({ 'Name': Name.value, 'Id': parseInt(Id) });
    });

    if (Size.length == 0) {

        alert("Выбирете цвет для удаления");
    }


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "DeleteSize",
        data: {
            Sizes: Size,
        },
        success: function (data) {

            console.log(data);
            $('#SizeBlock').load('/Admin/SizePartial');

        },
        error: function (data) {
            //console.log(data);
            $('#SizeBlock').load('/Admin/SizePartial');
        }
    });
}


function AddProduct() {
    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "AddProduct",
        data: {
        },
        success: function (data) {

            console.log(data);
      

        }      
        ,error: function (data) {
            $('#ProductBlock').load('/Admin/ProductsPartial');
        }
    });
 
}

function DeletProduct() {


    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Products = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        Products.push({'Id': parseInt(Id) });
    });

    if (Products.length == 0) {

        alert("Выбирете товар для удаления");
    }


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "DeleteProduct",
        data: {
            Products: Products,
        },
        success: function (data) {

            console.log(data);

        }, error: function (data) {
            $('#ProductBlock').load('/Admin/ProductsPartial');
        }
    });

}


function SaveProductMain() {

    var ProductId = document.getElementById("ProductHidden");


    var Name = document.getElementById(ProductId.value + "-name");
    var ArtNo = document.getElementById(ProductId.value + "-artno");
    var Enabled = document.getElementById(ProductId.value + "-enabled");
    var Category = document.querySelector("select[name='" + ProductId.value + "-category']");

    var Product = {
        'Id': parseInt(ProductId.value),
        'Name': Name.value,
        'ArtNo': ArtNo.value,
        'Enabled': Enabled.checked,
        'CategoryId': parseInt(Category.value),
    };

    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../UpProductSTR",
        data: {
            Product: Product
        },
        success: function (data) {

            alert("Данные сохранены");

        }
    });

}






function AddOffer() {
    var Product = $('#ProductHidden');

    if (Product.length == 0) { alert("Не найден продукт"); return; }

    var ProductId = parseInt(Product[0].value);


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../AddOffer",
        data: {
            ProductId: ProductId
        },
        success: function (data) {

            console.log(data);
            $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);

        },
        error: function (data) {
            //console.log(data);
            $('#OfferBlock').load('/Admin/OffersPartial/'+ProductId);
        }
    });

}

function UpOffer() {
    var Product = $('#ProductHidden');
    var ProductId = parseInt(Product[0].value);

    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Offers = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var ArtNoOffer = $('#'+Id + "-artnoOffer");
        var ColorId = $('#' +Id + "-color");
        var SizeId = $('#' +Id + "-size");
        var Price = $('#' + Id + "-price");

        if ((ArtNoOffer.length == 0) || (ColorId.length == 0) || (SizeId.length == 0) || (Price.length == 0))
        { alert("Не найдены данные по офферу"); }
        else
        {
            Offers.push({
                'Id': parseInt(Id), 'ArtNo': ArtNoOffer[0].value, 'ColorId': parseInt(ColorId[0].value),
                'SizeId': parseInt(SizeId[0].value), 'Price': parseInt(Price[0].value)
            });
        }


    });


    if (Offers.length == 0)
    {
        return;
    }

    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../UpOffer",
        data: {
            Offers: Offers,
        },
        success: function (data) {
            $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        },
        error: function (data) {
            $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        }
    });


}

function DeletOffer() {


    var Product = $('#ProductHidden');
    var ProductId = parseInt(Product[0].value);

    var CheckboxSelected = document.querySelectorAll("input.selected-checked");

    var Offers = [];


    CheckboxSelected.forEach(function (item, i, checkbox) {
        var Id = item.id;
        var ArtNoOffer = $('#' + Id + "-artnoOffer");
        var ColorId = $('#' + Id + "-color");
        var SizeId = $('#' + Id + "-size");
        var Price = $('#' + Id + "-price");

        if ((ArtNoOffer.length == 0) || (ColorId.length == 0) || (SizeId.length == 0) || (Price.length == 0)) { alert("Не найдены данные по офферу"); }
        else {
            Offers.push({
                'Id': parseInt(Id), 'ArtNo': ArtNoOffer[0].value, 'ColorId': parseInt(ColorId[0].value),
                'SizeId': parseInt(SizeId[0].value), 'Price': parseInt(Price[0].value)
            });
        }
    });



    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../DelOffer",
        data: {
            Offers: Offers,
        },
        success: function (data) {
            $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        },
        error: function (data) {
            $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        }
    });
}


///CLient


function SelectOfferClient(Offer)
{
    var Product = $("#ProductIdHidden");
    var Colors = $("[name='color']");
    var Sizes = $("[name='size']");
    var ProductId = 0;
    

    var OfferIdPage = $("#OfferIdHidden");
    var sumPage = $("#Sum");
    var OfferArtNoPage = $("#ArtNoOffer");

    sumPage[0].innerText = Offer.Price;
    OfferArtNoPage[0].innerText = Offer.ArtNo;
    OfferIdPage[0].value = Offer.Id;

    for (let i = 0; i < Colors.length; i++)
    {

        var ColorItem = Colors[i];
        if (ColorItem.className.toString().indexOf("item-offer-selected") != -1)
        {
            ColorItem.classList.remove("item-offer-selected");
        }

        if (ColorItem.id == Offer.Id)
        {
            ColorItem.classList.add("item-offer-selected");
        }        
    }

    for (let y = 0; y < Sizes.length; y++) {
        var SizeItem = Sizes[y];
        if (SizeItem.className.toString().indexOf("item-offer-selected") != -1) {
            SizeItem.classList.remove("item-offer-selected");
        }

        if (SizeItem.id == Offer.Id) {
            SizeItem.classList.add("item-offer-selected");
        }     
    }




}



function SendProduct()
{
    var OfferIdPage = $("#OfferIdHidden");

    var OfferId = parseInt(OfferIdPage[0].value);
    if (OfferId == 0)
    {
        return;
    }


    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../../Basket/Sold",
        data: {
            OfferId: OfferId,
        },
        success: function (data) {
          //  $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        },
        error: function (data) {

            $('#Kol').load('/Basket/Count');
            $('#content').load('/Basket/Basket');
           // $('#max').load('/Basket/Max');
           // $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        }
    });
}


function OrderCreate() {
    var OrderName = $("#Name");
    var OrderPhone = $("#Phone");
    var OrderDelivery = $("#Delivery");
    var OrderPayment = $("#Payment");


    var Delivery = OrderDelivery[0].value;
    var Payment = OrderPayment[0].value;
    var Name = OrderName[0].value;
    var Phone = OrderPhone[0].value;

    var OrderNew =
    {
        'Name': Name,
        'PhoneNuber': Phone,
        'DeliveryName': Delivery,
        'PaymentString': Payment
    };



    $.ajax({
        dataType: "application/json",
        cache: false,
        type: "POST",
        url: "../../Order/CreateOrder",
        data: {
            OrderNew: OrderNew,
        },
        success: function (data) {
            //  $('#OfferBlock').load('/Admin/OffersPartial/' + ProductId);
        },
        error: function (data) {



            var response = JSON.parse(data.responseText);

            if (response.result) {
                alert(response.msg);
                //location = 'Order/Finaly/' + response.OrderId;
         

                var link_url = document.createElement("a");

                link_url.href = '../Order/Finaly/' + response.OrderId;
                document.body.appendChild(link_url);
                link_url.click();
                document.body.removeChild(link_url);
            }
            else {

                alert(response.msg);
            }


        }
    });



    console.log(OrderName);


}

function ClientOrderItem(OrderId) {
    //var OrderMain = $("#OrderMain");
    var OrderTable = $("#OrderTable");
    var OrderMain = $("#OrderMain");
    OrderTable[0].style.display = "none";
    OrderMain[0].style.display = "block";
    $('#OrderMain').load('/Client/ItemOrder?OrderId=' + OrderId);

}

function ClientOrderTable() {
    var OrderMain = $("#OrderMain");
    var OrderTable = $("#OrderTable");

    OrderTable[0].style.display = "block";
    OrderMain[0].style.display = "none";

    // $('#OrderTable').load('/Client/OrderItem?OrderId=' + OrderId);

}


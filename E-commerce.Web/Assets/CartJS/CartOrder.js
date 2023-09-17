
let busketitem = JSON.parse(localStorage.getItem("basket")) || [];
document.getElementById("items").innerText = busketitem.length;
const paymentmethodcharge = document.querySelectorAll(".payment-method");
const paymentmethodchargechange = document.querySelectorAll(".payment-method-items-method");
paymentmethodcharge.forEach((payment, index) => {
    payment.addEventListener("click", () => {
        let charge = $(".amount-charge").eq(index).text();
        let chargeid = $(".deliverychargeid").eq(index).text();
        $("#payment-method-selected").empty();
        $("#paymentvalue").val(parseInt(chargeid));
        $(".payment-method").eq(index).clone().appendTo("#payment-method-selected");
        let totalcoast = totalcalculation();
        let totalcoastcharge = parseInt(charge) + parseInt(totalcoast);
        document.getElementById("total-cart").innerHTML = "$" + totalcoastcharge.toString();
        authentication();
    });
});
$(".payment-method-items-method").attr('disabled', 'disabled');
paymentmethodchargechange.forEach((payment, index) => {
    payment.addEventListener("click", () => {
        let charge = $(".amount-charge").eq(index).text();
        let chargeid = $(".deliverychargeid").eq(index).text();
        $("#payment-method-selected").empty();
        $(".payment-method-items-method").eq(index).clone().appendTo("#payment-method-selected");
        $("#paymentvalue").val(parseInt(chargeid));
        let totalcoast = totalcalculation();
        let totalcoastcharge = parseInt(charge) + parseInt(totalcoast);
        document.getElementById("total-cart").innerHTML = "$" + totalcoastcharge.toString();
        $(".payment-method-items-method").attr('disabled', 'disabled');
    })
});
//let removeevent = () => {
//   // let paymentmethodchargechange = document.querySelectorAll(".payment-method-items-method");
//    paymentmethodchargechange.forEach((payment) => {
//        console.log(payment);
//        addevent();
//        payment.removeEventListener("click", addevent)
//    });
//}

$(".change-button").click(() => {
    paymentmethodchargechange.forEach((payment, index) => {
        // payment.addEventListener("click", addevent);
        payment.removeAttribute("disabled");
    });
});
let addtocart = (id) => {
    let productName = "product-Name-" + id;
    let productPrice = "product-cash-" + id;
    let productiamge = document.getElementById(id);
    let productprice = document.getElementById(productPrice).innerHTML.split('$');
    let searchitem = busketitem.find((x) => x.id === id);
    if (searchitem == undefined && $("#input-number").val() == null) {
        busketitem.push({
            id: id,
            productImage: productiamge.src,
            productname: document.getElementById(productName).innerHTML,
            productprice: parseInt(document.getElementById(productPrice).innerHTML.split('$')[1]),
            totalitem: 1
        });
    }
    else if (searchitem == undefined && $("#input-number").val() != null) {
        busketitem.push({
            id: id,
            productImage: productiamge.src,
            productname: document.getElementById(productName).innerHTML,
            productprice: productprice[1],
            totalitem: parseInt($("#input-number").val())
        });
    }
    else {
        busketitem.totalitem = parseInt($("#input-number").val());
    }
    document.getElementById("items").innerText = busketitem.length;
    localStorage.setItem("basket", JSON.stringify(busketitem));
    // console.log(busketitem);
}

let cartitemadded = (id) => {
    let finditem = busketitem.find((x) => x.id === id);
    finditem.totalitem = finditem.totalitem + 1;
    localStorage.setItem("basket", JSON.stringify(busketitem));
    totalcalculation();
    $("#cart-product-list").empty();
    busketitemlist();
}
let cartitemdecrement = (id) => {
    let finditem = busketitem.find((x) => x.id === id);
    finditem.totalitem = finditem.totalitem - 1;
    localStorage.setItem("basket", JSON.stringify(busketitem));
    totalcalculation();
    $("#cart-product-list").empty();
    busketitemlist();
}
let increment = (id) => {
    let finditem = busketitem.find((x) => x.id === id);
    finditem.totalitem = finditem.totalitem + 1;
    localStorage.setItem("basket", JSON.stringify(busketitem));
    $("#cart-list-item").empty();
    navbartcartlist();
}
let decrement = (id) => {
    let finditem = busketitem.find((x) => x.id === id);
    finditem.totalitem = finditem.totalitem - 1;
    localStorage.setItem("basket", JSON.stringify(busketitem));
    $("#cart-list-item").empty();
    navbartcartlist();
}
let navbartcartlist = () => {

    document.getElementById("cart-list-item").innerHTML = busketitem.map(function (element) {
        let { id, productImage, productname, productprice, totalitem } = element;
        return `
        <li>
        <div class="product-item-details">
            <div class="">
                <img src="${productImage}"  class="product-image"/>
            </div>
            <div >
                <p class="product-name">
                ${productname}
                </p>
            </div>
            <div class="d-flex">
                <div class="single-product-button-cart">
                    <span class="small-inumber-decrement-cart"  onclick="decrement(${parseInt(id)})" >- </span>
                    <input class="input-number-cart" id="input-number-${parseInt(id)}" type="number" value="${parseInt(totalitem)}">
                    <span class="small-number-increment-cart" onclick="increment(${parseInt(id)})">+</span>
                    <span class="multiplesign">*</span>
                </div>
                <p class="total-price" id="product-price-update">
                ${productprice}
                </p>
            </div>
        </div>
        </li>
      `;
    }).join("");
    totalcalculation();
}
$("#navbarDropdown3").click(() => {
    $("#cart-item").toggle();
    navbartcartlist();
});
/////// Dependable Dropdown//////
$("#val").change(() => {

    let zoneid = $("#val").val();
    $.ajax({
        url: "/cart/GetAreaName",
        Method: "POST",
        data: JSON.parse(data),
        success: function (zoneid) {
            $("#areaname").empty();
            data = JSON.parse(data);
            console.log(data);
            $.each(data, function (i, datavalue) {
                $('#areaname').append($('<option/>').attr("value", datavalue.ZoneId).text(datavalue.DevisionName));
            });
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    });
});


///////////////////////////////////
let totalcalculation = () => {
    let busketitemtotal = JSON.parse(localStorage.getItem("basket"));
    let totalcost = 0;
    let discountcode = $("#cuponinput").val();
    let totaldiscount = discountcode.match(/^\d+|\d+\b|\d+(?=\w)/g); //=> ["4567", "4", "67"]
    console.log(totaldiscount);
    let totaldiscountamount = totaldiscount / 100;
    console.log(totaldiscountamount);
    busketitemtotal.map(function (element) {
        let { productprice, totalitem } = element;
        totalcost = totalcost + (productprice * totalitem);
    });
    if (totaldiscount != null) {
        //  let totalcoastcartcost = document.getElementById("total-cart").innerHTML.split('$')[1];
         totalcost = totalcost * totaldiscountamount;
        //  $("#total-cart").text("$" + totalcoastcuppon.toString());
    }
    document.getElementById("total-cart").innerHTML = "$" + totalcost;
    document.getElementById("total-cost").innerHTML = `
    <h4>Total Bill : $ ${totalcost}</h4>
    <div class="cart-button-cancle">
    <a class="btn checkout" onclick="cartlist()" href="/cart/cart">Checkout</a>
    <button onclick="clearCart()" class="removeAll">Clear Cart</button>
    </div>
`
        ;
    $("#TotalPricevalue").val(totalcost);
    return totalcost;
}

let checkbusket = () => {
    busketitem = busketitem.filter((x) => x.totalitem > 0);
    localStorage.setItem("basket", JSON.stringify(busketitem));
    return busketitem
}
let summarylist = () => {
    //  console.log(cartallitem);
    let productitem = checkbusket();
    document.getElementById("cart-product-list-cart").innerHTML = productitem.map(function (element) {
        let { id, productImage, productname, productprice, totalitem } = element;
        return `
        <tr>                         
        <td>
            <div class="media">
                <div class="d-flex">
                    <img src="${productImage}" class="product-image" alt="" />
                </div>
                <div class="media-body">
                    <p>${productname}</p>
                </div>
            </div>
            <input id="product-Count-update" value="${id}" type="hidden" name="Productitem" readonly />
        </td>
        <td>
            <input id="product-Price-update" value="${productprice}" name="ProductPriceitem" readonly />
        </td>
        <td>
            <div class="product_count">
                <input id="product-Count-update" type="number" value="${totalitem}" name="Quantityitem" readonly />
            </div>
        </td>
        <td> 
             <h5>$<span id="product-price-update-${id}">${totalitem * productprice}</span>.00</h5>
        </td>
    </tr>
      `;
    }).join("");
    //    totalcalculation();
    let areaname = document.getElementById("areaname");
    let zonename = document.getElementById("val");
    let address = $("#adressbox").val();
    $("#customerfulladdress").val(address);
    $("#dictrictvalue").val(areaname.options[areaname.selectedIndex].text);
    $("#dictrictvalue").val(areaname.value);
    $("#zonename").val(zonename.value);
    localStorage.setItem("basket", JSON.stringify(cartitemlist));
}
let removeItem = (id) => {
    debugger;
    // let selectedItem = id;
    // console.log(selectedItem.id);
    busketitem = busketitem.filter((x) => x.id != id);
    //generateCartItems();
    localStorage.setItem("basket", JSON.stringify(busketitem));
    totalcalculation();
};

let cartitemlist = (id) => {
    debugger;
    removeItem(id);
    let productlist = $('#cart-product-list');
    productlist.empty();
    busketitemlist();
    totalcalculation();
}
let clearCart = () => {
    busketitem = [];
    //  generateCartItems();
    localStorage.setItem("basket", JSON.stringify(busketitem));
};
// Order summary and Order Set Details
const paymentmethoditem = document.querySelectorAll(".payment-method");
const deliverycharge = document.querySelectorAll(".amount-charge");
paymentmethoditem.forEach((paymentitem, index) => {
    paymentitem[index].addEventListener("click", () => {
        $("#paymentvalue").val(deliverycharge[index].innerHTML);
        $(".payment-image-summary").src = $(".payment-image").eq(index).src;
        $(".amount-charge-cart").innerText = $(".amount-charge").eq(index).innerText;
        $(".payment-method-details-cart").innerText = $(".payment-method-details").eq(index).innerText;
    });
});


// Track Order
let trackorder = () => {
    let orderid = $("#order").val();
    $("#trackoderdetails").toggle();
    $.ajax({
        url: "/cart/GetOrderDetails",
        Method: "POST",
        data: orderid,
        success: function (data) {
            data = JSON.parse(data);
            document.getElementById("cart-product-list-track").innerHTML = $.each(data, function (i) {
                element += `
            <tr>
            <td>
                <div class="media">
                    <div class="d-flex">
                        <img src="${productImage}" class="product-image" alt="" />
                    </div>
                    <div class="media-body">
                        <p>${productname}</p>
                    </div>
                </div>
            </td>
            <td>
                <h5>$${productprice}.00</h5>
            </td>
            <td>
                <div class="product_count">
                    <span></span>
                </div>
            </td>
            <td>
                <h5 id="product-price-update">$<span id="product-price-update">${totalitem * productprice}</span>.00</h5>
            </td>
        </tr>
            `;
            }).join("");

        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
};


///////////////////////////////////////////////////////////////
/////////////// Js Function Start //////////////////////////
////////////////////////////////////////////////////////////

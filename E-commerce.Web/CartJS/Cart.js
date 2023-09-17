const faqgallery = document.querySelectorAll(".payment-method");
const paymentmethod = document.querySelectorAll(".payment-method-items-method");
faqgallery.forEach((faq, index) => {
    faq.addEventListener("click", () => {
        for (s = 0; s < 6; s++) {
            $(".payment-method").eq(s).css("border-color", "lightgray");
        }
        $(".payment-method").eq(index).css("border-color", "orange");
    });
});
paymentmethod.forEach((faq, index) => {
    faq.addEventListener("click", () => {
        for (s = 0; s < 6; s++) {
            $(".payment-method").eq(s).css("border-color", "lightgray");
        }
        $(".payment-method").eq(index).css("border-color", "orange");
        $(".payment-method").eq(index).css("border-color", "orange");
    });
});
var i = 1;
$(".form-title").hide();
$(".cart_inner").hide();
$("#cartsummary").hide();
var activetab = document.getElementsByClassName("steps");
var icon = document.getElementsByClassName("fa");
activetab[0].classList.add("activefromitem");
$("#btn_1_submit").hide();
$(".cart_inner").hide();
$(".form-title").eq(0).show();
$(".cart_inner").eq(0).show();
function cartitem(n) {
    var steps = document.getElementsByClassName("steps");
    var steptitle = document.getElementsByClassName("form-title");
    var icon = document.getElementsByClassName("fa");
    i = i + (n);
    for (s = 0; s < 3; s++) {
        steps[s].classList.remove("activefromitem");
    }
    for (s = 0; s < i; s++) {
        steps[s].classList.add("activefromitem");
    }
    $(".form-title").hide();
    $(".form-title").eq(i - 1).show();
    $(".cart_inner").hide();
    $(".cart_inner").eq(i - 1).show();
    if (i == 3) {
        $("#btn_1_submit").show();
        $("#procedbutton").hide();
        $("#cartsummary").show();
        summarylist();
    }
    else {
        $("#procedbutton").show();
        $("#btn_1_submit").hide();
        $("#cartsummary").hide();
    }
}
$("#cupponbutton").click(() => {
    alert("hi");
    // totalcoastcuppon = 0.00;
    var totalpercentise = "";
    let cupponcode = $("#cuponinput").val();
    let lessamount = cupponcode.match(/^\d+|\d+\b|\d+(?=\w)/g); //=> ["4567", "4", "67"]
    let totalfree = lessamount[0] / 100;
    let totalcoastcart = document.getElementById("total-cart").innerHTML.split('$')[1];
    let totalcoastcuppon = totalcoastcart * totalfree;
    $("#total-cart").text(totalcoastcuppon.toString());
});
$("#cart-item").hide();




$("#cart-item").hide();
let busketitem=JSON.parse(localStorage.getItem("basket")) || [];
document.getElementById("items").innerText=busketitem.length;
let addtocart=(id)=>{
    let productName="product-Name-"+id;
    let productPrice="product-cash-"+id;
    let productiamge= document.getElementById(id);
    let productprice=document.getElementById(productPrice).innerHTML.split('$');
    let searchitem=busketitem.find((x)=>x.id===id);
    if(searchitem== undefined && $("#input-number").val() == null)
    {
        busketitem.push({
            id:id,
            productImage:productiamge.src,
            productname:document.getElementById(productName).innerHTML,
            productprice:parseInt(document.getElementById(productPrice).innerHTML.split('$')[1]),
            totalitem: 1
         });
    }
    else if(searchitem== undefined && $("#input-number").val() != null)
    {
        busketitem.push({
            id:id,
            productImage:productiamge.src,
            productname:document.getElementById(productName).innerHTML,
            productprice:productprice[1],
            totalitem: parseInt($("#input-number").val())
         });
    }
    else
    {
        busketitem.totalitem=parseInt($("#input-number").val());
    }
    document.getElementById("items").innerText=busketitem.length;
    localStorage.setItem("basket", JSON.stringify(busketitem));
   // console.log(busketitem);
}
let cartitemadded=(id)=>{
    let finditem=busketitem.find((x)=>x.id===id);
    finditem.totalitem=finditem.totalitem+1;
    let productid="#input-number-"+id;
    $(productid).val(finditem.totalitem);
    var total=(finditem.totalitem * finditem.productPrice).toString();
    console.log("$"+total.toString());
    document.getElementById("product-price-update").innerHTML="$"+total.toString();
    totalcalculation();
    localStorage.setItem("basket", JSON.stringify(busketitem));
}
let cartitemdecrement=(id)=>{
    let finditem=busketitem.find(x =>x.id===id);
    console.log(finditem)
    finditem.totalitem=finditem.totalitem-1;
    let productid="#input-number-"+id;
    $(productid).val(finditem.totalitem);
    document.getElementById("product-price-update").innerHTML="$"+(finditem.totalitem * finditem.productPrice).toString();
    totalcalculation();
    localStorage.setItem("basket", JSON.stringify(busketitem));
}
let increment=()=>{
   let increment=parseInt($("#input-number").val());
   increment+1;
   $("#input-number").val(increment);
   
}
let decrement=()=>{
    let decrement=parseInt($("#input-number").val());
    decrement-1;
    $("#input-number").val(decrement);
}
$("#navbarDropdown3").click(()=>{
    $("#cart-item").toggle();
    document.getElementById("cart-list-item").innerHTML=busketitem.map(function(element){
        let { id, productImage,productname,productprice,totalitem} = element;
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
                    <span class="small-inumber-decrement-cart"  onclick="cartitemdecrement(${parseInt(id)})" >- </span>
                    <input class="input-number-cart" id="input-number-${parseInt(id)}" type="number" value="${parseInt(totalitem)}">
                    <span class="small-number-increment-cart" onclick="cartitemadded(${parseInt(id)})">+</span>
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
});

let totalcalculation=()=>{
    let totalcost=0;
    busketitem.map(function(element){
        let {productprice,totalitem}= element;
       totalcost=totalcost+(productprice * totalitem) ;
    });
    console.log(totalcost);
    document.getElementById("total-cart").innerHTML="$"+totalcost;
    document.getElementById("total-cost").innerHTML=`
    <h4>Total Bill : $ ${totalcost}</h4>
    <div class="cart-button-cancle">
    <a class="btn checkout" href="/cart/cart">Checkout</a>
    <button onclick="clearCart()" class="removeAll">Clear Cart</button>
    </div>
`
    ;
    return totalcost;
}


// Cart Page
let cartlist=()=>{
    document.getElementById("cart-product-list").innerHTML=busketitem.map(function(element){
        let { id, productImage,productname,productprice,totalitem} = element;
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
        </td>
        <td>
            <h5>$${productprice}.00</h5>
        </td>
        <td>
            <div class="product_count">
                <span class="input-number-decrement" onclick="cartitemadded(${id})"> <i class="fa fa-plus fa-icon"></i></span>
                <input class="input-number" type="text" value="${totalitem}" min="0" max="10">
                <span class="input-number-increment" onclick="cartitemdecrement(${id})"> <i class="fa fa-minus fa-icons"></i></span>
            </div>
        </td>
        <td>
            <h5 id="product-price-update">$${totalitem * productprice}.00</h5>
        </td>
        <td>
        <button id="delete-item" onclick="removeItem(${id})">Remove</button>
        </td>
    </tr>
      `;
    }).join("");
    totalcalculation();
}
let summarylist=()=>{
    document.getElementById("cart-product-list").innerHTML=busketitem.map(function(element){
        let { id, productImage,productname,productprice,totalitem} = element;
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
        </td>
        <td>
            <h5>$${productprice}.00</h5>
        </td>
        <td>
            <div class="product_count">
                <span class="input-number-decrement" onclick="cartitemadded(${id})"> <i class="fa fa-plus fa-icon"></i></span>
                <input class="input-number" type="text" value="${totalitem}" min="0" max="10">
                <span class="input-number-increment" onclick="cartitemdecrement(${id})"> <i class="fa fa-minus fa-icons"></i></span>
            </div>
        </td>
        <td>
            <h5 id="product-price-update">$${totalitem * productprice}.00</h5>
        </td>
        <td>
        <button id="delete-item" onclick="removeItem(${id})">Remove</button>
        </td>
    </tr>
      `;
    }).join("");
    totalcalculation();
}
let removeItem = (id) => {
    let selectedItem = id;
    // console.log(selectedItem.id);
    busketitem = busketitem.filter((x) => x.id !== selectedItem.id);
    //generateCartItems();
    totalcalculation();
    localStorage.setItem("basket", JSON.stringify(busketitem));
  };
  
  let clearCart = () => {
    busketitem = [];
  //  generateCartItems();
    localStorage.setItem("basket", JSON.stringify(busketitem));
  };
  // Order summary and Order Set Details
  const paymentmethoditem=document.querySelectorAll(".payment-method");
  const deliverycharge=document.querySelectorAll(".amount-charge");
  paymentmethoditem.forEach((paymentitem,index)=>{
    paymentitem[index].addEventListener("click",()=>{
      $("#paymentvalue").val(deliverycharge[index].innerHTML);
      $(".payment-image-summary").src=$(".payment-image").eq(index).src;
      $(".amount-charge-cart").innerText=$(".amount-charge").eq(index).innerText;
      $(".payment-method-details-cart").innerText=$(".payment-method-details").eq(index).innerText;
    })
  })
let cartsummaryform=()=> {
    document.getElementById("cart-product-list-cart").innerHTML=busketitem.map(function(element){
        let { id, productImage,productname,productprice,totalitem} = element;
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
            <input id="product-Count-update" value="${id}" type="hidden" readonly />
        </td>
        <td>
            <input id="product-Price-update" value="${productprice}" readonly />
        </td>
        <td>
            <div class="product_count">
                <input id="product-Count-update" value="${totalitem}" readonly />
            </div>
        </td>
        <td> 
             <h5>$${totalitem * productprice}.00</h5>
        </td>
    </tr>
      `;
    }).join("");

}


  // Track Order
  let trackorder=()=>{
   let orderid= $("#order").val();
   $("#trackoderdetails").toggle();
   $.ajax({
    url: "/cart/GetOrderDetails",
    Method: "POST",
    data: orderid,
    success: function (data) {
        data = JSON.parse(data);
        document.getElementById("cart-product-list-track").innerHTML= $.each(data, function (i) {
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
                <h5 id="product-price-update">$${totalitem * productprice}.00</h5>
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
  }

  
// Global Function
cartlist();

// Multie Layer Form


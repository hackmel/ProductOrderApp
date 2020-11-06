import React, { useContext } from "react";
import { ProductsContext } from "../../App";
import {sendOrder} from "../../services/orders";





export const Order = () => {
  const {state, dispatch} = useContext(ProductsContext);


  const onSendOrder = () => {

    if(!state.orders || state.orders.length === 0){
      alert("Please select an item")
      return
    }
    let orders =  buildRequest(state.orders)

    sendOrder(orders).then(resp => {
       alert("Order successfully submitted")
    }).catch(e =>  {
      alert("An error has occured. Please try again later")
    })
  }

  const onNewOrder = () => {
      dispatch({type:'reset_order'})
  }

  const buildRequest = (orders) => {
     return orders.map((item) => {
       return {
          productId: item.id,
          quantity: item.quantity
       }
    })
  }

  return (
    <>
    <h1>Your orders</h1>
  <h2>Total Price: {state.totalPrice}</h2>
      {state.orders.map((item) => {
        return (
          <>
          <div>
            ID: {item.id}
          </div>
          <div>
            Name: {item.name}
          </div>
          <div>
          Price: {item.price}
          </div>
          <div>
          Quantity: {item.quantity}
          </div>

          <div>
          Total: {item.quantity * item.price.replace("$","")}
          </div>
          ===============================================
         </>
        );
      })}
    
    <div>
      <button onClick={onSendOrder}>Send Order</button>
      <button onClick={onNewOrder}>Reset</button>
    </div>

    </>
  );
};

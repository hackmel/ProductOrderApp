import React, { useState, useContext } from "react";
import { ProductsContext } from "../../App";

export const SelectOrder = ({item}) => {
    const {state, dispatch} = useContext(ProductsContext);
    const [quantity, setQuantity] = useState("0");


    const onInput = (e) => {
        setQuantity(e.target.value)
    }

    const addToOrder = () => {
        if( !quantity || isNaN(quantity) || parseInt(quantity) === 0 || parseInt(quantity) < 0) {
            alert("Please enter a valid quantity");
            return;
        }
        
        dispatch({type: 'add_order', payload: {...item, quantity: quantity, totalPrice: removeDollarSign(item.price) * quantity} })
    }

    const removeDollarSign = (price) => {
        return price.replace("$","");
    }

    return(
        <>
           <label>Quantity:</label>
           <input type ="text" onChange={onInput}></input>
           <button onClick={addToOrder}>Add to order</button>
        </>
    )
}


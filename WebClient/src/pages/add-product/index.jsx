import React, { useState, useContext } from "react";
import {addNewProduct} from "../../services/products"
import { ProductsContext } from "../../App";

export const AddProduct = () => {

    const {state, dispatch} = useContext(ProductsContext);
    

    const [name, setName]= useState("")
    const [price, setPrice]= useState("")

    const onNameInput = (e) => {
        setName(e.target.value)
    }

    const onPriceInput = (e) => {
        setPrice(e.target.value)
    }

    const onSubmit = () => {
    
        if(isNaN(price) || !price || price <=0) {
            alert("Please enter a valid price");
            return;
        }

        if(!name) {
            alert("Please enter a product name");
            return;
        }

        addNewProduct({name, price}).then((resp) => { 
            dispatch({type:'add_product', payload: {id: resp.id, name: name, price: price}})    

        }).catch(e =>  {
            alert("An error has occured. Please try again later")
        })
        
    }

    return(
        <>
        <div>
            <h1>Add new Product</h1>
            <label>Product name: </label>
            <input type="text" onChange={onNameInput}/>
            <label>Product price: </label>
            <input type="text" onChange={onPriceInput}/>
        </div>

        <div>
            <button onClick={onSubmit}>submit</button>
        </div>

        </>
    )
};

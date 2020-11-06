import React, { useContext, useEffect } from "react";
import { ProductItems } from "../../components/product-items";
import { ProductsContext } from "../../App";
import { AddProduct } from "../add-product";
import { Order } from "../order";

export const ProductList = () => {
  const {state, dispatch} = useContext(ProductsContext);

  useEffect(()=> {

    async function GetAllProducts() {
      const products = await (
        await fetch("https://localhost:44372/products")
      ).json();

      dispatch({type: 'display_products', payload: products})
    
    }
    GetAllProducts();
    
  },[])
  return ( 
     <>
      <AddProduct/>
      <hr></hr>
      <ProductItems items={state.products} />
      <hr></hr>
      <Order/>

     </>
    
    
    )
};

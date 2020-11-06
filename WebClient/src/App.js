import React from "react";


import "./App.css";
import {reducer} from "./model/reducer"
import { ProductList } from "./pages/product-list";


export const ProductsContext = React.createContext();

let initialState = {
  products: [],
  orders:[],
  totalPrice: 0
};

function App() {
  
  let [state, dispatch] = React.useReducer(reducer, initialState);
  let value = { state, dispatch };
 
  return (
    <>
      <h1>Product Order App</h1>

      <ProductsContext.Provider value={value}>
        <ProductList/> 
      </ProductsContext.Provider>
    </>
  );
}

export default App;

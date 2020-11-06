import React from "react";
import { Item } from "../item";
import { SelectOrder } from "../select-order";

export const ProductItems = ({ items }) => {
  return (
    <>
     <h2>Product List</h2>
      {items.map((item) => {
        return (
          <div>
            <SelectOrder key={item.id} item={item} />
            <Item key={item.id} item={item} /> 
          </div>
        );
      })}
    </>
  );
};

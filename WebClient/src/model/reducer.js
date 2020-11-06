


export const  reducer = (state, action) => {
    const { type, payload } = action;
    const {products, orders, totalPrice} = state;

    switch (action.type) {
      case "display_products":
        return {...state, products: payload };
      case "add_product":
        return { ...state, products:[...products, payload] };
      case "add_order":
            return { ...state, orders:[...orders, payload], totalPrice: totalPrice + payload.totalPrice };  
      case "reset_order":
            return { ...state, orders:[], totalPrice: 0 };  
         
    }
  };

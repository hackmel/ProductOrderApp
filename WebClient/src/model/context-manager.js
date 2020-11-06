

 let initialState = {
    products: productList
  };

  

  let [state, dispatch] = React.useReducer(reducer, initialState);
  let value = { state, dispatch };


  function ContextProvider(props) {
   
    let [state, dispatch] = React.useReducer(reducer, initialState);
    let value = { state, dispatch };
  
  
    // [B]
    return (
      <ContextProvider.Provider value={value}>{props.children}</ContextProvider.Provider>
    );
  }
  
  let ContextOneConsumer = ContextOne.Consumer;

  
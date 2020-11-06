export async function sendOrder(orders) {

    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(orders)
    };

    const products = await (
        await fetch("https://localhost:44372/orders",requestOptions)
      ).json();

    return new Promise(resolve => {   
          resolve(products);
    })
    

  }
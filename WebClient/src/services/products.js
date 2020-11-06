

 export async function addNewProduct({name, price}) {

    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: name, price: price })
    };

    const products = await (
        await fetch("https://localhost:44372/products",requestOptions)
      ).json();

    return new Promise(resolve => {   
          resolve(products);
    })
    

  }
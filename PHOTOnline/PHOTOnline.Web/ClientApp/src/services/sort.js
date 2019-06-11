export function sortOrdersByDate(orders) {
    let len = orders.length;
    for (let i = len-1; i>=0; i--){
     for(let j = 1; j<=i; j++){
       if(orders[j-1].Order.Date > orders[j].Order.Date){
            let temp = orders[j-1];
            orders[j-1] = orders[j];
            orders[j] = temp;
        }
     }
   }
   return orders;
}
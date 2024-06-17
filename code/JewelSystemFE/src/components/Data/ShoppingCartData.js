import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';
import { Link } from 'react-router-dom';
import { useCart } from 'react-use-cart';





export const ShoppingCartData = () =>{


    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal} = useCart();
    const totalPrice = (price,quantity) => {return price*quantity};


    return({
        columns: [
            {
                name: "PRODUCT IMAGE",
                // selector: (row) => row.image,
                cell: row => <><img className="avatar rounded lg border" src={Product1} alt="" /></>,
                sortable: true,
            },
            {
                name: "PRODUCT NAME",
                selector: (row) => row.productName,
                sortable: true,
            },
            {
                name: "PRODUCT ID",
                selector: (row) => row.productId,
                sortable: true,
            },
            {
                name: "QUANTITY",
                selector: (row) => row.quantity,
                sortable: true,
                cell: (row) => <input type="number" value={row.quantity} min='1' className="form-control" onChange={(e)=>{updateItemQuantity(row.id,e.target.value)}}/>
            },
            {
                name: "PRICE",
                selector: (row) => row.price,
                sortable: true
            },
            {
                name: "TOTAL",
                selector: (row) => totalPrice(row.price,row.quantity) ,
                sortable: true,
            },
            {
                name: "ACTION",
                selector:  (row) => row.id,
                sortable: false,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <Link type="button" className="btn btn-outline-secondary" onClick={()=>{console.log(cartTotal)}}><i className="icofont-edit text-success"></i></Link>
                    <button type="button" className="btn btn-outline-secondary deleterow" onClick={()=>{console.log(removeItem(row.id))}}><i className="icofont-ui-delete text-danger"></i></button>
                </div>
            }
        ],
        rows: items
    })
}
 


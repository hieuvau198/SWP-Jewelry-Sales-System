import { useCart } from "react-use-cart"

export const PricingData = () =>{
    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal,updateCartMetadata, metadata } = useCart();

    return ([
    {
        color:'',
        name: 'Subotal Price:',
        price:  new Intl.NumberFormat("de-DE").format(Math.round(cartTotal)) + 'd'
    },
    {
        color:'discount',
        name: 'Discount Price:',
        price:  new Intl.NumberFormat("de-DE").format(Math.round(cartTotal*metadata.discount/100)) + 'd'
    },
    {
        color:'shipping',
        name: 'Tax(18%):',
        price:  new Intl.NumberFormat("de-DE").format(Math.round(cartTotal*18/100)) + 'd'
    },
    
])}
    
import React from 'react';
import { PricingData } from '../../Data/CheckoutData/PricingData';
import { useCart } from "react-use-cart"

function Pricing() {
    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal,updateCartMetadata, metadata } = useCart();

    return (
        <div className="card-body">
            <div className="checkout-sidebar">
                <div className="checkout-sidebar-price-table mt-30">
                    <h5 className="title fw-bold">Pricing</h5>
                    <div className="sub-total-price">
                        {
                            PricingData().map((d, i) => {
                                return <div key={'a' + i} className={`total-price ${d.color}`}>
                                    <p className="value">{d.name}</p>
                                    <p className="price">{d.price}</p>
                                </div>
                            })
                        }
                    </div>
                    <div className='checkout'>

                    </div>
                    <div className="total-payable">
                        <div className="payable-price">
                            <p className="value fw-bold">Total Payable:</p>
                            <p className="price fw-bold"> {new Intl.NumberFormat("de-DE").format(Math.round(cartTotal-cartTotal*metadata.discount/100+cartTotal*18/100)) }d</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Pricing;
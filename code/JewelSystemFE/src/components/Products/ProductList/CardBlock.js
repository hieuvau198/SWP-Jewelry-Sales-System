import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getProduct } from '../../Data/ProductListdata';
// import axios from "../../../api/axios";
// import { useCookies } from 'react-cookie';
import { useCart } from 'react-use-cart';
import axios from '../../../api/axios';
import { ProductListdata } from '../../Data/ProductListdata';





function CardBlock() {


  const { addItem, items, setItems, getItem } = useCart();
  const [ product, setProduct ] = useState(ProductListdata);
  const handleCartCheckbox = (d,i) => {
    const checkbox = document.getElementById(i);
    if(checkbox.checked){
        d.id = d.productId;
        d.price = d.totalPrice;
        addItem(d);
    }
  }
  useEffect(() =>{

    axios.get('/product').then(res=>{
        const dataArr = res.data ; 
        console.log(dataArr); 
        setProduct(res.data); 
       
    }).catch(err=>{
        console.log(err); 
    }); 


}, [])


    return (
        <div className="card mb-3 bg-transparent p-2">
            {
                product?.map((d, i) => {
                    return <div key={i} className="card border-0 mb-1">
                    <div className="form-check form-switch position-absolute top-0 end-0 py-3 px-3 d-none d-md-block" >
                        <input className="form-check-input" type="checkbox" id={i} onChange={() => handleCartCheckbox(d,i)} />
                        <label className="form-check-label" htmlFor={i}>Add to Cart</label>
                    </div>
                        <div className="card-body d-flex align-items-center flex-column flex-md-row">
                            <Link to={process.env.PUBLIC_URL + "/product-detail"}>
                                <img className="w120 rounded img-fluid" src={d.productImages} alt="" />
                            </Link>
                            <div className="ms-md-4 m-0 mt-4 mt-md-0 text-md-start text-center w-100">
                                <Link to={process.env.PUBLIC_URL + "/product-detail"}><h6 className="mb-3 fw-bold">{d.productName}<span className="text-muted small fw-light d-block">{d.productCode}</span></h6></Link>
                                <div className="d-flex flex-row flex-wrap align-items-center justify-content-center justify-content-md-start">
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Quantity</div>
                                        <strong>{d.productQuantity}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Gem ID</div>
                                        <strong>{d.gemId}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Gem Weight</div>
                                        <strong>{d.gemWeight}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Gold ID</div>
                                        <strong>{d.goldId}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Gold Weight</div>
                                        <strong>{d.goldWeight}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Price</div>
                                        <strong>{new Intl.NumberFormat("de-DE").format(Math.round(d.totalPrice))}d</strong>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                })
            }
        </div>
    )
}
export default CardBlock;




import React, { useState } from 'react';
import useEffect from 'react';
import { Link } from 'react-router-dom';
import { useCart } from "react-use-cart";
import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { Modal } from 'react-bootstrap';

function Bankdetail() {

    const { auth } = useAuth();
    const [isModal, setIsModal] = useState();
    const [invoiceItId, setInvoiceItId] = useState({});
    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal,updateCartMetadata, metadata } = useCart();
    const INVOICE_URL = '/invoice';
    const INVOICE_ITEM_URL = '/invoiceitem';
    const PRODUCT_URL = '/product';

    function makeid(length) {
        let result = '';
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        const charactersLength = characters.length;
        let counter = 0;
        while (counter < length) {
          result += characters.charAt(Math.floor(Math.random() * charactersLength));
          counter += 1;
        }
        return result;
    }

    function createInvoice() {
        try{
            const id = makeid(5);
            const invoice = {
                "invoiceId": id,
                "invoiceType": "buy",
                "customerId": metadata.userId,
                "userId": auth,
                "invoiceDate": "2024-02-21T00:00:00",
                "customerVoucher": 0,
                "totalPrice": cartTotal,
                "endTotalPrice": Math.round(cartTotal-cartTotal*metadata.discount/100+cartTotal*18/100),
                "invoiceStatus": "payed"
            }
            axios.post(INVOICE_URL, invoice);
            items.map((d, i)=>{
                const res = axios.get(PRODUCT_URL + '/' + d.id);
                const invoiceItemId = id + "." + makeid(5);
                axios.post(INVOICE_ITEM_URL, {
                    "invoiceItemId": invoiceItemId,
                    "invoiceId": id,
                    "productId": d.id,
                    "productName": d.productName,
                    "quantity": d.quantity,
                    "unitPrice": res.unitPrice,
                    "discountId": "1",
                    "discountRate": res.discountRate,
                    "totalPrice": res.totalPrice,
                    "endTotalPrice": res.endTotalPrice,
                    "warrantyId": "W2"
                  });
                invoiceItId[invoiceItemId] = invoiceItemId
                setInvoiceItId(invoiceItId);
                  
            })
            console.log(invoiceItId);
            setIsModal(true);

        }catch(err){
            console.log(err)
        }
    }

    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0 align-items-center">
                <div className="form-check d-flex align-items-center">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" value='' onChange={() => { }} />
                    <label className="form-check-label fw-bold d-flex align-items-center" htmlFor="flexRadioDefault1">
                        <i className="icofont-mastercard-alt fs-3 mx-2"></i> Debit/Credit Card
                    </label>
                </div>
            </div>
            <div className="card-body">
                <form>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">Enter Card Number</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">Valid Date</label>
                            <input type="date" className="form-control w-100" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">CVV</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                    </div>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">valid date</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">production</label>
                            <input type="date" className="form-control w-100" value='' onChange={() => { }} />

                        </div>
                    </div>
                </form>
            </div>
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0 align-items-center">
                <div className="form-check d-flex align-items-center">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value='' onChange={() => { }} />
                    <label className="form-check-label fw-bold d-flex align-items-center" htmlFor="flexRadioDefault2">
                        <i className="icofont-world fs-3 mx-2"></i> Net Banking
                    </label>
                </div>
            </div>
            <div className="card-body">
                <form>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">Enter Your Name</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-12">
                            <label className="form-label">Account Number</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">Bank Name</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label htmlFor="admittime1" className="form-label">IFC Code</label>
                            <input type="text" className="form-control" id="admittime1" value='' onChange={() => { }} />
                        </div>
                    </div>

                    <Link onClick={()=>{createInvoice()}} className="btn btn-primary mt-4 text-uppercase">Pay Now</Link>

                </form>
                <button type="button" className="btn btn-primary" data-toggle="modal" onClick={()=>{ setIsModal(true ) }}  data-target="#exampleModalLive">Launch demo modal</button>

                <Modal show={isModal} onHide={()=>{setIsModal(false ) }}>
                    <Modal.Header>
                        <h5 className="modal-title" id="exampleModalLiveLabel">announcement</h5>
                        <button type="button" className="btn-close" onClick={()=>{ setIsModal(false ) }}  ></button>
                    </Modal.Header>

                    <Modal.Body>
                    <p>checkout complete!</p>
                    </Modal.Body>

                    <Modal.Footer>
                        <button type="button" className="btn btn-secondary" onClick={()=>{setIsModal(false ) }}>Close</button>
                    </Modal.Footer>
                </Modal>
            </div>
        </div>
    )
}
export default Bankdetail;
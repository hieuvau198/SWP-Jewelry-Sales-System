import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { ProductListdata } from '../../Data/ProductListdata';
import axios from "../../../api/axios";


function CardBlock() {

    const [table_row, setTable_row] = useState();
    const [productId, setProductId] = useState("");
    const [productCode, setProductCode] = useState("");
    const [productName, setProductName] = useState("");
    const [productImages, setProductImages] = useState("");
    const [productQuantity, setProductQuantity] = useState("");
    const [productType, setProductType] = useState("");
    const [productWeight, setProductWeight] = useState("");
    const [productWarranty, setProductWarranty] = useState("");
    const [markupRate, setMarkupRate] = useState("");
    const [gemId, setGemId] = useState("");
    const [gemWeight, setGemWeight] = useState("");
    const [goldId, setGoldId] = useState("");
    const [goldWeight, setGoldWeight] = useState("");
    const [laborCost, setLaborCost] = useState("");
    const [createdAt, setCreatedAt] = useState("");
    const getProduct = () => {
      let isMounted = true;
      const controller = new AbortController();
      const get = async () => {
        try {
          const response = await axios.get("/product");
          isMounted && setTable_row(response.data);
          console.log(JSON.stringify(response.data));
        } catch (err) {
          console.error(err);
        }
      };
      get();
      return () => {
        isMounted = false;
        controller.abort();
      };
    };
  



    return (
        <div className="card mb-3 bg-transparent p-2">
            {
                ProductListdata.map((d, i) => {
                    return <div key={i} className="card border-0 mb-1">
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
                                        <strong>{d.laborCost}$</strong>
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
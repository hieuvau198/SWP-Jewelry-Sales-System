import React from 'react';

function Categories() {
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Categories</h6>
            </div>
            <div className="card-body">
                <label className="form-label">Categories Select</label>
                <select className="form-select" size="3" aria-label="size 4 select example">
                    <option >Gaming accessories</option>
                    <option value="1">Watch</option>
                    <option value="2">Clothes</option>
                    <option value="3">Toy</option>
                    <option value="4">Cosmetic</option>
                    <option value="5">Laptop</option>
                    <option value="6">Mobile</option>
                </select>
            </div>
        </>
    )
}
export default Categories;
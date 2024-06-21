import React, { useState } from 'react';

function Sizeblock() {

    const [callopseSize, setCallopseSize] = useState(false);
    return (
        <div className="size-block" style={{ borderFamily: 'groove' }}>
            <div className="filter-title">
                <a className="title" data-bs-toggle="collapse" href="#size" role="button" onClick={() => { setCallopseSize(!callopseSize) }} aria-expanded={callopseSize}>Select Size</a>
            </div>
            <div className={`collapse ${callopseSize ? 'show' : ''}`} id="size">
                <div className="filter-size" id="filter-size-1">
                    <ul>
                        <li>XS</li>
                        <li>S</li>
                        <li className="">M</li>
                        <li>L</li>
                        <li>XL</li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Sizeblock;
import React, { useState } from 'react';

function ColorBlock () {
    const[callopseColor,setCallopseColor]=useState(false)
        return (
            <div className="color-block">
                <div className="filter-title">
                    <a className="title"  href="#color" role="button"  onClick={() => { setCallopseColor(!callopseColor ) }} aria-expanded={callopseColor}>Select Color</a>
                </div>
                <div className={`collapse ${callopseColor ? 'show' : ''}`} id="color">
                    <div className="filter-color">
                        <ul>
                            <li>
                                <div className="color-check">
                                    <p><span style={{ backgroundColor: '#4114e4' }}></span> <strong>Blue</strong></p>

                                    <input type="checkbox" id="color-1" />
                                    <label htmlFor="color-1"><span></span></label>
                                </div>
                            </li>
                            <li>
                                <div className="color-check">
                                    <p><span style={{ backgroundColor: '#E14C7B' }}></span> <strong>Red</strong></p>

                                    <input type="checkbox" id="color-2" />
                                    <label htmlFor="color-2"><span></span></label>
                                </div>
                            </li>
                            <li>
                                <div className="color-check">
                                    <p><span style={{ backgroundColor: '#7CB637' }}></span> <strong>Green</strong></p>

                                    <input type="checkbox" id="color-3" />
                                    <label htmlFor="color-3"><span></span></label>
                                </div>
                            </li>
                            <li>
                                <div className="color-check">
                                    <p><span style={{ backgroundColor: '#161359' }}></span> <strong>Dark</strong></p>

                                    <input type="checkbox" id="color-4" />
                                    <label htmlFor="color-4"><span></span></label>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        )
    }
export default ColorBlock;
import React, { useState } from 'react';

function Categoriesblock() {
    const [open, setOpen] = useState(false);
    const [callopseGame, setCallopseGame] = useState(false);
    const [callopseBags, setCallopseBags] = useState(false);
    const [callposeFlower, setCallposeFlower] = useState(false);
    const [collapseWatch, setCollapseWatch] = useState(false);
    const [collapseAccessories, setCollapseAccessories] = useState(false);
    return (
        <div className="categories">
            <div className="filter-title">
                <a className="title" data-bs-toggle="collapse" href="#!" role="button" onClick={() => { setOpen(!open) }} aria-expanded={open}>Categories</a>
            </div>
            <div className={`collapse ${open ? 'show' : ''}`} id="category">
                <div className="filter-search">
                    <form action="#">
                        <input type="text" placeholder="Search" className="form-control" />
                        <button><i className="lni lni-search-alt"></i></button>
                    </form>
                </div>
                <div className="filter-category">
                    <ul className="category-list">

                        <li>
                            <a href="#!" className='callopsed'
                                onClick={() => { setCallopseGame(!callopseGame) }}
                                aria-expanded={callopseGame}
                                aria-controls="collapseOne">Game accessories</a>

                            <ul id="collapseOne" className={`sub-category collapse ${callopseGame ? 'show' : ""}`}>
                                <li><a href="#!">PlayStation 4</a></li>
                                <li><a href="#!">Oculus VR</a></li>
                                <li><a href="#!">Remote</a></li>
                                <li><a href="#!">Lighting Keyborad</a></li>
                            </ul>
                        </li>
                        <li><a className="collapsed" href="#!" onClick={() => { setCallopseBags(!callopseBags) }} aria-expanded={callopseBags} >Bags</a>
                            <ul id="collapseTwo" className={`sub-category collapse ${callopseBags ? 'show' : ""}`}>
                                <li><a href="#!">School Bags</a></li>
                                <li><a href="#!">Traveling Bags</a></li>
                            </ul>
                        </li>
                        <li><a className="collapsed" href="#!" onClick={() => { setCallposeFlower(!callposeFlower) }} aria-expanded={callposeFlower}>Flower Port</a>
                            <ul id="collapseThree" className={`sub-category collapse ${callposeFlower ? 'show' : ''}`}>
                                <li><a href="#!">Woodan Port</a></li>
                                <li><a href="#!">Pattern Port</a></li>
                            </ul>
                        </li>
                        <li><a className="collapsed" href="#!" onClick={() => { setCollapseWatch(!collapseWatch) }} aria-expanded={collapseWatch}>Watch</a>
                            <ul id="collapseFour" className={`sub-category collapse ${collapseWatch ? 'show' : ''}`}>
                                <li><a href="#!">Wall Clock</a></li>
                                <li><a href="#!">Smart Watch</a></li>
                                <li><a href="#!">Rado Watch</a></li>
                                <li><a href="#!">Fasttrack Watch</a></li>
                                <li><a href="#!">Noise Watch</a></li>
                            </ul>
                        </li>
                        <li><a className="collapsed" href="#!" onClick={() => { setCollapseAccessories(!collapseAccessories) }} aria-expanded={collapseAccessories}>Accessories</a>
                            <ul id="collapseFive" className={`sub-category collapse ${collapseAccessories ? 'show' : ''}`}>
                                <li><a href="#!">Note Diaries</a></li>
                                <li><a href="#!">Fold Diaries</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}
export default Categoriesblock
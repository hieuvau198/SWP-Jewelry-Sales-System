import React, { useState } from 'react';

function RatingBlock() {
    const [callopsRating, setCallopsRating] = useState(false)
    return (
        <div className="rating-block">
            <div className="filter-title">
                <a className="title" data-bs-toggle="collapse" href="#rating" role="button" onClick={() => {setCallopsRating( !callopsRating ) }} aria-expanded={callopsRating}>Select Rating</a>
            </div>
            <div className={`collapse ${callopsRating ? 'show' : ''}`} id="rating">
                <div className="filter-rating">
                    <ul>
                        <li>
                            <div className="rating-check">
                                <input type="checkbox" id="rating-5" />
                                <label htmlFor="rating-5"><span></span>

                                </label>
                                <p>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                </p>
                            </div>
                        </li>
                        <li>
                            <div className="rating-check">
                                <input type="checkbox" id="rating-4" />
                                <label htmlFor="rating-4"><span></span></label>
                                <p>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                </p>
                            </div>
                        </li>
                        <li>
                            <div className="rating-check">
                                <input type="checkbox" id="rating-3" />
                                <label htmlFor="rating-3"><span></span></label>
                                <p>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                </p>
                            </div>
                        </li>
                        <li>
                            <div className="rating-check">
                                <input type="checkbox" id="rating-2" />
                                <label htmlFor="rating-2"><span></span></label>
                                <p>
                                    <i className="icofont-star"></i>
                                    <i className="icofont-star"></i>
                                </p>
                            </div>
                        </li>
                        <li>
                            <div className="rating-check">
                                <input type="checkbox" id="rating-1" />
                                <label htmlFor="rating-1"><span></span></label>
                                <p>
                                    <i className="icofont-star"></i>
                                </p>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}
export default RatingBlock;
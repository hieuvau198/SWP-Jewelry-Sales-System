import React from 'react';
import { ReviewDiscriptionData } from '../../Data/ProductdetailData';

function ReviewDiscription() {
    return (
        <ul className="list-unstyled mb-4">
            {
                ReviewDiscriptionData.map((d, i) => {
                    return <li key={'kdmowem' + i} className="card mb-2">
                        <div className="card-body p-lg-4 p-3">
                            <div className="d-flex mb-3 pb-3 border-bottom flex-wrap">
                                <img className="avatar rounded" src={d.image} alt="" />
                                <div className="flex-fill ms-3 text-truncate">
                                    <h6 className="mb-0"><span>{d.name}</span></h6>
                                    <span className="text-muted">{d.time}</span>
                                </div>
                                <div className="d-flex align-items-center">
                                    <span className="mb-2 me-3">
                                        <a href='#!' className="rating-link active"><i className="bi bi-star-fill text-warning"></i></a>
                                        <a href='#!' className="rating-link active"><i className="bi bi-star-fill text-warning"></i></a>
                                        <a href='#!' className="rating-link active"><i className="bi bi-star-fill text-warning"></i></a>
                                        <a href='#!' className="rating-link active"><i className="bi bi-star-fill text-warning"></i></a>
                                        <a href='#!' className="rating-link active"><i className="bi bi-star-half text-warning"></i></a>
                                    </span>
                                </div>
                            </div>
                            <div className="timeline-item-post">
                                <h6 className="">{d.productname}</h6>
                                <p>{d.productdiscription}</p>

                                {
                                    d.type === 'second' ? <div>
                                        <div className="d-flex mt-3 pt-3 border-top">
                                            <img className="avatar rounded" src={d.img} alt="" />
                                            <div className="flex-fill ms-3 text-truncate">
                                                <p className="mb-0"><span>{d.secondname}</span> <small className="msg-time text-muted">5 Day ago</small></p>
                                                <span className="text-muted">{d.secondtime}</span>
                                            </div>
                                        </div>

                                        <div className="mt-4">
                                            <textarea className="form-control" placeholder="Replay"></textarea>
                                        </div>
                                    </div> : null
                                }

                            </div>
                        </div>
                    </li>
                })
            }
        </ul>

    )
}
export default ReviewDiscription;
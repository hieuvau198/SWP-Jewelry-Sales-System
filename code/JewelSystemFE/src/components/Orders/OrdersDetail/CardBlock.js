import React from 'react';
import { OrderDetailData } from '../../Data/OrderDetailData';

function CardBlock() {
    return (
        <div className="row g-3 mb-3 row-cols-1 row-cols-sm-2 row-cols-md-2 row-cols-lg-2 row-cols-xl-4">
            {
                OrderDetailData.map((d, i) => {
                    return <div key={'s' + i} className="col">
                        <div className={`${d.mainbgColor} alert mb-0`}>
                            <div className="d-flex align-items-center">
                                <div className={`avatar rounded no-thumbnail ${d.bgColor} text-light`}><i className={d.icon}></i></div>
                                <div className="flex-fill ms-3 text-truncate">
                                    <div className="h6 mb-0">{d.name}</div>
                                    <span className="small">{d.secondName}</span>
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
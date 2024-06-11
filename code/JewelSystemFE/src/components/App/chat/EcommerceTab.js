import React from 'react';
import { EcommerceData } from '../../Data/chat/EcommerceData';


function EcommerceTab() {

    return (
        <>
            <ul className="list-unstyled list-group list-group-custom list-group-flush mb-0">
                {
                    EcommerceData.map((d, i) => {
                        return <li key={'s' + i} className="list-group-item px-md-4 py-3 py-md-4">
                            <a href="#!" className="d-flex">
                                <div className="avatar rounded no-thumbnail">{d.text}</div>
                                <div className="flex-fill ms-3 text-truncate">
                                    <h6 className="d-flex justify-content-between mb-0"><span>{d.name}
                                    </span> <small className="msg-time">{d.time}</small></h6>
                                    <span className="text-muted">{d.message}</span>
                                </div>
                            </a>
                        </li>
                    })
                }
            </ul>
        </>
    )
}
export default EcommerceTab;
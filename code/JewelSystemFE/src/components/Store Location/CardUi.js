import React from 'react';
import { CardUiData } from '../Data/StoreLocatorData';

function CardUi() {
    return (<>
        {
            CardUiData.map((d, i) => {
                return <div key={'s' + i} className="col">
                    <div className={`${d.bgcolor} alert mb-0`}>
                        <div className="d-flex align-items-center">
                            <div className={`avatar rounded no-thumbnail ${d.bgicon} text-light`}><i className={`${d.icon} fs-5`}></i></div>
                            <div className="flex-fill ms-3 text-truncate">
                                <div className="h6 mb-0">{d.text}</div>
                                <span className="small">{d.num}</span>
                            </div>
                        </div>
                    </div>
                </div>
            })
        }

    </>
    )
}
export default CardUi;
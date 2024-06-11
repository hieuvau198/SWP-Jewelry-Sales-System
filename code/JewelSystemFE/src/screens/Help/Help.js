import React from 'react';
import MiniBlock from '../../components/Help/MiniBlock';
import HelpBlock from '../../components/Help/HelpBlock';

function Help() {
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <div className="row clearfix">
                    <div className="col-xxl-3 col-xl-3 col-lg-3 col-md-12 flex-lg-column">
                        <MiniBlock />
                    </div>
                    <div className="col-xxl-9 col-xl-9 col-lg-9 col-md-12">
                        <HelpBlock />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Help;
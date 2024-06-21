import React from 'react';
import DateSchedule from '../../components/SalesPromotion/CouponsEdits/DateSchedule';
import CouponsStatus from '../../components/SalesPromotion/CouponsEdits/CouponsStatus';
import CouponsOInfo from '../../components/SalesPromotion/CouponsEdits/CouponsInfo';
import PageHeader1 from '../../components/common/PageHeader1';

function CouponsEdit () {
        return (
            <div className="body d-flex py-lg-3 py-md-2">
                <div className="container-xxl">
                <PageHeader1 pagetitle='Coupons Edit' button={true} />     
                    <div className="row clearfix g-3">
                        <div className="col-lg-4">
                            <CouponsStatus />
                            <div className="card">
                                <DateSchedule />
                            </div>
                        </div>
                        <div className="col-lg-8">
                            <CouponsOInfo />
                        </div>
                    </div>
                </div>
            </div>
        )
    }
export default CouponsEdit;
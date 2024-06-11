import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import CouponsOInfo from '../../components/SalesPromotion/CouponAdd/CouponsInfo';
import CouponsStatus from '../../components/SalesPromotion/CouponAdd/CouponsStatus';
import DateSchedule from '../../components/SalesPromotion/CouponAdd/DateSchedule';

function CouponsAdd() {
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Coupons Add' />
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
export default CouponsAdd;
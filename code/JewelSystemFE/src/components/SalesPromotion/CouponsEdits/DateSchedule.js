import React from 'react';

function DateSchedule() {
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Date Schedule</h6>
            </div>
            <div className="card-body">
                <div className="row g-3 align-items-center">
                    <div className="col-md-12">
                        <label className="form-label">Start Date</label>
                        <input type="date" className="form-control w-100" value="2021-03-08"/>
                    </div>
                    <div className="col-md-12">
                        <label className="form-label">End Date</label>
                        <input type="date" className="form-control w-100" value="2021-03-30"/>
                    </div>
                </div>
            </div>
        </>

    )
}
export default DateSchedule;
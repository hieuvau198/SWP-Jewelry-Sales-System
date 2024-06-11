import React from 'react';

function PublicaSchedule() {
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Publish Schedule</h6>
            </div>
            <div className="card-body">
                <div className="row g-3 align-items-center">
                    <div className="col-md-12">
                        <label className="form-label">Publish Date</label>
                        <input type="date" className="form-control w-100" value="2021-03-28" onChange={() => { }} />
                    </div>
                    <div className="col-md-12">
                        <label className="form-label">Publish Time</label>
                        <input type="time" className="form-control w-100" value="10:30" onChange={() => { }} />
                    </div>
                </div>
            </div>
        </>
    )
}
export default PublicaSchedule;
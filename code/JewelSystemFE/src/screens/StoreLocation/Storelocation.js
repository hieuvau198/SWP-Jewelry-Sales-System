import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import AddStore from '../../components/Store Location/AddStore';
import CardUi from '../../components/Store Location/CardUi';
import FindLocation from '../../components/Store Location/FindLocation';
import Gmap from '../../components/Store Location/Gmap';
import StoreDataTable from '../../components/Store Location/StoreDataTable';

function StoreLocation() {
    return (
        <div className="body d-flex py-3">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Store Locator' />

                <div className="row g-3 mb-3 row-cols-1 row-cols-sm-2 row-cols-md-2 row-cols-lg-2 row-cols-xl-4">
                    <CardUi />
                </div>
                <div id='googleMap' className="row g-3 mb-3">
                    <Gmap />
                </div>
                <div className="row g-3 mb-3 row-deck">
                    <div className="col-lg-6">
                        <FindLocation />
                    </div>
                    <div className="col-lg-6">
                        <AddStore />
                    </div>
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-lg-12">
                        <div className="card">
                            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                                <h6 className="m-0 fw-bold">Stores Data</h6>
                                <button type="button" className="btn btn-primary">Import Stores (CSV)</button>
                            </div>
                            <div className="card-body">
                                <div id="myDataTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <StoreDataTable />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default StoreLocation;
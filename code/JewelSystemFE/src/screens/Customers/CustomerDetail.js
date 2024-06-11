import React from 'react';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import AddressBlock from '../../components/Customers/CustomerDetails/AddressBlock';
import ExpenseCountBlock from '../../components/Customers/CustomerDetails/ExpenseCountBlock';
import StatusReport from '../../components/Customers/CustomerDetails/StatusReport';
import { CustomerDetailDatatable } from '../../components/Data/CustomerDetailData';

function CustomerDetail() {
    return (
        <div className="body d-flex py-3">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Customer Detail' />
                <div className="row g-3 mb-xl-3">
                    <div className="col-xxl-12 col-xl-12 col-lg-12 col-md-12">
                        <AddressBlock />
                        <div className="card">
                            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                                <h6 className="mb-0 fw-bold ">Customer Order</h6>
                            </div>
                            <div className="card-body">
                                <div id="myProjectTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <div className="col-sm-12">
                                            <DataTable
                                                columns={CustomerDetailDatatable.columns}
                                                data={CustomerDetailDatatable.rows}
                                                defaultSortField="title"
                                                pagination
                                                selectableRows={false}
                                                className="table myDataTable table-hover align-middle mb-0 d-row nowrap dataTable no-footer dtr-inline"
                                                highlightOnHover={true}
                                            />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-xxl-12 col-xl-12 col-lg-12 col-md-12">
                        <div className="row row-cols-1 row-cols-sm-1 row-cols-md-1 row-cols-lg-2 row-cols-xl-2 row-cols-xxl-1 row-deck g-3">
                            <div className="col">
                                <ExpenseCountBlock />
                            </div>
                        </div>
                        <div className="card mt-3">
                            <StatusReport />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default CustomerDetail;
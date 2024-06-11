import React from 'react';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import { OrderVoiceData } from '../../components/Data/OrderInvoiceData';

function OrderInvoice() {
    return (
        <div className="body d-flex py-3">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Order Invoices' />
                <div className="row mb-3">
                    <div className="col-sm-12">
                        <div className="card">
                            <div className="card-body">
                                <div id="patient-table_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <div className="col-sm-12">
                                            <DataTable
                                                columns={OrderVoiceData.columns}
                                                data={OrderVoiceData.rows}
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
                </div>
            </div>
        </div>

    )
}
export default OrderInvoice;
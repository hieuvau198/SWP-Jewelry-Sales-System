import React from 'react';
import DataTable from 'react-data-table-component';
import { RecentTransactionData } from '../Data/RecentTransactionData';

function RecentTransaction() {
    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Recent Transactions</h6>
            </div>
            <div className="card-body">
                <div id="myDataTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer" >
                    <div className="row">
                        <div className="col-sm-12">
                            <DataTable
                                title={RecentTransactionData.title}
                                columns={RecentTransactionData.columns}
                                data={RecentTransactionData.rows}
                                defaultSortField="title"
                                selectableRows={false}
                                highlightOnHover={true}
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default RecentTransaction;
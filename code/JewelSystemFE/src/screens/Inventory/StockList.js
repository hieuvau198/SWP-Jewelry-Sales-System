import React from 'react';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import { StockListData } from '../../components/Data/StockListData';

function StockList () {
        return (
            <div className="body d-flex py-3">
                <div className="container-xxl">
                    <PageHeader1 pagetitle='Stock Inventory List' />
                    <div className="row g-3 mb-3">
                        <div className="col-md-12">
                            <div className="card">
                                <div className="card-body">
                                    <div id="myDataTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                        <div className="row">
                                            <div className="col-sm-12">
                                                <DataTable
                                                    columns={StockListData.columns}
                                                    data={StockListData.rows}
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
export default StockList;
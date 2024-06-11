import React, { useState } from 'react';
import DataTable from 'react-data-table-component';
import { Link } from 'react-router-dom';
import PageHeader1 from '../../components/common/PageHeader1';
import { CouponsListData } from '../../components/Data/CouponsListData';

function CouponsList() {
    const [table_row, setTable_row] = useState([...CouponsListData.rows]);
    const columns = () => {
        return [
            {
                name: "COUPONS CODE",
                selector: (row) => row.code,
                sortable: true,
            },
            {
                name: "TYPE",
                selector: (row) => row.type,
                sortable: true,
            },
            {
                name: "DISCOUNT",
                selector: (row) => row.discount,
                sortable: true

            },
            {
                name: "START DATE",
                selector: (row) => row.startdate,
                sortable: true
            },
            {
                name: "END DATE",
                selector: (row) => row.enddate,
                sortable: true
            },
            {
                name: "STATUS",
                selector: (row) => row.status,
                sortable: true,
                cell: row => <span className={`badge ${row.status === "Active" ? 'bg-success' : row.status === "Future Plann" ? "bg-warning" : "bg-danger"}`}>{row.status}</span>
            },
            {
                name: "DISCOUNT COUNTRY",
                selector: (row) => row.country,
                sortable: true
            },
            {
                name: "DISCOUNT PRODUCT",
                selector: (row) => row.product,
                sortable: true
            },
            {
                name: "ACTION",
                selector: (row) => { },
                sortable: true,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <Link to={process.env.PUBLIC_URL + '/coupons-edit'}><button type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button></Link>
                    <button type="button" onClick={() => { onDeleteRow(row) }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                </div>
            }
        ]
    }
    async function onDeleteRow(row) {
        //eslint-disable-next-line
        var result = await table_row.filter((d) => { if (d !== row) { return d } });
        
        setTable_row([...result])
    }
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Coupons' righttitle='Add Coupons' link='/coupons-add' routebutton={true} />
                <div className="row clearfix g-3">
                    <div className="col-sm-12">
                        <div className="card mb-3">
                            <div className="card-body">
                                <div id="myProjectTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <div className="col-sm-12">

                                            <DataTable
                                                columns={columns()}
                                                data={table_row}
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
export default CouponsList;
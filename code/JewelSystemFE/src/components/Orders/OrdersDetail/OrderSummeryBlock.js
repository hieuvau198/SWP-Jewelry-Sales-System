import React, { useState } from 'react';
import DataTable from 'react-data-table-component';
import { OrderDetailDataTable } from '../../Data/OrderDetailData';

function OrderSummeryBlock() {
    //eslint-disable-next-line
    const [table_row, setTable_row] = useState([...OrderDetailDataTable.rows])
    const columns = () => {
        return [
            {
                name: " PRODUCT IMAGE",
                selector: (row) => row.image,
                cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /></>,
                sortable: true,
            },
            {
                name: "PRODUCT NAME",
                selector: (row) => row.productName,
                sortable: true,
                cell: row => <>
                    <div className='row'><h6 className="title ">{row.productName}</h6><span className='d-block fs-6 text-primary'>{row.preOrder}</span></div></>,

            },
            {
                name: "QUANTITY",
                selector: (row) => row.quanty,
                sortable: true,
            },
            {
                name: "PRICE",
                selector: (row) => row.price,
                sortable: true
            },
        ]
    }
    return (
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
    )
}
export default OrderSummeryBlock;
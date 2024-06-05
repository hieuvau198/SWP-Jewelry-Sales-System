import React from 'react';
import DataTable from 'react-data-table-component';
import { Storetable } from '../Data/StoreLocatorData';

function StoreDataTable() {
    return (
        <div className="col-sm-12">
            <DataTable
                title={Storetable.title}
                columns={Storetable.columns}
                data={Storetable.rows}
                defaultSortField="title"
                pagination
                selectableRows={false}
                highlightOnHover={true}
            />
        </div>
    )
}
export default StoreDataTable;
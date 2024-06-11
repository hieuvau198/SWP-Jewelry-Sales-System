import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import BasicTable from '../../components/Other Pages/Table Example/BasicTable';
import HoverableTable from '../../components/Other Pages/Table Example/HoverableTable';
import StripedTable from '../../components/Other Pages/Table Example/StripedTable';
import TableDataTable from '../../components/Other Pages/Table Example/TableDataTable';
import VariantsTable from '../../components/Other Pages/Table Example/VariantsTable';

function TableExample() {
    return (
        <div className='body d-flex py-3'>
            <div className="container-xxl">
                <PageHeader1 pagetitle='Tables' />
                <div className="row align-item-center">
                    <div className="col-md-12">
                        <BasicTable />
                        <VariantsTable />
                        <StripedTable />
                        <HoverableTable />
                        <TableDataTable />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default TableExample;
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
export const PurchaseData = {
   
    columns: [
        {
            name: " ID",
            selector: (row) => row.id,
            sortable: true,
        },
        {
            name: "ITEMS",
            selector: (row) => row.item,
            sortable: true,
           
        },
        
        {
            name: "PURCHASE STATUS",
            selector: (row) => row.status,
            sortable: true,
            cell: row => <span className='badge bg-success'>{row.status}</span>
        },
        {
            name: "ORDER BY",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "DATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "SUPPLIER",
            selector: (row) => row.supplier,
            sortable: true
        },
        {
            name: "TOTAL",
            selector: (row) => row.total,
            sortable: true
        },
        {
            name: "PAID",
            selector: (row) => row.paid,
            sortable: true
        },
        {
            name: "BALANCE",
            selector: (row) => row.balance,
            sortable: true
        },
        {
            name: "CREDIT",
            selector: (row) => row.credit,
            sortable: true
        },
        {
            name: "Payment Status",
            selector: (row) => row.paymentstatus,
            sortable: true,
            cell: row => <span className={`badge ${row.paymentstatus === "pending" ?"bg-warning": 'bg-success'}`}>{row.status}</span>
        },
        {
            name: "ACTION",
            selector: (row) => { },
            sortable: true,
            cell: () => <div className="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
            </div>
        }

    ],
    rows: [
        {
            id:'#PR-00002',
            item:'Cloth',
            status:'Item Recived',
            image:Avatar1,
            name:'Joan Dyer',
            date:'12/03/2021',
            supplier: 'Cloth Supplier',
            total:'$1551',
            paid:'$1500',
            balance:'$51',
            credit:'3 Month',
            paymentstatus:'pending'
            
        },
        {
            id:'#PR-00004',
            item:'Cycle',
            status:'Item Recived',
            image:Avatar2,
            name:'Phil Glover',
            date:'16/03/2021',
            supplier: 'Toy Supplier',
            total:'	$1551',
            paid:'$1500',
            balance:'$51',
            credit:'3 Month',
            paymentstatus:'pending'
            
        },
        {
            id:'#PR-00006',
            item:'Shoes',
            status:'Item Recived',
            image:Avatar3,
            name:'Ryan Randall',
            date:'12/03/2021',
            supplier: 'Footwear Supplier',
            total:'$1551',
            paid:'$1500',
            balance:'$51',
            credit:'3 Month',
            paymentstatus:'pending'
            
        },
        {
            id:'#PR-00011',
            item:'Oil',
            status:'Item Recived',
            image:Avatar4,
            name:'Victor Rampling',
            date:'25/02/2021',
            supplier: '	Grocery Supplier',
            total:'$1551',
            paid:'$1500',
            balance:'$51',
            credit:'2 Month',
            paymentstatus:'complete'
            
        },
        {
            id:'#PR-00014',
            item:'Sunglasses',
            status:'Item Recived',
            image:Avatar1,
            name:'Robert Anderson',
            date:'18/01/2021',
            supplier: 'Sunglass Supplier',
            total:'$1551',
            paid:'$1500',
            balance:'$51',
            credit:'2 Month',
            paymentstatus:'complete'
            
        },
        {
            id:'#PR-00018',
            item:'Watch',
            status:'Item Recived',
            image:Avatar1,
            name:'Sally Graham',
            date:'16/02/2021',
            supplier: 'Watch Supplier',
            total:'$1551',
            paid:'$1500',
            balance:'$51',
            credit:'1 Month',
            paymentstatus:'complete'
            
        },
    ]
}

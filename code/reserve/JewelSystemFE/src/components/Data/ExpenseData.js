import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
export const ExpenseData = {
   
    columns: [
        {
            name: " ID",
            selector: (row) => row.id,
            sortable: true,
        },
        {
            name: "EXP ITEM",
            selector: (row) => row.item,
            sortable: true,
           
        },
        {
            name: "EXP ORDER BY",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /> <span>{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "DATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "FROM",
            selector: (row) => row.from,
            sortable: true
        },
        {
            name: "AMOUNT",
            selector: (row) => row.amount,
            sortable: true
        },
        {
            name: "STATUS",
            selector: (row) => row.status,
            sortable: true,
            cell: row => <span className={`badge ${row.status === "Completed" ? 'bg-success' : "bg-warning"}`}>{row.status}</span>
        },
        {
            name: "ACTIONS",
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
            id:'#EX-00002',
            item:'Mortgage Payments',
            image:Avatar1,
            name:'Joan Dyer',
            date:'12/05/2021',
            from: '	Office Owner',
            amount:'$50000',
            status:'In Progress'
            
        },
        {
            id:'#EX-00004',
            item:'Taxes',
            image:Avatar2,
            name:'Phil Glover',
            date:'16/04/2021',
            from: 'Goverment',
            amount:'$125897',
            status:'In Progress'
            
        },
        {
            id:'#EX-00006',
            item:'Business Insurance',
            image:Avatar3,
            name:'Ryan Randall',
            date:'12/04/2021',
            from: 'Insurance Company',
            amount:'$20000',
            status:'In Progress'
            
        },
        {
            id:'#EX-00011',
            item:'Advertising and marketing',
            image:Avatar4,
            name:'Victor Rampling',
            date:'25/03/2021',
            from: 'Marketing Company',
            amount:'$6000',
            status:'Completed'
            
        },
        {
            id:'#EX-00014',
            item:'Salary',
            image:Avatar1,
            name:'Robert Anderson',
            date:'	01/05/2021',
            from: 'Company Saff',
            amount:'$60000',
            status:'Completed'
        },
        {
            id:'#EX-00018',
            item:'Office equipment.',
            image:Avatar1,
            name:'Sally Graham',
            date:'16/03/2021',
            from: 'Suppliers',
            amount:'$1500',
            status:'Completed'
        },
    ]
}

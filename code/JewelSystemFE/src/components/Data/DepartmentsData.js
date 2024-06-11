import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
export const DepartmentsData = {
   
    columns: [
        {
            name: " ID",
            selector: (row) => row.id,
            sortable: true,
            maxWidth:'50px'
        },
       
        {
            name: "DEPARTMENTS HEAD",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded-circle lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, 
        },
        {
            name: "DEPARTMENTS NAME",
            selector: (row) => row.Dname,
            sortable: true
        },
        {
            name: "STAFF UNDERWORK",
            selector: (row) => row.staff,
            sortable: true
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
            id:'1',
            image:Avatar1,
            name:'Joan Dyer',
            Dname:'Logistics',
            staff:'40',
        },
        {
            id:'2',
            image:Avatar2,
            name:'Ryan Randall',
            Dname:'Digital Marketing',
            staff:'48',
        },
        {
            id:'3',
            image:Avatar3,
            name:'Phil Glover',
            Dname:'Customer Service',
            staff:'15',
        },
        {
            id:'4',
            image:Avatar4,
            name:'Victor Rampling',
            Dname:'Inventory Associates',
            staff:'	39',
        },
        {
            id:'5',
            image:Avatar1,
            name:'Sally Graham',
            Dname:'Finance and Accounting',
            staff:'12',
        },
        {
            id:'6',
            image:Avatar2,
            name:'Robert Anderson',
            Dname:'Business Analyst',
            staff:'8',
        },
    ]
}

import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
export const supplierData = {
   
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
            name: "SUPPLIERS",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "SUPPLIERS REGDATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "MAIL",
            selector: (row) => row.mail,
            sortable: true
        },
        {
            name: "PHONE",
            selector: (row) => row.phone,
            sortable: true
        },
        {
            name: "ADDRESS",
            selector: (row) => row.address,
            sortable: true
        },
        {
            name: "TAX_NUM",
            selector: (row) => row.taxnum,
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
            id:'#SP-00002',
            item:'Cloth',
            image:Avatar1,
            name:'Joan Dyer',
            date:'12/03/2021',
            mail: 'JoanDyer@gmail.com',
            phone:'	202-555-0983',
            address:' 70 Bowman St. South Windsor, CT 06074',
            taxnum:' 5869'
            
        },
        {
            id:'#SP-00004',
            item:'Cycle',
            image:Avatar2,
            name:'Phil Glover',
            date:'16/03/2021',
            mail: 'PhilGlover@gmail.com',
            phone:'843-555-0175',
            address:' 4 Shirley Ave. West Chicago, IL 60185',
            taxnum:' 4659'
        },
        {
            id:'#SP-00006',
            item:'Shoes',
            image:Avatar3,
            name:'Ryan Randall',
            date:'12/03/2021',
            mail: 'RyanRandall@gmail.com',
            phone:'	303-555-0151',
            address:'123 6th St. Melbourne, FL 32904',
            taxnum:' 4568'
        },
        {
            id:'#SP-00011',
            item:'	Oil',
            image:Avatar4,
            name:'Victor Rampling',
            date:'25/02/2021',
            mail: 'VictorRampling@gmail.com',
            phone:'404-555-0100',
            address:' 123 6th St. Melbourne, FL 32904',
            taxnum:' 2567'
        },
        {
            id:'#SP-00014',
            item:'Sunglasses',
            image:Avatar1,
            name:'Robert Anderson',
            date:'18/01/2021',
            mail: 'RobertAnderson@gmail.com',
            phone:'502-555-0133',
            address:' 123 6th St. Melbourne, FL 32904',
            taxnum:'6584'
        },
        {
            id:'#SP-00018',
            item:'Watch',
            image:Avatar2,
            name:'Sally Graham',
            date:'16/02/2021',
            mail: 'SallyGraham@gmail.com',
            phone:'502-555-0118', 
            address:' 4 Shirley Ave. West Chicago, IL 60185',
            taxnum:' 7586'
        },
    ]
}
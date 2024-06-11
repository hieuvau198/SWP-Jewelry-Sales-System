import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';


export const RetrunData = {
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
            minWidth: "100px"
        },
        {
            name: "CUSTOMER",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "RETURN DATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "TOTAL",
            selector: (row) => row.total,
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
            id: '#RT-00002',
            item: 'Cloth',
            image: Avatar1,
            name: 'Joan Dyer',
            date: '12/03/2021',
            total: '$1551',
        },
        {
            id: '#RT-00004',
            item: 'Cycle',
            image: Avatar2,
            name: 'Phil Glover',
            date: '16/03/2021',
            total: '$1551',
        },
        {
            id: '#RT-00006',
            item: 'Shoes',
            image: Avatar3,
            name: 'Ryan Randall',
            date: '12/03/2021',
            total: '$1551',
        },
        {
            id: '#RT-00011',
            item: 'Oil',
            image: Avatar4,
            name: 'Victor Rampling',
            date: '	25/02/2021',
            total: '$1551',
        },
        {
            id: '#RT-00014',
            item: 'Sunglasses',
            image: Avatar1,
            name: 'Robert Anderson',
            date: '18/01/2021',
            total: '$1551',
        },
        {
            id: '#RT-00018',
            item: 'Watch',
            image: Avatar1,
            name: 'Sally Graham',
            date: '16/02/2021',
            total: '$1551',
        },
    ]
}


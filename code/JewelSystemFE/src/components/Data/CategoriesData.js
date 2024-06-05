
export const CategoriesData = {

    columns: [
        {
            name: " ID",
            selector: (row) => row.idnum,
            sortable: true,
        },
        {
            name: "CATEGORIES",
            selector: (row) => row.name,
            sortable: true, minWidth: "250px"
        },
        {
            name: "DATE",
            selector: (row) => row.date,
            sortable: true,
            minWidth: "250px"
        },

        {
            name: "STATUS",
            selector: (row) => row.status,
            sortable: true,
            cell: row => <span className={`badge ${row.status === "Published"?'bg-success': row.status ==='Hidden' ? 'bg-danger':  "bg-warning"}`}>{row.status}</span>
        },
        {
            name: "ACTION",
            selector: (row) => { },
            sortable: true,
            cell: () => <div className="btn-group" role="group" aria-label="Basic outlined example">
                <a type="button" href="/categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></a>
                <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
            </div>
        }
    ],
    rows: [
        {
           idnum:'#0001',
           name:'Watch',
           date:'March 13, 2021',
           status:'Published'
        },
        {
            idnum:'#0002',
            name:'Toy',
            date:'January 14, 2021',
            status:'Scheduled'
         },
         {
            idnum:'#0003',
            name:'Laptop',
            date:'February 08, 2021',
            status:'Published'
         },
         {
            idnum:'#0004',
            name:'Mobile',
            date:'April  02, 2021',
            status:'Scheduled'
         },
         {
            idnum:'#0005',
            name:'Tv',
            date:'June 19, 2021',
            status:'Published'
         },
         {
            idnum:'#0006',
            name:'Cloths',
            date:'April 10, 2021',
            status:'Scheduled'
         },
         {
            idnum:'#0007',
            name:'Footwear',
            date:'May 11, 2021',
            status:'Published'
         },
         {
            idnum:'#0008',
            name:'Kitchenware',
            date:'June 13, 2021',
            status:'Hidden'
         },
         {
            idnum:'#0009',
            name:'Beautywear',
            date:'June 13, 2021',
            status:'Hidden'
         },
         {
            idnum:'#0010',
            name:'Game accessories',
            date:'February 13, 2021',
            status:'Published'
         },
      
    ]
}


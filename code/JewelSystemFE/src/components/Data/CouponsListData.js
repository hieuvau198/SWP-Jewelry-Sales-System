

export const CouponsListData = {
   
    columns: [
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
            cell: row => <span className={`badge ${row.status === "Active" ? 'bg-success':row.status === "Future Plann" ?  "bg-warning":"bg-danger"}`}>{row.status}</span>
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
            cell: () => <div className="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
            </div>
        }

    ],
    rows: [
        {
           code:'AXXQT-2547',
           type:'Percentage',
           discount:'20%',
           startdate:'08/03/2021',
           enddate:'30/03/2021',
           status:'In active',
           country:'India',
           product:'Watches'
        },
        {
            code:'BATTT-XA47',
            type:'Fixed Amount',
            discount:'	$18.00',
            startdate:'06/05/2021',
            enddate:'06/09/2021',
            status:'Active',
            country:'Oman',
            product:'Shoes'
         },
         {
            code:'DTZQT-8547',
            type:'Fixed Amount',
            discount:'	$12.6',
            startdate:'18/08/2021',
            enddate:'06/09/2021',
            status:'Active',
            country:'South Africa',
            product:'Clothes'
         },
         {
            code:'FALT-40',
            type:'Percentage',
            discount:'18%',
            startdate:'16/04/2021',
            enddate:'06/09/2021',
            status:'Active',
            country:'Oman',
            product:'Shoes'
         },
         {
            code:'FiFty-50%',
            type:'Percentage',
            discount:'50%',
            startdate:'08/03/2021',
            enddate:'30/03/2021',
            status:'Future Plann',
            country:'India',
            product:'toy'
         },
         {
            code:'SHIP-ZERO',
            type:'Free shipping',
            discount:'$0.0',
            startdate:'12/05/2021',
            enddate:'06/10/2021',
            status:'Active',
            country:'Denmark',
            product:'cream tube'
         },
    ]
}

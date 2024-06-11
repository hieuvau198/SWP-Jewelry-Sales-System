export const Storetable = {
   
    columns: [
        {
            name: " NAME",
            selector: (row) => row.name,
            sortable: true,
        },
        {
            name: "GEOCODED",
            selector: (row) => row.code,
            sortable: true,
            minWidth: "100px"
        },
        {
            name: "ADDRESS",
            selector: (row) => row.addr,
            sortable: true
        },
        {
            name: "PHONE",
            selector: (row) => row.number,
            sortable: true
        },
        {
            name: "EMAIL",
            selector: (row) => row.email,
            sortable: true,
        },
        {
            name: "URL",
            selector: (row) => row.url,
            sortable: true,
        },

    ],
    rows: [
        {
           name:'zcross',
           code:'32.585022',
           addr:'170 Wowman St. South Windsor, CT 06074',
           number:'2256547521',
           email:'Zcross@gmail.com',
           url:'https://eBazar.com/location/14H9OC'
        },
        {
            name:'Bitstore',
            code:'22.585022',
            addr:'70 Bowman St. South Windsor, CT 06074',
            number:'8856547521',
            email:'Bitstore@gmail.com',
            url:'https://eBazar.com/location/11H9OC'
         },
         {
            name:'Viaanmarket',
            code:'24.585022',
            addr:'123 6th St. Melbourne, FL 32904',
            number:'5856547521',
            email:'Viaanmarket@gmail.com',
            url:'https://eBazar.com/location/1LH9OC'
         },
         {
            name:'ShopyZip',
            code:'12.585022',
            addr:'4 Shirley Ave. West Chicago, IL 60185',
            number:'6856547521',
            email:'ShopyZip@gmail.com',
            url:'https://eBazar.com/location/2LH9OC'
         },
         {
            name:'ZBuy',
            code:'72.585022',
            addr:'123 6th St. Melbourne, FL 32904',
            number:'9856547521',
            email:'ZBuy@gmail.com',
            url:'https://eBazar.com/location/2LH9OC'
         },
         {
            name:'Generanshop',
            code:'78.585022',
            addr:'4 Shirley Ave. West Chicago, IL 60185',
            number:'4856547521',
            email:'Generanshop@gmail.com',
            url:'https://eBazar.com/location/15L9OC'
         }
    ]
}

export const CardUiData = [
    {
        bgcolor: 'alert-success',
        icon: 'icofont-cart-alt',
        bgicon: 'bg-success',
        text: 'Open Store',
        num: '1025'
    },
    {
        bgcolor: 'alert-danger',
        icon: 'icofont-star-alt-1',
        bgicon: 'bg-danger',
        text: 'New Store',
        num: '701'
    },
    {
        bgcolor: 'alert-warning',
        icon: 'icofont-spinner-alt-5',
        bgicon: 'bg-warning',
        text: 'Proceed Store',
        num: '142'
    },
    {
        bgcolor: 'alert-info',
        icon: 'icofont-verification-check',
        bgicon: 'bg-info',
        text: 'Completed Enquiry',
        num: '2000'
    },

]
import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';

export const OrderDetailDataTable = {

    columns: [
        {
            name: " PRODUCT IMAGE",
            selector: (row) => row.image,
            cell: row => <><img className="avatar rounded lg p-1" src={row.image} alt="" /></>,
            sortable: true,
        },
        {
            name: "PRODUCT NAME",
            selector: (row) => {},
            sortable: true,
            cell: row => <><h6 className="title">{row.productName}</h6><span className='d-block fs-6 text-primary'>{row.preOrder}</span></>,
           
        },
        {
            name: "QUANTITY",
            selector: (row) => row.quanty,
            sortable: true,
        },
        {
            name: "PRICE",
            selector: (row) => row.price,
            sortable: true
        },
    ],
    rows: [
        {
           image:Product3,
           productName:'Oculus VR',
           preOrder:'Pr-1204',
           price:'$149.00',
           quanty:'1'
        },
        {
            image:Product2,
            productName:'Wall Clock',
            preOrder:'Pr-1004',
            price:'$399.00',
            quanty:'1'
         },
         {
            image:Product1,
            productName:'Note Diaries',
            preOrder:'Pr-1224',
            price:'$149.00',
            quanty:'1'
         },
           {
           image:Product4,
           productName:'Flower Port',
           preOrder:'Pr-1414',
           price:'$399.00',
           quanty:'1'
        },
       
    ]
}

export const OrderDetailData=[
    {
        mainbgColor:'alert-success',
        bgColor:'bg-success',
        icon:'fa fa-shopping-cart fa-lg',
        name:'Order Created at',
        secondName:'16/03/2021 at 04:23 PM'
    },
    {
        name:'Name',
        secondName:'Gabrielle',
        icon:'fa fa-user fa-lg',
        bgColor:'bg-danger',
        mainbgColor:'alert-danger'
    },
    {
        mainbgColor:'alert-warning',
        bgColor:'bg-warning',
        icon:'fa fa-envelope fa-lg',
        name:'Email',
        secondName:'gabrielle.db@gmail.com'
    },
    {
        mainbgColor:'alert-info',
        bgColor:'bg-info',
        icon:'fa fa-phone-square fa-lg',
        name:'Contact No',
        secondName:'202-906-12354'
    },
]

export const OrderDiv=[
    {
        addressName:'Delivery Address',
        blockNumber:'A-510',
        address:'81 Fulton London',
        pincode:'385467',
        phone:'202-458-4568'
    },
    {
        addressName:'Billing Address',
        blockNumber:'A-510',
        address:'81 Fulton London',
        pincode:'385467',
        phone:'202-458-4568'
    }
]


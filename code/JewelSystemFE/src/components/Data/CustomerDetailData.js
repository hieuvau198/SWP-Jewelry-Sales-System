import { Link } from 'react-router-dom';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product3 from '../../assets/images/product/product-3.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';

export const CustomerDetailData=[
    {
        name:'Delivery Address',
        blokNum:'A-510',
        address:'81 Fulton London',
        pincode:'385467',
        phone:'202-458-4568'
    },
    {
        name:'Billing Address',
        blokNum:'A-510',
        address:'81 Fulton London',
        pincode:'385467',
        phone:'202-458-4568'
    }
]

export const CustomerDetailDatatable = {
   
    columns: [
        {
            name: "ID",
            selector: (row) => row.id,
            sortable: true,
            maxWidth: "150px",
            cell: (row) => <Link to={process.env.PUBLIC_URL+"/order-detail"} className="">{row.id}</Link>
        },
        {
            name: "ITEM",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "200px"
        },
       
        {
            name: "PAYMENT INFO",
            selector: (row) => row.bankCard,
            sortable: true
        },
        {
            name: "ORDER DATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "PRICE",
            selector: (row) => row.price,
            sortable: true
        },
    ],
    rows: [
        {
            id: "#Order-11414",
            image: Product3,
            name: "Note Diaries",
            bankCard: "Bank Emi",
            date:'March 16, 2021',
            price:'$620',
          
        },
        {
            id: "#Order-18414",
            image: Product2,
            name: "Wall Clock",
            date:'June 18, 2021', 
            bankCard: "Debit Card",
            price:'  $820',
          
        },
        {
            id: "#Order-27414",
            image: Product2,
            name: "Bag",
            date:'June 18, 2021',
            bankCard: "Debit Card",
            price:'  $820',
           
        },
        {
            id: "#Order-28414",
            image: Product1,
            name: "Oculus VR",
            date:'June 17, 2021',
            bankCard: "Debit Card",
            price:'$20',
        },
        {
            id: "#Order-38414",
            image: Product4,
            name: "Flower Port",
            date:'June 16, 2021',
            bankCard: "Credit Card",
            price:'$320',
        },
        {
            id: "#Order-48414",
            image: Product3,
            name: "Note Diaries",
            date:'June 16, 2021',
            bankCard: "Debit Card",
            price:'$250',
        },
        {
            id: "#Order-58414",
            image: Product2,
            name: "Wall Clock",
            date:'June 16, 2021',
            bankCard: "Debit Card",
            price:'$220',
        },
        {
            id: "#Order-78414",
            image: Product1,
            name: "Oculus VR ",
            date:'June 16, 2021',
            bankCard: "Credit Card",
            price:'$420',
        },
        {
            id: "#Order-78514",
            image: Product1,
            name: "Rado watch",
            date:'March 16, 2021',
            bankCard: "Credit Card",
            price:'$420',
           
        }
    ]
}

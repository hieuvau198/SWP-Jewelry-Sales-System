import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';
import { Link } from 'react-router-dom';

export const OrderListData = {
   
    columns: [
        {
            name: "ID",
            selector: (row) => row.id,
            sortable: true,
            cell: (row) => <Link to={process.env.PUBLIC_URL+"/order-detail"} className="">{row.id}</Link>,
            minWidth:'150px'
        },
        {
            name: "ITEM",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "CUSTOMERS NAME",
            selector: (row) => row.customerName,
            sortable: true,
            minWidth: "250px"
        },
        {
            name: "PAYMENT INFO",
            selector: (row) => row.bankCard,
            sortable: true
        },
        {
            name: "PRICE",
            selector: (row) => row.price,
            sortable: true
        },
        {
            name: "STATUS",
            selector: (row) => row.status,
            sortable: true,
            cell: row => <span className={`badge ${row.status === "Complited" ? 'bg-success' : "bg-warning"}`}>{row.status}</span>
        },

    ],
    rows: [
        {
            id: "#Order-11414",
            image: Product3,
            name: "Note Diaries",
            customerName: "Gabrielle",
            bankCard: "Bank Emi",
            price:'$620',
            status: "Complited"
        },
        {
            id: "#Order-18414",
            image: Product2,
            name: "Wall Clock",
            customerName: "Alexander",
            bankCard: "Debit Card",
            price:'  $820',
            status: "Complited"
        },
        {
            id: "#Order-28414",
            image: Product1,
            name: "Oculus VR",
            customerName: "Adam H",
            bankCard: "Debit Card",
            price:'$20',
            status: "Progress"
        },
        {
            id: "#Order-38414",
            image: Product4,
            name: "Flower Port",
            customerName: "Sonia",
            bankCard: "Credit Card",
            price:'$320',
            status: "Progress"
        },
        {
            id: "#Order-48414",
            image: Product3,
            name: "Note Diaries",
            customerName: "Julia",
            bankCard: "Debit Card",
            price:'$250',
            status: "Complited"
        },
        {
            id: "#Order-58414",
            image: Product2,
            name: "Wall Clock",
            customerName: "Brian",
            bankCard: "Debit Card",
            price:'$220',
            status: "Complited"
        },
        {
            id: "#Order-78414",
            image: Product1,
            name: "Oculus VR ",
            customerName: "Molly",
            bankCard: "Credit Card",
            price:'$420',
            status: "Progress"
        }
    ]
}

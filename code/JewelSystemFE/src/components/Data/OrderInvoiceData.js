import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';
import { Link } from 'react-router-dom';

export const OrderVoiceData = {

    columns: [
        {
            name: "ID",
            selector: (row) => row.id,
            sortable: true,
            minWidth: "50px"
        },
        {
            name: "ITEM",
            selector: (row) => row.itemName,
            cell: row => <><img className="avatar rounded lg border" src={row.itemimage} alt="" /><span className="px-2">{row.itemName}</span></>,
            sortable: true, minWidth: "200px"
        },
        {
            name: "BILLING DATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "TOTAL AMOUNT",
            selector: (row) => row.price,
            sortable: true
        },
        {
            name: "USER NAME",
            selector: (row) => row.userName,
            sortable: true,
           
        },
        {
            name: "ACTION",
            selector: (row) => { },
            sortable: true,
            cell: () =>
                <div>
                    <Link type="button" to={process.env.PUBLIC_URL+'/invoices'} className="btn btn-outline-secondary"><i className="icofont-print fs-5"></i></Link>
                    <Link type="button" to={process.env.PUBLIC_URL+'/invoices'} className="btn btn-outline-secondary deleterow mx-1"><i className="icofont-download fs-5"></i></Link>
                    <Link type="button" to={process.env.PUBLIC_URL+'/invoices'} className="btn btn-outline-secondary deleterow"><i className="icofont-send-mail fs-5"></i></Link>
                </div>,
                minWidth: "200px"
        }
    ],
    rows: [
        {
            id: '#Order-18414',
            itemimage: Product3,
            itemName: 'Rado Watch',
            date: 'May 22, 2021',
            price: '$330',
            userName: 'Dianalove',
        },
        {
            id: '#Order-28414',
            itemimage: Product1,
            itemName: 'Bag',
            date: 'May 18, 2021',
            price: '$300',
            userName: 'Grace786',
        },
        {
            id: '#Order-38414',
            itemimage: Product2,
            itemName: 'Flower Port',
            date: 'May 23, 2021',
            price: '$112',
            userName: 'Zoesmart',
        },
        {
            id: '#Order-48414',
            itemimage: Product2,
            itemName: 'Note Diaries',
            date: 'May 16, 2021',
            price: '$612',
            userName: 'Peterjio',
        },
        {
            id: '#Order-58414',
            itemimage: Product3,
            itemName: 'Wall Clock',
            date: 'May 22, 2021',
            price: '$612',
            userName: 'Joan123',
        },
        {
            id: '#Order-78414',
            itemimage: Product1,
            itemName: 'Oculus VR ',
            date: 'May 16, 2021',
            price: '$212',
            userName: 'Alexander007',
        },
        {
            id: '#Order-88414',
            itemimage: Product4,
            itemName: 'Traveling bag',
            date: 'May 16, 2021',
            price: '$370',
            userName: 'Sarahone',
        },
        {
            id: '#Order-98414',
            itemimage: Product1,
            itemName: 'Chair',
            date: 'May 16, 2021',
            price: '$170',
            userName: 'Julia42',
        },
    ]
}

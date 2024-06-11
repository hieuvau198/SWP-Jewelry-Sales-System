import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';
import { Link } from 'react-router-dom';

export const ShoppingCartData = {

    columns: [
        {
            name: " PRODUCT IMAGE",
            selector: (row) => row.image,
            cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /></>,
            sortable: true,
        },
        {
            name: "PRODUCT NAME",
            selector: (row) => row.productName,
            sortable: true,
        },
        {
            name: "PRE-ORDER",
            selector: (row) => row.preOrder,
            sortable: true,
        },
        {
            name: "QUANTITY",
            selector: (row) => { },
            sortable: true,
            cell: () => <input type="number" value="1" className="form-control" onChange={()=>{}}/>
        },
        {
            name: "PRICE",
            selector: (row) => row.price,
            sortable: true
        },
        {
            name: "ACTION",
            selector: (row) => { },
            sortable: true,
            cell: () => <div className="btn-group" role="group" aria-label="Basic outlined example">
                <Link type="button" to={process.env.PUBLIC_URL+'/product-detail'}  className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
            </div>
        }
    ],
    rows: [
        {
           image:Product3,
           productName:'Oculus VR',
           preOrder:'Pr-1204',
           price:'$149.00'
        },
        {
            image:Product2,
            productName:'Wall Clock',
            preOrder:'Pr-1004',
            price:'$399.00'
         },
         {
            image:Product1,
            productName:'Note Diaries',
            preOrder:'Pr-1224',
            price:'$149.00'
         },
           {
           image:Product4,
           productName:'Flower Port',
           preOrder:'Pr-1414',
           price:'$399.00'
        },
       
    ]
}
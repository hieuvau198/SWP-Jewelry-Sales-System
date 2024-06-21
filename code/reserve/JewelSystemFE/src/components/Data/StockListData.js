import Product3 from '../../assets/images/product/product-3.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product1 from '../../assets/images/product/product-1.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';

export const StockListData = {
   
    columns: [
        {
            name: "ID",
            selector: (row) => row.id,
            sortable: true,
        },
        {
            name: "PRODUCTS",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "200px"
        },
        {
            name: "CATEGORY",
            selector: (row) => row.category,
            sortable: true,
           
        },
        {
            name: "DATE ADDED",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "STOCK",
            selector: (row) => row.stock,
            sortable: true
        },
        {
            name: "IN STOCK",
            selector: (row) => row.instock,
            sortable: true
        },
        {
            name: "COLOR",
            selector: (row) => row.color,
            sortable: true
        },
        {
            name: "STATUS",
            selector: (row) => row.status,
            sortable: true,
            cell: row => <span className={`badge ${row.status === "sell" ? 'bg-success':row.status === "offer process" ?  "bg-warning":"bg-danger"}`}>{row.status}</span>
        },
    ],
    rows: [
        {
            id: "#SKUN111",
            image:Product1,
            name: "Oculus VR",
            category: "Game accessories",
            date: "June 13, 2021",
            stock:'1455',
            instock:'451',
            color: "Yellow",
            status:'offer process'
        },
        {
            id: "#SKUN112",
            image:Product2,
            name: "Wall Clock",
            category: "Clock",
            date: "June 22, 2021",
            stock:'5555',
            instock:'1451',
            color: "Gold",
            status:'sell'
        },
        {
            id: "#SKUN113",
            image:Product3,
            name: "Flower Port",
            category: "accessories",
            date: "June 16, 2021",
            stock:'555',
            instock:'11',
            color: "Silver",
            status:'sell'
        },
        {
            id: "#SKUN114",
            image:Product4,
            name: "Flower Port",
            category: "Port Box",
            date: "June 23, 2021",
            stock:'7581',
            instock:'2468',
            color: "Brown",
            status:'offer process'
        },
        {
            id: "#SKUN115",
            image:Product1,
            name: "School Bag",
            category: "Bags",
            date: "June 18, 2021",
            stock:'1581',
            instock:'1581',
            color: "Chocolate",
            status:'out of stock'
        },
        {
            id: "#SKUN116",
            image:Product3,
            name: "Rado Watch",
            category: "Watch",
            date: "June 13, 2021",
            stock:'4581',
            instock:'3468',
            color: "Silver",
            status:'sell'
        },
        {
            id: "#SKUN117",
            image:Product2,
            name: "Wildcraft",
            category: "Traveling Bag",
            date: "June 17, 2021",
            stock:'2581',
            instock:'2468',
            color: "Silver",
            status:'sell'
        },
        {
            id: "#SKUN118",
            image:Product4,
            name: "Chair",
            category: "Furniture",
            date: "June 17, 2021",
            stock:'581',
            instock:'468',
            color: "Browen",
            status:'sell'
        },
        
    ]
}

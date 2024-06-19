import { Link } from 'react-router-dom';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
import axios from '../../api/axios';
import { useState } from 'react';










const getdata = [
  {
    "customerId": "C5",
    "customerName": "Emily Wilson",
    "customerRank": "Bronze",
    "customerPoint": 90,
    "attendDate": "2024-05-05T00:00:00"
  },
  {
    "customerId": "C4",
    "customerName": "Bob Brown",
    "customerRank": "Bronze",
    "customerPoint": 120,
    "attendDate": "2024-04-30T00:00:00"
  },
  {
    "customerId": "C3",
    "customerName": "Alice Johnson",
    "customerRank": "Bronze",
    "customerPoint": 50,
    "attendDate": "2024-03-25T00:00:00"
  },
  {
    "customerId": "C2",
    "customerName": "Jane Smith",
    "customerRank": "Silver",
    "customerPoint": 80,
    "attendDate": "2024-02-20T00:00:00"
  },
  {
    "customerId": "C1",
    "customerName": "John Doe",
    "customerRank": "Gold",
    "customerPoint": 100,
    "attendDate": "2024-01-15T00:00:00"
  }
];

  


export const CustomerData= ()=>{ 
  const [ rowdata, setrowData] = useState(getdata);
  const get = async () => {
    try {
      console.log("response.data");
      const response = await axios.get("/customer");
      console.log(response.data);
      setrowData(response.data);
      return response.data;
    } catch (error) {
      console.log(error);
    }
  }
  get();
      console.log("response.data");
  return( {
   
    columns: [
        
      {
        name: " ID",
        selector: (row) => row.customerId,
        sortable: true,
    },
    {
        name: "CUSTOMER",
        selector: (row) => row.customerName,
        cell: row => <Link to={process.env.PUBLIC_URL+'/customer-detail'}>
            <img className="avatar rounded lg" src={Avatar1} alt="" />
            <span className="px-2">{row.customerName}</span>
          </Link>,
        sortable: true, minWidth: "200px"
    },
    {
        name: "REGISTER DATE",
        selector: (row) => row.attendDate,
        sortable: true,
        
    },
    {
      name: "CUSTOMER POINT",
      selector: (row) => row.customerPoint,
      sortable: true,
  },
    {
      name: "CUSTOMER RANK",
      selector: (row) => row.customerRank,
      sortable: true,
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
    rows: rowdata
}

  )
}

export const ProfileBlockData=[
  {
    icon:'icofont-ui-touch-phone',
    detail:'202-555-0174 '
  },
  {
    icon:'icofont-email',
    detail:'adrianallan@gmail.com'
  },
  {
    icon:'icofont-birthday-cake',
    detail:'19/03/1980'
  },
  {
    icon:'icofont-address-book',
    detail:'2734  West Fork Street,EASTON 02334.'
  }
]
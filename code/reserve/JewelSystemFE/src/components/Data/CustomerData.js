import { Link } from 'react-router-dom';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';

export const CustomerData= {
   
    columns: [
        {
            name: " ID",
            selector: (row) => row.id,
            sortable: true,
        },
        {
            name: "CUSTOMER",
            selector: (row) => row.name,
            cell: row => <Link to={process.env.PUBLIC_URL+'/customer-detail'}>
                <img className="avatar rounded lg" src={row.image} alt="" />
                <span className="px-2">{row.name}</span>
              </Link>,
            sortable: true, minWidth: "200px"
        },
        {
            name: "REGISTER DATE",
            selector: (row) => row.date,
            sortable: true,
            
        },
        {
            name: "MAIL",
            selector: (row) => row.mail,
            sortable: true
        },
        {
            name: "PHONE",
            selector: (row) => row.phone,
            sortable: true
        },
        {
            name: "COUNTRY",
            selector: (row) => row.country,
            sortable: true,
        },
        {
          name: "TOTAL ORDER",
          selector: (row) => row.order,
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
    rows: [
        {
          id:'#CS-00002',
          image:Avatar1,
          name:'Joan Dyer',
          date:'12/03/2021',
          mail:'JoanDyer@gmail.com',
          phone:'202-555-0983',
          country:'South Africa',
          order:'02'
        },
        {
            id:'#CS-00004',
            image:Avatar2,
            name:'Phil	Glover',
            date:'16/03/2021',
            mail:'PhilGlover@gmail.com',
            phone:'843-555-0175',
            country:'Sri Lanka',
            order:'03'
          },
          {
            id:'#CS-00006',
            image:Avatar3,
            name:'Ryan	Randall',
            date:'12/03/2021',
            mail:'RyanRandall@gmail.com',
            phone:'303-555-0151',
            country:'Australia',
            order:'05'
          },
          {
            id:'#CS-00008',
            image:Avatar4,
            name:'Victor Rampling',
            date:' 25/02/2021',
            mail:'VictorRampling@gmail.com',
            phone:'404-555-0100',
            country:'Israel',
            order:'14'
          },
          {
            id:'#CS-00014',
            image:Avatar1,
            name:'Robert Anderson',
            date:'18/01/2021',
            mail:'RobertAnderson@gmail.com',
            phone:'502-555-0133',
            country:'Malaysia',
            order:'18'
          },
          {
            id:'#CS-00018',
            image:Avatar3,
            name:'Sally Graham',
            date:'16/02/2021',
            mail:'SallyGraham@gmail.com',
            phone:'502-555-0118',
            country:'Indonesia',
            order:'4668'
          },

       
    ]
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
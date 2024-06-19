import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';
export const ProfileData = [

    {
        icon: 'icofont-ui-touch-phone',
        detail: '202-555-0174 '
    },
    {
        icon: 'icofont-email',
        detail: 'adrianallan@gmail.com'
    },
    {
        icon: 'icofont-birthday-cake',
        detail: '19/03/1980'
    },
    {
        icon: 'icofont-address-book',
        detail: '2734  West Fork Street,EASTON 02334.'
    }
]

export const PricePlanExampleData = [
    {
        title: 'Deluxe',
        price: '$9',
        voicechat: '10Hr',
        chatwithout: '500Mb',
        support: 'No',
        domain: '1',
        hiddenfees: 'No'
    },
    {
        title: 'Economy',
        price: '$29',
        voicechat: '100Hr',
        chatwithout: '50GB',
        support: 'Yes',
        domain: '2',
        hiddenfees: 'No'
    },
    {
        title: 'Ultimate',
        price: '$39',
        voicechat: 'Unlimited',
        chatwithout: 'Unlimited',
        support: 'Yes',
        domain: 'Unlimited',
        hiddenfees: 'No'
    },
]

export const ContactTableListViewTable={
    columns: [
        {
            name: "PERSON NAME",
            selector: (row) => row.name,
            cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
            sortable: true, minWidth: "250px"
        },
        {
            name: "BIRTHDATE",
            selector: (row) => row.date,
            sortable: true
        },
        {
            name: "EMAIL",
            selector: (row) => row.mail,
            sortable: true
        },
        {
            name: "PHONENUMBER",
            selector: (row) => row.phonenumber,
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
            image:Avatar1,
            name:'Phil Glover',
            date:'16/03/2021',
            mail: 'PhilGlover@gmail.com',
            phonenumber:'775-555-0117'
        },
        {
            image:Avatar2,
            name:'Robert Anderson',
            date:'18/01/2021',
            mail: 'RobertAnderson@gmail.com',
            phonenumber:'402-555-0177'
        },
        {
            image:Avatar3,
            name:'Ryan Randall',
            date:'12/03/2021',
            mail: 'RyanRandall@gmail.com',
            phonenumber:'402-555-0177'
        },
        {
            image:Avatar4,
            name:'Sally Graham',
            date:'16/02/2021',
            mail: 'SallyGraham@gmail.com',
            phonenumber:'303-555-0133'
        },
        {
            image:Avatar1,
            name:'Victor Rampling',
            date:'25/02/2021',
            mail: 'VictorRampling@gmail.com',
            phonenumber:'512-555-0189'
        },
        {
            image:Avatar1,
            name:'Joan Dyer',
            date:'12/03/2021',
            mail: 'JoanDyer@gmail.com',
            phonenumber:'518-555-0145'

        },
       
       
    ]
}

export const ContactProfileViewData=[
    {
        image:Avatar1,
        id:'Contact ID : Con-0001',
        title:'Phil Glover',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar2,
        id:'Contact ID : Con-0001',
        title:'Adrian	Allan',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar3,
        id:'Contact ID : Con-0001',
        title:'Robert Anderson',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar4,
        id:'Contact ID : Con-0001',
        title:'Ryan Randall',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar1,
        id:'Contact ID : Con-0001',
        title:'Joan Dyer',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar2,
        id:'Contact ID : Con-0001',
        title:'Victor Rampling',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar3,
        id:'Contact ID : Con-0001',
        title:'Victor Rampling',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },
    {
        image:Avatar4,
        id:'Contact ID : Con-0001',
        title:'Adrian	Allan',
        icon:'icofont-edit',
        year:'24 years, California',
        number:'202-555-0174',
        mail:'adrianallan@gmail.com',
        date:'19/03/1980',
        num:'775-555-0117'
    },

]
export const LeadersListData={
    title:"Leaders List",
    columns:[
        {
            name: "LEADER NAME",
            selector:(row)=>row.leadername,
            sortable: true,
            cell:row=><><img className="avatar rounded-circle" src={row.image} alt="" /> <span className="fw-bold ms-1">{row.leadername}</span></>,
            minWidth:"250px"
        },
        {
            name: "PROJECT",
            selector: (row)=>row.project,
            sortable: true
        },
        {
            name: "TOTAL TASK",
            selector: (row)=>row.totaltask,
            sortable: true
        },
        {
            name: "EMAIL",
            selector: (row)=>row.email,
            sortable: true
        },
        {
            name: "PROJECT ASSIGNED",
            selector: (row)=>row.projectassigned,
            sortable: true
        },
       
        {
            name: "STATUS",
            selector: (row)=>{},
            sortable: true,
            cell:row=><span className="badge bg-success">{row.status}</span>
        },
        {
            name: "ACTION",
            selector: (row)=>{},
            sortable: true,
            cell:()=><div className="btn-group" role="group" aria-label="Basic outlined example">
                        <button type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                        <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                    </div>
        }
        
    ],
    rows:[
        {
            leadername:"Phil Glover",
            image:Avatar1,
            project:"Gob Geeklords",
            totaltask:"2 Task",
            email:"PhilGlover@gmail.com",
            projectassigned:"18/03/21",
            status:"Working",
        },
        {
            leadername:"Robert Anderson",
            image:Avatar3,
            project:"Rhinestone",
            totaltask:"5 Task",
            email:"RobertAnderson@gmail.com",
            projectassigned:"14/01/21",
            status:"Working",
        },
        {
            leadername:"Ryan Randall",
            image:Avatar2,
            project:"Fast Cad",
            totaltask:"8 Task",
            email:"RyanRandall@gmail.com",
            projectassigned:"14/01/21",
            status:"Working",
        },
        {
            leadername:"Ryan Stewart",
            image:Avatar2,
            project:"Social Geek Made",
            totaltask:"15 Task",
            email:"RyanStewart@gmail.com",
            projectassigned:"13/01/21",
            status:"Working",
        },
        {
            leadername:"Sally Graham",
            image:Avatar1,
            project:"Practice to Perfect",
            totaltask:"9 Task",
            email:"SallyGraham@gmail.com",
            projectassigned:"13/01/21",
            status:"Working",
        },
        {
            leadername:"Victor Rampling",
            image:Avatar4,
            project:"Practice to Perfect",
            totaltask:"7 Task",
            email:"VictorRampling@gmail.com",
            projectassigned:"18/06/21",
            status:"Working",
        },
        {
            leadername:"Joan Dyer",
            image:Avatar1,
            project:"Box of Crayons",
            totaltask:"5 Task",
            email:"joandyer@gmail.com",
            projectassigned:"23/02/21",
            status:"Working",
        }
    ]
}
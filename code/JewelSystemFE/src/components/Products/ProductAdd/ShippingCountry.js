import React, { useState } from 'react';
import DualListBox from 'react-dual-listbox';
import 'react-dual-listbox/lib/react-dual-listbox.css';

const options = [
    {
        label: "Alaskan/Hawaiian Time Zone",
        options: [
            { value: "Alaska", label: "Alaska" },
            { value: "Hawaii", label: "Hawaii" },
        ]
    },
    {
        label: "Pacific Time Zone",
        options: [
            { value: "California", label: "California" },
            { value: "Nevada", label: "Nevada" },
            { value: "Oregon", label: "Oregon" },
            { value: "Washington", label: "Washington" }
        ]
    },
    {
        label: "Mountain Time Zone",
        options: [
            { value: "Arizona", label: "Arizona" },
            { value: "Colorado", label: "Colorado" },
            { value: "Idaho", label: "Idaho" },
            { value: "Montana", label: "Montana" },
            { value: "Nebraska", label: "Nebraska" },
            { value: "New Mexico", label: "New Mexico" },
            { value: "North Dakota", label: "North Dakota" },
            { value: "Utah", label: "Utah" },
            { value: "Wyoming", label: "Wyoming" }
        ]
    },
    {
        label: "Central Time Zone",
        options: [
            { value: "Alabama", label: "Alabama" },
            { value: "Arkansas", label: "Arkansas" },
            { value: "Illinois", label: "Illinois" },
            { value: "Iowa", label: "Iowa" },
            { value: "Kansas", label: "Kansas" },
            { value: "Kentucky", label: "Kentucky" },
            { value: "Louisiana", label: "Louisiana" },
            { value: "Minnesota", label: "Minnesota" },
            { value: "Mississippi", label: "Mississippi" },
            { value: "Missouri", label: "Missouri" },
            { value: "Oklahoma", label: "Oklahoma" },
            { value: "South Dakota", label: "South Dakota" },
            { value: "Texas", label: "Texas" },
            { value: "Tennessee", label: "Tennessee" },
            { value: "Wisconsin", label: "Wisconsin" },
        ]
    },
    {
        label: "Eastern Time Zone",
        options: [
            { value: "Connecticut", label: "Connecticut" },
            { value: "Delaware", label: "Delaware" },
            { value: "Florida", label: "Florida" },
            { value: "Georgia", label: "Georgia" },
            { value: "Indiana", label: "Indiana" },
            { value: "Maine", label: "Maine" },
            { value: "Maryland", label: "Maryland" },
            { value: "Massachusetts", label: "Massachusetts" },
            { value: "Michigan", label: "Michigan" },
            { value: "New Hampshire", label: "New Hampshire" },
            { value: "New Jersey", label: "New Jersey" },
            { value: "New York", label: "New York" },
            { value: "North Carolina", label: "North Carolina" },
            { value: "Ohio", label: "Ohio" },
            { value: "Pennsylvania", label: "Pennsylvania" },
            { value: "Rhode Island", label: "Rhode Island" },
            { value: "South Carolina", label: "South Carolina" },
            { value: "Vermont", label: "Vermont" },
            { value: "Virginia", label: "Virginia" },
            { value: "West Virginia", label: "West Virginia" },
        ]
    },

];


function ShippingCountries() {

    const [selected, setSelected] = useState([options[0]]);

    const onChange = (selected) => {

        setSelected(selected);
    };

    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Shipping Country</h6>
            </div>
            <DualListBox
                options={options}
                selected={selected}
                allowDuplicates
                simpleValue={false}
                onChange={onChange}
            />
        </>
    )
}
export default ShippingCountries
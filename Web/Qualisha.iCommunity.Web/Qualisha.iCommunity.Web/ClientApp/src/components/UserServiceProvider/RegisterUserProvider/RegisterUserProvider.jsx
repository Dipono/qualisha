import { useState } from 'react'
import './RegisterUserProvider.css';
import { NavLink/*, useNavigate*/ } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import DisclaimerPopUp from './TermsAndConditions_Disclaimer/Disclaimer';
import TermsAndConditionsPopUp from './TermsAndConditions_Disclaimer/TermsAndConditions';

toast.configure();
const RegisterUserProvider = () => {

    const [ButtonTriggeredDisclaimer, setButtonTriggeredDisclaimer] = useState(false);
    const [ButtonTriggeredTerms, setButtonTriggeredTerms] = useState(false);


    let service = [
        { id: 1, name: "School Transport" },
        { id: 2, name: "Salon" },
        { id: 3, name: "Car Wash" },
        { id: 4, name: "Resturant" },
    ];
    const [ServiceTask, setServiceTask] = useState({
        UserId: 0,
        ServiceId: "",
        CompanyName: "",
        CompanyDescription: "",
        CompanyRegistrationNumber: "",
        ServicePhoneNumber: "",
        IdDocument : null,
        ResidentialAddress : null,
        
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setServiceTask(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const RegisterAsServiceProvider = (e) => {
        e.preventDefault();

        console.log(ServiceTask)
        //if (!CheckTask.ServicePhoneNumber) { return toast("Enter contact number.") }
        if (isNaN(ServiceTask.ServiceId)) { return toast("Please select service provider.") }
        if (ServiceTask.CompanyName.length > 0) {
            if (!ServiceTask.CompanyDescription) { return toast("Enter company description") }
        }

        toast("Almost done")

    }

    return (
        <div className="container">
            <div className="nav-bar">
                <NavLink ClassName="nav" to="/landing">Back</NavLink>
            </div>

            <div className="content">
                <div className="form-group">
                    <input type="text" className="control-form" name="CompanyName" placeholder='Company Name'
                        value={ServiceTask.CompanyName} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">

                    <label>Company Description<br /> </label>
                    <textarea cols="30" rows="10">
                    </textarea>
                </div>

                <div className="form-group">
                    <input type="number" className="control-form" name="CompanyRegistrationNumber" placeholder='Company Registration Number'
                        value={ServiceTask.CompanyRegistrationNumber} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">
                    <label>Contact Number <span className='required'>*</span></label>
                    <input type="number" className="control-form" name="ServicePhoneNumber" placeholder='Phone Number/ Business Number/ Work Number'
                        value={ServiceTask.ServicePhoneNumber} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">
                    <label>Service Provider type <span className='required'>*</span></label>
                    <select onChange={handleChange} value={ServiceTask.ServiceId} name="ServiceId">
                        <option>-- Select a Service --</option>
                        {service.map((ServiceTask) => <option value={ServiceTask.id}>{ServiceTask.name}</option>)}
                    </select>
                </div>

                <div className="form-group">
                    <label>Identification</label>
                    <input type="file" name="CompanyRegistrationNumber" placeholder='Company Registration Number'
                        value={ServiceTask.CompanyRegistrationNumber} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">
                    <label>Proof of Resident</label>
                    <input type="file" name="CompanyRegistrationNumber" placeholder='Company Registration Number'
                        value={ServiceTask.CompanyRegistrationNumber} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">
                    <label>
                        By clicking on Register then you agree to our 
                        <button className='btn-link' onClick={()=> setButtonTriggeredTerms(true)}>Terms and Conditions</button>
                        with the 
                        <button className='btn-link' onClick={()=> setButtonTriggeredDisclaimer(true)}>Disclaimer</button> 
                        .
                    </label>
                </div>
                <TermsAndConditionsPopUp triggerTerms={ButtonTriggeredTerms} setTrigger={setButtonTriggeredTerms}>
                </TermsAndConditionsPopUp>

                <DisclaimerPopUp triggerDisclaimer={ButtonTriggeredDisclaimer} setTrigger={setButtonTriggeredDisclaimer}>
                </DisclaimerPopUp>

                <div className="form-group">
                    <button className='btn btn-success' onClick={RegisterAsServiceProvider}>Register</button>
                </div>
            </div>
        </div>
    )
}

export default RegisterUserProvider;
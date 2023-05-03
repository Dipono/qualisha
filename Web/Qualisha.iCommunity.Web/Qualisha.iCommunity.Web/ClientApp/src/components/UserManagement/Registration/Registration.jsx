import { useState } from 'react'
import './Registration.css';
import { NavLink, useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure()
const Registration = () => {
    const navigate = useNavigate();

    const [Tasks, setTasks] = useState({
        LastName: '',
        FirstName: '',
        EmailAddress: '',
        Password: '',
        ConfirmPassword: '',
        PhoneNumber: '',
        AddressDto: {
            Line1: '',
            Line2: '',
            Province: '',
            City: '',
            Suburb: '',
            Estate: '',
            Code: '',
        }
    });

    const [AddressTask, setAddressTask] = useState({
        Line1: '',
        Line2: '',
        Province: '',
        City: '',
        Suburb: '',
        Estate: '',
        Code: '',
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setTasks(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleChangeAddress = e => {
        const { name, value } = e.target;
        setAddressTask(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const registerUser = async (e) => {
        e.preventDefault();

        Tasks.AddressDto = {
            Line1: AddressTask.Line1,
            Line2: AddressTask.Line2,
            Province: AddressTask.Province,
            City: AddressTask.City,
            Suburb: AddressTask.Suburb,
            Estate: AddressTask.Estate,
            Code: AddressTask.Code,
        }

        // Validate Input fields
        var alphabet = /^[a-zA-Z][a-zA-Z\s]*$/

        // Lastname
        if (!Tasks.LastName) return toast('Enter your Lastname');
        if (Tasks.LastName.length < 3) return toast('Lastname must have at least 3 characters');
        if (!Tasks.LastName.match(alphabet)) return toast('Lastname must contain alphabets only or alphabets with spaces')

        // Firstname
        if (!Tasks.FirstName) return toast('Enter your Firstname');
        if (Tasks.FirstName.length < 3) return toast('FirstName must have at least 3 characters');
        if (!Tasks.FirstName.match(alphabet)) return toast('Firstname must contain alphabet only')

        // Email Address
        if (!Tasks.EmailAddress) return toast('Enter Email Address');
        const regExEmail = /^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/;
        if (!regExEmail.test(Tasks.EmailAddress)) return toast('Enter valid Email Address');
        if (Tasks.EmailAddress.length < 8) return toast('Email Address must have at least 10 characters');

        // Phone number 
        if (Tasks.PhoneNumber !== '' && Tasks.PhoneNumber.length < 10) {
            return toast('Phone number must be at least 10 digits')
        }

        // Password
        let ErroPasswordMessage = `
        The password must contain 
            (1) at least 8 characters long
            (2) at least one uppercase letter.
            (3) at least one lowercase letter.
            (4) at least one digit.
            (5) at least one special character.
        `
        const regExPassword = /(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})/
        if (!Tasks.Password) return toast('Enter Password');
        if (!regExPassword.test(Tasks.Password)) { return toast(ErroPasswordMessage) }
        if (Tasks.Password !== Tasks.ConfirmPassword) return toast('Password do not match');

        // Address
        if (!AddressTask.Line1) return toast('Enter Street Address or Stand Number');
        if (AddressTask.Line1.length < 3) return toast('Line must have at least 3 characters');

        if (!AddressTask.Province) return toast('Enter Province Name');
        if (AddressTask.Province.length < 2) return toast('Line must have at least 3 characters');
        if (!AddressTask.Province.match(alphabet)) return toast('Province must contain alphabet only')

        if (!AddressTask.City) return toast('Enter City Name');
        if (AddressTask.Line1.length < 3) return toast('Line must have at least 3 characters');

        if (!AddressTask.Suburb) return toast('Enter Suburb name');
        if (AddressTask.Suburb.length < 3) return toast('Suburb must have at least 3 characters');

        if (!AddressTask.Estate) return toast('Enter Estate Name');
        if (AddressTask.Estate.length < 3) return toast('Estate must have at least 3 characters');

        if (!AddressTask.Code) return toast('Enter Code Number');
        if (AddressTask.Code.toString().length < 4) return toast('Code must have at least 4 characters');

        const axios = require('axios').default;


        try {
            const userData = await axios.post('https://localhost:7270/api/UserManagement/Register', Tasks);
            console.log(userData)
            if (userData.data.success === true) {
                localStorage.setItem('UserId', userData.data.result.id.toString())
                toast(userData.data.message);
                navigate('/activate_account')
            }
            else{
                toast(userData.data.message);
            }


        }
        catch (err) {
            console.log(err)
        }

    }

    return (
        <div className="container">
            <h2>Sign-up</h2>
            <form onSubmit={registerUser}>
                <div className="form-group">
                    <label>Lastname <span className="required">*</span></label>
                    <input type="text" className="control-form" name="LastName"
                        value={Tasks.LastName} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-group">
                    <label>First Name <span className="required">*</span></label>
                    <input type="text" className="control-form" name="FirstName"
                        value={Tasks.FirstName} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-group">
                    <label>Email Address <span className="required">*</span></label>
                    <input type="text" className="control-form" name="EmailAddress"
                        value={Tasks.EmailAddress} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-group">
                    <label>Phone Number</label>
                    <input type="number" className="control-form" name="PhoneNumber"
                        value={Tasks.PhoneNumber} onChange={handleChange}>
                    </input>
                </div>

                <div className="form-group">
                    <label>Password <span className="required">*</span></label>
                    <input type="password" className="control-form" name="Password"
                        value={Tasks.Password} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>

                </div>

                <div className="form-group">
                    <label>Confirm Password <span className="required">*</span></label>
                    <input type="password" className="control-form" name="ConfirmPassword"
                        value={Tasks.ConfirmPassword} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <fieldset className="address">
                    <legend>Physical Address</legend>
                    <div className="form-group">
                        <label>Line 1 <span className="required">*</span></label>
                        <input type="text" className="control-form" name="Line1"
                            value={AddressTask.Line1} onChange={handleChangeAddress}>
                        </input>
                        <span className=".error-message">{ }</span>
                    </div>

                    <div className="form-group">
                        <label>Line 2</label>
                        <input type="text" className="control-form" name="Line2"
                            value={AddressTask.Line2} onChange={handleChangeAddress}></input>
                    </div>

                    <div className="form-group">
                        <label>Province <span className="required">*</span></label>
                        <input type="text" className="control-form" name="Province"
                            value={AddressTask.Province} onChange={handleChangeAddress}></input>
                        <span className=".error-message">{ }</span>
                    </div>

                    <div className="form-group">
                        <label>City <span className="required">*</span></label>
                        <input type="text" className="control-form" name="City"
                            value={AddressTask.City} onChange={handleChangeAddress}>
                        </input>
                        <span className=".error-message">{ }</span>
                    </div>

                    <div className="form-group">
                        <label>Suburb <span className="required">*</span></label>
                        <input type="text" className="control-form" name="Suburb"
                            value={AddressTask.Suburb} onChange={handleChangeAddress}>
                        </input>
                        <span className=".error-message">{ }</span>
                    </div>

                    <div className="form-group">
                        <label>Estate <span className="required">*</span></label>
                        <input type="text" className="control-form" name="Estate"
                            value={AddressTask.Estate} onChange={handleChangeAddress}>
                        </input>
                        <span className=".error-message">{ }</span>
                    </div>

                    <div className="form-group">
                        <label>Code <span className="required">*</span></label>
                        <input type="number" className="control-form" name="Code"
                            value={AddressTask.Code} onChange={handleChangeAddress}>
                        </input>
                        <span className=".error-message">{ }</span>
                    </div>
                </fieldset>
                <div className="form-button">
                    <button className="btn btn-block" >Register</button>
                </div>
            </form>
            <NavLink activeClassName="is-active" to="/">Login</NavLink>
        </div>
    );
}

export default Registration;
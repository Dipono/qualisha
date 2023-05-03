import { useState } from 'react'
import './Forgot_Password.css';
import { useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure();
const UpdatePassword = () => {
    const navigate = useNavigate();

    const [UpdatePasswordTasks, setUpdatePasswordTasks] = useState({
        Password: '',
        ConfirmPassword: '',
        UserId: 0
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setUpdatePasswordTasks(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const UpdatePassword = async (e) => {
        e.preventDefault();

        UpdatePasswordTasks.UserId = Number(JSON.parse(localStorage.getItem('UserId')))

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
        if (!UpdatePasswordTasks.Password) return toast('Enter Password');
        if (!regExPassword.test(UpdatePasswordTasks.Password)) { return toast(ErroPasswordMessage) }
        if (UpdatePasswordTasks.Password !== UpdatePasswordTasks.ConfirmPassword) return toast('Password do not match');
    
        try {
            const axios = require('axios');
            const userData = await axios.post('https://localhost:7270/api/UserManagement/UpdatePassword', UpdatePasswordTasks)
            
            if(userData.data.success === true){
                userData.data.message = "Successfully updated"
                toast(userData.data.message)
                navigate('/')
            }
        }

        catch(err){
            toast(err)
        }
    }

    return (
        <div className='container'>
            <h2>Udate Password</h2>
            <div id='password'>
                <div className="form-group">
                    <input type="password" className="control-form" name="Password" placeholder='New Password'
                        value={UpdatePasswordTasks.Password} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-group">
                    <input type="password" className="control-form" name="ConfirmPassword" placeholder='Confirm Password'
                        value={UpdatePasswordTasks.ConfirmPassword} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-button">
                    <button type='button' className="btn btn-block" onClick={UpdatePassword}>Send Email</button>
                </div>
            </div>
        </div>
    )
}

export default UpdatePassword;
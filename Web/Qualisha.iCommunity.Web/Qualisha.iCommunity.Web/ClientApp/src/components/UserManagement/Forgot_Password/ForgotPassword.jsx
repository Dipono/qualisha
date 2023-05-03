import { useState } from 'react'
import './Forgot_Password.css';
import { useNavigate, NavLink } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure();
const ForgotPassword = () => {
    const navigate = useNavigate();

    const [UserTasks, setUserTasks] = useState({
        EmailAddress: '',
        OTP: '',
        UserId: 0
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setUserTasks(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const SendUserEmail = async (e) => {
        e.preventDefault();
        // Email Address
        if (!UserTasks.EmailAddress) return toast('Enter Email Address');
        const regExEmail = /^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/;
        if (!regExEmail.test(UserTasks.EmailAddress)) return toast('Enter valid Email Address');
        if (UserTasks.EmailAddress.length < 8) return toast('Email Address must have at least 10 characters');

        try {
            const axios = require('axios');
            const userData = await axios.post('https://localhost:7270/api/UserManagement/ForgotPassword', UserTasks)
            console.log(userData)
            console.log(userData.data)

            if(userData.data.success === true)
            {
                UserTasks.UserId = localStorage.setItem('UserId', userData.data.results.toString())
               return navigate('/otp');
            }
            toast(userData.data.message)
        }
        catch (err) {
            toast(err)
        }
    }

    return (
        <div className='container'>
            <h2>Reset Password</h2>
            <div className='navigation'>
                <NavLink activeClassName="is-active" to="/">Login</NavLink>
            </div>
            <div id='email'>
                <div className="form-group">
                    <input type="text" className="control-form" name="EmailAddress" placeholder='Email Address'
                        value={UserTasks.EmailAddress} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-button">
                    <button type='button' className="btn btn-block" onClick={SendUserEmail}>Send OTP</button>
                </div>
            </div>

        </div>
    )
}

export default ForgotPassword;
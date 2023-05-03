import { useState } from 'react'
import './Login.css';
import { NavLink, useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure()
const Login = () => {
    const navigate = useNavigate();

    const [LoginTasks, setLoginTasks] = useState({
        EmailAddress: '',
        Password: '',
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setLoginTasks(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    var message;

    const LoginUser = async (e) => {
        e.preventDefault();

        message = "";

        if (!LoginTasks.EmailAddress || !LoginTasks.Password) {
            message = "Please enter all the fields";
            return toast(message);
        }

        const axios = require('axios');
        const UserLogedin = await axios.post('https://localhost:7270/api/UserManagement/Login', LoginTasks);
        console.log(UserLogedin)

        if (UserLogedin.data.success === true) {
            localStorage.setItem('UserId', UserLogedin.data.results.id.toString())
            toast(UserLogedin.data.message)
            navigate('/landing')
        }
        else {
            toast(UserLogedin.data.message)
        }

    }

    return (
        <div className="container">
            <h2>Log-in</h2>
            <div className="form-group">
                <input type="text" className="control-form" name="EmailAddress" placeholder='User Name'
                    value={LoginTasks.EmailAddress} onChange={handleChange}>
                </input>
                <span className=".error-message">{ }</span>
            </div>

            <div className="form-group">
                <input type="password" className="control-form" name="Password" placeholder='Password'
                    value={LoginTasks.Password} onChange={handleChange}>
                </input>
                <span className=".error-message">{ }</span>

            </div>

            <div className="form-button">
                <button className="btn btn-block" onClick={LoginUser}>Login</button>
            </div>
            <div className="footer">
                <div className='btn-footer'>
                    <NavLink activeClassName="is-active" to="/register">Register</NavLink>
                </div>

                <div className='btn-footer'>
                    <NavLink activeClassName="is-active" to="/forgot_password">Forgot Password</NavLink>
                </div>


            </div>

        </div>
    )
}

export default Login;
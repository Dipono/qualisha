import { useState } from 'react'
import './Landing.css';
import { NavLink/*, useNavigate */} from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure();
const Landing = () => {
    const [HomeTask, setHomeTask] = useState({
        UserId: 0
    })

    const defaultUserServiceButton = "Register as a user provider"

    const handleChange = e => {
        const { name, value } = e.target;
        setHomeTask(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    return (
        <div className="container">
            <div className="nav-bar">
            <NavLink activeClassName="nav" className="btn btn-primary" to="/register_user_provider">{defaultUserServiceButton}</NavLink>

            </div>
            <div className="form-group">
                <h1>Welcome to Qualisha Home Page</h1>
                <span className=".error-message">{ }</span>
            </div>
        </div>
    )
}

export default Landing;
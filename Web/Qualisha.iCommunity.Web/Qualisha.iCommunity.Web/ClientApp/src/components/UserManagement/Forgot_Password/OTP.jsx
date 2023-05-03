import { useState } from 'react'
import './Forgot_Password.css';
import { useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure();
const OTP = () => {
    const navigate = useNavigate();
    const [OTPTasks, setOTPTasks] = useState({
        OTP: '',
        UserId: 0
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setOTPTasks(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const verifyOTP = async (e) => {
        OTPTasks.UserId = Number(JSON.parse(localStorage.getItem('UserId')))
        if (!OTPTasks.OTP) return toast('Enter OTP');
        if (OTPTasks.OTP.toString().length < 5) return toast('Code must have 5 numbers');
        
        try {
            const axios = require('axios');
            const userVerifiedData = await axios.post('https://localhost:7270/api/UserManagement/VerifyOTP', OTPTasks)

            if (userVerifiedData.data.success === true) {
                return navigate('/update_password')
            }
            toast(userVerifiedData.data.message)
        }
        catch (err) {
            toast(err)
        }
    }

    return (
        <div className='container'>
            <h2>OTP</h2>
            <div id='otp'>
                <div className="form-group" >
                    <input type="number" className="control-form" name="OTP" placeholder='OTP'
                        value={OTPTasks.OTP} onChange={handleChange}>
                    </input>
                    <span className=".error-message">{ }</span>
                </div>

                <div className="form-button" >
                    <button type='button' className="btn btn-block" onClick={verifyOTP}>Verify OTP</button>
                </div>
            </div>
        </div>
    )
}

export default OTP;
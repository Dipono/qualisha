import { useState } from 'react'
import './Registration.css';
import { useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure()
const ActivateAccount = () => {
    const navigate = useNavigate();
    const [OTPActivateAccount, setOTPActivateAccount] = useState({
        OTP: '',
        UserId: 0
    })

    const handleChange = e => {
        const { name, value } = e.target;
        setOTPActivateAccount(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const verifyOTP = async (e) => {
        OTPActivateAccount.UserId = Number(JSON.parse(localStorage.getItem('UserId')))
        if (!OTPActivateAccount.OTP) return toast('Enter OTP');
        if (OTPActivateAccount.OTP.toString().length < 5) return toast('Code must have 5 numbers');
        
        try {
            const axios = require('axios');
            const userVerifiedData = await axios.post('https://localhost:7270/api/UserManagement/ActivateAccount', OTPActivateAccount)
            if (userVerifiedData.data.success === true) {
                toast("Successefully Activated Account.");
                navigate('/')
            }
            toast(userVerifiedData.data.message)
        }
        catch (err) {
            console.log(err)
        }
    }

    return (
        <div className='container'>
            <h2>Activate Account</h2>
            <div id='otp'>
                <div className="form-group" >
                    <input type="number" className="control-form" name="OTP" placeholder='OTP'
                        value={OTPActivateAccount.OTP} onChange={handleChange}>
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

export default ActivateAccount;
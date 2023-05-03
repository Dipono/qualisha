import React from 'react'
import './TermsAndConditions_Disclaimer.css';

function TermsAndConditions(props){
    return (props.triggerTerms) ? (
        <div className="popup">
            <div className="popup-inner">
                <button className='btn-close' onClick={() => props.setTrigger(false)}></button>
                <h1>Terms and Conditions</h1>
                {props.children}
            </div>

        </div>
    ): ""
}


export default TermsAndConditions;
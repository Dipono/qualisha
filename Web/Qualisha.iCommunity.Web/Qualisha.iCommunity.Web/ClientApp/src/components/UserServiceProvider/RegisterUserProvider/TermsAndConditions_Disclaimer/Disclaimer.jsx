import React from 'react'
import './TermsAndConditions_Disclaimer.css';


function Disclaimer(props){
    return (props.triggerDisclaimer) ? (
        <div className="popup">
            <div className="popup-inner">
            <button className='btn-close' onClick={() => props.setTrigger(false)}></button>
                <h1>Disclaimer</h1>
                {props.children}
            </div>

        </div>
    ): ""
}

/*const Disclaimer = (open) => {
    if(!open) return null
    return (
        <div className="container">
            <div className="form-group">
                <h1>Disclaimer</h1>
                <span className=".error-message">{ }</span>
            </div>
        </div>
    )
}*/

export default Disclaimer;
import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Layout } from './components/Layout';
import Registration from './components/UserManagement/Registration/Registration';
import Login from './components/UserManagement/Login/Login';
import ForgotPassword from './components/UserManagement/Forgot_Password/ForgotPassword';
import UpdatePassword from './components/UserManagement/Forgot_Password/UpdatePassword';
import OTP from './components/UserManagement/Forgot_Password/OTP';
import ActivateAccount from './components/UserManagement/Registration/ActivateAccount';
import Landing from './components/UserManagement/Landing/Landing';
import RegisterUserProvider from './components/UserServiceProvider/RegisterUserProvider/RegisterUserProvider';
import Disclaimer from './components/UserServiceProvider/RegisterUserProvider/TermsAndConditions_Disclaimer/Disclaimer';
import TermsAndConditions from './components/UserServiceProvider/RegisterUserProvider/TermsAndConditions_Disclaimer/TermsAndConditions';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          <Route exact path='/' element={<Login />} />
          <Route exact path='/register' element={<Registration />} />
          <Route exact path='/forgot_password' element={<ForgotPassword />} />
          <Route exact path='/update_password' element={<UpdatePassword />} />
          <Route exact path='/otp' element={<OTP />} />
          <Route exact path='/activate_account' element={<ActivateAccount />} />
          <Route exact path='/landing' element={<Landing />} />
          <Route exact path='/register_user_provider' element={<RegisterUserProvider />} />
          <Route exact path='/terms_and_conditions' element={<TermsAndConditions />} />
          <Route exact path='/disclaimer' element={<Disclaimer />} />



        </Routes>


      </Layout>
    );
  }
}

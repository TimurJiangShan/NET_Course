import React, { useEffect } from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';

// @withRouter

const CheckLogin = (props) => {
  useEffect(() => {
    axios.get('xxxxx')
    .then(res => {
        if(res.status === 200) {
            if(res.data.code === 0) {
              console.log(res);
            }else {
                this.props.history.push('/login')
            }
        }
    })
  },[]);

  return (
    <></>
  );
}

export default CheckLogin;
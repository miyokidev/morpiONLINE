const socket = io("ws://10.5.47.43:7000", {
    auth :  {token: sessionStorage.getItem('token')}
});